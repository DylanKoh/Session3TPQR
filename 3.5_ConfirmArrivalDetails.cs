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
    public partial class confirmDetails : Form
    {
        string _userID;
        public confirmDetails(string userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void confirmDetails_Load(object sender, EventArgs e)
        {

        }

        //Redirects user back to Representative Main Menu page - 3.3
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new RepresentativeMain(_userID)).ShowDialog();
            this.Close();
        }

        /// <summary>
        /// When 22nd July is selected, reload the DGV with relevant coloring of cells
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void twentysecondBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        /// <summary>
        /// This method is responsible for loading the relevant cells (Timings) of the DGV and coloring the invalid timings black
        /// </summary>
        private void GridRefresh()
        {
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "9am";
            dataGridView1.Columns[1].Name = "10am";
            dataGridView1.Columns[2].Name = "11am";
            dataGridView1.Columns[3].Name = "12pm";
            dataGridView1.Columns[4].Name = "1pm";
            dataGridView1.Columns[5].Name = "2pm";
            dataGridView1.Columns[6].Name = "3pm";
            dataGridView1.Columns[7].Name = "4pm";
            List<string> rows = new List<string>()
            {
                "9am", "10am", "11am",
                "12pm", "1pm", "2pm", "3pm", "4pm"
            };
            dataGridView1.Rows.Add(rows.ToArray());
            if (twentysecondBtn.Checked)
            {
                dataGridView1.Rows[0].Cells["10am"].Style.BackColor = Color.Black;
                dataGridView1.Rows[0].Cells["1pm"].Style.BackColor = Color.Black;
                dataGridView1.Rows[0].Cells["2pm"].Style.BackColor = Color.Black;
            }
            else if (twentythirdBtn.Checked)
            {
                dataGridView1.Rows[0].Cells["9am"].Style.BackColor = Color.Black;
                dataGridView1.Rows[0].Cells["4pm"].Style.BackColor = Color.Black;
            }

        }

        /// <summary>
        /// When the 23rd July radio button is selected, refreshes the DGV again by clearing and repopulating
        /// it with relevant coloring of the invalid timings of the day
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void twentythirdBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void headBox_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// When number of delegate is keyed in, this method houses the algorithm to
        /// calculate the required number 19-seater and 42-seater buses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delegateBox_TextChanged(object sender, EventArgs e)
        {
            bigBusLbl.Text = 0.ToString();
            smallBusLbl.Text = 0.ToString();

            try
            {
                ///d stands for number of attendees (without head)!!
                int d = Int32.Parse(delegateBox.Text);

                //Check if competitor number is not 0 or empty
                if (competitorBox.Text.Trim() != "0" || competitorBox.Text.Trim() != "")
                {
                    //Adds number od competitor to amount variable
                    d += Int32.Parse(competitorBox.Text);

                    //Checks if number of attendees (excluding head) is divisible by 19 and is smaller or equals to 38
                    if (d % 19 == 0 && d <= 38)
                    {
                        //If so, number of 19-seater buses is the quotient of attendees / 19
                        smallBusLbl.Text = (d / 19).ToString();
                    }
                    
                    //Else, check if number of attendees is less than 19 or is more than 19 but less than or equals to 38
                    else if (d < 19 || (d > 19 && d <= 38))
                    {
                        //If less than 19, 1 19-seater bus will be booked
                        if (d < 19)
                            smallBusLbl.Text = 1.ToString();

                        //Else, 2 19-seater buses will be booked
                        else
                            smallBusLbl.Text = 2.ToString();
                    }

                    //Else if number of attendees is more than 38...
                    else
                    {
                        //Check if number of attendees is still less than 42. If so, number of 42-seater buses booked will be 1
                        if (d < 42) bigBusLbl.Text = 1.ToString();
                        else
                        {
                            //Find remainder after minusing off quotient of attendees / 42
                            var i = d - 42 * Convert.ToInt32(d / 42);

                            //If remainder is more than 38, 42-seater buses is quotient of attendees / 42 then + 1
                            if (i > 38)
                            {
                                bigBusLbl.Text = (Convert.ToInt32(d / 42) + 1).ToString();
                            }

                            //Else if remainder is less than or equals to 38 and is also more than 0
                            else if (i <= 38 && i > 0)
                            {
                                //1 42-seater bus is booked
                                bigBusLbl.Text = (Convert.ToInt32(d / 42)).ToString();

                                //If remainder is less than or equals to 19, 1 19-seater bus will also be booked
                                if (i <= 19)
                                    smallBusLbl.Text = 1.ToString();

                                //Else, 2 19-seater buses will also be booked
                                else
                                    smallBusLbl.Text = 2.ToString();
                            }

                            //If remainder is 0
                            else
                            {
                                //Number of 42-seater buses that will be booked is quotient of attendees / 42
                                bigBusLbl.Text = (Convert.ToInt32(d / 42)).ToString();
                            }

                        }

                    }
                }

                //Checks if number of competitor os 0 or empty
                else if (competitorBox.Text.Trim() == "0" || competitorBox.Text.Trim() == "")
                {
                    //Checks if number of attendees (excluding head) is divisible by 19 and is smaller or equals to 38
                    if (d % 19 == 0 && d <= 38)
                    {
                        //If so, number of 19-seater buses is the quotient of attendees / 19
                        smallBusLbl.Text = (d / 19).ToString();
                    }

                    //Else, check if number of attendees is less than 19 or is more than 19 but less than or equals to 38
                    else if (d < 19 || (d > 19 && d <= 38))
                    {
                        //If less than 19, 1 19-seater bus will be booked
                        if (d < 19)
                            smallBusLbl.Text = 1.ToString();

                        //Else, 2 19-seater buses will be booked
                        else
                            smallBusLbl.Text = 2.ToString();
                    }

                    //Else if number of attendees is more than 38...
                    else
                    {
                        //Check if number of attendees is still less than 42. If so, number of 42-seater buses booked will be 1
                        if (d < 42) bigBusLbl.Text = 1.ToString();
                        else
                        {
                            //Find remainder after minusing off quotient of attendees / 42
                            var i = d - 42 * Convert.ToInt32(d / 42);

                            //If remainder is more than 38, 42-seater buses is quotient of attendees / 42 then + 1
                            if (i > 38)
                            {
                                bigBusLbl.Text = (Convert.ToInt32(d / 42) + 1).ToString();
                            }

                            //Else if remainder is less than or equals to 38 and is also more than 0
                            else if (i <= 38 && i > 0)
                            {
                                //1 42-seater bus is booked
                                bigBusLbl.Text = (Convert.ToInt32(d / 42)).ToString();

                                //If remainder is less than or equals to 19, 1 19-seater bus will also be booked
                                if (i <= 19)
                                    smallBusLbl.Text = 1.ToString();

                                //Else, 2 19-seater buses will also be booked
                                else
                                    smallBusLbl.Text = 2.ToString();
                            }

                            //If remainder is 0
                            else
                            {
                                //Number of 42-seater buses that will be booked is quotient of attendees / 42
                                bigBusLbl.Text = (Convert.ToInt32(d / 42)).ToString();
                            }
                        }



                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number or 0!", "No number detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The method has the exact same algorithm as delegateBox_TextChanged with slight details changed like checking if delegate is 0/empty or not.
        /// Calculation is the exact same.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void competitorBox_TextChanged(object sender, EventArgs e)
        {
            bigBusLbl.Text = 0.ToString();
            smallBusLbl.Text = 0.ToString();
            try
            {
                int d = Int32.Parse(competitorBox.Text);
                if (delegateBox.Text.Trim() != "0" || delegateBox.Text.Trim() != "")
                {
                    d += Int32.Parse(delegateBox.Text);
                    if (d % 19 == 0 && d <= 38)
                    {
                        smallBusLbl.Text = (d / 19).ToString();
                    }
                    else if (d < 19 || (d > 19 && d <= 38))
                    {
                        if (d < 19)
                            smallBusLbl.Text = 1.ToString();
                        else
                            smallBusLbl.Text = 2.ToString();
                    }
                    else
                    {
                        var i = d - 42 * Convert.ToInt32(d / 42);
                        if (i > 38)
                        {
                            bigBusLbl.Text = (Convert.ToInt32(d / 42) + 1).ToString();
                        }
                        else if (i <= 38 && i > 0)
                        {
                            bigBusLbl.Text = (Convert.ToInt32(d / 42)).ToString();
                            if (i <= 19)
                                smallBusLbl.Text = 1.ToString();
                            else
                                smallBusLbl.Text = 2.ToString();
                        }
                        else
                        {
                            bigBusLbl.Text = (Convert.ToInt32(d / 42)).ToString();
                        }

                    }
                }
                else if (delegateBox.Text.Trim() == "0" || delegateBox.Text.Trim() == "")
                {
                    if (d % 19 == 0 && d <= 38)
                    {
                        smallBusLbl.Text = (d / 19).ToString();
                    }
                    else if (d < 19 || (d > 19 && d <= 38))
                    {
                        if (d < 19)
                            smallBusLbl.Text = 1.ToString();
                        else
                            smallBusLbl.Text = 2.ToString();
                    }
                    else
                    {
                        var i = d - 42 * Convert.ToInt32(d / 42);
                        if (i > 38)
                        {
                            bigBusLbl.Text = (Convert.ToInt32(d / 42) + 1).ToString();
                        }
                        else if (i <= 38 && i > 0)
                        {
                            bigBusLbl.Text = (Convert.ToInt32(d / 42)).ToString();
                            if (i <= 19)
                                smallBusLbl.Text = 1.ToString();
                            else
                                smallBusLbl.Text = 2.ToString();
                        }
                        else
                        {
                            bigBusLbl.Text = (Convert.ToInt32(d / 42)).ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number or 0!", "No number detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Triggered when the Confirm button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            //Check if there is even a dell selected for timing or if the cell backcolor is black. If so, prompts error message
            if (dataGridView1.CurrentCell == null || dataGridView1.CurrentCell.Style.BackColor == Color.Black)
            {
                MessageBox.Show("Please select a timing that is not blacked out!");
            }
            else
            {
                using (var context = new Session3Entities())
                {
                    var checkIfBookingExist = (from x in context.Arrivals
                                               where x.userIdFK == _userID
                                               select x).FirstOrDefault();

                    //If booking does not exist in DB, add details to DB
                    if (checkIfBookingExist == null)
                    {
                        //If 22nd July is checked, then add date as 22 July 2020
                        if (twentysecondBtn.Checked)
                        {

                            context.Arrivals.Add(new Arrival()
                            {
                                arrivalDate = DateTime.Parse("22 July"),
                                arrivalTime = dataGridView1.CurrentCell.Value.ToString(),
                                numberHead = Convert.ToInt32(headBox.Value),
                                userIdFK = _userID,
                                numberDelegate = Int32.Parse(delegateBox.Text),
                                numberCompetitors = Int32.Parse(competitorBox.Text),
                                number19seat = Int32.Parse(smallBusLbl.Text),
                                numberCars = Int32.Parse(carLbl.Text),
                                number42seat = Int32.Parse(bigBusLbl.Text)
                            });
                            context.SaveChanges();


                        }
                        //If 23rd July is checked, then add date as 23 July 2020
                        else
                        {
                            context.Arrivals.Add(new Arrival()
                            {
                                arrivalDate = DateTime.Parse("23 July"),
                                arrivalTime = dataGridView1.CurrentCell.Value.ToString(),
                                numberHead = Convert.ToInt32(headBox.Value),
                                userIdFK = _userID,
                                numberDelegate = Int32.Parse(delegateBox.Text),
                                numberCompetitors = Int32.Parse(competitorBox.Text),
                                number19seat = Int32.Parse(smallBusLbl.Text),
                                numberCars = Int32.Parse(carLbl.Text),
                                number42seat = Int32.Parse(bigBusLbl.Text)
                            });
                            context.SaveChanges();
                        }
                    }

                    //Else, if booking already exist in DB, update details to DB
                    else
                    {
                        //If 22nd July is checked, then update date as 22 July 2020
                        if (twentysecondBtn.Checked)
                        {


                            checkIfBookingExist.arrivalDate = DateTime.Parse("22 July");
                            checkIfBookingExist.arrivalTime = dataGridView1.CurrentCell.Value.ToString();
                            checkIfBookingExist.numberHead = Convert.ToInt32(headBox.Value);
                            checkIfBookingExist.numberDelegate = Int32.Parse(delegateBox.Text);
                            checkIfBookingExist.numberCompetitors = Int32.Parse(competitorBox.Text);
                            checkIfBookingExist.number19seat = Int32.Parse(smallBusLbl.Text);
                            checkIfBookingExist.numberCars = Int32.Parse(carLbl.Text);
                            checkIfBookingExist.number42seat = Int32.Parse(bigBusLbl.Text);

                            context.SaveChanges();


                        }

                        //If 23rd July is checked, then update date as 23 July 2020
                        else
                        {
                            checkIfBookingExist.arrivalDate = DateTime.Parse("23 July");
                            checkIfBookingExist.arrivalTime = dataGridView1.CurrentCell.Value.ToString();
                            checkIfBookingExist.numberHead = Convert.ToInt32(headBox.Value);
                            checkIfBookingExist.numberDelegate = Int32.Parse(delegateBox.Text);
                            checkIfBookingExist.numberCompetitors = Int32.Parse(competitorBox.Text);
                            checkIfBookingExist.number19seat = Int32.Parse(smallBusLbl.Text);
                            checkIfBookingExist.numberCars = Int32.Parse(carLbl.Text);
                            checkIfBookingExist.number42seat = Int32.Parse(bigBusLbl.Text);
                            context.SaveChanges();
                        }
                    }

                }
                this.Hide();
                (new RepresentativeMain(_userID)).ShowDialog();
                this.Close();
            }
        }

        /// <summary>
        /// This is triggered when value is changed from 0 to 1 or back to 0. Calculates whether a car is neeeded for the Head of delegate as the
        /// value is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void headBox_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int head = Convert.ToInt32(headBox.Value);
                if (head == 1)
                {
                    carLbl.Text = 1.ToString();
                }
                else if (head == 0)
                {
                    carLbl.Text = 0.ToString();
                }
                else
                {
                    MessageBox.Show("Head of Delegate can only be either 1 or 0!", "Invalid number",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number or 0!", "No number detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }
    }
}
