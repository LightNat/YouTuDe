using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace YouTuDe.Forgot
{
    public partial class Id : Form
    {
        public static string userid;

        public Id()
        {
            InitializeComponent();
        }

        private void Id_Load(object sender, EventArgs e)
        {
            var YouTude = Path.GetDirectoryName(Application.ExecutablePath) + "\\Image\\YouTuDe.png";
            pbLogo.Image = Image.FromFile(YouTude);
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            int convertedId;

            if (String.IsNullOrWhiteSpace(txtId.Text) == true)
            {
                btnreset.Enabled = false;
            }
            else
            {
                
                if (!(Int32.TryParse(txtId.Text, out convertedId)))
                {
                    btnreset.Enabled = false;
                }
                else
                {
                    btnreset.Enabled = true;
                }
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Visible = false;
            login.Show();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int random = rand.Next(1000, 4000);
            string convertedRandom = random.ToString();

            userid = txtId.Text;

            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "SELECT * FROM users WHERE userid = '"+userid+"' ";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                Function.Function.reader = Function.Function.command.ExecuteReader();

                if (Function.Function.reader.HasRows)
                {
                    Function.Function.reader.Read();

                    try
                    {
                        Connection.Connection.DB();
                        Function.Function.gen = "UPDATE users SET verCode = '" + convertedRandom + "' WHERE userid = '" + userid + "' ";
                        Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                        Function.Function.command.ExecuteNonQuery();

                        Forgot.Code code = new Forgot.Code();
                        this.Visible = false;
                        code.Show();

                        Connection.Connection.conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Userid '"+userid+"' is currently Unavailable, Please try Again! ", "Invaild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
