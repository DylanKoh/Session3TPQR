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
    public partial class Book_Hotel : Form
    {
        int _hotelID = 0;
        string _userID;
        public Book_Hotel(string userID, int hotelID)
        {
            InitializeComponent();
            _userID = userID;
            _hotelID = hotelID;
        }

        private void Book_Hotel_Load(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                var getHotelName = (from x in context.Hotels
                                    where x.hotelId == _hotelID
                                    select x.hotelName).First();
                var getHotelSingle = (from x in context.Hotels
                                      where x.hotelId == _hotelID
                                      select new { x }).First();
                var getHotelDouble = (from x in context.Hotels
                                      where x.hotelId == _hotelID
                                      select new { x }).First();
                hotelName.Text = getHotelName;
                var getArrival = (from x in context.Arrivals
                                  where x.userIdFK == _userID
                                  select x).FirstOrDefault();
                if (getArrival != null)
                {
                    delegatePax.Text = getArrival.numberDelegate.ToString();
                    competitorPax.Text = getArrival.numberCompetitors.ToString();
                }
                dataGridView1.ColumnCount = 5;
                dataGridView1.Columns[0].Name = "Room Type";
                dataGridView1.Columns[1].Name = "Room Rate per Night ($)";
                dataGridView1.Columns[2].Name = "Available No. of Rooms";
                dataGridView1.Columns[3].Name = "Rooms Required";
                dataGridView1.Columns[4].Name = "Sub-Total ($)";


                if (Int32.Parse(competitorPax.Text) % 2 == 0)
                {
                    List<string> row1 = new List<string>()
                    {
                        "Single", getHotelSingle.x.singleRate.ToString(), (getHotelSingle.x.numSingleRoomsTotal - getHotelSingle.x.numSingleRoomsBooked).ToString(),
                        delegatePax.Text.ToString(), (Int32.Parse(delegatePax.Text) * getHotelSingle.x.singleRate).ToString()

                    };
                    List<string> row2 = new List<string>()
                    {
                        "Double", getHotelDouble.x.doubleRate.ToString(), (getHotelDouble.x.numDoubleRoomsTotal - getHotelDouble.x.numSingleRoomsBooked).ToString(),
                    Convert.ToInt32(Int32.Parse(competitorPax.Text) / 2).ToString(), (Convert.ToInt32(Int32.Parse(competitorPax.Text) / 2) * getHotelDouble.x.doubleRate).ToString()
                    };

                    dataGridView1.Rows.Add(row1.ToArray());
                    dataGridView1.Rows.Add(row2.ToArray());
                }
                else
                {
                    List<string> row1 = new List<string>()
                    {
                        "Single", getHotelSingle.x.singleRate.ToString(), (getHotelSingle.x.numSingleRoomsTotal - getHotelSingle.x.numSingleRoomsBooked).ToString(),
                        (Int32.Parse(delegatePax.Text) + 1).ToString(), (Convert.ToInt32(Int32.Parse(competitorPax.Text)/2) * getHotelSingle.x.singleRate).ToString()
                    };
                    List<string> row2 = new List<string>()
                    {
                        "Double", getHotelDouble.x.doubleRate.ToString(), (getHotelDouble.x.numDoubleRoomsTotal - getHotelDouble.x.numSingleRoomsBooked).ToString(),
                    Convert.ToInt32(Int32.Parse(competitorPax.Text) / 2).ToString(), (Convert.ToInt32(Int32.Parse(competitorPax.Text) / 2) * getHotelDouble.x.doubleRate).ToString()
                    };
                    dataGridView1.Rows.Add(row1.ToArray());
                    dataGridView1.Rows.Add(row2.ToArray());
                }
                int total = 0;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    total += Convert.ToInt32(item.Cells[4].Value);
                }

                totalValue.Text += total.ToString();

            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                context.Hotel_Booking.Add(new Hotel_Booking()
                {
                    hotelIdFK = _hotelID,
                    numSingleRoomsRequired = Convert.ToInt32(dataGridView1.Rows[0].Cells[3].Value),
                    userIdFK = _userID,
                    numDoubleRoomsRequired = Convert.ToInt32(dataGridView1.Rows[1].Cells[3].Value)
                });
                var getUpdate = (from x in context.Hotels
                                 where x.hotelId == _hotelID
                                 select x).First();
                getUpdate.numDoubleRoomsBooked += Convert.ToInt32(dataGridView1.Rows[1].Cells[3].Value);
                getUpdate.numSingleRoomsBooked += Convert.ToInt32(dataGridView1.Rows[0].Cells[3].Value);
                context.SaveChanges();
                this.Hide();
                (new RepresentativeMain(_userID)).ShowDialog();
                this.Close();
            }
        }
    }
}
