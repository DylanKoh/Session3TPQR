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
                twentysecondList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                twentythirdList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

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
                twentysecondList.ColumnHeadersVisible = false;
                var date = DateTime.Parse("22 July");
                var arrivingOn22 = (from x in context.Arrivals
                                    where x.arrivalDate == date
                                    select x.arrivalTime);
                var grouping22 = (from x in context.Arrivals
                                  where x.arrivalDate == date
                                  select x);

                //List for Cell row since only showing 1 row
                var list = new List<string>()
                {
                    "9am", "10am", "11am", "12pm", "1pm", "2pm", "3pm", "4pm"
                };
                twentysecondList.Rows.Add(list.ToArray());

                twentysecondList.Columns["10am"].DefaultCellStyle.BackColor = Color.Black;
                twentysecondList.Columns["1pm"].DefaultCellStyle.BackColor = Color.Black;
                twentysecondList.Columns["2pm"].DefaultCellStyle.BackColor = Color.Black;

                //If anyone arrives on the 22nd, adds Country name and vehicles provided to the cell based on the relevant timing
                foreach (var item in arrivingOn22)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(item);
                    foreach (var item2 in grouping22.Where(x => x.arrivalTime == item))
                    {
                        var total = item2.number19seat + item2.number42seat + item2.numberCars;
                        sb.Append($"\n\n{item2.User.countryName}\n({total} vehicles)");
                    }
                    twentysecondList.Rows[0].Cells[item].Value = sb.ToString();
                }
                

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
                twentythirdList.ColumnHeadersVisible = false;

                var date2 = DateTime.Parse("23 July");
                var arrivingOn23 = (from x in context.Arrivals
                                    where x.arrivalDate == date2
                                    select x.arrivalTime);
                var grouping23 = (from x in context.Arrivals
                                  where x.arrivalDate == date2
                                  select x);

                twentythirdList.Rows.Add(list.ToArray());

                //If anyone arrives on the 23rd, adds Country name and vehicles provided to the cell based on the relevant timing
                foreach (var item in arrivingOn23)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(item);
                    foreach (var item2 in grouping23.Where(x => x.arrivalTime == item))
                    {
                        var total = item2.number19seat + item2.number42seat + item2.numberCars;
                        sb.Append($"\n\n{item2.User.countryName}\n({total} vehicles)");
                    }
                    twentythirdList.Rows[0].Cells[item].Value = sb.ToString();
                }

                twentythirdList.Columns["9am"].DefaultCellStyle.BackColor = Color.Black;
                twentythirdList.Columns["12pm"].DefaultCellStyle.BackColor = Color.Black;
                twentythirdList.Columns["4pm"].DefaultCellStyle.BackColor = Color.Black;
                #endregion
            }

        }
    }
}
