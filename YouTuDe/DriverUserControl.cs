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

namespace YouTuDe
{
    public partial class DriverUserControl : UserControl
    {
        public string userid;
        public string firstname;
        public string lastname;
        public string age;
        public string license;
        public string number;
        public string Profile;
        public string Username;
        public string Password;
        public string Rolename;

        public DriverUserControl()
        {
            InitializeComponent();
        }

        private void DriverUserControl_Load(object sender, EventArgs e)
        {
            lblfullname.Text = firstname + " " + lastname;
            lblage.Text = age;
            lblphonenumber.Text = number;
            DisplayProfile();
        }

        private void DisplayProfile()
        {
            try
            {
                var image = Path.GetDirectoryName(Application.ExecutablePath) + "\\Profile\\" + Profile;
                pbprofile.Image = Image.FromFile(image);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
