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
    public partial class Pending : Form
    {

        private int id;

        private string profile;


        //for string count
        int count;
        string name;

        public Pending()
        {
            InitializeComponent();
        }

        private void Pending_Load(object sender, EventArgs e)
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
    }
}
