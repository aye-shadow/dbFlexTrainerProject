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
        private bool appointmentType;
        private DateTime dateSelected;

        public memberViewSpecificAppointment(DateTime showAppointmentDate, bool appointmentType)
        {
            InitializeComponent();
            this.appointmentType = appointmentType;
            dateSelected = showAppointmentDate;
            monthCalendar1.SetSelectionRange(dateSelected, dateSelected);
            monthCalendar1.AddBoldedDate(dateSelected);
            comboBox1.Enabled = appointmentType;
            comboBox2.Enabled = appointmentType;

            if (showAppointmentDate < DateTime.Today)
            {
                button1.Visible = false;
                button2.Visible = false;
            }
            else
            {
                button2.Enabled = true;
                if (appointmentType)
                {
                    button1.Text = "SCHEDULE APPOINTMENT";
                }
                else
                {
                    button1.Text = "CANCEL APPOINTMENT";
                }
                button2.Visible = !appointmentType;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            appointmentdetails form = new appointmentdetails();
            this.Hide();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "GO BACK")
            {
                appointmentdetails manage_Appointments_Trainer = new appointmentdetails();
                this.Hide();
                manage_Appointments_Trainer.Show();
            }
            else
            {
                button3.Text = "GO BACK";
                button2.Enabled = true;
                button1.Text = "CANCEL APPOINTMENT";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "CANCEL APPOINTMENT")
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
            else if (button1.Text == "SCHEDULE APPOINTMENT" && appointmentType == false)
            {
                // update appointment date to db

                MessageBox.Show("Appointment Successfuly Rescheduled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                appointmentdetails manage_Appointments_Trainer = new appointmentdetails();
                this.Hide();
                manage_Appointments_Trainer.Show();
            }
            else
            {
                if (comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter a gym!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter a trainer to schedule with!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // add new appointment to db

                    MessageBox.Show("Appointment Successfuly Scheduled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    appointmentdetails manage_Appointments_Trainer = new appointmentdetails();
                    this.Hide();
                    manage_Appointments_Trainer.Show();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            monthCalendar1.Enabled = true;
            button2.Enabled = false;
            button1.Text = "SCHEDULE APPOINTMENT";
            button3.Text = "CANCEL";
        }

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;

            if (selectedDate < DateTime.Today)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }
    }
}
