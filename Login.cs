using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                if (userIDBox.Text.Trim() == "" || passwordBox.Text.Trim() == "")
                {
                    MessageBox.Show("Please check your User ID or Password fields!", "Empty Fields",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else
                {
                    var getUser = (from x in context.Users
                                   where x.userId == userIDBox.Text
                                   select x).FirstOrDefault();
                    if (getUser == null)
                    {
                        MessageBox.Show("User does not exist!", "Invalid Credentials",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (passwordBox.Text != getUser.passwd)
                    {
                        MessageBox.Show("Password is incorrect!", "Invalid Credentials",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        var getUserType = (from x in context.User_Type
                                           where x.userTypeId == getUser.userTypeIdFK
                                           select x.userTypeName).FirstOrDefault();

                        if (getUserType == "Country Rep")
                        {
                            MessageBox.Show($"Welcome {getUser.countryName}!", "Successful Login",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            (new RepresentativeMain(getUser.userId)).ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show($"Welcome {getUser.countryName}!", "Successful Login",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            (new AdminMain()).ShowDialog();
                            this.Close();
                        }

                    }
                }
            }
        }

        private void createAccBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new AccountCreation()).ShowDialog();
            this.Close();
        }
    }
}
