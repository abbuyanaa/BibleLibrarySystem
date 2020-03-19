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
    public partial class CbasicForm : Form
    {
        MySqlConnection con = MyConnection.getConnection();
        CategoryController category = new CategoryController();
        MySqlDataReader reader;
        MySqlCommand command;
        DialogResult dr;
        public int basic_id;

        public CbasicForm()
        {
            InitializeComponent();
        }

        private void CbasicForm_Load(object sender, EventArgs e)
        {
            dataGridCbasic.DataSource = data();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            store(textBoxName.Text);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            update(basic_id, textBoxName.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete(basic_id);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            basic_id = 0;
            textBoxName.Text = "";
        }

        public DataTable data()
        {
            DataTable table = new DataTable();
            try
            {
                using (command = new MySqlCommand("SELECT * FROM `category_basic` ORDER BY `id` DESC", con))
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

        private void dataGridBasic_Click(object sender, EventArgs e)
        {
            basic_id = Convert.ToInt32(dataGridCbasic.CurrentRow.Cells[0].Value.ToString());
            textBoxName.Text = dataGridCbasic.CurrentRow.Cells[1].Value.ToString();
        }

        // Basic Insert Data
        public void store(String name)
        {
            try
            {
                if (!category.verifyData(name))
                {
                    showMessage("Утга хоосон байна!");
                }
                else if (category.existData("category_basic", name))
                {
                    showMessage("Төрөл дахиж оруулах боломжгүй!");
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

        // Basic Update Data
        public void update(int basic_id, String name)
        {
            try
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
                    showMessage("Жагсаалтаас төрөл сонгоно уу!");
                }
            }
            catch (Exception ex)
            {
                showMessage("Cat: " + ex.Message);
            }
        }

        // Basic Delete Data
        public void delete(int basic_id)
        {
            try
            {
                if (basic_id != 0)
                {
                    dr = MessageBox.Show("Та жагсаалтаас хасахдаа итгэлтэй байна уу?", "Үндсэн төрөл хасах", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        command = new MySqlCommand("DELETE FROM `category_basic` WHERE `id`=@id", con);
                        command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToString(basic_id);
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

        private void btnCsub_Click(object sender, EventArgs e)
        {
            if (basic_id != 0)
            {
                CsubForm csubForm = new CsubForm(basic_id);
                csubForm.ShowDialog();
            }
            else
            {
                showMessage("Жагсаалтаас сонгоно уу!");
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
            dataGridCbasic.DataSource = data();
        }

        private void showMessage(String text)
        {
            MessageBox.Show(text);
        }
    }
}
