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

        public static int containerCount;
        private string[] containerid = new string[100];
        private string[] userid = new string[100];
        private string[] firstname = new string[100];
        private string[] lastname = new string[100];
        private string[] userprofile = new string[100];
        private string[] category = new string[100];

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

            GenerateContainer();
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

        private void GenerateContainer()
        {
            flowLayoutPanelContainer.Controls.Clear();

            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "SELECT COUNT(*) AS Count FROM selectedContainerClient WHERE selectedContainerClient.userid = '"+Login.userid+"' ";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                Function.Function.reader = Function.Function.command.ExecuteReader();

                if (Function.Function.reader.HasRows)
                {
                    Function.Function.reader.Read();

                    string count = Function.Function.reader.GetValue(0).ToString();
                    containerCount = Convert.ToInt32(count);

                    ContainerUserControl[] containerUserControl = new ContainerUserControl[containerCount];

                    try
                    {
                        Connection.Connection.DB();
                        Function.Function.gen = "SELECT selectedContainerClient.containerid, selectedContainerClient.userid, users.firstname, users.lastname, users.profile, selectedContainerClient.category FROM selectedContainerClient INNER JOIN users ON selectedContainerClient.userid = users.userid WHERE selectedContainerClient.userid = '"+Login.userid+"' ";
                        Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                        Function.Function.reader = Function.Function.command.ExecuteReader();

                        if (Function.Function.reader.HasRows)
                        {
                            for (int i = 0; i < containerUserControl.Length; i++)
                            {
                                Function.Function.reader.Read();

                                containerid[i] = Function.Function.reader.GetValue(0).ToString();
                                userid[i] = Function.Function.reader.GetValue(1).ToString();
                                firstname[i] = Function.Function.reader.GetValue(2).ToString();
                                lastname[i] = Function.Function.reader.GetValue(3).ToString();
                                userprofile[i] = Function.Function.reader.GetValue(4).ToString();
                                category[i] = Function.Function.reader.GetValue(5).ToString();

                                //Initialize
                                containerUserControl[i] = new ContainerUserControl();

                                //adding Data
                                containerUserControl[i].containerid = containerid[i];
                                containerUserControl[i].userid = userid[i];
                                containerUserControl[i].firstname = firstname[i];
                                containerUserControl[i].lastname = lastname[i];
                                containerUserControl[i].userprofile = userprofile[i];
                                containerUserControl[i].category = category[i];

                                flowLayoutPanelContainer.Controls.Add(containerUserControl[i]);
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
    }
}
