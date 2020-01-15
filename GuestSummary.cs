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
    public partial class GuestSummary : Form
    {
        public GuestSummary()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new AdminMain()).ShowDialog();
            this.Close();
        }

        private void GuestSummary_Load(object sender, EventArgs e)
        {
            cbTypeGuest.SelectedItem = "No Filter";
            LoadGraph();
        }
        private void LoadGraph()
        {
            chart1.Series[0].Points.Clear();
            if (cbTypeGuest.SelectedItem.ToString() == "No Filter")
            {

            }
        }
    }
}
