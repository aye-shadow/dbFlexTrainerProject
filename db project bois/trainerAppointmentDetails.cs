using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class trainerAppointmentDetails : Form
    {
        private bool appointmentType;
        private DateTime dateSelected;
        public trainerAppointmentDetails(DateTime showAppointmentDate, bool appointmentType)
        {
            InitializeComponent();
            this.appointmentType = appointmentType;
            dateSelected = showAppointmentDate;
            monthCalendar1.SetSelectionRange(dateSelected, dateSelected);
            monthCalendar1.AddBoldedDate(dateSelected);
            comboBox1.Enabled = appointmentType;

            if (showAppointmentDate < DateTime.Today)
            {
                button3.Visible = false;
                button2.Visible = false;
            }
            else
            {
                button2.Enabled = true;
                if (appointmentType)
                {
                    button3.Text = "SCHEDULE APPOINTMENT";
                }
                else
                {
                    button3.Text = "CANCEL APPOINTMENT";
                }
                button2.Visible = !appointmentType;
            }
        }

        private void appointmentDetails_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "GO BACK")
            {
                manage_appointments_trainer manage_Appointments_Trainer = new manage_appointments_trainer();
                this.Hide();
                manage_Appointments_Trainer.Show();
            }
            else
            {
                button1.Text = "GO BACK";
                button2.Enabled = true;
                button3.Text = "CANCEL APPOINTMENT";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "CANCEL APPOINTMENT") 
            {
                DialogResult result = MessageBox.Show("Cancel appointment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // delete appointment from db

                    MessageBox.Show("Appointment Cancelled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    manage_appointments_trainer manage_Appointments_Trainer = new manage_appointments_trainer();
                    this.Hide();
                    manage_Appointments_Trainer.Show();
                }
            }
            else if (button3.Text == "SCHEDULE APPOINTMENT" && appointmentType == false)
            {
                // update appointment date to db

                MessageBox.Show("Appointment Successfuly Rescheduled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                manage_appointments_trainer manage_Appointments_Trainer = new manage_appointments_trainer();
                this.Hide();
                manage_Appointments_Trainer.Show();
            }
            else 
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter a member to schedule appointment with!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    // add new appointment to db

                    MessageBox.Show("Appointment Successfuly Scheduled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    manage_appointments_trainer manage_Appointments_Trainer = new manage_appointments_trainer();
                    this.Hide();
                    manage_Appointments_Trainer.Show();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            monthCalendar1.Enabled = true;
            button2.Enabled = false;
            button3.Text = "SCHEDULE APPOINTMENT";
            button1.Text = "CANCEL";
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Get the selected date from the MonthCalendar control
            DateTime selectedDate = monthCalendar1.SelectionStart;

            if (selectedDate < DateTime.Today)
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }
        }
    }
}
