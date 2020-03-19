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
    public partial class BookReturn : Form
    {
        MySqlConnection con = MyConnection.getConnection();
        MySqlDataReader reader;
        MySqlCommand command;
        public int user_id;
        string user_gender;
        string user_type;
        string dateInString;
        int book_qty;

        public BookReturn()
        {
            InitializeComponent();
        }

        private void BookReturn_Load(object sender, EventArgs e)
        {
            dataGridBook.ColumnCount = 3;
            dataGridBook.Columns[0].Name = "№";
            dataGridBook.Columns[1].Name = "Нэр";
            dataGridBook.Columns[2].Name = "Зураг";
            // Full Row Select active
            dataGridBook.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridBook.MultiSelect = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            dateInString = DateTime.Now.ToString();
            lbDateTime.Text = "Өнөөдөр: " + DateTime.Now.ToString("yyyy/mm/dd hh:mm:ss");
        }

        private void userRegid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string regid = userRegid.Text;
                if (!regid.Equals(""))
                {
                    try
                    {
                        string query = "SELECT * FROM `users` WHERE `regid` LIKE '" + regid + "%'";
                        using (command = new MySqlCommand(query, con))
                        {
                            con.Open();
                            reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                                user_id = reader.GetInt32("id");
                                string lname = firstCharToUpper(reader.GetString("last_name"));
                                string fname = firstCharToUpper(reader.GetString("first_name"));
                                string email = firstCharToUpper(reader.GetString("email"));
                                char gender = reader.GetChar("gender");
                                char type = reader.GetChar("type");
                                switch (type)
                                {
                                    case 't':
                                        user_type = "Багш";
                                        break;
                                    case 's':
                                        user_type = "Оюутан";
                                        break;
                                }
                                switch (gender)
                                {
                                    case 'm':
                                        user_gender = "Эрэгтэй";
                                        break;
                                    default:
                                        user_gender = "Эмэгтэй";
                                        break;
                                }
                                int phone = reader.GetInt32("phone");
                                lbLname.Text = "Овог: " + lname;
                                lbFname.Text = "Нэр: " + fname;
                                lbPhone.Text = "Утас: " + phone;
                                lbEmail.Text = "Цахим хаяг: " + email;
                                lbGender.Text = "Хүйс: " + user_gender;

                                // Users calculator return day
                                //startDate = DateTime.Parse(dateInString);
                                //expiryDate = DateTime.Today.AddDays(returnDay);

                                // Current Year, Month, Day
                                //DateTime startDateValue = (Convert.ToDateTime(startDate.ToString()));
                                //string cY = startDateValue.Year.ToString();
                                //string cM = startDateValue.Month.ToString();
                                //string cD = startDateValue.Day.ToString();

                                // Expiry Year, Month, Day
                                //DateTime expiryDateValue = (Convert.ToDateTime(expiryDate.ToString()));
                                //string fY = expiryDateValue.Year.ToString();
                                //string fM = expiryDateValue.Month.ToString();
                                //string fD = expiryDateValue.Day.ToString();

                                //lbReturnTime.Text = "Буцаах хугацаа: " + cY + "." + cM + "." + cD + " - " + fY + "." + fM + "." + fD;
                                //row = new int[userIndex];
                            }
                            con.Close();
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("User get data: " + ex.Message);
                    }
                }
                else
                {
                    lbLname.Text = "Овог: ";
                    lbFname.Text = "Нэр: ";
                    lbPhone.Text = "Утас: ";
                    lbEmail.Text = "Цахим хаяг: ";
                }
            }
            catch (Exception ex)
            {
                showMessage("User Details: " + ex.Message);
            }
        }

        // First word uppercase
        public static String firstCharToUpper(String text)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentException("ARGH!");
            return text.First().ToString().ToUpper() + text.Substring(1);
        }

        private void showMessage(string text)
        {
            MessageBox.Show(text);
        }

        private void bookCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Close();
                string book_code = bookCode.Text;
                if (!book_code.Equals(""))
                {
                    try
                    {
                        string query = "SELECT * FROM book_users AS bu "
                                    + "INNER JOIN users AS u ON u.id = bu.user_id "
                                    + "INNER JOIN book AS b ON b.id = bu.book_id "
                                    + "WHERE u.id = @user AND b.id = @book AND bu.status = 0";
                        using (command = new MySqlCommand(query, con))
                        {
                            command.Parameters.Add("@user", MySqlDbType.Int32).Value = user_id;
                            command.Parameters.Add("@book", MySqlDbType.VarChar).Value = book_code.ToString();
                            con.Open();
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                int book_no = reader.GetInt32("id");
                                string bname = firstCharToUpper(reader.GetString("name"));
                                string giving_at = reader.GetString("giving_at");
                                book_qty++;
                                bookName.Text = "Нэр: " + bname;
                                bookQty.Text = "Номны тоо: " + book_qty;
                                bookGiving.Text = "Ном авсан өдөр: " + giving_at;
                                
                                DateTime startDateValue = (Convert.ToDateTime(giving_at));
                                int startY = startDateValue.Year;
                                int startM = startDateValue.Month;
                                int startD = startDateValue.Day;
                                DateTime start = new DateTime(startY, startM, startD);

                                DateTime endDateValue = (Convert.ToDateTime(dateInString));
                                int endY = endDateValue.Year;
                                int endM = endDateValue.Month;
                                int endD = endDateValue.Day;
                                DateTime end = new DateTime(endY, endM, endD);

                                TimeSpan diff = end - start;

                                bookOverdue.Text = "Хэтэрсэн хоног: " + diff;

                                dataGridBook.Rows.Add(book_no, bname, bname);
                                bookCode.Text = "";
                            }
                            else
                            {
                                showMessage("Мэдээлэл олдсонгүй!");
                            }
                            con.Close();
                        }
                    }
                    catch (MySqlException ex)
                    {
                        showMessage("Book get data: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                showMessage("Book code: " + ex.Message);
            }
        }
    }
}
