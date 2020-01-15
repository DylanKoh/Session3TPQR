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
    public partial class GuestSummary : Form
    {
        public GuestSummary()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new AdminMain()).ShowDialog();
            this.Close();
        }

        private void GuestSummary_Load(object sender, EventArgs e)
        {
            cbTypeGuest.SelectedItem = "No Filter";
            LoadGraph();
        }
        private void LoadGraph()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            if (cbTypeGuest.SelectedItem.ToString() == "No Filter")
            {
                using (var context = new Session3Entities())
                {
                    
                    var getCountries = (from x in context.Users
                                        select x.countryName).Distinct();
                    foreach (var item in getCountries)
                    {
                        var getDetails = (from x in context.Arrivals
                                          where x.User.countryName == item
                                          select x).FirstOrDefault();
                        if (getDetails != null)
                        {
                            chart1.Series[0].Points.AddXY(item, getDetails.numberDelegate + getDetails.numberHead);
                            chart1.Series[1].Points.AddXY(item, getDetails.numberCompetitors);
                        }
                    }
                }
            }
            else if (cbTypeGuest.SelectedItem.ToString() == "Delegates")
            {
                using (var context = new Session3Entities())
                {

                    var getCountries = (from x in context.Users
                                        select x.countryName).Distinct();
                    foreach (var item in getCountries)
                    {
                        var getDetails = (from x in context.Arrivals
                                          where x.User.countryName == item
                                          select x).FirstOrDefault();
                        if (getDetails != null)
                        {
                            chart1.Series[0].Points.AddXY(item, getDetails.numberDelegate + getDetails.numberHead);
                        }
                    }
                }
            }
            else
            {
                using (var context = new Session3Entities())
                {

                    var getCountries = (from x in context.Users
                                        select x.countryName).Distinct();
                    foreach (var item in getCountries)
                    {
                        var getDetails = (from x in context.Arrivals
                                          where x.User.countryName == item
                                          select x).FirstOrDefault();
                        if (getDetails != null)
                        {
                            
                            chart1.Series[1].Points.AddXY(item, getDetails.numberCompetitors);
                        }
                    }
                }
            }
        }

        private void cbTypeGuest_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGraph();
        }
    }
}
