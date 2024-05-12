using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class trainerAppointmentDetails : Form
    {
        private int memberID, sessionID;
        private bool viewOnly;
        private DateTime dateSelected;
        private string gymName, dateString;
        Dictionary<int, string> dictionary = new Dictionary<int, string>();
        public trainerAppointmentDetails(string gymName, bool viewOnly, int sessionID, int memberID = 1, string dateSelected = "")
        {
            MessageBox.Show(sessionID.ToString());
            InitializeComponent();
            this.memberID = memberID;
            this.sessionID = sessionID;
            this.gymName = gymName;
            this.viewOnly = viewOnly;
            this.dateString = dateSelected;
            if (dateSelected == "")
            {
                this.dateSelected = DateTime.Today;
            }
            else
            {
                this.dateSelected = DateTime.Parse(dateSelected);
            }
            initialiseFields();
            checkIfAppointmentCancelled();
        }

        private void checkIfAppointmentCancelled()
        {
            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
            string query = "select * from Training_session$ where id = @sessionID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sessionID", sessionID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Clear existing items in the ComboBox
                        comboBox1.Items.Clear();
                        // Read each row from the result set and add the value to the ComboBox
                        while (reader.Read())
                        {
                            if (reader["status"].ToString() == "Cancelled")
                            {
                                button2.Visible = false;
                                button3.Visible = false;
                            }
                        }
                    }
                }
            }
        }

        private void initialiseFields()
        {
            monthCalendar1.SetSelectionRange(this.dateSelected, this.dateSelected);
            monthCalendar1.AddBoldedDate(this.dateSelected);
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

            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
            string query = "select Member$.ID, concat(Member$.firstname, ' ', Member$.lastname) as name from Member$ join Training_session$ on Training_session$.MemberID = Member$.ID join Trainer$ on Trainer$.ID = Training_session$.TrainerID where Trainer$.ID = @memberID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@memberID", memberID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Clear existing items in the ComboBox
                        comboBox1.Items.Clear();

                        // Read each row from the result set and add the value to the ComboBox
                        while (reader.Read())
                        {
                            dictionary.Add(int.Parse(reader["id"].ToString()), reader["name"].ToString());
                        }
                    }

                    foreach (var kvp in dictionary)
                    {
                        comboBox1.Items.Add(new KeyValuePair<int, string>(kvp.Key, kvp.Value));
                    }

                    query = "SELECT Training_session$.MemberID, concat(firstname, ' ', lastname) as name, Training_session$.status from Training_session$ join Member$ on Member$.ID = Training_session$.MemberID where Training_session$.ID = @sessionID";
                    using (SqlCommand command1 = new SqlCommand(query, connection))
                    {
                        command1.Parameters.AddWithValue("@sessionID", sessionID);

                        using (SqlDataReader reader1 = command1.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                textBox1.Text = reader1["status"].ToString();
                                KeyValuePair<int, string> selectedPair = new KeyValuePair<int, string>(int.Parse(reader1["memberid"].ToString()), reader1["name"].ToString());
                                int index = -1;
                                for (int i = 0; i < comboBox1.Items.Count; i++)
                                {
                                    KeyValuePair<int, string> item = (KeyValuePair<int, string>)comboBox1.Items[i];
                                    if (item.Key == selectedPair.Key && item.Value == selectedPair.Value)
                                    {
                                        index = i;
                                        break;
                                    }
                                }
                                comboBox1.SelectedIndex = index;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void appointmentDetails_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            manage_appointments_trainer manage_Appointments_Trainer = new manage_appointments_trainer(gymName, memberID, viewOnly, sessionID, dateString);
            this.Hide();
            manage_Appointments_Trainer.Show();
        }

        private int GetSelectedID(string selectedItem)
        {
            foreach (var pair in dictionary)
            {
                if (pair.Value == selectedItem)
                {
                    return pair.Key;
                }
            }

            return -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "CANCEL APPOINTMENT")
            {
                DialogResult result = MessageBox.Show("Cancel appointment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
                    string query = "update Training_session$ set [Status] = 'Cancelled' where id = @sessionID";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@sessionID", sessionID);

                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Appointment Cancelled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    manage_appointments_trainer manage_Appointments_Trainer = new manage_appointments_trainer(gymName, memberID, viewOnly, sessionID, dateString);
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

                    manage_appointments_trainer manage_Appointments_Trainer = new manage_appointments_trainer(gymName, memberID, viewOnly, sessionID, dateString);
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
                DateTime selectedDate = monthCalendar1.SelectionStart;
                string formattedDate = selectedDate.ToString("yyyy-MM-dd");

                string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
                string query = "update Training_session$ set [RequestDate] = @formattedDate where id = @sessionID";
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
                manage_appointments_trainer manage_Appointments_Trainer = new manage_appointments_trainer(gymName, memberID, viewOnly, sessionID, dateString);
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
