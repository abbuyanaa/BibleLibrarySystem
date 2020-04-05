using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BibleLibrarySystem.Controllers
{
    class CategoryController
    {
        MySqlConnection con = MyConnection.getConnection();
        MySqlDataAdapter adapter;
        MySqlDataReader reader;
        MySqlCommand command;

        // Check null data
        public bool verifyData(String text)
        {
            return !text.Equals("");
        }

        // Exist data
        public bool existData(string table, string name)
        {
            command = new MySqlCommand("SELECT * FROM `" + table + "` WHERE `name`='" + name + "'", con);
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

        public void data(DataGridView dataGridBasic, DataTable table)
        {
            try
            {
                command = new MySqlCommand("SELECT * FROM `category_basic` ORDER BY `id` DESC", con);
                adapter = new MySqlDataAdapter(command);
                table = new DataTable();

                adapter.Fill(table);

                dataGridBasic.RowTemplate.Height = 50;
                dataGridBasic.AllowUserToAddRows = false;
                dataGridBasic.DataSource = table;
            }
            catch (MySqlException ex)
            {
                showMessage(ex.Message);
            }
        }

        //private Boolean existData(String table, String text)
        //{
        //    con.Open();
        //    command = new MySqlCommand("SELECT * FROM `category_basic` WHERE `name`=@name", con);
        //    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = text;
        //    reader = command.ExecuteReader();
        //    int total = Convert.ToInt32(command.ExecuteScalar());

        //    if (total == 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public void storeBasic(String name)
        {
            try
            {
                if (verifyData(name))
                {
                    showMessage("Утга хоосон байна!");
                }
                else
                {
                    command = new MySqlCommand("INSERT INTO `category_basic`(`name`) VALUES (@name)", con);
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                    executeQuery(command, "Үндсэн төрөлд амжилттай шинэ мэдээлэл хадгаллаа.");
                }
            }
            catch (Exception ex)
            {
                showMessage(ex.Message);
            }
        }

        public void edit(int basic_id, String name)
        {
            if (basic_id != 0)
            {
                command = new MySqlCommand("UPDATE `category_basic` SET `name`=@name WHERE `id`=@id", con);
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToString(basic_id);
                executeQuery(command, "Мэдээлэл амжилттай шинэчилэгдлээ.");
            }
            else
            {
                showMessage("No");
            }
        }

        public void update(int basic_id)
        {
            //
        }

        public void delete(int basic_id)
        {
            //
        }

        // Main
        public void comboBox(ComboBox cb, String table)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cb.Items.Clear();
                String query = "SELECT `name` FROM `" + table + "` ORDER BY `name` ASC";
                command = new MySqlCommand(query, con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cb.Items.Add(firstCharToUpper(reader.GetString("name")));
                }
                con.Close();
            }
            catch (MySqlException ex)
            {
                showMessage(ex.Message);
            }
        }

        // BookMain
        public int categoryId(String table, String name)
        {
            try
            {
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
                showMessage(ex.Message);
            }
            return 0;
        }

        public String categoryName(String table, int id)
        {
            try
            {
                con.Open();
                String query = "SELECT `name` FROM `" + table + "` WHERE `id` = '" + id+ "'";
                command = new MySqlCommand(query, con);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    String text = reader.GetString("name");
                    con.Close();
                    return text;
                }
            }
            catch (MySqlException ex)
            {
                showMessage(ex.Message);
            }
            return "";
        }

        private void executeQuery(MySqlCommand command, String myMsg)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (command.ExecuteNonQuery() == 1)
            {
                showMessage(myMsg);
            }
            else
            {
                showMessage("Мэдээлэлтэй харьцахад алдаа гарлаа!");
            }
            con.Close();
        }

        private void showMessage(String text)
        {
            MessageBox.Show(text);
        }

        public static String firstCharToUpper(String text)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentException("ARGH!");
            return text.First().ToString().ToUpper() + text.Substring(1);
        }
    }
}
