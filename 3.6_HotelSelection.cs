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
    public partial class HotelSelection : Form
    {
        string _userID;
        public HotelSelection(string userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void HotelSelection_Load(object sender, EventArgs e)
        {
        }

        //Redirects user back to Representative Main Menu page - 3.3
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new RepresentativeMain(_userID)).ShowDialog();
            this.Close();
        }

        //Pop-up of Pan Pacific Hotel Booking in Book Hotel page - 3.7
        private void button2_Click_1(object sender, EventArgs e)
        {
            (new Book_Hotel(_userID, 2)).Show();
        }

        //Pop-up of Ritz-Carlton Hotel Booking in Book Hotel page - 3.7
        private void button1_Click_1(object sender, EventArgs e)
        {
            (new Book_Hotel(_userID, 1)).Show();
        }

        //Pop-up of Charlton Hotel Booking in Book Hotel page - 3.7
        private void button3_Click(object sender, EventArgs e)
        {
            (new Book_Hotel(_userID, 3)).Show();
        }

        //Pop-up of Intercontinental Singapore Hotel Booking in Book Hotel page - 3.7
        private void button4_Click(object sender, EventArgs e)
        {
            (new Book_Hotel(_userID, 4)).Show();
        }

        //Pop-up of Hotel Grand Pacific Hotel Booking in Book Hotel page - 3.7
        private void button5_Click(object sender, EventArgs e)
        {
            (new Book_Hotel(_userID, 5)).Show();
        }

        //Pop-up of Hotel Royal Queens Hotel Booking in Book Hotel page - 3.7
        private void button6_Click(object sender, EventArgs e)
        {
            (new Book_Hotel(_userID, 6)).Show();;
        }
    }
}
