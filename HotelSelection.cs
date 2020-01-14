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

        
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            (new Book_Hotel(_userID, 2)).ShowDialog();
            this.Close();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new RepresentativeMain(_userID)).ShowDialog();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            (new Book_Hotel(_userID, 1)).ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Book_Hotel(_userID, 3)).ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Book_Hotel(_userID, 4)).ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Book_Hotel(_userID, 5)).ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Book_Hotel(_userID, 6)).ShowDialog();
            this.Close();
        }
    }
}
