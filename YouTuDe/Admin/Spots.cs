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
    public partial class Spots : Form
    {
        //Variable for update
        private string attractionIdUpdate;

        //Variables for ViewSpots
        private int attractionCount;
        private string[] attractionId = new string[100];
        private string[] touristAttraction = new string[100];
        private string[] touristDestination = new string[100];
        private string[] attractionImage = new string[100];
        private string[] attractionCost = new string[100];
        private string[] attractionDescription = new string[100];

        //Spot Image
        private string imageFile;

        //Variable to update image
        private string fileImage;

        //Spot Profile and Category
        private string spotProfile;
        private string spotCategory;

        //User
        private int id;
        private string profile;

        //for string count
        int count;
        string name;

        public Spots()
        {
            InitializeComponent();
        }

        private void Spots_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Login.userid);

            displayProfile();

            Allignment();

            lblfullname.Text = Login.firstname + " " + Login.lastname;

            GenerateSpotsNorthern();
            GenerateSpotsSouthern();

            CebuParts();
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

        public void CebuParts()
        {
            try
            {
                var imageSouthern = Path.GetDirectoryName(Application.ExecutablePath) + "\\Image\\CebuMapSouthern.png";
                pbsouthern.Image = Image.FromFile(imageSouthern);

                var imageNorthern = Path.GetDirectoryName(Application.ExecutablePath) + "\\Image\\CebuMapNorthern.png";
                pbnorthern.Image = Image.FromFile(imageNorthern);
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

                    profile = Function.Function.reader.GetValue(7).ToString();

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

        private void btnchoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;) | *.jpg; *.jpeg; *.gif; *.bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                fileImage = open.FileName;
                imageFile = fileImage;
                pbimage.Image = new Bitmap(imageFile);
                AdminViewSpotsUserControl.change = false;

            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                var file = Path.GetFileName(imageFile);
                spotProfile = file;

                if (String.IsNullOrWhiteSpace(txtattraction.Text) == true)
                {
                    MessageBox.Show("Tourist Attraction must not be set as Null or WhiteSpace, Please try Again!", "Null | WhiteSpace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(String.IsNullOrWhiteSpace(txtdestination.Text) == true)
                {
                    MessageBox.Show("Destination must not be set as Null or WhiteSpace, Please try Again!", "Null | WhiteSpace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrWhiteSpace(txtcost.Text) == true)
                {
                    MessageBox.Show("cost must not be set as Null or WhiteSpace, Please try Again!", "Null | WhiteSpace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(String.IsNullOrEmpty(spotProfile) == true)
                {
                    MessageBox.Show("Image File not Found!", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(String.IsNullOrWhiteSpace(txtdescription.Text) == true)
                {
                    MessageBox.Show("Description must not be set as Null or WhiteSpace, Please try Again!", "Null | WhiteSpace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(String.IsNullOrEmpty(spotCategory) == true)
                {
                    MessageBox.Show("You must choose a particular category for this Attraction, Please try Again!", "Null | Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!(Double.TryParse(txtcost.Text, out Double sample)))
                    {
                        MessageBox.Show("Cost Input is not a Curreny-Type value, Please try Again!", "Currency Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            double money = Convert.ToDouble(txtcost.Text);
                            double convertedMoney = Convert.ToDouble(String.Format("{0:00.00}", money));

                            Connection.Connection.DB();
                            Function.Function.gen = "INSERT INTO Attractions(touristAttraction, touristDestination, attractionImage, attractionCost, attractionDescription, attractionCategory) VALUES('"+txtattraction.Text+"',  '"+txtdestination.Text+"',  '"+spotProfile+"',  '"+convertedMoney+"',  '"+txtdescription.Text+"', '"+spotCategory+"') ";
                            Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                            Function.Function.command.ExecuteNonQuery();

                            try
                            {
                                File.Copy(imageFile, Path.Combine(Path.GetDirectoryName(Application.ExecutablePath) +"\\Attractions", spotProfile));
                            }
                            catch (Exception ex)
                            {
                                //Do Nothing
                            }

                            Admin.Spots spots = new Admin.Spots();
                            this.Visible = false;
                            spots.Show();

                            MessageBox.Show("Tourist Spot Added Successfully!", "Cebu Tourist Spot", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Connection.Connection.conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                attractionIdUpdate = AdminViewSpotsUserControl.attractionIdUpdate;

                if (AdminViewSpotsUserControl.change == true)
                {
                    //to set the current image as default
                    imageFile = AdminViewSpotsUserControl.attractionImageUpdate;
                    
                }
                else
                {   
                    //to be able to change the fileimage
                    imageFile = fileImage;
                }

                var file = Path.GetFileName(imageFile);
                spotProfile = file;

                if (String.IsNullOrWhiteSpace(txtattraction.Text) == true)
                {
                    MessageBox.Show("Tourist Attraction must not be set as Null or WhiteSpace, Please try Again!", "Null | WhiteSpace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrWhiteSpace(txtdestination.Text) == true)
                {
                    MessageBox.Show("Destination must not be set as Null or WhiteSpace, Please try Again!", "Null | WhiteSpace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrWhiteSpace(txtcost.Text) == true)
                {
                    MessageBox.Show("cost must not be set as Null or WhiteSpace, Please try Again!", "Null | WhiteSpace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrEmpty(spotProfile) == true)
                {
                    MessageBox.Show("Image File not Found!", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrWhiteSpace(txtdescription.Text) == true)
                {
                    MessageBox.Show("Description must not be set as Null or WhiteSpace, Please try Again!", "Null | WhiteSpace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!(Double.TryParse(txtcost.Text, out Double sample)))
                    {
                        MessageBox.Show("Cost Input is not a Curreny-Type value, Please try Again!", "Currency Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            double money = Convert.ToDouble(txtcost.Text);
                            double convertedMoney = Convert.ToDouble(String.Format("{0:00.00}", money));

                            Connection.Connection.DB();
                            Function.Function.gen = "UPDATE Attractions SET touristAttraction = '"+txtattraction.Text+"', touristDestination = '"+txtdestination.Text+"', attractionImage = '"+spotProfile+"', attractionCost = '"+txtcost.Text+"', attractionDescription = '"+txtdescription.Text+"' WHERE attractionid = '"+attractionIdUpdate+"' ";
                            Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                            Function.Function.command.ExecuteNonQuery();

                            try
                            {
                                File.Copy(imageFile, Path.Combine(Path.GetDirectoryName(Application.ExecutablePath) + "\\Attractions", spotProfile));
                            }
                            catch (Exception ex)
                            {
                                //Do Nothing
                            }

                            Admin.Spots spots = new Admin.Spots();
                            this.Visible = false;
                            spots.Show();

                            MessageBox.Show("Tourist Spot Updated Successfully!", "Cebu Tourist Spot Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Connection.Connection.conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtdescription_TextChanged(object sender, EventArgs e)
        {
            txtdescription.MaxLength = 35;
        }

        private void GenerateSpotsNorthern()
        {
            flowLayoutPanelSpotsNorthern.Controls.Clear();

            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "SELECT COUNT(*) FROM Attractions WHERE attractionCategory = 'Northern' ";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                Function.Function.reader = Function.Function.command.ExecuteReader();

                if (Function.Function.reader.HasRows)
                {
                    Function.Function.reader.Read();

                    string count = Function.Function.reader.GetValue(0).ToString();
                    attractionCount = Convert.ToInt32(count);

                    AdminViewSpotsUserControl[] adminViewSpotsUserControl = new AdminViewSpotsUserControl[attractionCount];

                    try
                    {
                        Connection.Connection.DB();
                        Function.Function.gen = "SELECT * FROM Attractions WHERE attractionCategory = 'Northern' ";
                        Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                        Function.Function.reader = Function.Function.command.ExecuteReader();

                        if (Function.Function.reader.HasRows)
                        {
                            for (int i = 0; i < adminViewSpotsUserControl.Length; i++)
                            {
                                Function.Function.reader.Read();

                                attractionId[i] = Function.Function.reader.GetValue(0).ToString();
                                touristAttraction[i] = Function.Function.reader.GetValue(1).ToString();
                                touristDestination[i] = Function.Function.reader.GetValue(2).ToString();
                                attractionImage[i] = Function.Function.reader.GetValue(3).ToString();
                                attractionCost[i] = Function.Function.reader.GetValue(4).ToString();
                                attractionDescription[i] = Function.Function.reader.GetValue(5).ToString();


                                //Initialize
                                adminViewSpotsUserControl[i] = new AdminViewSpotsUserControl();

                                //Adding Data
                                adminViewSpotsUserControl[i].attractionId = attractionId[i];
                                adminViewSpotsUserControl[i].touristAttraction = touristAttraction[i];
                                adminViewSpotsUserControl[i].touristDestination = touristDestination[i];
                                adminViewSpotsUserControl[i].attractionImage = attractionImage[i];
                                adminViewSpotsUserControl[i].attractionCost = attractionCost[i];
                                adminViewSpotsUserControl[i].attractionDescription = attractionDescription[i];

                                flowLayoutPanelSpotsNorthern.Controls.Add(adminViewSpotsUserControl[i]);
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

        private void GenerateSpotsSouthern()
        {
            flowLayoutPanelSpotsSouthern.Controls.Clear();

            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "SELECT COUNT(*) FROM Attractions WHERE attractionCategory = 'Southern' ";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                Function.Function.reader = Function.Function.command.ExecuteReader();

                if (Function.Function.reader.HasRows)
                {
                    Function.Function.reader.Read();

                    string count = Function.Function.reader.GetValue(0).ToString();
                    attractionCount = Convert.ToInt32(count);

                    AdminViewSpotsUserControl[] adminViewSpotsUserControl = new AdminViewSpotsUserControl[attractionCount];

                    try
                    {
                        Connection.Connection.DB();
                        Function.Function.gen = "SELECT * FROM Attractions WHERE attractionCategory = 'Southern' ";
                        Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                        Function.Function.reader = Function.Function.command.ExecuteReader();

                        if (Function.Function.reader.HasRows)
                        {
                            for (int i = 0; i < adminViewSpotsUserControl.Length; i++)
                            {
                                Function.Function.reader.Read();

                                attractionId[i] = Function.Function.reader.GetValue(0).ToString();
                                touristAttraction[i] = Function.Function.reader.GetValue(1).ToString();
                                touristDestination[i] = Function.Function.reader.GetValue(2).ToString();
                                attractionImage[i] = Function.Function.reader.GetValue(3).ToString();
                                attractionCost[i] = Function.Function.reader.GetValue(4).ToString();
                                attractionDescription[i] = Function.Function.reader.GetValue(5).ToString();


                                //Initialize
                                adminViewSpotsUserControl[i] = new AdminViewSpotsUserControl();

                                //Adding Data
                                adminViewSpotsUserControl[i].attractionId = attractionId[i];
                                adminViewSpotsUserControl[i].touristAttraction = touristAttraction[i];
                                adminViewSpotsUserControl[i].touristDestination = touristDestination[i];
                                adminViewSpotsUserControl[i].attractionImage = attractionImage[i];
                                adminViewSpotsUserControl[i].attractionCost = attractionCost[i];
                                adminViewSpotsUserControl[i].attractionDescription = attractionDescription[i];

                                flowLayoutPanelSpotsSouthern.Controls.Add(adminViewSpotsUserControl[i]);
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

        public void ClickUpdate()
        {

            tabControl1.SelectedIndex = 1;

            txtattraction.Text = AdminViewSpotsUserControl.touristAttractionUpdate;
            txtdestination.Text = AdminViewSpotsUserControl.touristDestinationUpdate;
            txtcost.Text = AdminViewSpotsUserControl.attractionCostUpdate;
            txtdescription.Text = AdminViewSpotsUserControl.attractionDescriptionUpdate;

            var image = Path.GetDirectoryName(Application.ExecutablePath) + "\\Attractions\\" + AdminViewSpotsUserControl.attractionImageUpdate;
            pbimage.Image = Image.FromFile(image);

            btnsave.Enabled = false;
            btnupdate.Enabled = true;
        }

        private void rdbSouthern_Click(object sender, EventArgs e)
        {
            spotCategory = "Southern";
        }

        private void rdbNorthern_Click(object sender, EventArgs e)
        {
            spotCategory = "Northern";
        }

        private void pbnorthern_Click(object sender, EventArgs e)
        {
            lblnorthern.Visible = true;

            pbnorthern.Visible = false;
            lblnorth.Visible = false;

            //hide other pb and its label
            pbsouthern.Visible = false;
            lblsouth.Visible = false;

            flowLayoutPanelSpotsNorthern.Visible = true;

            btnnorthern.Visible = true;
        }

        private void pbsouthern_Click(object sender, EventArgs e)
        {
            lblsouthern.Visible = true;

            pbsouthern.Visible = false;
            lblsouth.Visible = false;

            //hide other pb and its label
            pbnorthern.Visible = false;
            lblnorth.Visible = false;

            flowLayoutPanelSpotsSouthern.Visible = true;

            btnsouthern.Visible = true;
        }

        private void btnnorthern_Click(object sender, EventArgs e)
        {
            lblnorthern.Visible = false;

            pbnorthern.Visible = true;
            lblnorth.Visible = true;

            //show other pb and its label
            pbsouthern.Visible = true;
            lblsouth.Visible = true;

            flowLayoutPanelSpotsNorthern.Visible = false;

            btnnorthern.Visible = false;
        }

        private void btnsouthern_Click(object sender, EventArgs e)
        {
            lblsouthern.Visible = false;

            pbsouthern.Visible = true;
            lblsouth.Visible = true;

            //hide other pb and its label
            pbnorthern.Visible = true;
            lblnorth.Visible = true;

            flowLayoutPanelSpotsSouthern.Visible = false;

            btnsouthern.Visible = false;
        }
    }
}
