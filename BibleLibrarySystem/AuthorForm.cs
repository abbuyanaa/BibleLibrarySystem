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
    public partial class AuthorForm : Form
    {
        MySqlConnection con = MyConnection.getConnection();
        AuthorController author = new AuthorController();
        MySqlDataReader reader;
        MySqlCommand command;
        DialogResult dr;
        public int author_id;

        public AuthorForm()
        {
            InitializeComponent();
        }

        private void AuthorForm_Load(object sender, EventArgs e)
        {
            dataGridAuthor.DataSource = data();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxName.Text.Trim();
                if (!author.verifyData(name))
                {
                    showMessage("Утга хоосон байна!");
                }
                else if (author.existData(name))
                {
                    showMessage("Exist");
                }
                else
                {
                    using (command = new MySqlCommand("INSERT INTO `authors`(`name`) VALUES (@name)", con))
                    {
                        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                        executeQuery(command, "Зохиолч амжилттай нэмэгдлээ.");
                        BookMain main = new BookMain();
                        CategoryController category = new CategoryController();
                        category.comboBox(main.cbAuthor, "authors");
                    }
                }
            }
            catch (Exception ex)
            {
                showMessage("Author: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (author_id != 0)
            {
                string name = textBoxName.Text;
                command = new MySqlCommand("UPDATE `authors` SET `name`=@name WHERE `id`=@id", con);
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToString(author_id);
                executeQuery(command, "Мэдээлэл амжилттай шинэчилэгдлээ.");
            }
            else
            {
                showMessage("Жагсаалтаас сонгоно уу!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (author_id != 0)
            {
                dr = MessageBox.Show("Та жагсаалтаас хасахдаа итгэлтэй байна уу?", "Зохиолч хасах", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    command = new MySqlCommand("DELETE FROM `authors` WHERE `id`=@id", con);
                    command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToString(author_id);
                    executeQuery(command, "Мэдээлэл амжилттай устгагдлаа.");
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dataGridAuthor_MouseClick(object sender, MouseEventArgs e)
        {
            author_id = Convert.ToInt32(dataGridAuthor.CurrentRow.Cells[0].Value.ToString());
            textBoxName.Text = dataGridAuthor.CurrentRow.Cells[1].Value.ToString();
        }

        public DataTable data()
        {
            DataTable table = new DataTable();
            try
            {
                using (command = new MySqlCommand("SELECT id as '№', name as 'Нэр', created_at as 'Нэмсэн' FROM `authors` ORDER BY `id` DESC", con))
                {
                    con.Open();
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    con.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return table;
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
            clear();
            dataGridAuthor.DataSource = data();
        }

        private void clear()
        {
            author_id = 0;
            textBoxName.Text = "";
        }

        private void showMessage(string text)
        {
            MessageBox.Show(text);
        }
    }
}
