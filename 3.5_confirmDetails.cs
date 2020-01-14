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

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new RepresentativeMain(_userID)).ShowDialog();
            this.Close();
        }

        private void twentysecondBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        private void GridRefresh()
        {
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

        private void delegateBox_TextChanged(object sender, EventArgs e)
        {
            bigBusLbl.Text = 0.ToString();
            smallBusLbl.Text = 0.ToString();

            try
            {
                int d = Int32.Parse(delegateBox.Text);
                if (competitorBox.Text.Trim() != "")
                {
                    d += Int32.Parse(competitorBox.Text);
                    if (d % 19 == 0)
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
                        if (d < 42) bigBusLbl.Text = 1.ToString();
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
                                if (i < 19)
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
                else if (competitorBox.Text.Trim() == "")
                {
                    if (d % 19 == 0)
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
                        if (d < 42) bigBusLbl.Text = 1.ToString();
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
                                if (i < 19)
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
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number or 0!", "No number detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void competitorBox_TextChanged(object sender, EventArgs e)
        {
            bigBusLbl.Text = 0.ToString();
            smallBusLbl.Text = 0.ToString();
            try
            {
                int d = Int32.Parse(competitorBox.Text);
                if (delegateBox.Text.Trim() != "")
                {
                    d += Int32.Parse(delegateBox.Text);
                    if (d % 19 == 0)
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
                            if (i < 19)
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
                else if (delegateBox.Text.Trim() == "")
                {
                    if (d % 19 == 0)
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
                        var i = d - 42*Convert.ToInt32(d / 42);
                        if (i > 38)
                        {
                            bigBusLbl.Text = (Convert.ToInt32(d / 42) + 1).ToString();
                        }
                        else if (i <= 38 && i > 0)
                        {
                            bigBusLbl.Text = (Convert.ToInt32(d / 42)).ToString();
                            if (i < 19)
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

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null || dataGridView1.CurrentCell.Style.BackColor == Color.Black)
            {
                MessageBox.Show("Please select a timing that is not blacked out!");
            }
            else
            {
                using (var context = new Session3Entities())
                {
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
                this.Hide();
                (new RepresentativeMain(_userID)).ShowDialog();
                this.Close();
            }
        }

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
    }
}
