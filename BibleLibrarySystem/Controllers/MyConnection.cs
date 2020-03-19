using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace BibleLibrarySystem.Controllers
{
    class MyConnection
    {
        //private MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='csharp_bible_library';username=root;password=");


        public static MySqlConnection getConnection()
        {
            MySqlConnection con = null;
            try
            {
                con = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='csharp_bible_library';username=root;password=");
                return con;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return con;
        }

        // Create a function to return our connection
        //public MySqlConnection getConnection()
        //{
        //    return con;
        //}

        // Create a function to open the connection
        //public void openConnection()
        //{
        //    if (con.State == ConnectionState.Closed)
        //    {
        //        con.Open();
        //    }
        //}

        // Create a function to close the connection
        //public void closeConnection()
        //{
        //    if (con.State == ConnectionState.Open)
        //    {
        //        con.Close();
        //    }
        //}
    }
}
