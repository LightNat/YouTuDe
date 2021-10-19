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
    public partial class Drivers : Form
    {
        private int id;
        private string profile;

        //Variables for pendingDrivers
        private int pendingDriverCount;
        private string[] pendingDriverUserId = new string[100];
        private string[] pendingDriverFirstname = new string[100];
        private string[] pendingDriverLastname = new string[100];
        private string[] pendingDriverAge = new string[100];
        private string[] pendingDriverLicense = new string[100];
        private string[] pendingDriverProfile = new string[100];
        private string[] pendingDriverNumber = new string[100];
        private string[] pendingDriverUsername = new string[100];
        private string[] pendingDriverPassword = new string[100];
        private string[] pendingDriverRolename = new string[100];

        //Variables for Drivers
        private int driverCount;
        private string[] driverUserID = new string[100];
        private string[] driverUserFirstname = new string[100];
        private string[] driverUserLastname = new string[100];
        private string[] driverUserAge = new string[100];
        private string[] driverUserLicense = new string[100];
        private string[] driverUserProfile = new string[100];
        private string[] driverUserNumber = new string[100];
        private string[] driverUserUsername = new string[100];
        private string[] driverUserPassword = new string[100];
        private string[] driverUserRolename = new string[100];

        //for string count
        int count;
        string name;

        //extension
        private string firstname;
        private string lastname;

        public Drivers()
        {
            InitializeComponent();
        }

        private void Drivers_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Login.userid);

            displayProfile();

            GenerateFullName();

            GeneratePendingDrivers();
            GenerateDrivers();
            
            if (PendingDriverUserControl.licenseOn == true)
            {
                try
                {
                    pblicense.Image = Image.FromFile(PendingDriverUserControl.License);
                    PendingDriverUserControl.licenseOn = false;
                }
                catch (Exception ex)
                {
                    //Don Nothing
                }
            }
            else
            {
                try
                {
                    pblicense.Image = null;
                }
                catch (Exception ex)
                {
                    //Do Nothing
                }
            }

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

                    if (count == 20)
                    {
                        this.lblfullname.Location = new Point(-4, 114);
                    }
                    else if (count == 19)
                    {
                        this.lblfullname.Location = new Point(0, 114);
                    }
                    else if (count == 18)
                    {
                        this.lblfullname.Location = new Point(4, 114);
                    }
                    else if (count == 17)
                    {
                        this.lblfullname.Location = new Point(8, 114);
                    }
                    else if (count == 16)
                    {
                        this.lblfullname.Location = new Point(12, 114);
                    }
                    else if (count == 15)
                    {
                        this.lblfullname.Location = new Point(16, 114);
                    }
                    else if (count == 14)
                    {
                        this.lblfullname.Location = new Point(20, 114);
                    }
                    else if (count == 13)
                    {
                        this.lblfullname.Location = new Point(24, 114);
                    }
                    else if (count == 12)
                    {
                        this.lblfullname.Location = new Point(28, 114);
                    }
                    else if (count == 11)
                    {
                        this.lblfullname.Location = new Point(32, 114);
                    }
                    else if (count == 10)
                    {
                        this.lblfullname.Location = new Point(36, 114);
                    }
                    else if (count == 9)
                    {
                        this.lblfullname.Location = new Point(40, 114);
                    }
                    else if (count == 8)
                    {
                        this.lblfullname.Location = new Point(44, 114);
                    }
                    else if (count == 7)
                    {
                        this.lblfullname.Location = new Point(48, 114);
                    }
                    else if (count == 6)
                    {
                        this.lblfullname.Location = new Point(52, 114);
                    }
                    else if (count == 5)
                    {
                        this.lblfullname.Location = new Point(56, 114);
                    }
                    else if (count == 4)
                    {
                        this.lblfullname.Location = new Point(60, 114);
                    }
                    else if (count == 3)
                    {
                        this.lblfullname.Location = new Point(64, 114);
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

        private void GeneratePendingDrivers()
        {
            flowLayoutPanelPendingDrivers.Controls.Clear();

            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "SELECT COUNT(*) FROM pendingDriver";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                Function.Function.reader = Function.Function.command.ExecuteReader();

                if (Function.Function.reader.HasRows)
                {
                    Function.Function.reader.Read();

                    string count = Function.Function.reader.GetValue(0).ToString();
                    pendingDriverCount = Convert.ToInt32(count);

                    PendingDriverUserControl[] pendingDriverUserControl = new PendingDriverUserControl[pendingDriverCount];

                    try
                    {
                        Connection.Connection.DB();
                        Function.Function.gen = "SELECT * FROM pendingDriver";
                        Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                        Function.Function.reader = Function.Function.command.ExecuteReader();

                        if (Function.Function.reader.HasRows)
                        {
                            for (int i = 0; i < pendingDriverUserControl.Length; i++)
                            {
                                Function.Function.reader.Read();

                                pendingDriverUserId[i] = Function.Function.reader.GetValue(0).ToString();
                                pendingDriverFirstname[i] = Function.Function.reader.GetValue(1).ToString();
                                pendingDriverLastname[i] = Function.Function.reader.GetValue(2).ToString();
                                pendingDriverAge[i] = Function.Function.reader.GetValue(3).ToString();
                                pendingDriverLicense[i] = Function.Function.reader.GetValue(4).ToString();
                                pendingDriverProfile[i] = Function.Function.reader.GetValue(5).ToString();
                                pendingDriverNumber[i] = Function.Function.reader.GetValue(6).ToString();
                                pendingDriverUsername[i] = Function.Function.reader.GetValue(7).ToString();
                                pendingDriverPassword[i] = Function.Function.reader.GetValue(8).ToString();
                                pendingDriverRolename[i] = Function.Function.reader.GetValue(9).ToString();

                                //Initialize
                                pendingDriverUserControl[i] = new PendingDriverUserControl();

                                //Adding Data
                                pendingDriverUserControl[i].userid = pendingDriverUserId[i];
                                pendingDriverUserControl[i].firstname = pendingDriverFirstname[i];
                                pendingDriverUserControl[i].lastname = pendingDriverLastname[i];
                                pendingDriverUserControl[i].age = pendingDriverAge[i];
                                pendingDriverUserControl[i].license = pendingDriverLicense[i];
                                pendingDriverUserControl[i].number = pendingDriverNumber[i];
                                pendingDriverUserControl[i].Profile = pendingDriverProfile[i];
                                pendingDriverUserControl[i].Username = pendingDriverUsername[i];
                                pendingDriverUserControl[i].Password = pendingDriverPassword[i];
                                pendingDriverUserControl[i].Rolename = pendingDriverRolename[i];

                                flowLayoutPanelPendingDrivers.Controls.Add(pendingDriverUserControl[i]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GenerateDrivers()
        {
            flowLayoutPanelDrivers.Controls.Clear();

            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "SELECT COUNT(*) FROM users WHERE rolename = 'Driver' ";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                Function.Function.reader = Function.Function.command.ExecuteReader();

                if (Function.Function.reader.HasRows)
                {
                    Function.Function.reader.Read();

                    string count = Function.Function.reader.GetValue(0).ToString();
                    driverCount = Convert.ToInt32(count);

                    DriverUserControl[] driverUserControl = new DriverUserControl[driverCount];

                    try
                    {
                        Connection.Connection.DB();
                        Function.Function.gen = "SELECT * FROM users WHERE rolename = 'Driver' ";
                        Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                        Function.Function.reader = Function.Function.command.ExecuteReader();

                        if (Function.Function.reader.HasRows)
                        {
                            for (int i = 0; i < driverUserControl.Length; i++)
                            {
                                Function.Function.reader.Read();

                                driverUserID[i] = Function.Function.reader.GetValue(0).ToString();
                                driverUserFirstname[i] = Function.Function.reader.GetValue(1).ToString();
                                driverUserLastname[i] = Function.Function.reader.GetValue(2).ToString();
                                driverUserAge[i] = Function.Function.reader.GetValue(3).ToString();
                                driverUserLicense[i] = Function.Function.reader.GetValue(4).ToString();
                                driverUserProfile[i] = Function.Function.reader.GetValue(8).ToString();
                                driverUserNumber[i] = Function.Function.reader.GetValue(9).ToString();
                                driverUserUsername[i] = Function.Function.reader.GetValue(10).ToString();
                                driverUserPassword[i] = Function.Function.reader.GetValue(11).ToString();
                                driverUserRolename[i] = Function.Function.reader.GetValue(12).ToString();

                                //Initialize
                                driverUserControl[i] = new DriverUserControl();

                                //Adding Data
                                driverUserControl[i].userid = driverUserID[i];
                                driverUserControl[i].firstname = driverUserFirstname[i];
                                driverUserControl[i].lastname = driverUserLastname[i];
                                driverUserControl[i].age = driverUserAge[i];
                                driverUserControl[i].license = driverUserLicense[i];
                                driverUserControl[i].Profile = driverUserProfile[i];
                                driverUserControl[i].number = driverUserNumber[i];
                                driverUserControl[i].Username = driverUserUsername[i];
                                driverUserControl[i].Password = driverUserPassword[i];
                                driverUserControl[i].Rolename = driverUserRolename[i];

                                flowLayoutPanelDrivers.Controls.Add(driverUserControl[i]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RefreshFlowLayout()
        {
            Admin.Drivers drivers = new Admin.Drivers();
            this.Visible = false;
            drivers.Show();
        }
    }
}
