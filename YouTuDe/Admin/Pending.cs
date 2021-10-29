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

namespace YouTuDe.Admin
{
    public partial class Pending : Form
    {
        private int id;
        private string profile;

        //for string count
        int count;
        string name;

        //extension
        private string firstname;
        private string lastname;

        public Pending()
        {
            InitializeComponent();
        }

        private void Pending_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Login.userid);

            displayProfile();

            GenerateFullName();
        }

        public void GenerateFullName()
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

                    firstname = Function.Function.reader.GetValue(1).ToString();
                    lastname = Function.Function.reader.GetValue(2).ToString();
                    lblfullname.Text = firstname + " " + lastname;

                    name = firstname + " " + lastname;
                    count = name.Length;
                    int x = 64;
                    for (int i = 3; i < count; i++)
                    {
                        this.lblfullname.Location = new Point(x, 114);
                        x -= 4;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                    try
                    {
                        var image = Path.GetDirectoryName(Application.ExecutablePath) + "\\Profile\\" + profile;
                        pbprofile.Image = Image.FromFile(image);
                    }
                    catch (Exception ex)
                    {

                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Admin.Dashboard dashboard = new Admin.Dashboard();
            this.Visible = false;
            dashboard.Show();
        }

        private void btnSpots_Click(object sender, EventArgs e)
        {
            Admin.Spots spots = new Admin.Spots();
            this.Visible = false;
            spots.Show();
        }

        private void btnTourist_Click(object sender, EventArgs e)
        {
            Admin.Tourist tourist = new Admin.Tourist();
            this.Visible = false;
            tourist.Show();
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            Admin.Drivers drivers = new Admin.Drivers();
            this.Visible = false;
            drivers.Show();
        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            Admin.Pending pending = new Admin.Pending();
            this.Visible = false;
            pending.Show();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            Admin.Status status = new Admin.Status();
            this.Visible = false;
            status.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Admin.Reports reports = new Admin.Reports();
            this.Visible = false;
            reports.Show();
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

        private void btnTourist_MouseHover(object sender, EventArgs e)
        {
            btnTourist.BackColor = Color.FromArgb(255, 222, 89);
            btnTourist.ForeColor = Color.Red;
        }

        private void btnTourist_MouseLeave(object sender, EventArgs e)
        {
            btnTourist.BackColor = Color.FromArgb(28, 33, 32);
            btnTourist.ForeColor = Color.FromArgb(255, 222, 89);
        }

        private void btnDrivers_MouseHover(object sender, EventArgs e)
        {
            btnDrivers.BackColor = Color.FromArgb(255, 222, 89);
            btnDrivers.ForeColor = Color.Red;
        }

        private void btnDrivers_MouseLeave(object sender, EventArgs e)
        {
            btnDrivers.BackColor = Color.FromArgb(28, 33, 32);
            btnDrivers.ForeColor = Color.FromArgb(255, 222, 89);
        }

        private void btnPending_MouseHover(object sender, EventArgs e)
        {
            btnPending.BackColor = Color.FromArgb(255, 222, 89);
            btnPending.ForeColor = Color.Red;
        }

        private void btnPending_MouseLeave(object sender, EventArgs e)
        {
            btnPending.BackColor = Color.FromArgb(28, 33, 32);
            btnPending.ForeColor = Color.FromArgb(255, 222, 89);
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

        private void btnReports_MouseHover(object sender, EventArgs e)
        {
            btnReports.BackColor = Color.FromArgb(255, 222, 89);
            btnReports.ForeColor = Color.Red;
        }

        private void btnReports_MouseLeave(object sender, EventArgs e)
        {
            btnReports.BackColor = Color.FromArgb(28, 33, 32);
            btnReports.ForeColor = Color.FromArgb(255, 222, 89);
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
