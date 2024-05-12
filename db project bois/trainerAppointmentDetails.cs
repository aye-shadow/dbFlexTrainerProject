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
        private int memberID;
        private bool viewOnly;
        private DateTime dateSelected;
        private string gymName;
        public trainerAppointmentDetails(string gymName, bool viewOnly, int memberID = 1, string dateSelected = "")
        {
            InitializeComponent();
            this.memberID = memberID;
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
            this.gymName = gymName;
            this.viewOnly = viewOnly;
            comboBox1.Enabled = !viewOnly;

            if (!viewOnly)
            {
                monthCalendar1.Enabled = true;
                button3.Text = "SCHEDULE APPOINTMENT";
                button2.Visible = false;
            }
            else if (viewOnly)
            {
                button3.Text = "CANCEL APPOINTMENT";
                button2.Text = "RESCHEDULE APPOINTMENT";
                monthCalendar1.Enabled = false;
                if (this.dateSelected < DateTime.Today)
                {
                    button3.Visible = false;
                    button2.Visible = false;

                }
                else
                {
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button3.Visible = true;
                    button2.Visible = true;

                }
            }
        }

        private void appointmentDetails_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            manage_appointments_trainer manage_Appointments_Trainer = new manage_appointments_trainer(memberID, gymName);
            this.Hide();
            manage_Appointments_Trainer.Show();
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

                    manage_appointments_trainer manage_Appointments_Trainer = new manage_appointments_trainer(memberID, gymName);
                    this.Hide();
                    manage_Appointments_Trainer.Show();
                }
            }
            else if (button3.Text == "SCHEDULE APPOINTMENT" && viewOnly == false)
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Select member to schedule with!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // add appointment to db

                    MessageBox.Show("Appointment Successfuly Scheduled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    manage_appointments_trainer manage_Appointments_Trainer = new manage_appointments_trainer(memberID, gymName);
                    this.Hide();
                    manage_Appointments_Trainer.Show();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "RESCHEDULE APPOINTMENT" && viewOnly == true)
            {
                monthCalendar1.Enabled = true;
                button3.Enabled = false;
                button2.Text = "SCHEDULE APPOINTMENT";
            }
            else if (button2.Text == "SCHEDULE APPOINTMENT")
            {
                // edit date in db

                MessageBox.Show("Appointment Successfuly Rescheduled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                manage_appointments_trainer manage_Appointments_Trainer = new manage_appointments_trainer(memberID, gymName);
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
                button3.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }
    }
}
