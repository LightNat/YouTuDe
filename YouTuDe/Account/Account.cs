using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace YouTuDe.Account
{
    public partial class Account : Form
    {
        private bool licenseOn = false;

        //for license
        private string licenseImage;

        private string imageFile;

        public static string profile;

        public static string rolename;

        public Account()
        {
            InitializeComponent();
        }

        private void Account_Load(object sender, EventArgs e)
        {

        }

        private void btnchoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;) | *.jpg; *.jpeg; *.gif; *.bmp;";

            if (open.ShowDialog() == DialogResult.OK)
            {
                imageFile = open.FileName;
                pbimage.Image = new Bitmap(imageFile);
            }
        }

        private void btnlicense_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;) | *.jpg; *.jpeg; *.gif; *.bmp;";

            if (open.ShowDialog() == DialogResult.OK)
            {
                licenseImage = open.FileName;
                lbllicense.Text = Path.GetFileName(licenseImage);
            }
        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                var file = Path.GetFileName(imageFile);
                profile = file;

                if (String.IsNullOrWhiteSpace(txtfirstname.Text) == true)
                {
                    MessageBox.Show("Firstname must not be set as Null or Whitespace", "Null | Whitespace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrWhiteSpace(txtlastname.Text) == true)
                {
                    MessageBox.Show("Lastname must not be set as Null or Whitespace", "Null | Whitespace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrWhiteSpace(txtage.Text) == true)
                {
                    MessageBox.Show("Age must not be set as Null or Whitespace", "Null | Whitespace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrEmpty(profile) == true)
                {
                    MessageBox.Show("Image File not Found!", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrWhiteSpace(txtusername.Text) == true)
                {
                    MessageBox.Show("Username must not be set as Null or Whitespace", "Null | Whitespace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrWhiteSpace(txtpassword.Text) == true)
                {
                    MessageBox.Show("Password must not be set as Null or Whitespace", "Null | Whitespace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrWhiteSpace(txtphonenumber.Text) == true)
                {
                    MessageBox.Show("Phone Number must not be set as Null or Whitespace", "Null | Whitespace", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(!(Int64.TryParse(txtphonenumber.Text, out long convertedNumber)))
                {
                    MessageBox.Show("Phone number must not be set as String", "String Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(!(Int64.TryParse(txtphonenumber.Text, out long convertedAge)))
                {
                    MessageBox.Show("Age must not be set as String", "String Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        if (rdbTourist.Checked == true)
                        {
                            rolename = "Tourist";
                            try
                            {
                                Connection.Connection.DB();
                                Function.Function.gen = "INSERT INTO users(firstname, lastname, age, profile, userNumber, username, password, rolename, userMoney) VALUES('"+txtfirstname.Text+"', '"+txtlastname.Text+"', '"+txtage.Text+"', '"+profile+"', ('+' + '"+txtphonenumber.Text+"'), '"+txtusername.Text+"', '"+txtpassword.Text+"', '"+rolename+"', '"+0.00+"') ";
                                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                                Function.Function.command.ExecuteNonQuery();

                                try
                                {
                                    File.Copy(imageFile, Path.Combine(Path.GetDirectoryName(Application.ExecutablePath) + "\\Profile", profile));
                                }
                                catch (Exception ex)
                                {
                                    //Do Nothing
                                }

                                Login login = new Login();
                                this.Visible = false;
                                login.Show();

                                MessageBox.Show("Account Successfully Saved!", "Account", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Connection.Connection.conn.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else if (rdbDriver.Checked == true)
                        {
                            rolename = "Driver";
                            if (licenseOn == true)
                            {
                                if (String.IsNullOrWhiteSpace(lbllicense.Text) == true)
                                {
                                    MessageBox.Show("Image File for License not Found!", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    try
                                    {
                                        Connection.Connection.DB();
                                        Function.Function.gen = "INSERT INTO pendingDriver(firstname, lastname, age, license, profile, userNumber, username, password, rolename) VALUES('" + txtfirstname.Text + "', '" + txtlastname.Text + "', '" + txtage.Text + "', '"+lbllicense.Text+"', '" + profile + "', ('+' + '" + txtphonenumber.Text + "'), '" + txtusername.Text + "', '" + txtpassword.Text + "', '" + rolename + "') ";
                                        Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.conn);
                                        Function.Function.command.ExecuteNonQuery();


                                        try
                                        {
                                            File.Copy(imageFile, Path.Combine(Path.GetDirectoryName(Application.ExecutablePath) + "\\Profile", profile));
                                        }
                                        catch (Exception ex)
                                        {
                                            //Do Nothing
                                        }

                                        try
                                        {
                                            File.Copy(licenseImage, Path.Combine(Path.GetDirectoryName(Application.ExecutablePath) + "\\License", lbllicense.Text));
                                        }
                                        catch (Exception ex)
                                        {
                                            //Do Nothing
                                        }

                                        Login login = new Login();
                                        this.Visible = false;
                                        login.Show();

                                        MessageBox.Show("Application Saved Successfully! \nPlease wait for Manager's Approval", "Account", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                        Connection.Connection.conn.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }

                               
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("User Type must not be set as Null or Empty", "Null | Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnback_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Visible = false;
            login.Show();
        }

        private void rdbDriver_CheckedChanged(object sender, EventArgs e)
        {
            btnlicense.Enabled = true;

            licenseOn = true;
        }

        private void rdbTourist_CheckedChanged(object sender, EventArgs e)
        {
            btnlicense.Enabled = false;
        }
    }
}
