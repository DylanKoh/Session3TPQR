using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                #region Onload, get all relevant details like name of hotel selected and Arrival details of user
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
                #endregion

                ///Populating the DGV for the recommended required rooms for number of attendees
                dataGridView1.ColumnCount = 5;
                dataGridView1.Columns[0].Name = "Room Type";
                dataGridView1.Columns[1].Name = "Room Rate per Night ($)";
                dataGridView1.Columns[2].Name = "Available No. of Rooms";
                dataGridView1.Columns[3].Name = "Rooms Required";
                dataGridView1.Columns[4].Name = "Sub-Total ($)";

                var checkArrival = (from x in context.Arrivals
                                    where x.userIdFK == _userID
                                    select x.arrivalDate).FirstOrDefault();

                ///Does the Sub-total calculation for 22nd July arrival if arrival date is 22 July
                if (checkArrival == DateTime.Parse("22 July"))
                {
                    //If number of competitor is divisible by 2, then add number of single rooms = number of delegates and number of double rooms = number of competitor / 2
                    if (Int32.Parse(competitorPax.Text) % 2 == 0)
                    {
                        List<string> row1 = new List<string>()
                        {
                            "Single", getHotelSingle.x.singleRate.ToString(), (getHotelSingle.x.numSingleRoomsTotal - getHotelSingle.x.numSingleRoomsBooked).ToString(),
                            delegatePax.Text.ToString(), (Int32.Parse(delegatePax.Text) * getHotelSingle.x.singleRate * 8).ToString()

                        };

                        List<string> row2 = new List<string>()
                        {
                            "Double", getHotelDouble.x.doubleRate.ToString(), (getHotelDouble.x.numDoubleRoomsTotal - getHotelDouble.x.numSingleRoomsBooked).ToString(),
                            Convert.ToInt32(Int32.Parse(competitorPax.Text) / 2).ToString(), (Convert.ToInt32(Int32.Parse(competitorPax.Text) / 2) * getHotelDouble.x.doubleRate * 8).ToString()
                        };

                        dataGridView1.Rows.Add(row1.ToArray());
                        dataGridView1.Rows.Add(row2.ToArray());
                    }

                    //If number of competitor is not divisible by 2, then add number of single rooms = number of delegates + 1 and number of double rooms = quotient number of competitor / 2
                    else
                    {
                        List<string> row1 = new List<string>()
                        {
                            "Single", getHotelSingle.x.singleRate.ToString(), (getHotelSingle.x.numSingleRoomsTotal - getHotelSingle.x.numSingleRoomsBooked).ToString(),
                            (Int32.Parse(delegatePax.Text) + 1).ToString(), (Convert.ToInt32(Int32.Parse(competitorPax.Text)/2) * getHotelSingle.x.singleRate * 8).ToString()
                        };

                        List<string> row2 = new List<string>()
                        {
                            "Double", getHotelDouble.x.doubleRate.ToString(), (getHotelDouble.x.numDoubleRoomsTotal - getHotelDouble.x.numSingleRoomsBooked).ToString(),
                            Convert.ToInt32(Int32.Parse(competitorPax.Text) / 2).ToString(), (Convert.ToInt32(Int32.Parse(competitorPax.Text) / 2) * getHotelDouble.x.doubleRate * 8).ToString()
                        };
                        dataGridView1.Rows.Add(row1.ToArray());
                        dataGridView1.Rows.Add(row2.ToArray());
                    }
                }

                ///Does the Sub-total calculation for 23rd July arrival if arrival date is 23 July
                else
                {
                    //If number of competitor is divisible by 2, then add number of single rooms = number of delegates and number of double rooms = number of competitor / 2
                    if (Int32.Parse(competitorPax.Text) % 2 == 0)
                    {
                        List<string> row1 = new List<string>()
                        {
                            "Single", getHotelSingle.x.singleRate.ToString(), (getHotelSingle.x.numSingleRoomsTotal - getHotelSingle.x.numSingleRoomsBooked).ToString(),
                            delegatePax.Text.ToString(), (Int32.Parse(delegatePax.Text) * getHotelSingle.x.singleRate * 7).ToString()

                        };

                        List<string> row2 = new List<string>()
                        {
                            "Double", getHotelDouble.x.doubleRate.ToString(), (getHotelDouble.x.numDoubleRoomsTotal - getHotelDouble.x.numSingleRoomsBooked).ToString(),
                             Convert.ToInt32(Int32.Parse(competitorPax.Text) / 2).ToString(), (Convert.ToInt32(Int32.Parse(competitorPax.Text) / 2) * getHotelDouble.x.doubleRate * 7).ToString()
                        };

                        dataGridView1.Rows.Add(row1.ToArray());
                        dataGridView1.Rows.Add(row2.ToArray());
                    }

                    //If number of competitor is not divisible by 2, then add number of single rooms = number of delegates + 1 and number of double rooms = quotient number of competitor / 2
                    else
                    {
                        List<string> row1 = new List<string>()
                        {
                            "Single", getHotelSingle.x.singleRate.ToString(), (getHotelSingle.x.numSingleRoomsTotal - getHotelSingle.x.numSingleRoomsBooked).ToString(),
                            (Int32.Parse(delegatePax.Text) + 1).ToString(), (Convert.ToInt32(Int32.Parse(competitorPax.Text)/2) * getHotelSingle.x.singleRate * 7).ToString()
                        };

                        List<string> row2 = new List<string>()
                        {
                            "Double", getHotelDouble.x.doubleRate.ToString(), (getHotelDouble.x.numDoubleRoomsTotal - getHotelDouble.x.numSingleRoomsBooked).ToString(),
                            Convert.ToInt32(Int32.Parse(competitorPax.Text) / 2).ToString(), (Convert.ToInt32(Int32.Parse(competitorPax.Text) / 2) * getHotelDouble.x.doubleRate * 7).ToString()
                        };
                        dataGridView1.Rows.Add(row1.ToArray());
                        dataGridView1.Rows.Add(row2.ToArray());
                    }
                }

                int total = 0;

                //Runs through each row and adds the sub-total together
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    total += Convert.ToInt32(item.Cells[4].Value);
                }

                totalValue.Text += total.ToString();

            }
        }

        //Closes this pop-out form and go back to the Hotel Selection page - 3.6
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Triggered when the Book button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bookBtn_Click(object sender, EventArgs e)
        {
            //Check if the two rows have any invalid entries like booking more than available rooms availble in the hotel
            if ((Convert.ToInt32(dataGridView1.Rows[0].Cells[3].Value) > Convert.ToInt32(dataGridView1.Rows[0].Cells[2].Value)) || (Convert.ToInt32(dataGridView1.Rows[1].Cells[3].Value) > Convert.ToInt32(dataGridView1.Rows[1].Cells[2].Value)))
            {
                MessageBox.Show("Unable to book more rooms than available rooms!", "Insufficient rooms",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (var context = new Session3Entities())
                {
                    var checkBooking = (from x in context.Hotel_Booking
                                        where x.userIdFK == _userID
                                        select x).ToList();
                    //If any instance of booking of hotel of the country exist, delete the previous booking details to prevent double booking
                    foreach (var item in checkBooking)
                    {
                        context.Hotel_Booking.Remove(item);
                        context.SaveChanges();
                    }

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
                    this.Close();
                }
            }
            
        }

        /// <summary>
        /// Upon change of value in cell, recalculate the sub-total by re-retrieving arrival date for calculation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            using (var context = new Session3Entities())
            {
                var total = 0;
                var checkArrival = (from x in context.Arrivals
                                    where x.userIdFK == _userID
                                    select x.arrivalDate).FirstOrDefault();
                if (checkArrival == DateTime.Parse("22 July"))
                {

                    totalValue.Text = "Total ($): ";
                    if (e.ColumnIndex == 3)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[4].Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value) * Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) * 8;
                        foreach (DataGridViewRow item in dataGridView1.Rows)
                        {
                            total += Convert.ToInt32(item.Cells[4].Value);
                        }
                        totalValue.Text += total.ToString();
                    }
                    
                }
                else
                {

                    totalValue.Text = "Total ($): ";
                    if (e.ColumnIndex == 3)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[4].Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value) * Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) * 7;
                        foreach (DataGridViewRow item in dataGridView1.Rows)
                        {
                            total += Convert.ToInt32(item.Cells[4].Value);
                        }
                        totalValue.Text += total.ToString();
                    }
                    
                }

            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
