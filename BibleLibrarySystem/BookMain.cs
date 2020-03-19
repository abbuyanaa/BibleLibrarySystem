using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // MessageBox
using System.Drawing.Printing; // PrintPageEventArgs
using System.IO; // MemoryStream
using MySql.Data.MySqlClient; // MySqlConnection
using BibleLibrarySystem.Controllers;
using BibleLibrarySystem.Models;

namespace BibleLibrarySystem
{
    public partial class BookMain : Form
    {
        MySqlConnection con = MyConnection.getConnection();
        CategoryController category = new CategoryController();
        BookController book = new BookController();
        MySqlCommand command;
        MySqlDataAdapter adapter;
        MySqlDataReader reader;
        DialogResult dr;
        DataTable table;
        MemoryStream ms;
        Bitmap bmp;
        Random rand = new Random();
        byte[] image = null;
        int current_year = DateTime.Now.Year;
        int book_id, book_lastid;
        int bible = 0;

        // Category get id variables
        int author_id, lang_id, cbasic_id, csub_id, company_id;

        // Book insert variables
        string book_name, book_tailbar, book_qty, book_year, book_qrcode;
        
        public BookMain()
        {
            InitializeComponent();

            // Publish Year loop
            for (int pyear = 1980; pyear <= current_year; pyear++)
            {
                cbYear.Items.Add(pyear.ToString());
            }
            comboBoxes(cbAuthor, "authors");
            comboBoxes(cbBasic, "category_basic");
            comboBoxes(cbCompany, "company");
            comboBoxes(cbLang, "languages");

            cbAuthor.SelectedIndex = 0;
            cbBasic.SelectedIndex = 0;
            cbCompany.SelectedIndex = 0;
            cbLang.SelectedIndex = 0;
            cbYear.SelectedIndex = 0;
            fillBook();
            bookLastId(); // Book Last ID;
        }

        // Random or QRCoder
        public Image qrgen(string qrcode)
        {
            //if (qrcode.Equals(""))
            //{
            //    int first_qr = rand.Next(10000, 99999);
            //    int second_qr = rand.Next(10000, 99999);
            //    qrcode = first_qr.ToString() + second_qr.ToString();
            //}
            //else
            //{
            //    qrcode = qrcode.ToString();
            //}
            bookCode.Text = qrcode;
            QRCoder.QRCodeGenerator qrCodeGenerator = new QRCoder.QRCodeGenerator();
            QRCoder.QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(qrcode, QRCoder.QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);
            Image img = qrCode.GetGraphic(2);
            return img;
        }

        //private void BookMain_Load(object sender, EventArgs e)
        //{
        //    pictureCode.Image = qrgen(book_lastid.ToString());
        //}

        private void buttonBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG;*.JPEG;*.PNG;*.GIF)|*.jpg;*.jpeg;*.png;*.gif;";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                bookImage.Image = Image.FromFile(opf.FileName);
            }
            else
            {
                MessageBox.Show("No Selecte Image!");
            }
        }

        // Book QR code generator
        private void btnGenerator_Click(object sender, EventArgs e)
        {
            if (book_id != 0)
            {
                qrgen(bookCode.Text);
            }
            else
            {
                qrgen("");
            }
        }

        // Book Preview
        private void btnPreview_Click(object sender, EventArgs e)
        {
            pageSetupDialog.ShowDialog();
        }

        private void btnPageSetup_Click(object sender, EventArgs e)
        {
            printDialog.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }

        public bool checkImage(PictureBox pic)
        {
            return pic.Image == null;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                book_name = bookName.Text;
                book_tailbar = richTailbar.Text;
                book_qty = bookQty.Text.ToString();
                book_year = cbYear.SelectedItem.ToString();
                book_qrcode = bookCode.Text.ToString();

                if (chBible.Checked)
                {
                    bible = 1;
                }
                else
                {
                    bible = 0;
                }

                if (book_name.Equals("") || book_tailbar.Equals(""))
                {
                    showMessage("Мэдээлэл дутуу оруулсан байна!");
                }
                else if (checkImage(bookImage))
                {
                    showMessage("Зураг сонгоно уу!");
                }
                else
                {
                    try
                    {
                        ms = new MemoryStream();
                        bookImage.Image.Save(ms, bookImage.Image.RawFormat);
                        image = ms.ToArray();
                        String book_query = "INSERT INTO `book`"
                            + "(`name`, `tailbar`, `year`, `qty`, `qrcode`, `image`, `created_at`) VALUES"
                            + "(@name, @tailbar, @year, @qty, @qrcode, @image, NOW())";

                        command = new MySqlCommand(book_query, con);
                        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = book_name;
                        command.Parameters.Add("@tailbar", MySqlDbType.VarChar).Value = book_tailbar;
                        command.Parameters.Add("@year", MySqlDbType.VarChar).Value = book_year;
                        command.Parameters.Add("@qty", MySqlDbType.VarChar).Value = book_qty;
                        command.Parameters.Add("@qrcode", MySqlDbType.VarChar).Value = book_qrcode;
                        command.Parameters.Add("@image", MySqlDbType.Blob).Value = image;

                        con.Open();
                        if (command.ExecuteNonQuery() == 1)
                        {
                            con.Close();

                            // BookDetails insert
                            if (con.State == ConnectionState.Closed)
                            {
                                String book_details_query = "INSERT INTO `book_details`"
                                    + "(`book_id`, `author_id`, `lang_id`, `basic_id`, `sub_id`, `company_id`, `bible`) VALUES"
                                    + "((SELECT `id` FROM `book` ORDER BY `id` DESC LIMIT 1), @author_id, @lang_id, @basic_id, @sub_id, @company_id, @bible)";
                                using (command = new MySqlCommand(book_details_query, con))
                                {
                                    command.Parameters.Add("@author_id", MySqlDbType.VarChar).Value = author_id.ToString();
                                    command.Parameters.Add("@lang_id", MySqlDbType.VarChar).Value = lang_id.ToString();
                                    command.Parameters.Add("@basic_id", MySqlDbType.VarChar).Value = cbasic_id.ToString();
                                    command.Parameters.Add("@sub_id", MySqlDbType.VarChar).Value = csub_id.ToString();
                                    command.Parameters.Add("@company_id", MySqlDbType.VarChar).Value = company_id.ToString();
                                    command.Parameters.Add("@bible", MySqlDbType.VarChar).Value = bible.ToString();

                                    executeQuery(command, "Ном амжилттай нэмэгдлээ");
                                }
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        showMessage("Book insert: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                showMessage("Book Add: " + ex.Message);
            }
        }

        // Book get Last ID
        public void bookLastId()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String query = "SELECT COUNT(*) FROM `book` ORDER BY `id` DESC LIMIT 1";
                using (command = new MySqlCommand(query, con))
                {
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        book_lastid = reader.GetInt32("count(*)") + 1;
                        qrgen(book_lastid.ToString());
                        Console.WriteLine("Book LastID: " + book_lastid);
                    }
                }
                con.Close();
            }
            catch (MySqlException ex)
            {
                showMessage("Book LastID: " + ex.Message);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                book_name = bookName.Text;
                book_tailbar = richTailbar.Text;
                book_qty = bookQty.Text.ToString();
                book_year = cbYear.SelectedItem.ToString();
                book_qrcode = bookCode.Text.ToString();

                if (chBible.Checked)
                {
                    bible = 1;
                }
                else
                {
                    bible = 0;
                }

                if (book_name.Equals("") || book_tailbar.Equals(""))
                {
                    showMessage("Мэдээлэл дутуу оруулсан байна!");
                }
                else
                {
                    try
                    {
                        ms = new MemoryStream();
                        bookImage.Image.Save(ms, bookImage.Image.RawFormat);
                        image = ms.ToArray();
                        String book_query = "UPDATE `book` SET `name`=@name, `tailbar`=@tailbar, `year`=@year, `qty`=@qty, `qrcode`=@qrcode, `image`=@image WHERE `id`=@id";

                        using (command = new MySqlCommand(book_query, con))
                        {
                            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = book_name;
                            command.Parameters.Add("@tailbar", MySqlDbType.VarChar).Value = book_tailbar;
                            command.Parameters.Add("@year", MySqlDbType.VarChar).Value = book_year;
                            command.Parameters.Add("@qty", MySqlDbType.VarChar).Value = book_qty;
                            command.Parameters.Add("@qrcode", MySqlDbType.VarChar).Value = book_qrcode;
                            command.Parameters.Add("@image", MySqlDbType.Blob).Value = image;
                            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = book_id.ToString();
                        }

                        con.Open();
                        if (command.ExecuteNonQuery() == 1)
                        {
                            con.Close();
                            if (con.State == ConnectionState.Closed)
                            {
                                String book_details_query = "UPDATE `book_details` SET `author_id`=@author, `lang_id`=@lang, `basic_id`=@basic, `sub_id`=@sub, `company_id`=@company, `bible`=@bible WHERE `book_id`=@id";
                                using (command = new MySqlCommand(book_details_query, con))
                                {
                                    command.Parameters.Add("@author", MySqlDbType.VarChar).Value = author_id.ToString();
                                    command.Parameters.Add("@lang", MySqlDbType.VarChar).Value = lang_id.ToString();
                                    command.Parameters.Add("@basic", MySqlDbType.VarChar).Value = cbasic_id.ToString();
                                    command.Parameters.Add("@sub", MySqlDbType.VarChar).Value = csub_id.ToString();
                                    command.Parameters.Add("@company", MySqlDbType.VarChar).Value = company_id.ToString();
                                    command.Parameters.Add("@bible", MySqlDbType.VarChar).Value = bible.ToString();
                                    command.Parameters.Add("@id", MySqlDbType.VarChar).Value = book_id.ToString();

                                    executeQuery(command, "Ном амжилттай шинэчилэгдлээ.");
                                }
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        showMessage("Book update: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                showMessage("Book edit: " + ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (book_id != 0)
            {
                dr = MessageBox.Show("Ном жагсаалтаас устгахдаа итгэлтэй байна уу?", "Ном устгах", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    command = new MySqlCommand("DELETE FROM `book_details` WHERE `book_id`='" + book_id + "'", con);

                    con.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        con.Close();
                        command = new MySqlCommand("DELETE FROM `book` WHERE `id`='" + book_id + "'", con);
                        executeQuery(command, "Мэдээлэл амжилттай устгагдлаа.");
                    }
                }
                else
                {
                    clear();
                }
            }
            else
            {
                showMessage("Жагсаалтаас сонгоно уу!");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnAuthor_Click(object sender, EventArgs e)
        {
            AuthorForm authForm = new AuthorForm();
            authForm.Show();
        }

        private void btnBasic_Click(object sender, EventArgs e)
        {
            CbasicForm basicForm = new CbasicForm();
            basicForm.Show();
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            CompanyForm companyForm = new CompanyForm();
            companyForm.Show();
        }

        private void btnLang_Click(object sender, EventArgs e)
        {
            LangForm langForm = new LangForm();
            langForm.Show();
        }

        // Fill in DataGridBook
        public void fillBook()
        {
            try
            {
                String query = "SELECT "
                    + "b.id as '№', b.image as 'Зураг', b.name as 'Нэр', a.name AS 'Зохиолч', b.tailbar as 'Тайлбар', cb.name AS 'Үндсэн', "
                    + "cs.name AS 'Дэд', b.year as 'Гарсан он', b.qty as 'Ширхэг', l.name AS 'Хэл', c.name AS 'Байгууллага' "
                    + "FROM book AS b "
                    + "INNER JOIN book_details AS bd ON bd.book_id = b.id "
                    + "INNER JOIN `authors` AS a ON a.id = bd.author_id "
                    + "INNER JOIN languages AS l ON l.id = bd.lang_id "
                    + "INNER JOIN category_basic AS cb ON cb.id = bd.basic_id "
                    + "INNER JOIN category_sub AS cs ON cs.id = bd.sub_id "
                    + "INNER JOIN company AS c ON c.id = bd.company_id ORDER BY b.id DESC";
                using (command = new MySqlCommand(query, con))
                {
                    adapter = new MySqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        dataGridBook.RowTemplate.Height = 120;
                        dataGridBook.AllowUserToAddRows = false;
                        dataGridBook.DataSource = table;

                        DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                        imageColumn = (DataGridViewImageColumn)dataGridBook.Columns[1];
                        imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                        dataGridBook.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (MySqlException ex)
            {
                showMessage("Fill Book: " + ex.Message);
            }
        }

        // ComboBox get data
        public void comboBoxes(ComboBox cb, String table)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String query = "SELECT `name` FROM `" + table + "` ORDER BY `name` ASC";
                using (command = new MySqlCommand(query, con))
                {
                    reader = command.ExecuteReader();
                    cb.Items.Clear();
                    while (reader.Read())
                    {
                        cb.Items.Add(firstCharToUpper(reader.GetValue(0).ToString()));
                    }
                }
                con.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ComboBox " + table + ":" + ex.Message);
            }
        }

        // Printing QR Code
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font fb = new Font("Times New Roman", 8f, FontStyle.Bold, GraphicsUnit.Pixel);
            Font fn = new Font("Times New Roman", 8f, FontStyle.Regular, GraphicsUnit.Pixel);

            String pBasic = cbBasic.SelectedItem.ToString();
            String pSub = cbSub.SelectedItem.ToString();
            String pCode = bookCode.Text;

            bmp = new Bitmap(pictureCode.Width - 10, pictureCode.Height - 10);
            SolidBrush sb = new SolidBrush(Color.Black);
            pictureCode.DrawToBitmap(bmp, new Rectangle(0, 0, pictureCode.Width - 10, pictureCode.Height - 10));
            e.Graphics.DrawImage(bmp, -12, -4); // (X, Y)
            e.Graphics.DrawString("Үндсэн төрөл:", fb, sb, 50, 12);
            e.Graphics.DrawString(pBasic, fn, sb, 50, 20);
            e.Graphics.DrawString("Дэд төрөл:", fb, sb, 50, 30);
            e.Graphics.DrawString(pSub, fn, sb, 50, 38);
            e.Graphics.DrawString("Код:", fb, sb, 50, 47);
            e.Graphics.DrawString(pCode, fn, sb, 68, 47);
        }

        /**
         * ComboBox selected item id
         **/
        // Author get ID
        private void cbAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string author = cbAuthor.SelectedItem.ToString();
            author_id = categoryId("authors", author);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            Console.WriteLine("Author selected: " + author_id.ToString());
        }

        // Basic get ID
        private void cbBasic_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string cbasic = cbBasic.SelectedItem.ToString();
                cbasic_id = categoryId("category_basic", cbasic);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                Console.WriteLine("Category Basic: " + cbasic_id.ToString());
                String query = "SELECT cs.name FROM category_basic AS cb "
                            + "INNER JOIN category AS c ON c.basic_id = cb.id "
                            + "INNER JOIN category_sub AS cs ON cs.id = c.sub_id "
                            + "WHERE cb.name = '" + cbasic + "' "
                            + "ORDER BY cs.name ASC";
                using (command = new MySqlCommand(query, con))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    reader = command.ExecuteReader();
                    cbSub.Items.Clear();
                    while (reader.Read())
                    {
                        cbSub.Items.Add(firstCharToUpper(reader.GetValue(0).ToString()));
                    }
                }
                con.Close();
                cbSub.SelectedIndex = 0;
            }
            catch (MySqlException ex)
            {
                showMessage("ComboBox Basic:" + ex.Message);
            }
        }

        // Category Sub get id
        private void cbSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string csub = cbSub.SelectedItem.ToString();
                csub_id = categoryId("category_sub", csub);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                Console.WriteLine("Category Sub: " + csub_id.ToString());
            }
            catch (Exception ex)
            {
                showMessage("Csub selectedIndex: " + ex.Message);
            }
        }

        // Company get id
        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                company_id = categoryId("company", cbCompany.SelectedItem.ToString());
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                Console.WriteLine("Company: "+company_id.ToString());
            }
            catch (Exception ex)
            {
                showMessage("Company selectedIndex: " + ex.Message);
            }
        }

        // Language get id
        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            lang_id = categoryId("languages", cbLang.SelectedItem.ToString());
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            Console.WriteLine("Language: "+lang_id.ToString());
        }

        // DataGridBook row click
        private void dataGridBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                book_id = Convert.ToInt32(dataGridBook.CurrentRow.Cells[0].Value.ToString());
                String query = "SELECT b.*, bd.bible FROM `book` as b inner join book_details as bd on bd.book_id = b.id WHERE b.id = '" + book_id + "'";
                command = new MySqlCommand(query, con);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    try
                    {
                        bookName.Text = dataGridBook.CurrentRow.Cells[2].Value.ToString();
                        richTailbar.Text = dataGridBook.CurrentRow.Cells[4].Value.ToString();
                        bookQty.Text = reader.GetString("qty");

                        cbYear.SelectedItem = reader.GetString("year");
                        bookCode.Text = reader.GetString("qrcode");

                        if (reader.GetInt32("bible") != 0)
                        {
                            chBible.Checked = true;
                        }
                        else
                        {
                            chBible.Checked = false;
                        }

                        Byte[] image = (Byte[])dataGridBook.CurrentRow.Cells[1].Value;
                        ms = new MemoryStream(image);
                        bookImage.Image = Image.FromStream(ms);

                        string get_basic = dataGridBook.CurrentRow.Cells[5].Value.ToString();
                        cbBasic.SelectedItem = firstCharToUpper(get_basic);
                        string get_sub = dataGridBook.CurrentRow.Cells[6].Value.ToString();
                        cbSub.SelectedItem = firstCharToUpper(get_sub);
                        string get_lang = dataGridBook.CurrentRow.Cells[9].Value.ToString();
                        cbLang.SelectedItem = firstCharToUpper(get_lang);
                        string get_company = dataGridBook.CurrentRow.Cells[10].Value.ToString();
                        cbCompany.SelectedItem = firstCharToUpper(get_company);
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        showMessage("Read: " + ex.Message);
                    }
                }
                con.Close();
            }
            catch (MySqlException ex)
            {
                showMessage("Book Click get data: " + ex.Message);
            }
        }

        private void executeQuery(MySqlCommand command, String myMsg)
        {
            con.Open();
            if (command.ExecuteNonQuery() == 1)
            {
                showMessage(myMsg);
            }
            else
            {
                showMessage("Мэдээлэлтэй харьцахад алдаа гарлаа!");
            }
            con.Close();
            fillBook();
            clear();
        }

        // Get Categories id
        public int categoryId(String table, String name)
        {
            try
            {
                con.Close();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String query = "SELECT `id` FROM `" + table + "` WHERE `name` = '" + name + "'";
                using (command = new MySqlCommand(query, con))
                {
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.GetInt32("id");
                    }
                }
            }
            catch (MySqlException ex)
            {
                showMessage("Category ID: " + ex.Message);
            }
            return 0;
        }

        // Show Dialog Message
        private void showMessage(String text)
        {
            MessageBox.Show(text);
        }

        // First word uppercase
        public static String firstCharToUpper(String text)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentException("ARGH!");
            return text.First().ToString().ToUpper() + text.Substring(1);
        }

        public void clear()
        {
            book_id = 0;
            bookName.Text = "";
            cbAuthor.SelectedIndex = 0;
            richTailbar.Text = "";
            bookQty.Text = "1";
            bookImage.Image = null;
            cbBasic.SelectedIndex = 0;
            cbCompany.SelectedIndex = 0;
            cbLang.SelectedIndex = 0;
            cbYear.SelectedIndex = 0;
            bookLastId();
        }

        private void bookCode_TextChanged(object sender, EventArgs e)
        {
            pictureCode.Image = qrgen(bookCode.Text);
        }
    }
}
