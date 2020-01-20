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
    public partial class Update : Form
    {
        string _userID;
        public Update(string userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void Update_Load(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                #region Populating fields of current booking
                var getBookings = (from x in context.Arrivals
                                   where x.userIdFK == _userID
                                   join y in context.Hotel_Booking on x.userIdFK equals y.userIdFK
                                   select new { x, y }).FirstOrDefault();
                numHeadOfDelegation.Value = getBookings.x.numberHead;
                txtDelegates.Text = getBookings.x.numberDelegate.ToString();
                txtCompetitors.Text = getBookings.x.numberCompetitors.ToString();
                #endregion
            }

            //Loads the DGV
            GridRefresh();
        }

        //Redirects user back to Representative Main Menu - 3.3
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new RepresentativeMain(_userID)).ShowDialog();
            this.Close();
        }

        /// <summary>
        /// This method is responsible for the loading of the DGV and the previously booked number of rooms of the hotels.
        /// New required rooms field and new sub-total will be 0 by default
        /// </summary>
        private void GridRefresh()
        {
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Room Type";
            dataGridView1.Columns[1].Name = "Room Rate per Night ($)";
            dataGridView1.Columns[2].Name = "Available Number of Rooms";
            dataGridView1.Columns[3].Name = "Rooms Booked";
            dataGridView1.Columns[4].Name = "New No. of Rooms Required";
            dataGridView1.Columns[5].Name = "New Sub-Total";
            using (var context = new Session3Entities())
            {
                var getBooking = (from x in context.Hotel_Booking
                                  where x.userIdFK == _userID
                                  join y in context.Hotels on x.hotelIdFK equals y.hotelId
                                  select new
                                  {
                                      singleRoomRate = y.singleRate,
                                      doubleRoomRate = y.doubleRate,
                                      singleBooked = x.numSingleRoomsRequired,
                                      doubleBooked = x.numDoubleRoomsRequired,
                                      availSingle = y.numSingleRoomsTotal - y.numSingleRoomsBooked,
                                      availDouble = y.numDoubleRoomsTotal - y.numDoubleRoomsBooked
                                  }).First();
                var row1 = new List<string>()
                {
                    "Single", getBooking.singleRoomRate.ToString(), getBooking.availSingle.ToString(), getBooking.singleBooked.ToString(),
                    "0", "0"
                };
                var row2 = new List<string>()
                {
                    "Double", getBooking.doubleRoomRate.ToString(), getBooking.availDouble.ToString(), getBooking.doubleBooked.ToString(),
                    "0", "0"
                };
                dataGridView1.Rows.Add(row1.ToArray());
                dataGridView1.Rows.Add(row2.ToArray());
            }
        }

        /// <summary>
        /// Triggered when value change is committed (Pressed enter)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Runs if only the change happens in the 5th Column of the DGV
            if (e.ColumnIndex == 4)
            {
                //Check if there are any overbooking of rooms based on available rooms of the room types of the hotel
                if(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) > Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value))
                {
                    MessageBox.Show("Unable to reserve more rooms than current availble rooms!", "Insufficient Rooms",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Empty;
                }
                else
                {
                    var total = 0;
                    lblTotal.Text = "Total($): ";
                    using (var context = new Session3Entities())
                    {
                        var getDate = (from x in context.Arrivals
                                       where x.userIdFK == _userID
                                       select x.arrivalDate).First();

                        //Calculation based on 22nd July arrival
                        if (getDate == DateTime.Parse("22 July"))
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[5].Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value) *
                                Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) * 8;
                            foreach (DataGridViewRow item in dataGridView1.Rows)
                            {
                                total += Convert.ToInt32(item.Cells[5].Value);
                            }
                            lblTotal.Text += total.ToString();
                        }

                        //Calculation based on 23rd July arrival
                        else
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[5].Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value) *
                                Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) * 7;
                            foreach (DataGridViewRow item in dataGridView1.Rows)
                            {
                                total += Convert.ToInt32(item.Cells[5].Value);
                            }
                            lblTotal.Text += total.ToString();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Triggered when Update button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(txtDelegates.Text) < 0 || Int32.Parse(txtCompetitors.Text) < 0)
            {
                MessageBox.Show("Number of competitors or delegates cannot be less than 0!",
                "Invalid number of attendees", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var dl = MessageBox.Show("Are you sure you want to update your info and bookings?",
                "Update details", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                ///If user click Yes response in MessageBox, run update to DB
                if (dl == DialogResult.Yes)
                {
                    var getComparisonSingle = Convert.ToInt32(dataGridView1.Rows[0].Cells[4].Value) - Convert.ToInt32(dataGridView1.Rows[0].Cells[3].Value);
                    var getComparisonDouble = Convert.ToInt32(dataGridView1.Rows[1].Cells[4].Value) - Convert.ToInt32(dataGridView1.Rows[1].Cells[3].Value);
                    using (var context = new Session3Entities())
                    {
                        var getDetails = (from x in context.Hotel_Booking
                                          where x.userIdFK == _userID
                                          join y in context.Hotels on x.hotelIdFK equals y.hotelId
                                          join z in context.Arrivals on x.userIdFK equals z.userIdFK
                                          select new { x, y, z }).First();
                        getDetails.x.numSingleRoomsRequired = Convert.ToInt32(dataGridView1.Rows[0].Cells[4].Value);
                        getDetails.x.numDoubleRoomsRequired = Convert.ToInt32(dataGridView1.Rows[1].Cells[4].Value);
                        getDetails.z.numberHead = Convert.ToInt32(numHeadOfDelegation.Value);
                        getDetails.z.numberDelegate = Int32.Parse(txtDelegates.Text);
                        getDetails.z.numberCompetitors = Int32.Parse(txtCompetitors.Text);
                        if (getComparisonSingle < 0)
                        {
                            getDetails.y.numSingleRoomsBooked += getComparisonSingle;
                            context.SaveChanges();
                        }
                        else
                        {
                            getDetails.y.numSingleRoomsBooked -= getComparisonSingle;
                            context.SaveChanges();
                        }
                        if (getComparisonDouble < 0)
                        {
                            getDetails.y.numDoubleRoomsBooked += getComparisonDouble;
                            context.SaveChanges();
                        }
                        else
                        {
                            getDetails.y.numDoubleRoomsBooked -= getComparisonDouble;
                            context.SaveChanges();
                        }
                        context.SaveChanges();
                        dataGridView1.Rows.Clear();
                        Update_Load(null, null);
                    }
                }
            }
            
        }

        /// <summary>
        /// Does a try catch so that it warns User to key in a valid integer and will not crash application when attempting to update details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDelegates_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var i = Int32.Parse(txtDelegates.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Please input a positive integer or 0!", "Invalid input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Does a try catch so that it warns User to key in a valid integer and will not crash application when attempting to update details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCompetitors_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var i = Int32.Parse(txtCompetitors.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Please input a positive integer or 0!", "Invalid input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
