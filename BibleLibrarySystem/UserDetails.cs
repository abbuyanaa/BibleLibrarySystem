using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // MemoryStream
using MySql.Data.MySqlClient;
using BibleLibrarySystem.Controllers;

namespace BibleLibrarySystem
{
    public partial class UserDetails : Form
    {
        MySqlConnection con = MyConnection.getConnection();
        CategoryController category = new CategoryController();
        MySqlCommand command;
        MySqlDataAdapter adapter;
        MySqlDataReader reader;
        DataTable table;
        MemoryStream ms;
        DialogResult dr;
        int user_id;
        char gender = ' ';
        byte[] image = null;
        char[] user_type = { 't', 's', 'w', 'g' };
        String[] type_array = { "Багш", "Оюутан", "Ажилтан", "Төгсөгч" };
        int chuulgan_id;
        string get_chuulgan;

        public UserDetails()
        {
            InitializeComponent();
            fillUser();
            comboBoxes(cbChuulgan);
            cbChuulgan.SelectedIndex = 0;
            cbType.SelectedIndex = 0;
        }

        private void UserDetails_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < type_array.Length; i++)
            {
                cbType.Items.Add(type_array[i]);
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG;*.JPEG;*.PNG;*.GIF)|*.jpg;*.jpeg;*.png;*.gif;";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureProfile.Image = Image.FromFile(opf.FileName);
            }
            else
            {
                MessageBox.Show("Зураг цуцлагдлаа!");
            }
        }

        public bool checkImage(PictureBox profile)
        {
            return profile.Image == null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                String fname = textFname.Text;
                String lname = textLname.Text;
                String regid = textRegid.Text;
                String email = textEmail.Text;
                String address = richAddress.Text;
                int phone = Convert.ToInt32(textPhone.Text);
                int type_index = cbType.SelectedIndex;
                //string chuulgan = cbChuulgan.SelectedItem.ToString();

                // User gender
                if (rbMale.Checked)
                {
                    gender = 'm';
                }
                else
                {
                    gender = 'f';
                }

                if (fname.Equals("") || lname.Equals("") || regid.Equals("") || phone == 0 || email.Equals("") || address.Equals(""))
                {
                    showMessage("Утга хоосон байна!");
                }
                else if (checkImage(pictureProfile))
                {
                    showMessage("Зураг хоосон байна!");
                }
                else
                {
                    ms = new MemoryStream();
                    pictureProfile.Image.Save(ms, pictureProfile.Image.RawFormat);
                    image = ms.ToArray();
                    try
                    {
                        String query = "INSERT INTO `users` "
                            + "(`first_name`, `last_name`, `email`, `regid`, `address`, `phone`, `gender`, `type`, `chuulgan_id`, `profile`, `created_at`) VALUES "
                            + "(@fname, @lname, @email, @regid, @address, @phone, @gender, @type, @chuulgan, @profile, NOW())";
                        using (command = new MySqlCommand(query, con))
                        {
                            command.Parameters.Add("@fname", MySqlDbType.VarChar).Value = fname;
                            command.Parameters.Add("@lname", MySqlDbType.VarChar).Value = lname;
                            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                            command.Parameters.Add("@regid", MySqlDbType.VarChar).Value = regid;
                            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = address;
                            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone.ToString();
                            command.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender;
                            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = user_type[type_index];
                            command.Parameters.Add("@chuulgan", MySqlDbType.VarChar).Value = chuulgan_id.ToString();
                            command.Parameters.Add("@profile", MySqlDbType.Blob).Value = image;

                            executeQuery(command, "Хэрэглэгч ажилттай бүртгэлээ.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        showMessage("User insert: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                showMessage("User add: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (user_id != 0)
                {
                    String fname = textFname.Text;
                    String lname = textLname.Text;
                    String regid = textRegid.Text;
                    String email = textEmail.Text;
                    String address = richAddress.Text;
                    int phone = Convert.ToInt32(textPhone.Text);
                    int type = cbType.SelectedIndex;
                    //String chuulgan = cbChuulgan.SelectedItem.ToString();

                    // User gender
                    if (rbMale.Checked)
                    {
                        gender = 'm';
                    }
                    else
                    {
                        gender = 'f';
                    }

                    if (fname.Equals("") || lname.Equals("") || regid.Equals("") || phone == 0 || email.Equals("") || address.Equals(""))
                    {
                        showMessage("Утга хоосон байна!");
                    }
                    else
                    {
                        try
                        {
                            if (checkImage(pictureProfile))
                            {
                                String query = "UPDATE `users` SET "
                                    + "`first_name`=@fname, `last_name`=@lname, `email`=@email, `regid`=@regid, `address`=@hayg, "
                                    + "`phone`=@phone, `gender`=@gender, `type`=@type, `chuulgan_id`=@chuulgan WHERE `id`=@id";
                                using (command = new MySqlCommand(query, con))
                                {
                                    command.Parameters.Add("@fname", MySqlDbType.VarChar).Value = fname;
                                    command.Parameters.Add("@lname", MySqlDbType.VarChar).Value = lname;
                                    command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                                    command.Parameters.Add("@regid", MySqlDbType.VarChar).Value = regid;
                                    command.Parameters.Add("@hayg", MySqlDbType.VarChar).Value = address;
                                    command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone.ToString();
                                    command.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender;
                                    command.Parameters.Add("@type", MySqlDbType.VarChar).Value = user_type[type];
                                    command.Parameters.Add("@chuulgan", MySqlDbType.VarChar).Value = chuulgan_id.ToString();
                                    command.Parameters.Add("@id", MySqlDbType.VarChar).Value = user_id.ToString();

                                    executeQuery(command, "Хэрэглэгч ажилттай шинжчиллээ.");
                                }
                            }
                            else
                            {
                                ms = new MemoryStream();
                                pictureProfile.Image.Save(ms, pictureProfile.Image.RawFormat);
                                image = ms.ToArray();
                                String query = "UPDATE `users` SET "
                                    + "`first_name`=@fname,`last_name`=@lname,`email`=@email,`regid`=@regid,`address`=@hayg,"
                                    + "`phone`=@phone,`gender`=@gender,`type`=@type,`chuulgan_id`=@chuulgan,`profile`=@profile WHERE `id`=@id";
                                using (command = new MySqlCommand(query, con))
                                {
                                    command.Parameters.Add("@fname", MySqlDbType.VarChar).Value = fname;
                                    command.Parameters.Add("@lname", MySqlDbType.VarChar).Value = lname;
                                    command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                                    command.Parameters.Add("@regid", MySqlDbType.VarChar).Value = regid;
                                    command.Parameters.Add("@hayg", MySqlDbType.VarChar).Value = address;
                                    command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone.ToString();
                                    command.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender;
                                    command.Parameters.Add("@type", MySqlDbType.VarChar).Value = user_type[type];
                                    command.Parameters.Add("@chuulgan", MySqlDbType.VarChar).Value = chuulgan_id.ToString();
                                    command.Parameters.Add("@profile", MySqlDbType.Blob).Value = image;
                                    command.Parameters.Add("@id", MySqlDbType.VarChar).Value = user_id.ToString();

                                    executeQuery(command, "Хэрэглэгч ажилттай шинжчиллээ.");
                                }
                            }
                        }
                        catch (MySqlException ex)
                        {
                            showMessage("User update: " + ex.Message);
                        }
                    }
                }
                else
                {
                    showMessage("Жагсаалтаас сонгоогүй байнa!");
                }
            }
            catch (Exception ex)
            {
                showMessage("User edit: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete(user_id);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        public void fillUser()
        {
            try
            {
                String query = "SELECT u.id as '№', u.profile as 'Зураг', u.first_name as 'Овог', u.last_name as 'Нэр', u.email as 'Цахим хаяг', u.regid as 'Р/дугаар', u.address as 'Хаяг', u.phone as 'Утас', a.name as 'Чуулган' FROM users AS u "
                            + "INNER JOIN chuulgan AS a ON a.id = u.chuulgan_id "
                            + "ORDER BY u.id DESC";
                using (command = new MySqlCommand(query, con))
                {
                    adapter = new MySqlDataAdapter(command);
                    table = new DataTable();

                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {

                        dataGridUser.RowTemplate.Height = 80;
                        dataGridUser.AllowUserToAddRows = false;
                        dataGridUser.DataSource = table;

                        //dataGridUser.AutoGenerateColumns = false;
                        //dataGridUser.ColumnCount = 2;
                        //dataGridUser.Columns[0].HeaderText = "№";
                        //dataGridUser.Columns[0].DataPropertyName = "id";
                        //dataGridUser.Columns[2].HeaderText = "Овог";
                        //dataGridUser.Columns[2].DataPropertyName = "last_name";
                        //dataGridUser.Columns[3].HeaderText = "Нэр";
                        //dataGridUser.Columns[3].DataPropertyName = "first_name";

                        //DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                        //imageColumn.Name = "Data";
                        //imageColumn.DataPropertyName = "profile";
                        //imageColumn.HeaderText = "Image";
                        //dataGridUser.Columns.Add(imageColumn);

                        DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                        imageColumn = (DataGridViewImageColumn)dataGridUser.Columns[1];
                        imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

                        dataGridUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (MySqlException ex)
            {
                showMessage("Fill User: " + ex.Message);
            }
        }

        public void comboBoxes(ComboBox cb)
        {
            try
            {
                con.Open();
                String query = "SELECT `name` FROM `chuulgan` ORDER BY `name` ASC";
                using (command = new MySqlCommand(query, con))
                {
                    reader = command.ExecuteReader();
                    cb.Items.Clear();
                    while (reader.Read())
                    {
                        cb.Items.Add(reader.GetString("name"));
                    }
                }
                con.Close();
            }
            catch (MySqlException ex)
            {
                showMessage("ComboBox:" + ex.Message);
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
            clearFields();
            fillUser();
        }

        private void showMessage(String text)
        {
            MessageBox.Show(text);
        }

        private void dataGridUser_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                user_id = Convert.ToInt32(dataGridUser.CurrentRow.Cells[0].Value.ToString());
                command = new MySqlCommand("SELECT * FROM `users` WHERE `id` = '" + user_id + "'", con);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    textFname.Text = reader.GetString("first_name");
                    textLname.Text = reader.GetString("last_name");
                    textRegid.Text = reader.GetString("regid");
                    textEmail.Text = reader.GetString("email");
                    richAddress.Text = reader.GetString("address");
                    textPhone.Text = reader.GetString("phone");

                    // Chuulgan combobox selected item
                    get_chuulgan = category.categoryName("chuulgan", reader.GetInt32("chuulgan_id"));
                    if (reader.GetString("gender").Equals("m"))
                    {
                        rbMale.Checked = true;
                    }
                    else
                    {
                        rbFemale.Checked = true;
                    }

                    switch (reader.GetChar("type"))
                    {
                        case 't':
                            cbType.SelectedIndex = 0;
                            break;
                        case 's':
                            cbType.SelectedIndex = 1;
                            break;
                        case 'w':
                            cbType.SelectedIndex = 2;
                            break;
                        case 'g':
                            cbType.SelectedIndex = 3;
                            break;
                    }
                    Byte[] image = (Byte[])dataGridUser.CurrentRow.Cells[1].Value;
                    ms = new MemoryStream(image);
                    pictureProfile.Image = Image.FromStream(ms);
                }
                cbChuulgan.SelectedItem = get_chuulgan;
                con.Close();
            }
            catch (MySqlException ex)
            {
                showMessage(ex.Message);
            }
        }

        private void cbChuulgan_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryController category = new CategoryController();
            chuulgan_id = category.categoryId("chuulgan", cbChuulgan.SelectedItem.ToString());
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public void delete(int user_id)
        {
            try
            {
                if (user_id != 0)
                {
                    dr = MessageBox.Show("Жагсаалтаас устгахдаа итгэлтэй байна уу?", "Хэрэрлэгч хасах", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        command = new MySqlCommand("DELETE FROM `users` WHERE `id`='" + user_id + "'", con);
                        executeQuery(command, "Хэрэглэгч амжилттай устгалаа.");
                    }
                    else
                    {
                        clearFields();
                    }
                }
                else
                {
                    showMessage("Жагсаалтаас сонгоно уу!");
                }
            }
            catch (MySqlException ex)
            {
                showMessage(ex.Message);
            }
        }

        private void clearFields()
        {
            user_id = 0;
            textLname.Text = "";
            textFname.Text = "";
            textRegid.Text = "";
            textEmail.Text = "";
            richAddress.Text = "";
            cbType.SelectedIndex = 0;
            cbChuulgan.SelectedIndex = 0;
            textPhone.Text = "0";
            rbMale.Checked = true;
            pictureProfile.Image = null;
        }

        public static string firstCharToUpper(string text)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentException("ARGH!");
            return text.First().ToString().ToUpper() + text.Substring(1);
        }
    }
}
