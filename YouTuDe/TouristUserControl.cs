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
    public partial class TouristUserControl : UserControl
    {
        public string userid;
        public string Fullname;
        public string age;
        public string number;
        public string Profile;

        public TouristUserControl()
        {
            InitializeComponent();
        }

        private void TouristUserControl_Load(object sender, EventArgs e)
        {
            lbluserid.Text = userid;
            lblfullname.Text = Fullname;
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
