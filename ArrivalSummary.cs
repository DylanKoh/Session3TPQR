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
    public partial class ArrivalSummary : Form
    {
        public ArrivalSummary()
        {
            InitializeComponent();
        }

        private void ArrivalSummary_Load(object sender, EventArgs e)
        {
            GridRefresh();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new AdminMain()).ShowDialog();
            this.Close();
        }
        private void GridRefresh()
        {
            using (var context = new Session3Entities())
            {
                #region Loading 22nd July List
                twentysecondList.ColumnCount = 8;
                twentysecondList.Columns[0].Name = "9am";
                twentysecondList.Columns[1].Name = "10am";
                twentysecondList.Columns[2].Name = "11am";
                twentysecondList.Columns[3].Name = "12pm";
                twentysecondList.Columns[4].Name = "1pm";
                twentysecondList.Columns[5].Name = "2pm";
                twentysecondList.Columns[6].Name = "3pm";
                twentysecondList.Columns[7].Name = "4pm";

                var date = DateTime.Parse("22 July");
                var grouping = (from x in context.Arrivals
                                where x.arrivalDate == date
                                group x by x.arrivalTime into q
                                select new { timing = q.Key,
                                Country = q.Select(x => x.User.countryName).FirstOrDefault(),
                                userID = q.Select(x => x.userIdFK).FirstOrDefault()});
                
                #endregion

                #region Loading 23rd July List
                twentythirdList.ColumnCount = 8;
                twentythirdList.Columns[0].Name = "9am";
                twentythirdList.Columns[1].Name = "10am";
                twentythirdList.Columns[2].Name = "11am";
                twentythirdList.Columns[3].Name = "12pm";
                twentythirdList.Columns[4].Name = "1pm";
                twentythirdList.Columns[5].Name = "2pm";
                twentythirdList.Columns[6].Name = "3pm";
                twentythirdList.Columns[7].Name = "4pm";
                #endregion
            }

        }
    }
}
