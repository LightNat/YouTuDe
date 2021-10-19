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
    public partial class Status : Form
    {
        private int id;

        private string profile;

        //Tourist Image
        private string imageFile;
        private string fileImage;

        //Torurist Variables
        private string profileUpdate;

        private string updateProfile;

        private bool change = false;


        //for string count
        int count;
        string name;

        public Status()
        {
            InitializeComponent();
        }

        private void Status_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Login.userid);

            displayProfile();

            Allignment();

            lblfullname.Text = Login.firstname + " " + Login.lastname;

            DisplayDetails();
        }
        
        private void DisplayDetails()
        {
            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "SELECT * FROM users WHERE userid = '"+Login.userid+"' ";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                Function.Function.reader = Function.Function.command.ExecuteReader();

                if (Function.Function.reader.HasRows)
                {
                    Function.Function.reader.Read();

                    txtfirstname.Text = Function.Function.reader.GetValue(1).ToString();
                    txtlastname.Text = Function.Function.reader.GetValue(2).ToString();
                    txtage.Text = Function.Function.reader.GetValue(3).ToString();
                    profileUpdate = Function.Function.reader.GetValue(8).ToString();
                    txtnumber.Text = Function.Function.reader.GetValue(9).ToString();
                    txtusername.Text = Function.Function.reader.GetValue(10).ToString();
                    txtpassword.Text = Function.Function.reader.GetValue(11).ToString();

                    var image = Path.GetDirectoryName(Application.ExecutablePath) + "\\Profile\\" + profileUpdate;
                    pbimage.Image = Image.FromFile(image);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Allignment()
        {
            name = Login.firstname + " " + Login.lastname;
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

        private void btnchoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;) | *.jpg; *.jpeg; *.gif; *.bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                
                fileImage = open.FileName;
                imageFile = fileImage;
                pbimage.Image = new Bitmap(imageFile);
                change = true;
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (change == false)
            {
                imageFile = profileUpdate;
            }
            else
            {
                imageFile = fileImage;
            }

            var file = Path.GetFileName(imageFile);
            updateProfile = file;

            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "UPDATE users SET firstname = '"+txtfirstname.Text+"', lastname = '"+txtlastname.Text+"', age = '"+txtage.Text+"', profile = '"+updateProfile+"', userNumber = '"+txtnumber.Text+"', username = '"+txtusername.Text+"', password = '"+txtpassword.Text+"' WHERE userid = '"+Login.userid+"' ";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                Function.Function.command.ExecuteNonQuery();

                try
                {
                    File.Copy(imageFile, Path.Combine(Path.GetDirectoryName(Application.ExecutablePath) + "\\Profile", updateProfile));
                }
                catch (Exception ex)
                {
                    //Do Nothing
                }

                MessageBox.Show("Info updated Successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Client.Status status = new Client.Status();
                this.Visible = false;
                status.Show();

                Connection.Connection.conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
