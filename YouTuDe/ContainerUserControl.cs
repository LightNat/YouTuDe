using System;
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
    public partial class ContainerUserControl : UserControl
    {
        private int attractionSelectedCount;
        private string[] attractionSelectedid = new string[100];
        private string[] attractionSelectedAttractionid = new string[100];
        private string[] attractionSelecteduserid = new string[100];
        private string[] attractionSelectedTouristAttraction = new string[100];
        private string[] attractionSelectedTouristDestination = new string[100];
        private string[] attractionSelectedAttractionCost = new string[100];
        private string[] attractionSelectedContainerid = new string[100];

        public string containerid;
        public string userid;
        public string firstname;
        public string lastname;
        public string userprofile;
        public string category;

        public static int limit = Client.Requests.containerCount;
        public static string[] ContainerId = new string[limit];

        public string counter;

        public ContainerUserControl()
        {
            InitializeComponent();
        }

        private void UserControlContainer_Load(object sender, EventArgs e)
        {
            lblcategory.Text = category;

            DataFIll();
        }

        public void DataFIll()
        {
            Function.Function.gen = "SELECT attractionSelectedClient.touristAttraction, attractionSelectedClient.touristDestination, attractionSelectedClient.attractionCost, attractionSelectedClient.selectedid, attractionSelectedClient.attractionid FROM attractionSelectedClient WHERE attractionSelectedClient.userid = '" + userid + "' AND attractionSelectedClient.containerid = '" + containerid + "' ";
            Function.Function.fill(Function.Function.gen, dataGridViewSelected);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(containerid);
            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                Function.Function.command.ExecuteNonQuery();
                Connection.Connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
