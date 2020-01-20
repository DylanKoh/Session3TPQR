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
    public partial class HotelSummary : Form
    {
        public HotelSummary()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new AdminMain()).ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Gets the rooms booked for the Hotel Royal Queens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntHotelRoyalQueens_Click(object sender, EventArgs e)
        {
            lblHotelName.Text = "Hotal Name: ";
            dataGridView1.Rows.Clear();
            GridRefresh();
            using (var context = new Session3Entities())
            {
                var getHotel = (from x in context.Hotels
                                where x.hotelName == "Hotel Royal Queens"
                                join y in context.Hotel_Booking on x.hotelId equals y.hotelIdFK
                                select y);
                foreach (var item in getHotel)
                {
                    var rows = new List<string>()
                    {
                        item.User.countryName, item.numSingleRoomsRequired.ToString(), item.numDoubleRoomsRequired.ToString()
                    };
                    dataGridView1.Rows.Add(rows.ToArray());
                }
                lblHotelName.Text += "Hotel Royal Queens";
            }
        }

        /// <summary>
        /// Initialise the columns
        /// </summary>
        private void GridRefresh()
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Country";
            dataGridView1.Columns[1].Name = "No. of First Rooms Booked";
            dataGridView1.Columns[2].Name = "No. of Double Rooms Booked";
        }

        /// <summary>
        /// Gets the rooms booked for the Hotel Grand Pacific
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHotelGrandPacific_Click(object sender, EventArgs e)
        {
            lblHotelName.Text = "Hotal Name: ";
            dataGridView1.Rows.Clear();
            GridRefresh();
            using (var context = new Session3Entities())
            {
                var getHotel = (from x in context.Hotels
                                where x.hotelName == "Hotel Grand Pacific"
                                join y in context.Hotel_Booking on x.hotelId equals y.hotelIdFK
                                select y);
                foreach (var item in getHotel)
                {
                    var rows = new List<string>()
                    {
                        item.User.countryName, item.numSingleRoomsRequired.ToString(), item.numDoubleRoomsRequired.ToString()
                    };
                    dataGridView1.Rows.Add(rows.ToArray());
                }
                lblHotelName.Text += "Hotel Grand Pacific";
            }
        }

        /// <summary>
        /// Gets the rooms booked for the Intercontinental Singapore
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIntercontinentalSingapore_Click(object sender, EventArgs e)
        {
            lblHotelName.Text = "Hotal Name: ";
            dataGridView1.Rows.Clear();
            GridRefresh();
            using (var context = new Session3Entities())
            {
                var getHotel = (from x in context.Hotels
                                where x.hotelName == "Intercontinental Singapore"
                                join y in context.Hotel_Booking on x.hotelId equals y.hotelIdFK
                                select y);
                foreach (var item in getHotel)
                {
                    var rows = new List<string>()
                    {
                        item.User.countryName, item.numSingleRoomsRequired.ToString(), item.numDoubleRoomsRequired.ToString()
                    };
                    dataGridView1.Rows.Add(rows.ToArray());
                }
                lblHotelName.Text += "Intercontinental Singapore";
            }
        }

        /// <summary>
        /// Gets the rooms booked for the Carlton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCarlton_Click(object sender, EventArgs e)
        {
            lblHotelName.Text = "Hotal Name: ";
            dataGridView1.Rows.Clear();
            GridRefresh();
            using (var context = new Session3Entities())
            {
                var getHotel = (from x in context.Hotels
                                where x.hotelName == "Charlton Hotel"
                                join y in context.Hotel_Booking on x.hotelId equals y.hotelIdFK
                                select y);
                foreach (var item in getHotel)
                {
                    var rows = new List<string>()
                    {
                        item.User.countryName, item.numSingleRoomsRequired.ToString(), item.numDoubleRoomsRequired.ToString()
                    };
                    dataGridView1.Rows.Add(rows.ToArray());
                }
                lblHotelName.Text += "Charlton Hotel";
            }
        }

        /// <summary>
        /// Gets the rooms booked for the Pan Pacific Singapore
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPanPacificSingapore_Click(object sender, EventArgs e)
        {
            lblHotelName.Text = "Hotal Name: ";
            dataGridView1.Rows.Clear();
            GridRefresh();
            using (var context = new Session3Entities())
            {
                var getHotel = (from x in context.Hotels
                                where x.hotelName == "Pan Pacific Hotel"
                                join y in context.Hotel_Booking on x.hotelId equals y.hotelIdFK
                                select y);
                foreach (var item in getHotel)
                {
                    var rows = new List<string>()
                    {
                        item.User.countryName, item.numSingleRoomsRequired.ToString(), item.numDoubleRoomsRequired.ToString()
                    };
                    dataGridView1.Rows.Add(rows.ToArray());
                }
                lblHotelName.Text += "Pan Pacific Hotel";
            }
        }

        /// <summary>
        /// Gets the rooms booked for the Ritz-Carlton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRitzCarlton_Click(object sender, EventArgs e)
        {
            lblHotelName.Text = "Hotal Name: ";
            dataGridView1.Rows.Clear();
            GridRefresh();
            using (var context = new Session3Entities())
            {
                var getHotel = (from x in context.Hotels
                                where x.hotelName == "Ritz-Carlton"
                                join y in context.Hotel_Booking on x.hotelId equals y.hotelIdFK
                                select y);
                foreach (var item in getHotel)
                {
                    var rows = new List<string>()
                    {
                        item.User.countryName, item.numSingleRoomsRequired.ToString(), item.numDoubleRoomsRequired.ToString()
                    };
                    dataGridView1.Rows.Add(rows.ToArray());
                }
                lblHotelName.Text += "Ritz-Carlton";
            }
        }
    }
}
