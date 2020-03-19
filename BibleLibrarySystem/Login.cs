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
    public partial class Login : Form
    {
        MySqlConnection con = MyConnection.getConnection();
        MySqlCommand command;
        MySqlDataReader reader;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String query = "SELECT * FROM `login` WHERE `user_code`=@code AND `user_pass`=@pass";
                using (command = new MySqlCommand(query, con))
                {
                    command.Parameters.Add("@code", MySqlDbType.VarChar).Value = textCode.Text;
                    command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textPass.Text;

                    reader = command.ExecuteReader();

                    // if the username and the password exists
                    if (reader.Read())
                    {
                        con.Close();
                        // Show the main form
                        this.Hide();
                        Main main = new Main();
                        main.Show();
                    }
                    else
                    {
                        if (textCode.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Код оруулна уу!", "Код хоосон байна!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (textPass.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Нууц үг оруулна уу!", "Нууц үг хоосон байна!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Код болон нууц үг оруулна уу!", "Утга оруулна уу!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
