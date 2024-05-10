using db_project_bois;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Db_project_1
{

    public partial class appointmentdetails : Form
    {
        private List<DateTime> datesToHighlight = new List<DateTime>();
        public appointmentdetails()
        {
            InitializeComponent();
            loadAllAppointments();
            updateCalender();
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Members form = new Members();
            this.Hide();
            form.ShowDialog();
        }

        private void appointmentdetails_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Db_project_1.Members memberManageAppointments = new Db_project_1.Members();
            this.Hide();
            memberManageAppointments.Show();
        }

        private void loadAllAppointments()
        {
            // load all appointments a member has from db

            DateTime[] dummyDates = { new DateTime(2024, 5, 10), new DateTime(2024, 5, 15), new DateTime(2024, 5, 20), new DateTime(2024, 5, 3) };

            foreach (DateTime date in dummyDates)
            {
                datesToHighlight.Add(date);
            }
        }

        private void updateCalender()
        {
            monthCalendar1.RemoveAllBoldedDates();

            foreach (DateTime date in datesToHighlight)
            {
                if (date >= monthCalendar1.MinDate && date <= monthCalendar1.MaxDate)
                {
                    monthCalendar1.AddBoldedDate(date);
                }
            }

            monthCalendar1.UpdateBoldedDates(); ;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;

            if (monthCalendar1.BoldedDates.Contains(selectedDate))
            {
                button2.Enabled = true;
                button2.Text = "VIEW APPOINTMENT";
            }
            else if (selectedDate < DateTime.Today)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                if (monthCalendar1.BoldedDates.Contains(selectedDate))
                {
                    button2.Text = "VIEW APPOINTMENT";
                }
                else
                {
                    button2.Text = "SCHEDULE APPOINTMENT";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            memberViewSpecificAppointment appointmentDetails;

            if (button2.Text == "VIEW APPOINTMENT")
            {
                // simply display details of appointment
                appointmentDetails = new memberViewSpecificAppointment(monthCalendar1.SelectionStart, false);
            }
            else
            {
                // give form to enter new appointment
                appointmentDetails = new memberViewSpecificAppointment(monthCalendar1.SelectionStart, true);
            }
            this.Hide();
            appointmentDetails.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
