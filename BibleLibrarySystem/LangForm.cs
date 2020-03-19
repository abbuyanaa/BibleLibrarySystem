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
    public partial class LangForm : Form
    {
        MySqlConnection con = MyConnection.getConnection();
        MySqlDataReader reader;
        MySqlCommand command;
        DialogResult dr;
        public int lang_id;

        public LangForm()
        {
            InitializeComponent();
        }

        private void LangForm_Load(object sender, EventArgs e)
        {
            dataGridLang.DataSource = data();
        }

        private void dataGridLang_MouseClick(object sender, MouseEventArgs e)
        {
            lang_id = Convert.ToInt32(dataGridLang.CurrentRow.Cells[0].Value.ToString());
            textBoxName.Text = dataGridLang.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            store(textBoxName.Text);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            update(lang_id, textBoxName.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete(lang_id);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            lang_id = 0;
            textBoxName.Text = "";
        }

        public DataTable data()
        {
            DataTable table = new DataTable();
            try
            {
                using (command = new MySqlCommand("SELECT id as '№', name as 'Гадаад хэл' FROM `languages` ORDER BY `id` DESC", con))
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

        // Check Null Data
        private bool verifyData(String text)
        {
            return !text.Equals("");
        }

        // Exist Data
        public bool existData(string name)
        {
            command = new MySqlCommand("SELECT * FROM `languages` WHERE `name`='" + name + "'", con);
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
                else if (existData(name))
                {
                    showMessage(name+" дахиж оруулах боломжгүй!");
                }
                else
                {
                    using (command = new MySqlCommand("INSERT INTO `languages`(`name`) VALUES (@name)", con))
                    {
                        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                        executeQuery(command, "Зохиолч амжилттай нэмэгдлээ.");
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
                command = new MySqlCommand("UPDATE `languages` SET `name`=@name WHERE `id`=@id", con);
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = basic_id.ToString();
                executeQuery(command, "Мэдээлэл амжилттай шинэчилэгдлээ.");
            }
            else
            {
                showMessage("Жагсаалтаас сонгоно уу!");
            }
        }

        // Delete Data
        public void delete(int lang_id)
        {
            try
            {
                if (lang_id != 0)
                {
                    dr = MessageBox.Show("Та жагсаалтаас устгахдаа итгэлтэй байна уу!", "Гадаад хэл", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        command = new MySqlCommand("DELETE FROM `languages` WHERE `id`=@lang_id", con);
                        command.Parameters.Add("@lang_id", MySqlDbType.VarChar).Value = lang_id.ToString();
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
            clear();
            dataGridLang.DataSource = data();
        }

        private void showMessage(String text)
        {
            MessageBox.Show(text);
        }
    }
}
