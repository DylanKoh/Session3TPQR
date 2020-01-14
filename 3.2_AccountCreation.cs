using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session3
{
    public partial class AccountCreation : Form
    {
        public AccountCreation()
        {
            InitializeComponent();
        }

        private void AccountCreation_Load(object sender, EventArgs e)
        {
            HashSet<string> country = new HashSet<string>()
            {
                "Brunei", "Cambodia", "Indonesia", "Laos", "Malaysia", "Myanmar", "Philippines", "Singapore", "Thailand", "Vietnam"
            };
            countryBox.Items.AddRange(country.ToArray());
            using (var context = new Session3Entities())
            {
                var getCountry = (from x in context.Users
                                  where x.userTypeIdFK == 2
                                  select x.countryName);
                foreach (var item in getCountry)
                {
                    countryBox.Items.Remove(item);
                }
            }
            
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Login()).ShowDialog();
            this.Close();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            using (var context =  new Session3Entities())
            {
                var getPossibleAccount = (from x in context.Users
                                          where x.countryName == countryBox.SelectedItem.ToString()
                                          select x).FirstOrDefault();
                if (getPossibleAccount != null)
                {
                    MessageBox.Show("Your Country already has an account!", "Unable to create account",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var checkForSame = (from x in context.Users
                                        where x.userId == userIDBox.Text
                                        select x).FirstOrDefault();

                    Regex regex = new Regex(@"[A-Z]{1,}[a-z]{1,}[0-9]{1,}");
                    if (!regex.Match(userIDBox.Text).Success)
                    {
                        MessageBox.Show("User ID must be at least 8 characters long, containing 1 upper and lower case with at least 1 number!",
                            "Invalid User ID",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (userIDBox.Text.Length < 8)
                    {
                        MessageBox.Show("User ID must be at least 8 characters long!",
                            "Invalid User ID",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (checkForSame != null)
                    {
                        MessageBox.Show("User ID has been used!", "Invalid User ID",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (passwordBox.Text.Trim() == "")
                    {
                        MessageBox.Show("Password is empty!!", "Empty Password",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (passwordBox.Text != rePasswordBox.Text)
                    {
                        MessageBox.Show("Passwords do not match!", "Mismatched Passwords",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var dl = MessageBox.Show("Are you sure you want to create an account?", "Create Account",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (DialogResult.Yes == dl)
                        {
                            context.Users.Add(new User()
                            {
                                countryName = countryBox.SelectedItem.ToString(),
                                passwd = passwordBox.Text,
                                userId = userIDBox.Text,
                                userTypeIdFK = 2
                            });
                            context.SaveChanges();
                            this.Hide();
                            (new Login()).ShowDialog();
                            this.Hide();
                        }
                    }
                 
                }
                
            }
           
            
        }
    }
}
