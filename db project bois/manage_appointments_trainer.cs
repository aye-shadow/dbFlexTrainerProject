using Db_project_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class manage_appointments_trainer : Form
    {
        public int id, sessionID;
        public string gname, dateSelected;
        bool viewOnly;
        string filterBy = "";
        public manage_appointments_trainer(string gymname, int id, bool viewOnly = false, int sessionID = 0, string dateSelected = "")
        {
            InitializeComponent();
            this.id = id;
            this.gname = gymname;
            this.sessionID = sessionID;
            this.dateSelected = dateSelected;
            this.viewOnly = viewOnly;
            updateStatus();
            loadAppointmentDate();
        }
        void updateStatus()
        {
            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
            string query = "UPDATE [Training_session$] SET status = CASE WHEN GETDATE() > appointmentDate and status like 'Confirmed' THEN 'Confirmed' WHEN GETDATE() > appointmentDate and status like 'Scheduled' Then 'Cancelled' ELSE status END WHERE id > 0";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters   
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        private void manage_appointments_trainer_Load(object sender, EventArgs e)
        {

        }

        private void loadAppointmentDate()
        {
            // load all appointments a trainer has from db into list
            flowLayoutPanel1.Controls.Clear();

            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
            string query = "SELECT [Training_session$].id, concat(firstName, ' ', LastName) as name, appointmentDate, [Training_session$].Status from [Training_session$] join Member$ on Member$.ID = Training_session$.MemberID where [TrainerID] = @id" + filterBy;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters   
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Panel panel = new Panel();
                            panel.AutoSize = true;
                            panel.Dock = DockStyle.Top;
                            panel.AutoSize = true;

                            Label idLabel = new Label();
                            idLabel.Text = reader["id"].ToString();
                            idLabel.AutoSize = true;
                            idLabel.Visible = false;
                            panel.Controls.Add(idLabel);

                            Label memberLabel = new Label();
                            memberLabel.Text = reader["name"].ToString();
                            memberLabel.AutoSize = true;
                            panel.Controls.Add(memberLabel);

                            Label dateLabel = new Label();
                            dateLabel.Text = reader["appointmentDate"].ToString();
                            dateLabel.AutoSize = true;
                            panel.Controls.Add(dateLabel);

                            LinkLabel viewScheduleLink = new LinkLabel();
                            viewScheduleLink.AutoSize = true;

                            if (reader["Status"].ToString() == "Scheduled")
                            {
                                viewScheduleLink.Text = "Confirm Appointment?";
                                viewScheduleLink.Click += (sender, e) =>
                                {
                                    int primaryKey = int.Parse(idLabel.Text);
                                    query = "UPDATE [Training_session$] SET STATUS = 'Confirmed' WHERE id = @primaryKey";
                                    using (SqlConnection connection1 = new SqlConnection(connectionString))
                                    {
                                        connection1.Open();

                                        using (SqlCommand command1 = new SqlCommand(query, connection1))
                                        {
                                            // Add parameters   
                                            command1.Parameters.AddWithValue("@primaryKey", primaryKey);

                                            command1.ExecuteNonQuery();
                                        }
                                    }

                                    MessageBox.Show("Appointment confirmed!", "Success", MessageBoxButtons.OK);
                                    Trainer_home trainer_Home = new Trainer_home(id);
                                    this.Hide();
                                    trainer_Home.Show();
                                };
                            }
                            else
                            {
                                viewScheduleLink.Text = "View";
                                viewScheduleLink.Click += (sender, e) =>
                                {
                                    trainerAppointmentDetails editPlan = new trainerAppointmentDetails(gname, true, int.Parse(idLabel.Text), id, dateLabel.Text);
                                    this.Hide();
                                    editPlan.Show();
                                };
                            }

                            panel.Controls.Add(viewScheduleLink);

                            int xOffset = memberLabel.Width + 5;
                            dateLabel.Location = new Point(xOffset, 0); // Set label's location
                            xOffset += dateLabel.Width + 5;
                            viewScheduleLink.Location = new Point(xOffset, 0); // Set label's location
                            flowLayoutPanel1.Controls.Add(panel);

                            Panel linePanel = new Panel();
                            linePanel.BackColor = Color.Black; // Set line color
                            linePanel.Height = 1; // Set line height
                            linePanel.Dock = DockStyle.Top; // Dock to top of the panels
                            flowLayoutPanel1.Controls.Add(linePanel);
                        }
                    }
                }
            }
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Trainer_home trainer_Home = new Trainer_home(id);
            this.Hide();
            trainer_Home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trainerAppointmentDetails editPlan = new trainerAppointmentDetails(gname, false, sessionID, id, dateSelected);
            this.Hide();
            editPlan.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    filterBy = " order by appointmentDate ";
                    break;
                case 1:
                    filterBy = " order by appointmentDate desc ";
                    break;
                case 2:
                    filterBy = " and training_session$.status like 'Cancelled' ";
                    break;
                case 3:
                    filterBy = " and training_session$.status like 'Scheduled' ";
                    break;
                case 4:
                    filterBy = " and training_session$.status like 'Confirmed' ";
                    break;
                case 5:
                    filterBy = " and training_session$.status like 'Completed' ";
                    break;
                default:
                    filterBy = "";
                    break;
            }
            loadAppointmentDate();
        }
    }
}
