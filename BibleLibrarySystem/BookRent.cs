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
using System.Collections;

namespace BibleLibrarySystem
{
    public partial class BookRent : Form
    {
        MySqlConnection con = MyConnection.getConnection();
        //MySqlDataAdapter adapter;
        MySqlDataReader reader;
        MySqlCommand command;
        //DataTable table;
        public int user_id;
        public int[] row = new int[10];
        string currentDateTime;
        string currentDate;
        string user_type;
        int userIndex;
        int num = 0;
        int returnDay;
        DateTime startDate;
        DateTime expiryDate;

        public BookRent()
        {
            InitializeComponent();
        }

        private void BookRent_Load(object sender, EventArgs e)
        {
            //dataGridRent.Columns.Add("book_no","№");
            //dataGridRent.Columns.Add("book_name", "Нэр");
            //dataGridRent.Columns.Add("book_tailbar", "Тайлбар");
            //dataGridRent.Columns.Add("book_year", "Он");
            //dataGridRent.Columns.Add("book_cbasic", "Ү/төрөл");
            //dataGridRent.Columns.Add("book_csub", "Д/төрөл");

            dataGridRent.ColumnCount = 3;
            dataGridRent.Columns[0].Name = "№";
            dataGridRent.Columns[1].Name = "Нэр";
            dataGridRent.Columns[2].Name = "Зураг";
            currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //string date = DateTime.Now.ToLongDateString();
            //string time = DateTime.Now.ToLongTimeString();
            //lbDateTime.Text = "Өнөөдөр: " + date + " " + time;
            currentDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            lbDateTime.Text = "Өнөөдөр: " + currentDateTime;
        }

        private void userRegid_TextChanged(object sender, EventArgs e)
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
                            char type = reader.GetChar("type");
                            Console.WriteLine("User type: " + type);
                            switch (type)
                            {
                                case 't':
                                    userIndex = 5;
                                    user_type = "Багш";
                                    returnDay = 21;
                                    break;
                                case 's':
                                    userIndex = 3;
                                    user_type = "Оюутан";
                                    returnDay = 14;
                                    break;
                            }
                            int phone = reader.GetInt32("phone");
                            lbLname.Text = "Овог: " + lname;
                            lbFname.Text = "Нэр: " + fname;
                            lbPhone.Text = "Утас: " + phone;
                            lbType.Text = "Төлөв: " + user_type + " нэг дор " + userIndex + "ш ном " + returnDay + " хоног авах боломжтой.";

                            // Users calculator return day
                            startDate = DateTime.Parse(currentDate);
                            expiryDate = DateTime.Today.AddDays(returnDay);

                            // Current Year, Month, Day
                            DateTime startDateValue = (Convert.ToDateTime(startDate.ToString()));
                            string cY = startDateValue.Year.ToString();
                            string cM = startDateValue.Month.ToString();
                            string cD = startDateValue.Day.ToString();

                            // Expiry Year, Month, Day
                            DateTime expiryDateValue = (Convert.ToDateTime(expiryDate.ToString()));
                            string fY = expiryDateValue.Year.ToString();
                            string fM = expiryDateValue.Month.ToString();
                            string fD = expiryDateValue.Day.ToString();

                            lbReturnTime.Text = "Буцаах хугацаа: " + cY + "." + cM + "." + cD + " - " + fY + "." + fM + "." + fD;

                            row = new int[userIndex];
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
                lbType.Text = "Төлөв: ";
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
                        string query = "SELECT * FROM `book` WHERE `id`='" + book_code + "'";
                        using (command = new MySqlCommand(query, con))
                        {
                            con.Open();
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                int book_no = reader.GetInt32("id");
                                string bname = firstCharToUpper(reader.GetString("name"));
                                string btailbar = firstCharToUpper(reader.GetString("tailbar"));
                                int book_year = reader.GetInt32("year");

                                if (num < userIndex)
                                {
                                    dataGridRent.Rows.Add(book_no, bname, book_year);
                                    Console.WriteLine("DataGridBook: " + book_no);
                                    row[num] = book_no;
                                    num++;
                                }
                                else
                                {
                                    MessageBox.Show(user_type + " нэг дор " + userIndex + "ш ном авах боломжтой!", "Анхаар!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                bookCode.Text = "";
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

        private bool existRent(int user_id)
        {
            string query = "SELECT * FROM `book_users` WHERE `user_id`=@user AND `status`='0' ORDER BY `id` DESC";
            command = new MySqlCommand(query, con);
            command.Parameters.Add("@user", MySqlDbType.Int32).Value = user_id;

            con.Open();
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

        private void btnRent_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Date: " + currentDate);
                // Checking rent book
                if (existRent(user_id))
                {
                    showMessage("Дахиж ном түрээслэх боломжгүй!");
                }
                else
                {
                    for (int i = 0; i < userIndex; i++)
                    {
                        if (row[i] != 0)
                        {
                            Console.WriteLine("Book Rent - User ID: " + user_id + ", Book ID: " + row[i]);
                            string rent_insert_query = "INSERT INTO `book_users` "
                                            + "(`user_id`, `book_id`, `overdue_date`, `mongo`, `status`, `giving_at`, `receipt_at`) VALUES "
                                            + "(@user, @book, 0, 0, 0, @giving, (SELECT DATE_ADD(@giving, INTERVAL @days DAY)))";
                            using (command = new MySqlCommand(rent_insert_query, con))
                            {
                                command.Parameters.Add("@user", MySqlDbType.Int32).Value = user_id;
                                command.Parameters.Add("@book", MySqlDbType.Int32).Value = row[i];
                                command.Parameters.Add("@giving1", MySqlDbType.VarChar).Value = currentDate;
                                command.Parameters.Add("@giving2", MySqlDbType.VarChar).Value = currentDate;
                                command.Parameters.Add("@days", MySqlDbType.Int32).Value = returnDay;

                                con.Open();
                                if (command.ExecuteNonQuery() == 1)
                                {
                                    con.Close();
                                }
                                else
                                {
                                    con.Close();
                                    Console.WriteLine("Алдаа гарлаа: " + row[i]);
                                }
                            }
                        }
                    }
                    showMessage("Амжилттай бүртгэгдлээ.");
                }
            }
            catch (Exception ex)
            {
                showMessage("Book Rent button: " + ex.Message);
            }
        }

        public void bookRent(int user_id, int book_id)
        {
            
        }

        public void bookMinus(int book_id)
        {
            try
            {
                string book_update_query = "UPDATE `book` SET `qty`=`qty`-1 WHERE `id`='" + book_id + "'";
                using (command = new MySqlCommand(book_update_query, con))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    if (command.ExecuteNonQuery() == 1)
                    {
                        Console.WriteLine("Book minused: " + book_id);
                    }
                    else
                    {
                        Console.WriteLine("Book minused: " + book_id);
                    }
                    con.Close();
                }
            }
            catch (MySqlException ex)
            {
                showMessage("Book minus: " + ex.Message);
            }
        }
    }
}
