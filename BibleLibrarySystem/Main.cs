using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BibleLibrarySystem.Controllers;

namespace BibleLibrarySystem
{
    public partial class Main : Form
    {
        MySqlConnection con = MyConnection.getConnection();
        CategoryController category = new CategoryController();
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;

        int current_year = DateTime.Now.Year;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            for (int byear = 1980; byear <= current_year; byear++)
            {
                bookYear.Items.Add(byear.ToString());
            }
            category.comboBox(bookAuthor, "authors");
            category.comboBox(bookCbasic, "category_basic");
            category.comboBox(bookCompany, "company");
            category.comboBox(bookAuthor, "authors");
            fillBook("");
        }

        public void fillBook(string value)
        {
            try
            {
                string query = "SELECT "
                            + "b.id as '№', b.image as 'Зураг', b.name as 'Нэр', a.name AS 'Зохиолч',"
                            + "cb.name AS 'Үндсэн', cs.name AS 'Дэд', b.year as 'Гарсан он', b.qty as 'Ширхэг', "
                            + "l.name AS 'Хэл', c.name AS 'Байгууллага' "
                            + "FROM book AS b INNER JOIN book_details AS bd ON bd.book_id = b.id "
                            + "INNER JOIN `authors` AS a ON a.id = bd.author_id "
                            + "INNER JOIN languages AS l ON l.id = bd.lang_id "
                            + "INNER JOIN category_basic AS cb ON cb.id = bd.basic_id "
                            + "INNER JOIN category_sub AS cs ON cs.id = bd.sub_id "
                            + "INNER JOIN company AS c ON c.id = bd.company_id "
                            + "WHERE CONCAT(b.name, b.year, b.qrcode, a.name, l.name, cb.name, cs.name, c.name) LIKE '%" + value + "%'"
                            + "ORDER BY b.id DESC";
                command = new MySqlCommand(query, con);
                adapter = new MySqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);

                dataGridBook.RowTemplate.Height = 60;
                dataGridBook.AllowUserToAddRows = false;
                dataGridBook.DataSource = table;

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)dataGridBook.Columns[1];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridBook.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (MySqlException ex)
            {
                showMessage("Fill book: " + ex.Message);
            }
        }

        private void showMessage(string text)
        {
            MessageBox.Show(text);
        }

        private void btnBookMain_Click(object sender, EventArgs e)
        {
            BookMain bookMain = new BookMain();
            bookMain.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UserDetails userDetails = new UserDetails();
            userDetails.ShowDialog();
        }

        private void btnAuthor_Click(object sender, EventArgs e)
        {
            AuthorForm authorForm = new AuthorForm();
            authorForm.ShowDialog();
        }

        private void btnLang_Click(object sender, EventArgs e)
        {
            LangForm langForm = new LangForm();
            langForm.ShowDialog();
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            CompanyForm companyForm = new CompanyForm();
            companyForm.ShowDialog();
        }

        private void btnCbasic_Click(object sender, EventArgs e)
        {
            CbasicForm cbasicForm = new CbasicForm();
            cbasicForm.Show();
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //
        }

        private void bookCode_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void bookName_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void bookYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void bookCbasic_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void bookAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void bookCsub_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void bookCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }
    }
}
