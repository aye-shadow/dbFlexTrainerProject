using Db_project_1;
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

namespace db_project_bois
{
    public partial class viewWorkoutReport : Form
    {
        private bool memberType;
        private int workoutID, memberID;
        public viewWorkoutReport(bool memberType, int workoutID, int memberID)
        {
            InitializeComponent();
            this.memberType = memberType;
            this.workoutID = workoutID; 
            this.memberID = memberID;
            loadWorkout();
        }

        private void loadWorkout()
        {
            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;";
            string query = "select workoutName, goal, experienceLevel from Workout_plan$ where id = @workoutID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@workoutID", workoutID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                textBox2.Text = reader["workoutName"].ToString();
                                textBox1.Text = reader["goal"].ToString();
                                textBox3.Text = reader["experienceLevel"].ToString();
                                break;
                            }
                        }
                    }
                }
            }

            query = "select Exercise$.Name, sets, reps" +
                "  from Workout_plan$" +
                "  join Workout_exercise$ on Workout_exercise$.WorkoutID = Workout_plan$.ID" +
                "  join Exercise$ on Exercise$.ID = Workout_exercise$.ExerciseID" +
                "  where Workout_plan$.id = @workoutID";
            using (SqlConnection connection1 = new SqlConnection(connectionString))
            {
                connection1.Open();

                using (SqlCommand command1 = new SqlCommand(query, connection1))
                {
                    command1.Parameters.AddWithValue("@workoutID", workoutID);

                    using (SqlDataReader reader1 = command1.ExecuteReader())
                    {
                        while(reader1.Read())
                        {
                            Panel panel = new Panel();
                            panel.AutoSize = true;
                            panel.Dock = DockStyle.Top;
                            panel.AutoSize = true;

                            Label exerciseLabel = new Label();
                            exerciseLabel.Text = reader1["name"].ToString() + "     " + reader1["sets"].ToString() + " sets     " + reader1["reps"].ToString() + " reps";
                            exerciseLabel.AutoSize = true;
                            panel.Controls.Add(exerciseLabel);

                            flowLayoutPanel1.Controls.Add(panel);

                            Panel linePanel = new Panel();
                            linePanel.BackColor = Color.Black; // Set line color
                            linePanel.Height = 1; // Set line height
                            linePanel.Dock = DockStyle.Top; // Dock to top of the panel
                            flowLayoutPanel1.Controls.Add(linePanel);
                        }
                    }
                }
            }

            query = "select concat(firstname, ' ', lastname) as name, GymName" +
                "  from Workout_plan$ " +
                "  join Workout_Followers$ on Workout_Followers$.WorkoutID = Workout_plan$.ID" +
                "  join Member$ on Member$.ID = Workout_Followers$.MemberID" +
                "  join Member_gym$ on Member_gym$.MemberID = Member$.ID" +
                "  join Gym$ on Gym$.GymID = Member_gym$.MemberID" +
                "  where Workout_plan$.id = @workoutID and Member$.ID in (select MemberID from Training_session$ where TrainerID = @memberID)";
            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();

                using (SqlCommand command2 = new SqlCommand(query, connection2))
                {
                    command2.Parameters.AddWithValue("@workoutID", workoutID);
                    command2.Parameters.AddWithValue("@memberID", memberID);

                    using (SqlDataReader reader2 = command2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            Panel panel = new Panel();
                            panel.AutoSize = true;
                            panel.Dock = DockStyle.Top;
                            panel.AutoSize = true;

                            Label clientLabel = new Label();
                            clientLabel.Text = reader2["name"].ToString() + "     (" + reader2["GymName"].ToString() + ")";
                            clientLabel.AutoSize = true;
                            panel.Controls.Add(clientLabel);

                            flowLayoutPanel2.Controls.Add(panel);

                            Panel linePanel = new Panel();
                            linePanel.BackColor = Color.Black; // Set line color
                            linePanel.Height = 1; // Set line height
                            linePanel.Dock = DockStyle.Top; // Dock to top of the panel
                            flowLayoutPanel2.Controls.Add(linePanel);
                        }
                    }
                }
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            viewWorkout memberDietplan = new viewWorkout(memberType, memberID);
            this.Hide();
            memberDietplan.Show();
        }
    }
}
