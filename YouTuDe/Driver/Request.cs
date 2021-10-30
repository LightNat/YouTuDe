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

namespace YouTuDe.Driver
{
    public partial class Request : Form
    {

        private int id;

        private string profile;


        //for string count
        int count;
        string name;

        public Request()
        {
            InitializeComponent();
        }

        private void Request_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Login.userid);

            displayProfile();

            Allignment();

            lblfullname.Text = Login.firstname + " " + Login.lastname;
        }

        public void Allignment()
        {
            name = Login.firstname + " " + Login.lastname;
            count = name.Length;
            int x = 64;
            for (int i = 3; i < count; i++)
            {
                this.lblfullname.Location = new Point(x, 114);
                x -= 4;
            }

        }

        public void displayProfile()
        {
            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "SELECT * FROM users WHERE userid = '" + id + "' ";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                Function.Function.reader = Function.Function.command.ExecuteReader();

                if (Function.Function.reader.HasRows)
                {
                    Function.Function.reader.Read();

                    profile = Function.Function.reader.GetValue(8).ToString();

                    var image = Path.GetDirectoryName(Application.ExecutablePath) + "\\Profile\\" + profile;
                    pbprofile.Image = Image.FromFile(image);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Driver.Dashboard dashboard = new Driver.Dashboard();
            this.Visible = false;
            dashboard.Show();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            Driver.Request request = new Driver.Request();
            this.Visible = false;
            request.Show();
        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            Driver.Pending pending = new Driver.Pending();
            this.Visible = false;
            pending.Show();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            Driver.Status status = new Driver.Status();
            this.Visible = false;
            status.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            string text = "Do you wish to log out?";
            string caption = "Logout";
            DialogResult result = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                this.Visible = false;
                login.Show();
            }
        }
    }
}
