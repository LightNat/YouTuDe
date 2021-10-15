using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YouTuDe
{
    public partial class Login : Form
    {
        //Personal Info
        public static string userid;
        public static string firstname;
        public static string lastname;
        public static string age;
        public static string accountSid;
        public static string authToken;
        public static string accountNumber;
        public static string profile;
        public static string userNumber;
        public static string username;
        public static string password;
        public static string rolename;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            var YouTude = Path.GetDirectoryName(Application.ExecutablePath) + "\\Image\\YouTuDe.png";
            pbLogo.Image = Image.FromFile(YouTude);
        }

        private void linkLabelCreate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Account.Account account = new Account.Account();
            this.Visible = false;
            account.Show();
        }

        private void linkLabelForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forgot.Id id = new Forgot.Id();
            this.Visible = false;
            id.Show();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtusername.Text) == true)
            {
                MessageBox.Show("Username must not be set as Null or Empty", "Null | Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(String.IsNullOrEmpty(txtpassword.Text) == true)
            {
                MessageBox.Show("Password must not be set as Null or Empty", "Null | Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Connection.Connection.DB();
                    Function.Function.gen = "SELECT * FROM users WHERE username = '"+txtusername.Text+"' AND password = '"+txtpassword.Text+"' ";
                    Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                    Function.Function.reader = Function.Function.command.ExecuteReader();

                    if (Function.Function.reader.HasRows)
                    {
                        Function.Function.reader.Read();

                        txtusername.Text = Function.Function.reader.GetValue(10).ToString();
                        txtpassword.Text = Function.Function.reader.GetValue(11).ToString();

                        //Full Info
                        userid = Function.Function.reader.GetValue(0).ToString();
                        firstname = Function.Function.reader.GetValue(1).ToString();
                        lastname = Function.Function.reader.GetValue(2).ToString();
                        age = Function.Function.reader.GetValue(3).ToString();
                        accountSid = Function.Function.reader.GetValue(5).ToString();
                        authToken = Function.Function.reader.GetValue(6).ToString();
                        accountNumber = Function.Function.reader.GetValue(7).ToString();
                        profile = Function.Function.reader.GetValue(8).ToString();
                        userNumber = Function.Function.reader.GetValue(9).ToString();
                        username = txtusername.Text;
                        password = txtpassword.Text;
                        rolename = Function.Function.reader.GetValue(12).ToString();

                        if (rolename == "Tourist")
                        {
                            Client.Dashboard dashboard = new Client.Dashboard();
                            this.Visible = false;
                            dashboard.Show();
                        }
                        else if (rolename == "Driver")
                        {
                            MessageBox.Show("Driver");
                        }
                        else
                        {
                            Admin.Dashboard dashboard = new Admin.Dashboard();
                            this.Visible = false;
                            dashboard.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Credentials!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        
    }
}
