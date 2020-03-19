using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibleLibrarySystem.Controllers;
using MySql.Data.MySqlClient;

namespace BibleLibrarySystem
{
    public partial class CompanyForm : Form
    {
        MySqlConnection con = MyConnection.getConnection();
        CompanyController company = new CompanyController();
        MySqlCommand command;
        MySqlDataReader reader;
        DialogResult dr;
        public static int company_id;

        public CompanyForm()
        {
            InitializeComponent();
            dataGridCompany.DataSource = fillCompanyData();
        }

        private void CompanyForm_Load(object sender, EventArgs e)
        {
            dataGridCompany.DataSource = fillCompanyData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            store(textBoxName.Text);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            update(company_id, textBoxName.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete(company_id);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        public DataTable fillCompanyData()
        {
            DataTable table = new DataTable();
            try
            {
                using (command = new MySqlCommand("SELECT * FROM `company` ORDER BY `id` DESC", con))
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

        public bool verifyData(String name)
        {
            return !name.Equals("");
        }

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
                    using (command = new MySqlCommand("INSERT INTO `company`(`name`) VALUES (@name)", con))
                    {
                        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                        executeQuery(command, "Байгууллага амжилттай нэмэгдлээ.");
                    }
                }
            }
            catch (MySqlException ex)
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
            dataGridCompany.DataSource = fillCompanyData();
        }

        private void clear()
        {
            company_id = 0;
            textBoxName.Text = "";
        }

        private void showMessage(String text)
        {
            MessageBox.Show(text);
        }

        private void dataGridCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            company_id = Convert.ToInt32(dataGridCompany.CurrentRow.Cells[0].Value.ToString());
            textBoxName.Text = dataGridCompany.CurrentRow.Cells[1].Value.ToString();
        }

        // Update Data
        public void update(int id, String name)
        {
            if (company_id != 0)
            {
                command = new MySqlCommand("UPDATE `company` SET `name`=@name WHERE `id`=@id", con);
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = company_id.ToString();
                executeQuery(command, "Мэдээлэл амжилттай шинэчилэгдлээ.");
            }
            else
            {
                showMessage("Жагсаалтаас сонгоно уу!");
            }
        }

        // Delete Data
        public void delete(int company_id)
        {
            try
            {
                if (company_id != 0)
                {
                    dr = MessageBox.Show("Жагсаалтаас устгахдаа итгэлтэй байна уу!", "Байгууллга хасах", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        command = new MySqlCommand("DELETE FROM `company` WHERE `id`=@id", con);
                        command.Parameters.Add("@id", MySqlDbType.VarChar).Value = company_id.ToString();
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
    }
}
