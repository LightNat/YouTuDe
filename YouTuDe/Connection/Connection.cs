using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace YouTuDe.Connection
{
    class Connection
    {//Redo
        public static SqlConnection conn;
        private static string connect = "Data Source=DESKTOP-GQFB644;Initial Catalog=YouTuDe;Integrated Security=True";

        public static void DB()
        {
            try
            {
                conn = new SqlConnection(connect);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
