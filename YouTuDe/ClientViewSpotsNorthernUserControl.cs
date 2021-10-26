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
    public partial class ClientViewSpotsNorthernUserControl : UserControl
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
        public static string moneyString;
        public static double convertedMoney;
        public static string concatMoney;
        public static string totalMoney;

        public static string total;
        public static string spots;
        public static string concatSpots;
        public static int spotsCount = 0;

        public static string result;

        public static string[] attractions = new string[100];
        public static string[] cost = new string[100];

        public static string[] sample = new string[]{"sample", "ko", "lang"};
        

        public ClientViewSpotsNorthernUserControl()
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
            moneyString = convertedMoney.ToString();

            total = (Client.Spots.totalNorthern += convertedMoney).ToString();
            totalMoney = (Client.Spots.totalNorthernString += moneyString + ",");
            concatMoney = totalMoney.Substring(0, totalMoney.Length - 1);

            spotsCount++;

            concatSpots = (Client.Spots.attractionNorthern += (touristAttractionUpdate + ","));
            spots = concatSpots.Substring(0, concatSpots.Length - 1);

            this.Visible = false;

            result = "Spots Count: "+spotsCount.ToString() + "\n" + "Attractions: "+spots + "\n" + "Total Cost: Php "+total.ToString();

            attractions = spots.Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries);
            cost = concatMoney.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

        }

    }
}
