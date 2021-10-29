using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouTuDe.Client
{
    public partial class Requests : Form
    {
        private int id;

        private string profile;


        //for string count
        int count;
        string name;

        public Requests()
        {
            InitializeComponent();
        }

        private void Requests_Load(object sender, EventArgs e)
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
                Function.Function.gen = "SELECT * FROM users WHERE userid = '"+id+"' ";
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
            Client.Dashboard dashboard = new Client.Dashboard();
            this.Visible = false;
            dashboard.Show();
        }

        private void btnSpots_Click(object sender, EventArgs e)
        {
            Client.Spots spots = new Client.Spots();
            this.Visible = false;
            spots.Show();
        }

        private void btnRequests_Click(object sender, EventArgs e)
        {
            Client.Requests requests = new Client.Requests();
            this.Visible = false;
            requests.Show();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            Client.Status status = new Client.Status();
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

        private void btnDashboard_MouseHover(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(255, 222, 89);
            btnDashboard.ForeColor = Color.Red;
        }

        private void btnDashboard_MouseLeave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(28, 33, 32);
            btnDashboard.ForeColor = Color.FromArgb(255, 222, 89);
        }

        private void btnSpots_MouseHover(object sender, EventArgs e)
        {
            btnSpots.BackColor = Color.FromArgb(255, 222, 89);
            btnSpots.ForeColor = Color.Red;
        }

        private void btnSpots_MouseLeave(object sender, EventArgs e)
        {
            btnSpots.BackColor = Color.FromArgb(28, 33, 32);
            btnSpots.ForeColor = Color.FromArgb(255, 222, 89);
        }

        private void btnRequests_MouseHover(object sender, EventArgs e)
        {
            btnRequests.BackColor = Color.FromArgb(255, 222, 89);
            btnRequests.ForeColor = Color.Red;
        }

        private void btnRequests_MouseLeave(object sender, EventArgs e)
        {
            btnRequests.BackColor = Color.FromArgb(28, 33, 32);
            btnRequests.ForeColor = Color.FromArgb(255, 222, 89);
        }

        private void btnStatus_MouseHover(object sender, EventArgs e)
        {
            btnStatus.BackColor = Color.FromArgb(255, 222, 89);
            btnStatus.ForeColor = Color.Red;
        }

        private void btnStatus_MouseLeave(object sender, EventArgs e)
        {
            btnStatus.BackColor = Color.FromArgb(28, 33, 32);
            btnStatus.ForeColor = Color.FromArgb(255, 222, 89);
        }

        private void btnLogout_MouseHover(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(255, 222, 89);
            btnLogout.ForeColor = Color.Red;
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(28, 33, 32);
            btnLogout.ForeColor = Color.FromArgb(255, 222, 89);
        }
    }
}
