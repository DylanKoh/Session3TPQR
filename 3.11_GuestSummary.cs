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

        //Redirects user back to Admin Main Menu page - 3.4
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new AdminMain()).ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Onload, load initial pie chart with no filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuestSummary_Load(object sender, EventArgs e)
        {
            cbTypeGuest.SelectedItem = "No Filter";
            LoadGraph();
        }

        /// <summary>
        /// This method is responsible in filling points of Pie Chart based on filtered options
        /// </summary>
        private void LoadGraph()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            //Check if filter is on No Filter
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

            //Check if filter is on Delegates
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

            //Else get data based on filter of Competitors
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

        /// <summary>
        /// Every time selected filter changes, calls to reload Pie Chart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTypeGuest_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGraph();
        }
    }
}
