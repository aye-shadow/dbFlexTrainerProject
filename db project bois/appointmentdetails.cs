using db_project_bois;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp1;

namespace Db_project_1
{

    public partial class appointmentdetails : Form
    {
        private int memberID;
        string filterBy = "";
        public appointmentdetails(int memberID = 1)
        {
            InitializeComponent();
            this.memberID = memberID;
            updateStatus();
            loadAllAppointments();
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
            // load all appointments a trainer has from db into list
            flowLayoutPanel1.Controls.Clear();

            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
            string query = "SELECT [Training_session$].id, concat(firstName, ' ', LastName) as name, appointmentDate, [Training_session$].Status from [Training_session$] join Trainer$ on Trainer$.ID = Training_session$.TrainerID where MemberID = @memberID" + filterBy;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters   
                    command.Parameters.AddWithValue("@memberID", memberID);

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
                            viewScheduleLink.Text = "View";
                            viewScheduleLink.Click += (sender, e) =>
                            {
                                memberViewSpecificAppointment editPlan = new memberViewSpecificAppointment(dateLabel.Text, true, memberID, int.Parse(idLabel.Text));
                                this.Hide();
                                editPlan.Show();
                            };

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

        private void button2_Click(object sender, EventArgs e)
        {
            memberViewSpecificAppointment appointmentDetails = new memberViewSpecificAppointment("", false, memberID);
            this.Hide();
            appointmentDetails.Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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
            loadAllAppointments();
        }
    }
}
