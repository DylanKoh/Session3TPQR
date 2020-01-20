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
    public partial class RepresentativeMain : Form
    {
        string _userID;
        public RepresentativeMain(string userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void RespresentativeMain_Load(object sender, EventArgs e)
        {

        }

        //Redirects user back to Login page - 3.1
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Login()).ShowDialog();
            this.Close();
        }

        //Redirects user to Confirm Arrival page - 3.5
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            

            this.Hide();
            (new confirmDetails(_userID)).ShowDialog();
            this.Close();

        }

        //Redirects user to Hotel Selection page - 3.6
        private void bookingBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                var checkBookings = (from x in context.Arrivals
                                     where x.userIdFK == _userID
                                     select x).FirstOrDefault();
                if (checkBookings != null)
                {
                    this.Hide();
                    (new HotelSelection(_userID)).ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please confirm your arrival details first!", "No details for arrival confrimed!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
        }

        //Redirects user to Update Info/Booking page - 3.8
        private void updateBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                var checkBookings = (from x in context.Hotel_Booking
                                     where x.userIdFK == _userID
                                     select x).FirstOrDefault();
                if (checkBookings != null)
                {
                    this.Hide();
                    (new Update(_userID)).ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You have not booked a hotel yet!", "No bookings detected",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
    }
}
