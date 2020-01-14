﻿using System;
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

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Login()).ShowDialog();
            this.Close();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new confirmDetails(_userID)).ShowDialog();
            this.Close();
        }

        private void bookingBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new HotelSelection(_userID)).ShowDialog();
            this.Close();
        }
    }
}
