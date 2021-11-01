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
    public partial class Spots : Form
    {
        public static bool state = false;

        //Variables for ViewSpots
        private int attractionCount;
        private string[] attractionId = new string[100];
        private string[] touristAttraction = new string[100];
        private string[] touristDestination = new string[100];
        private string[] attractionImage = new string[100];
        private string[] attractionCost = new string[100];
        private string[] attractionDescription = new string[100];

        private int id;

        private string profile;

        public static string totalUpdate;

        public static double totalSouthern;
        public static string attractidSouthern;
        public static string attractionSouthern;
        public static string totalSouthernString = totalSouthern.ToString();
        public static string destinationSouthern;
        public static string categorySouthern;

        public static double totalNorthern;
        public static string attractidNorthern;
        public static string attractionNorthern;
        public static string totalNorthernString = totalNorthern.ToString();
        public static string destinationNorthern;
        public static string categoryNorthern;

        //Reset Southern
        public static int resetCountSouthern = 0;
        public static double resetTotalSouthern = 0.00;
        public static string resetAttractSouthern = "";
        public static string resetSpotsSouthern = "";
        public static string resetDestinationSouthern = "";
        public static string resetCategorySouthern = "";

        //Reset Northern
        public static int resetCountNorthern = 0;
        public static double resetTotalNorthern = 0.00;
        public static string resetAttractNorthern = "";
        public static string resetSpotsNorthern = "";
        public static string resetDestinationNorthern = "";
        public static string resetCategoryNorthern = "";

        //for string count
        int count;
        string name;

        //for container
        public static string containeridNorthern;
        public static string containeridSouthern;

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

            ResetSouthern();
            ResetNorthern();
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
        public static void ResetSouthern()
        {
            totalSouthern = resetCountSouthern;
            ClientViewSpotsSouthernUserControl.spotsCount = resetCountSouthern;
            attractidSouthern = resetAttractSouthern;
            attractionSouthern = resetSpotsSouthern;
            destinationSouthern = resetDestinationSouthern;
            categorySouthern = resetCategorySouthern;
        }

        public static void ResetNorthern()
        {
            totalNorthern = resetCountNorthern;
            ClientViewSpotsNorthernUserControl.spotsCount = resetCountNorthern;
            attractidNorthern = resetAttractNorthern;
            attractionNorthern = resetSpotsNorthern;
            destinationNorthern = resetDestinationNorthern;
            categoryNorthern = resetCategoryNorthern;
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

                    ClientViewSpotsNorthernUserControl[] clientViewSpotsUserControl = new ClientViewSpotsNorthernUserControl[attractionCount];

                    try
                    {
                        Connection.Connection.DB();
                        Function.Function.gen = "SELECT * FROM Attractions WHERE attractionCategory = 'Northern' ";
                        Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                        Function.Function.reader = Function.Function.command.ExecuteReader();

                        if (Function.Function.reader.HasRows)
                        {
                            for (int i = 0; i < clientViewSpotsUserControl.Length; i++)
                            {
                                Function.Function.reader.Read();

                                attractionId[i] = Function.Function.reader.GetValue(0).ToString();
                                touristAttraction[i] = Function.Function.reader.GetValue(1).ToString();
                                touristDestination[i] = Function.Function.reader.GetValue(2).ToString();
                                attractionImage[i] = Function.Function.reader.GetValue(3).ToString();
                                attractionCost[i] = Function.Function.reader.GetValue(4).ToString();
                                attractionDescription[i] = Function.Function.reader.GetValue(5).ToString();

                                //Initialize
                                clientViewSpotsUserControl[i] = new ClientViewSpotsNorthernUserControl();

                                //Adding Data
                                clientViewSpotsUserControl[i].attractionId = attractionId[i];
                                clientViewSpotsUserControl[i].touristAttraction = touristAttraction[i];
                                clientViewSpotsUserControl[i].touristDestination = touristDestination[i];
                                clientViewSpotsUserControl[i].attractionImage = attractionImage[i];
                                clientViewSpotsUserControl[i].attractionCost = attractionCost[i];
                                clientViewSpotsUserControl[i].attractionDescription = attractionDescription[i];

                                flowLayoutPanelSpotsNorthern.Controls.Add(clientViewSpotsUserControl[i]);
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

                    ClientViewSpotsSouthernUserControl[] clientViewSpotsUserControl = new ClientViewSpotsSouthernUserControl[attractionCount];

                    try
                    {
                        Connection.Connection.DB();
                        Function.Function.gen = "SELECT * FROM Attractions WHERE attractionCategory = 'Southern' ";
                        Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                        Function.Function.reader = Function.Function.command.ExecuteReader();

                        if (Function.Function.reader.HasRows)
                        {
                            for (int i = 0; i < clientViewSpotsUserControl.Length; i++)
                            {
                                Function.Function.reader.Read();

                                attractionId[i] = Function.Function.reader.GetValue(0).ToString();
                                touristAttraction[i] = Function.Function.reader.GetValue(1).ToString();
                                touristDestination[i] = Function.Function.reader.GetValue(2).ToString();
                                attractionImage[i] = Function.Function.reader.GetValue(3).ToString();
                                attractionCost[i] = Function.Function.reader.GetValue(4).ToString();
                                attractionDescription[i] = Function.Function.reader.GetValue(5).ToString();

                                //Initialize
                                clientViewSpotsUserControl[i] = new ClientViewSpotsSouthernUserControl();

                                //Adding Data
                                clientViewSpotsUserControl[i].attractionId = attractionId[i];
                                clientViewSpotsUserControl[i].touristAttraction = touristAttraction[i];
                                clientViewSpotsUserControl[i].touristDestination = touristDestination[i];
                                clientViewSpotsUserControl[i].attractionImage = attractionImage[i];
                                clientViewSpotsUserControl[i].attractionCost = attractionCost[i];
                                clientViewSpotsUserControl[i].attractionDescription = attractionDescription[i];

                                flowLayoutPanelSpotsSouthern.Controls.Add(clientViewSpotsUserControl[i]);
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

        private void pbsouthern_Click(object sender, EventArgs e)
        {
            btnsouthern.Visible = true;
            btnsavesouthern.Visible = true;
            btnchecksouthern.Visible = true;

            flowLayoutPanelSpotsSouthern.Visible = true;

            lblsouth.Visible = false;
            pbsouthern.Visible = false;

            //hide other pb and its label
            lblnorth.Visible = false;
            pbnorthern.Visible = false;

            lblsouthern.Visible = true;
        }

        private void pbnorthern_Click(object sender, EventArgs e)
        {
            btnnorthern.Visible = true;
            btnsavenorthern.Visible = true;
            btnchecknorthern.Visible = true;

            flowLayoutPanelSpotsNorthern.Visible = true;

            lblnorth.Visible = false;
            pbnorthern.Visible = false;

            //hide other pb and its label
            lblsouth.Visible = false;
            pbsouthern.Visible = false;

            lblnorthern.Visible = true;
        }

        private void btnsouthern_Click(object sender, EventArgs e)
        {
            Client.Spots spots = new Client.Spots();
            this.Visible = false;
            spots.Show();

            btnsouthern.Visible = false;
            btnsavesouthern.Visible = false;
            btnchecksouthern.Visible = false;

            flowLayoutPanelSpotsSouthern.Visible = false;

            lblsouth.Visible = true;
            pbsouthern.Visible = true;

            //show other pb and its label
            lblnorth.Visible = true;
            pbnorthern.Visible = true;

            lblsouthern.Visible = false;
        }

        private void btnnorthern_Click(object sender, EventArgs e)
        {
            Client.Spots spots = new Client.Spots();
            this.Visible = false;
            spots.Show();

            btnnorthern.Visible = false;
            btnsavenorthern.Visible = false;
            btnchecknorthern.Visible = false;

            flowLayoutPanelSpotsNorthern.Visible = false;

            lblnorth.Visible = true;
            pbnorthern.Visible = true;

            //hide other pb and its label
            lblsouth.Visible = true;
            pbsouthern.Visible = true;

            lblnorthern.Visible = false;
        }

        private void btnchecksouthern_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ClientViewSpotsSouthernUserControl.result, "Southern Cebu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnchecknorthern_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ClientViewSpotsNorthernUserControl.result, "Northern Cebu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnsavesouthern_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "INSERT INTO selectedContainerClient(userid) VALUES('"+Login.userid+"')";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                Function.Function.command.ExecuteNonQuery();
                Connection.Connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "SELECT TOP 1 * FROM selectedContainerClient ORDER BY containerid DESC";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                Function.Function.reader = Function.Function.command.ExecuteReader();

                if (Function.Function.reader.HasRows)
                {
                    Function.Function.reader.Read();

                    containeridSouthern = Function.Function.reader.GetValue(0).ToString();

                    categorySouthern = "Southern";
                    for (int j = 0; j < ClientViewSpotsSouthernUserControl.attractions.Length; j++)
                    {
                        Console.WriteLine(ClientViewSpotsSouthernUserControl.attrid[j]);
                        Console.WriteLine(Login.userid);
                        Console.WriteLine(ClientViewSpotsSouthernUserControl.attractions[j]);
                        Console.WriteLine(ClientViewSpotsSouthernUserControl.cost[j]);
                        Console.WriteLine(ClientViewSpotsSouthernUserControl.desti[j]);
                        Console.WriteLine(categorySouthern);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsavenorthern_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "INSERT INTO selectedContainerClient(userid) VALUES('"+Login.userid+"')";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                Function.Function.command.ExecuteNonQuery();
                Connection.Connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "SELECT TOP 1 * FROM selectedContainerClient ORDER BY containerid DESC";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                Function.Function.reader = Function.Function.command.ExecuteReader();

                if (Function.Function.reader.HasRows)
                {
                    Function.Function.reader.Read();

                    containeridNorthern = Function.Function.reader.GetValue(0).ToString();

                    categoryNorthern = "Northern";
                    for (int j = 0; j < ClientViewSpotsNorthernUserControl.attractions.Length; j++)
                    {
                        Console.WriteLine(ClientViewSpotsNorthernUserControl.attrid[j]);
                        Console.WriteLine(Login.userid);
                        Console.WriteLine(ClientViewSpotsNorthernUserControl.attractions[j]);
                        Console.WriteLine(ClientViewSpotsNorthernUserControl.cost[j]);
                        Console.WriteLine(ClientViewSpotsNorthernUserControl.desti[j]);
                        Console.WriteLine(categoryNorthern);
                        Console.WriteLine(containeridNorthern);

                        Connection.Connection.DB();
                        Function.Function.gen = "INSERT INTO attractionSelectedClient(attractionid, userid, touristAttraction, touristDestination, attractionCost, containerid, attractionCategory) VALUES('"+ClientViewSpotsNorthernUserControl.attrid[j]+ "', '"+Login.userid+"', '"+ClientViewSpotsNorthernUserControl.attractions[j]+ "', '"+ClientViewSpotsNorthernUserControl.desti[j]+ "', '"+ClientViewSpotsNorthernUserControl.cost[j]+ "', '"+containeridNorthern+"', '"+categoryNorthern+ "')";
                        Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                        Function.Function.command.ExecuteNonQuery();
                        Connection.Connection.conn.Close();
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
