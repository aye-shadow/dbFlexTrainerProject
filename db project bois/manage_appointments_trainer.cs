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
    public partial class manage_appointments_trainer : Form
    {
        // load appointment dates from db into array
        private List<DateTime> datesToHighlight = new List<DateTime>();

        public manage_appointments_trainer()
        {
            InitializeComponent();

            loadAppointmentDate();
            updateCalender();
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
        }


        private void manage_appointments_trainer_Load(object sender, EventArgs e)
        {

        }

        private void loadAppointmentDate()
        {
            // load all appointments a trainer has from db into list

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
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Trainer_home trainer_Home = new Trainer_home();
            this.Hide();
            trainer_Home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trainerAppointmentDetails appointmentDetails;

            if (button2.Text == "VIEW APPOINTMENT")
            {
                // simply display details of appointment
                appointmentDetails = new trainerAppointmentDetails(monthCalendar1.SelectionStart, false);
            }
            else
            {
                // give form to enter new appointment
                appointmentDetails = new trainerAppointmentDetails(monthCalendar1.SelectionStart, true);
            }
            this.Hide();
            appointmentDetails.Show();
        }
    }
}
