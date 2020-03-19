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
    public partial class CsubForm : Form
    {
        MySqlConnection con = MyConnection.getConnection();
        CategoryController category = new CategoryController();
        MySqlCommand command;
        MySqlDataReader reader;
        DialogResult dr;
        public int basic_id;
        public int sub_id;

        public CsubForm(int basic_id)
        {
            InitializeComponent();
            this.basic_id = basic_id;
        }

        private void CsubForm_Load(object sender, EventArgs e)
        {
            dataGridCsub.DataSource = data(basic_id);
        }

        // Sub Add Data
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxName.Text;
                if (!category.verifyData(name))
                {
                    showMessage("Утга хоосон байна!");
                }
                else if (category.existData("category_sub", name))
                {
                    showMessage("Төрөл дахиж оруулах боломжгүй!");
                }
                else
                {
                    command = new MySqlCommand("INSERT INTO `category_sub`(`name`) VALUES (@name)", con);
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (command.ExecuteNonQuery() == 1)
                    {
                        con.Close();
                        command = new MySqlCommand("INSERT INTO `category`(`basic_id`, `sub_id`) VALUES (@basic, (SELECT `id` FROM `category_sub` ORDER BY `id` DESC LIMIT 1))", con);
                        command.Parameters.Add("@basic", MySqlDbType.VarChar).Value = basic_id.ToString();
                        executeQuery(command, "Мэдээлэл амжилттай хадгаллаа.");
                    }
                }
            }
            catch (Exception ex)
            {
                showMessage("Sub: " + ex.Message);
            }
        }

        // Sub Update Data
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxName.Text;
                if (sub_id != 0)
                {
                    command = new MySqlCommand("UPDATE `category_sub` SET `name`=@name WHERE `id`=@id", con);
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                    command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToString(basic_id);
                    executeQuery(command, "Мэдээлэл амжилттай шинэчилэгдлээ.");
                }
                else
                {
                    showMessage("Жагсаалтаас төрөл сонгоно уу!");
                }
            }
            catch (Exception ex)
            {
                showMessage("Sub: " + ex.Message);
            }
        }

        // Sub Delete Data
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (sub_id != 0)
                {
                    dr = MessageBox.Show("Та жагсаалтаас хасахдаа итгэлтэй байна уу?", "Дэд төрөл хасах", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        command = new MySqlCommand("DELETE FROM `category` WHERE `basic_id`=@basic AND `sub_id`=@sub", con);
                        command.Parameters.Add("@basic", MySqlDbType.VarChar).Value = basic_id.ToString();
                        command.Parameters.Add("@sub", MySqlDbType.VarChar).Value = sub_id.ToString();

                        con.Open();
                        if (command.ExecuteNonQuery() == 1)
                        {
                            con.Close();
                            command = new MySqlCommand("DELETE FROM `category_sub` WHERE `id`=@id", con);
                            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = sub_id.ToString(); ;
                            executeQuery(command, "Мэдээлэл амжилттай устгагдлаа.");
                        }
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        public DataTable data(int basic_id)
        {
            DataTable table = new DataTable();
            try
            {
                string query = "SELECT "
                            + "cs.* FROM category_basic AS cb "
                            + "INNER JOIN category AS c ON c.basic_id = cb.id "
                            + "INNER JOIN category_sub AS cs ON cs.id = c.sub_id "
                            + "WHERE cb.id = '" + basic_id + "' ORDER BY cs.id DESC";
                using (command = new MySqlCommand(query, con))
                {
                    con.Open();
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    con.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Table: " + ex.Message);
            }
            return table;
        }

        private void clear()
        {
            sub_id = 0;
            textBoxName.Text = "";
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
            dataGridCsub.DataSource = data(basic_id);
        }

        private void showMessage(string text)
        {
            MessageBox.Show(text);
        }

        private void dataGridCsub_Click(object sender, EventArgs e)
        {
            sub_id = Convert.ToInt32(dataGridCsub.CurrentRow.Cells[0].Value.ToString());
            textBoxName.Text = dataGridCsub.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
