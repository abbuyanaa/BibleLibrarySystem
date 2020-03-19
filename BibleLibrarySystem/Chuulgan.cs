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
    public partial class Chuulgan : Form
    {
        MySqlConnection con = MyConnection.getConnection();
        MySqlDataReader reader;
        MySqlCommand command;
        DialogResult dr;
        public int chuulgan_id;

        public Chuulgan()
        {
            InitializeComponent();
        }

        private void AssemblyForm_Load(object sender, EventArgs e)
        {
            dataGridChuulgan.DataSource = data();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            store(textBoxName.Text);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            update(chuulgan_id, textBoxName.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete(chuulgan_id);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            chuulgan_id = 0;
            textBoxName.Text = "";
        }

        public void clear()
        {
            chuulgan_id = 0;
            textBoxName.Text = "";
        }

        public DataTable data()
        {
            DataTable table = new DataTable();
            try
            {
                using (command = new MySqlCommand("SELECT * FROM `chuulgan` ORDER BY `id` DESC", con))
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
        private Boolean verifyData(String text)
        {
            return !text.Equals("");
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
                    using (command = new MySqlCommand("INSERT INTO `chuulgan`(`name`) VALUES (@name)", con))
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
                command = new MySqlCommand("UPDATE `chuulgan` SET `name`=@name WHERE `id`=@id", con);
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToString(basic_id);
                executeQuery(command, "Мэдээлэл амжилттай шинэчилэгдлээ.");
                basic_id = 0;
                textBoxName.Text = "";
            }
            else
            {
                showMessage("Жагсаалтаас сонгоно уу!");
            }
        }

        // Delete Data
        public void delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    dr = MessageBox.Show("Жагсаалтаас хасахдаа итгэлтэй байна уу?", "Чуулган", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        command = new MySqlCommand("DELETE FROM `chuulgan` WHERE `id`=@id", con);
                        command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToString(id);
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
            dataGridChuulgan.DataSource = data();
        }

        private void showMessage(String text)
        {
            MessageBox.Show(text);
        }

        private void dataGridChuulgan_MouseClick(object sender, MouseEventArgs e)
        {
            chuulgan_id = Convert.ToInt32(dataGridChuulgan.CurrentRow.Cells[0].Value.ToString());
            textBoxName.Text = dataGridChuulgan.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
