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

namespace YouTuDe
{
    public partial class AdminViewSpotsUserControl : UserControl
    {
        public static bool change = false;

        public string attractionId;
        public string touristAttraction;
        public string touristDestination;
        public string attractionImage;
        public string attractionCost;
        public string attractionDescription;

        public static string attractionIdUpdate;
        public static string touristAttractionUpdate;
        public static string touristDestinationUpdate;
        public static string attractionImageUpdate;
        public static string attractionCostUpdate;
        public static string attractionDescriptionUpdate;

        public AdminViewSpotsUserControl()
        {
            InitializeComponent();
        }

        private void AdminViewSpotsUserControl_Load(object sender, EventArgs e)
        {
            lblattraction.Text = touristAttraction;
            lbldestination.Text = touristDestination;
            lblcost.Text = attractionCost;
            lbldescription.Text = attractionDescription;

            DisplayProfile();
        }

        private void DisplayProfile()
        {
            try
            {
                var image = Path.GetDirectoryName(Application.ExecutablePath) + "\\Attractions\\" + attractionImage;
                pbprofile.Image = Image.FromFile(image);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        //For pulling the Data
        attractionIdUpdate = attractionId;
        touristAttractionUpdate = lblattraction.Text;
        touristDestinationUpdate = touristDestination;
        attractionImageUpdate = attractionImage;
        attractionCostUpdate = attractionCost;
        attractionDescriptionUpdate = attractionDescription;

        change = true;

            Admin.Spots spots = new Admin.Spots();
                spots.ClickUpdate();
                spots.Show();

            //To avoid form Duplication
            Form form = this.FindForm();
            form.Close();
            form.Dispose();

        }

        private void linkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string text = "Do you wish to remove this Tourist Attraction in the List?";
            string caption = "DELETE";
            DialogResult result = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Connection.Connection.DB();
                    Function.Function.gen = "DELETE FROM Attractions WHERE attractionid = '" + attractionId + "' ";
                    Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                    Function.Function.command.ExecuteNonQuery();

                    MessageBox.Show("Tourist Attraction Deleted Successfully!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Visible = false;

                    Connection.Connection.conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
