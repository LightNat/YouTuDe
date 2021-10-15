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

namespace YouTuDe.Forgot
{
    public partial class Code : Form
    {
        public Code()
        {
            InitializeComponent();
        }

        private void Code_Load(object sender, EventArgs e)
        {

        }

        private void txtcode_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtcode.Text) == true)
            {
                btnproceed.Enabled = false;
            }
            else
            {
                if (!(Int32.TryParse(txtcode.Text, out int sample)))
                {
                    btnproceed.Enabled = false;
                }
                else
                {
                    btnproceed.Enabled = true;
                }
            }
        }

        private void btnproceed_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "SELECT * FROM users WHERE userid = '"+Id.userid+"' AND verCode = '"+txtcode.Text+"' ";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                Function.Function.reader = Function.Function.command.ExecuteReader();

                if (Function.Function.reader.HasRows)
                {
                    Function.Function.reader.Read();

                    Forgot.Password password = new Forgot.Password();
                    this.Visible = false;
                    password.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Security code, Please try Agian!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
