using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BibleLibrarySystem.Controllers
{
    class AuthorController
    {
        MySqlConnection con = MyConnection.getConnection();
        MySqlCommand command;
        MySqlDataReader reader;
        DialogResult dr;

        // Check Null Data
        public bool verifyData(string text)
        {
            return !text.Equals("");
        }

        // Exist Data
        public bool existData(string text)
        {
            command = new MySqlCommand("SELECT * FROM `authors` WHERE `name`=@name", con);
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = text;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }

        // Insert Into DB
        public void store(String name)
        {
            try
            {
                if (!verifyData(name))
                {
                    showMessage("Утга хоосон байна!");
                }
                else
                {
                    using (command = new MySqlCommand("INSERT INTO `authors`(`name`) VALUES (@name)", con))
                    {
                        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                        executeQuery(command, "Зохиолч амжилттай нэмэгдлээ.");
                        //CategoryController cat = new CategoryController();
                        //cat.comboBox(BookMain.cbAuthor, "")
                    }
                }
            }
            catch (Exception ex)
            {
                showMessage(ex.Message);
            }
        }

        // Update to DB
        public void update(int basic_id, String name)
        {
            if (basic_id != 0)
            {
                command = new MySqlCommand("UPDATE `authors` SET `name`=@name WHERE `id`=@id", con);
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToString(basic_id);
                executeQuery(command, "Мэдээлэл амжилттай шинэчилэгдлээ.");
            }
            else
            {
                showMessage("Жагсаалтаас сонгоно уу!");
            }
        }

        // Delete Data
        public void delete(int author_id)
        {
            try
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
                }
                else
                {
                    showMessage("Жагсаалтаас сонгоно уу!");
                }
            }
            catch (Exception ex)
            {
                showMessage(ex.Message);
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
            AuthorForm author = new AuthorForm();
            author.dataGridAuthor.DataSource = data();
        }

        public DataTable data()
        {
            DataTable table = new DataTable();
            try
            {
                using (command = new MySqlCommand("SELECT * FROM `authors` ORDER BY `id` DESC", con))
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

        private void showMessage(String text)
        {
            MessageBox.Show(text);
        }
    }
}
