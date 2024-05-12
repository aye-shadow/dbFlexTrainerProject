using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Db_project_1
{
    public partial class memberViewSpecificAppointment : Form
    {
        private bool viewOnly;
        private DateTime dateSelected;

        public memberViewSpecificAppointment(string dateSelected, bool viewOnly, int memberID = 1)
        {
            InitializeComponent();
            this.viewOnly = viewOnly;
            if (dateSelected == "")
            {
                this.dateSelected = DateTime.Today;
            }
            else
            {
                this.dateSelected = DateTime.Parse(dateSelected);
            }
            monthCalendar1.SetSelectionRange(this.dateSelected, this.dateSelected);
            monthCalendar1.AddBoldedDate(this.dateSelected);
            comboBox1.Enabled = !viewOnly;
            comboBox2.Enabled = !viewOnly;

            if (!viewOnly)
            {
                monthCalendar1.Enabled = true;
                button1.Text = "SCHEDULE APPOINTMENT";
                button2.Visible = false;
            }
            else if (viewOnly)
            {
                button1.Text = "CANCEL APPOINTMENT";
                button2.Text = "RESCHEDULE APPOINTMENT";
                monthCalendar1.Enabled = false;
                if (this.dateSelected < DateTime.Today)
                {
                    button1.Visible = false;
                    button2.Visible = false;
                }
                else
                {
                    button2.Enabled = true;
                    button1.Enabled = true;
                    button1.Visible = true;
                    button2.Visible = true;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            appointmentdetails manage_Appointments_Trainer = new appointmentdetails();
            this.Hide();
            manage_Appointments_Trainer.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (viewOnly && button1.Text == "CANCEL APPOINTMENT")
            {
                DialogResult result = MessageBox.Show("Cancel appointment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // delete appointment from db

                    MessageBox.Show("Appointment Cancelled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    appointmentdetails manage_Appointments_Trainer = new appointmentdetails();
                    this.Hide();
                    manage_Appointments_Trainer.Show();
                }
            }
            else if (!viewOnly && button1.Text == "SCHEDULE APPOINTMENT")
            {
                if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select gym and member!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // add appointment date to db

                    MessageBox.Show("Appointment Successfuly Scheduled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    appointmentdetails manage_Appointments_Trainer = new appointmentdetails();
                    this.Hide();
                    manage_Appointments_Trainer.Show();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (viewOnly && button2.Text == "RESCHEDULE APPOINTMENT")
            {
                monthCalendar1.Enabled = true;
                button1.Enabled = true;
                button2.Text = "SCHEDULE APPOINTMENT";
            }
            else if (button2.Text == "SCHEDULE APPOINTMENT")
            {
                // edit date in db

                MessageBox.Show("Appointment Successfuly Rescheduled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                appointmentdetails manage_Appointments_Trainer = new appointmentdetails();
                this.Hide();
                manage_Appointments_Trainer.Show();
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Get the selected date from the MonthCalendar control
            DateTime selectedDate = monthCalendar1.SelectionStart;

            if (selectedDate < DateTime.Today)
            {
                button2.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                button1.Enabled = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
