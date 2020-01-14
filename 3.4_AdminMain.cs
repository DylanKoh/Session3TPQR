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
    public partial class AdminMain : Form
    {
        public AdminMain()
        {
            InitializeComponent();
        }

        private void AdminMain_Load(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Login()).ShowDialog();
            this.Close();

        }

        private void arrivalSummaryBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ArrivalSummary()).ShowDialog();
            this.Close();
        }

        private void hotelSummaryBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new HotelSummary()).ShowDialog();
            this.Close();
        }

        private void guestsSummaryBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new GuestSummary()).ShowDialog();
            this.Close();
        }
    }
}
