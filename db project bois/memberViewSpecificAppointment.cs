using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private int memberID, sessionID;

        public memberViewSpecificAppointment(string dateSelected, bool viewOnly, int memberID = 1, int sessionID = 1)
        {
            InitializeComponent();
            this.viewOnly = viewOnly;
            this.memberID = memberID;
            this.sessionID = sessionID;
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
                loadGyms();
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
                loadSpecificApp();
                checkIfAppointmentCancelled();
            }
        }

        private void checkIfAppointmentCancelled()
        {
            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
            string query = "select status from Training_session$ where Training_session$.ID = @sessionID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@sessionID", sessionID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["status"].ToString() == "Cancelled")
                            {
                                button2.Visible = false;
                                button1.Visible = false;
                            }
                        }
                    }
                }
            }

        }

        private void loadSpecificApp()
        {
            loadGyms();
            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
            string query = "select Gym$.GymID from Gym$ join Member_gym$ on Member_gym$.GymID = Gym$.GymID where Member_gym$.MemberID = @memberID";
            int gymID = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@memberID", memberID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            gymID = int.Parse(reader["gymid"].ToString());
                        }
                    }
                }
            }

            foreach (KeyValuePair<int, string> item in comboBox2.Items)
            {
                if (item.Key == gymID)
                {
                    comboBox2.SelectedItem = item;
                    break; // Exit loop once item is found
                }
            }

            query = "select TrainerID from Training_session$ where id = @sessionID";
            int trainerID = 0;
            using (SqlConnection connedtion2 = new SqlConnection(connectionString))
            {
                using (SqlCommand command2 = new SqlCommand(query, connedtion2))
                {
                    connedtion2.Open();

                    command2.Parameters.AddWithValue("@sessionID", sessionID);

                    using (SqlDataReader reader2 = command2.ExecuteReader())
                    {
                        if (reader2.Read())
                        {
                            trainerID = int.Parse(reader2["trainerID"].ToString());
                        }
                    }
                }
            }

            foreach (KeyValuePair<int, string> item in comboBox1.Items)
            {
                if (item.Key == trainerID)
                {
                    comboBox1.SelectedItem = item;
                    break; // Exit loop once item is found
                }
            }
        }

        private void loadGyms()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
            string query = "select distinct Gym$.gymid, gymname from Gym$ join Member_gym$ on Member_gym$.GymID = Gym$.GymID where memberID = @memberID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    
                    command.Parameters.AddWithValue("@memberID", memberID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox2.Items.Add(new KeyValuePair<int, string>(int.Parse(reader["gymid"].ToString()), reader["gymname"].ToString()));
                        }
                    }
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

        private bool trainerUnavailableOnDay(string day, int id)
        {
            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
            string query = "select * from Training_session$ where TrainerID = @id and CONVERT(date, appointmentDate) like @day and status not like 'Cancelled'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@day", day);
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Trainer not available on day!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (viewOnly && button1.Text == "CANCEL APPOINTMENT")
            {
                DialogResult result = MessageBox.Show("Cancel appointment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
                    string query = "update Training_session$ set Status = 'Cancelled' where Training_session$.ID = @sessionID";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@sessionID", sessionID);

                            command.ExecuteNonQuery();
                        }
                    }

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
                else if (trainerUnavailableOnDay(monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd"), ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key))
                {
                }
                else 
                {
                    string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
                    string query = "insert into Training_session$ (id, MemberID, TrainerID, RequestDate, appointmentDate) values ((SELECT Max(id) from training_session$) + 1, @memberID, @trainerID, GETDATE(), @apDate)";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@memberID", memberID);
                            command.Parameters.AddWithValue("@trainerID", ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key);
                            command.Parameters.AddWithValue("@apDate", monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd"));

                            command.ExecuteNonQuery();
                        }
                    }

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
            else if (button2.Text == "SCHEDULE APPOINTMENT" && !trainerUnavailableOnDay(monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd"), ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key))
            {
                // edit date in db
                DateTime selectedDate = monthCalendar1.SelectionStart;
                string formattedDate = selectedDate.ToString("yyyy-MM-dd");

                MessageBox.Show(selectedDate.ToString("yyyy-MM-dd") + " " +sessionID.ToString());

                string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
                string query = "update Training_session$ set appointmentdate = @formattedDate where id = @sessionID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@formattedDate", formattedDate);
                        command.Parameters.AddWithValue("@sessionID", sessionID);

                        command.ExecuteNonQuery();
                    }
                }

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
            string query = "select distinct Trainer$.id, concat(firstname, ' ', lastname) as name from Trainer$ join Trainer_gym$ on Trainer$.ID = Trainer_gym$.TrainerID where Trainer_gym$.GymID = @selectedGymID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@selectedGymID", ((KeyValuePair<int, string>)comboBox2.SelectedItem).Key);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(new KeyValuePair<int, string>(int.Parse(reader["id"].ToString()), reader["name"].ToString()));
                        }
                    }
                }
            }
        }
    }
}
