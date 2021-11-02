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

            GenerateSelected();
        }

        public void GenerateSelected()
        {
            flowLayoutPanelSelected.Controls.Clear();

            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "SELECT COUNT(*) FROM attractionSelectedClient WHERE attractionSelectedClient.userid = '" + userid + "' ";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                Function.Function.reader = Function.Function.command.ExecuteReader();

                if (Function.Function.reader.HasRows)
                {
                    Function.Function.reader.Read();

                    string count = Function.Function.reader.GetValue(0).ToString();
                    attractionSelectedCount = Convert.ToInt32(count);
                    
                    SelectedUserControl[] selectedUserControl = new SelectedUserControl[attractionSelectedCount];

                    try
                    {
                        Connection.Connection.DB();
                        Function.Function.gen = "SELECT * FROM attractionSelectedClient WHERE attractionSelectedClient.userid = '"+userid+"' AND attractionSelectedClient.containerid = '"+containerid+"' ";
                        Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                        Function.Function.reader = Function.Function.command.ExecuteReader();

                        if (Function.Function.reader.HasRows)
                        {
                            for (int i = 0; i < selectedUserControl.Length; i++)
                            {
                                Function.Function.reader.Read();


                                //Initialize
                                selectedUserControl[i] = new SelectedUserControl();

                                //Adding Data


                                flowLayoutPanelSelected.Controls.Add(selectedUserControl[i]);
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
    }
}
