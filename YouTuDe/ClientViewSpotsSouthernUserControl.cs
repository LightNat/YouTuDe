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
    public partial class ClientViewSpotsSouthernUserControl : UserControl
    {
        public static bool state = false;

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

        public static double money;
        public static double convertedMoney;

        public static string total;
        public static string spots;
        public static string concatSpots;
        public static int spotsCount = 0;

        public static string result;


        public ClientViewSpotsSouthernUserControl()
        {
            InitializeComponent();
        }

        private void ClientViewSpotsUserControl_Load(object sender, EventArgs e)
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

        private void btnadd_Click(object sender, EventArgs e)
        {
            state = true;
            //For pulling the Data
            attractionIdUpdate = attractionId;
            touristAttractionUpdate = lblattraction.Text;
            touristDestinationUpdate = touristDestination;
            attractionImageUpdate = attractionImage;
            attractionCostUpdate = attractionCost;
            attractionDescriptionUpdate = attractionDescription;

            money = Convert.ToDouble(attractionCostUpdate);
            convertedMoney = Convert.ToDouble(String.Format("{0:00.00}", money));

            total = (Client.Spots.totalSouthern += convertedMoney).ToString();
            spotsCount++;
            
            //MessageBox.Show(""+spotsCount);

            concatSpots = (Client.Spots.attractionSouthern += (touristAttractionUpdate + ", "));
            spots = concatSpots.Substring(0, concatSpots.Length - 2);

            this.Visible = false;

            //MessageBox.Show(spots);
            //MessageBox.Show(""+total);

            result = "Spots Count: " + spotsCount.ToString() + "\n" + "Attractions: " + spots + "\n" + "Total Cost: Php " + total.ToString();
        }

    }
}
