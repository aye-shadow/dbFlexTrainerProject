using Db_project_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace db_project_bois
{
    public partial class viewWorkout : Form
    {
        private bool memberType, orderBy = false;
        private int memberID;
        private string filterBy = "";
        public viewWorkout(bool memberType, int memberID)
        {
            InitializeComponent();
            this.memberType = memberType;
            this.memberID = memberID;
            linkLabel1.Enabled = false;
            showRows();
        }

        private void showRows()
        {
            flowLayoutPanel1.Controls.Clear();

            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;";
            string memberTYPE = "";
            if (memberType)
            {
                memberTYPE = "Member";
            }
            else
            {
                memberTYPE = "Trainer";
            }
            string query = "select Workout_plan$.id, workoutname, creatorid, CreatorType, CreationDate, workoutName, STRING_AGG(Exercise$.Name, ', ') AS exercises, ShareStatus," +
                "  case " +
                "  when CreatorType like 'trainer' " +
                "  then concat(trainer$.firstname, ' ', trainer$.lastname)" +
                "  else concat(Member$.firstname, ' ', Member$.lastname)" +
                "  end as name" +
                "  from Workout_plan$ " +
                "  join Workout_exercise$ on Workout_exercise$.WorkoutID = Workout_plan$.ID" +
                "  join Exercise$ on Exercise$.ID = Workout_exercise$.ExerciseID" +
                "  left join Trainer$ on Trainer$.ID = Workout_plan$.CreatorID" +
                "  left join Member$ on Member$.ID = Workout_plan$.CreatorID" +
                "  where CreatorType like @memberTYPE and CreatorID = @memberID " + (!orderBy ? filterBy : "") +
                "  group by Workout_plan$.id, workoutname, creatorid, CreatorType, CreationDate, workoutName, ShareStatus, trainer$.FirstName, trainer$.LastName, Member$.FirstName, Member$.LastName";
            if (memberType)
            {
                query += "  union " +
                "  select Workout_plan$.id, workoutname, creatorid, CreatorType, CreationDate, workoutName, STRING_AGG(Exercise$.Name, ', ') AS exercises, ShareStatus, " +
                "  case " +
                "  when CreatorType like 'trainer' " +
                "  then concat(trainer$.firstname, ' ', trainer$.lastname)" +
                "  else concat(Member$.firstname, ' ', Member$.lastname)" +
                "  end as name" +
                "  from Workout_plan$ " +
                "  join Workout_exercise$ on Workout_exercise$.WorkoutID = Workout_plan$.ID" +
                "  join Exercise$ on Exercise$.ID = Workout_exercise$.ExerciseID" +
                "  left join Trainer$ on Trainer$.ID = Workout_plan$.CreatorID" +
                "  left join Member$ on Member$.ID = Workout_plan$.CreatorID" +
                "  join Workout_Followers$ on Workout_Followers$.WorkoutID = Workout_plan$.ID" +
                "  where Workout_Followers$.MemberID = @memberID" + (!orderBy ? filterBy : "") +
                "  group by Workout_plan$.id, workoutname, creatorid, CreatorType, CreationDate, workoutName, ShareStatus, trainer$.FirstName, trainer$.LastName, Member$.FirstName, Member$.LastName";
            }
            query += (orderBy ? filterBy : "");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@memberTYPE", memberTYPE);
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

                            Label wIDLabel = new Label();
                            wIDLabel.Name = "wIDLabel";
                            wIDLabel.Text = reader["id"].ToString();
                            wIDLabel.AutoSize = true;
                            wIDLabel.Visible = false;
                            panel.Controls.Add(wIDLabel);
                            Label workoutLabel = new Label();
                            workoutLabel.Text = "|     " + reader["workoutName"].ToString() + "     |";
                            workoutLabel.AutoSize = true;
                            panel.Controls.Add(workoutLabel);

                            Label exerciseLabel = new Label();
                            exerciseLabel.Text = reader["exercises"].ToString();
                            exerciseLabel.AutoSize = true;
                            panel.Controls.Add(exerciseLabel);

                            Label cID = new Label();
                            cID.Name = "cID";
                            cID.Text = reader["CreatorID"].ToString();
                            cID.AutoSize = true;
                            cID.Visible = false;
                            Label cT = new Label();
                            cT.Name = "cT";
                            cT.Text = reader["CreatorType"].ToString();
                            cT.AutoSize = true;
                            cT.Visible = false;
                            panel.Controls.Add(cID);
                            Label authorLabel = new Label();
                            authorLabel.Text = "|     " + reader["name"].ToString() + "     |";
                            authorLabel.AutoSize = true;
                            panel.Controls.Add(authorLabel);

                            int maxSize = flowLayoutPanel1.Width - workoutLabel.Width - authorLabel.Width;

                            LinkLabel editLink = new LinkLabel();
                            if (int.Parse(cID.Text) == memberID && cT.Text == memberTYPE)
                            {
                                editLink.Text = "Edit";
                                editLink.AutoSize = true;
                                editLink.Click += (sender, e) =>
                                {
                                    editWorkout editWorkout = new editWorkout(memberType, memberID, int.Parse(wIDLabel.Text));
                                    this.Hide();
                                    editWorkout.Show();
                                };
                                panel.Controls.Add(editLink);
                                maxSize += editLink.Width;
                            }

                            exerciseLabel.MaximumSize = new Size(maxSize - 15, 0);

                            int xOffset = workoutLabel.Width + 5;
                            exerciseLabel.Location = new Point(xOffset, 0); // Set label's location
                            xOffset += exerciseLabel.Width + 5;
                            authorLabel.Location = new Point(xOffset, 0); // Set label's location
                            xOffset += authorLabel.Width + 5;
                            editLink.Location = new Point(xOffset, 0); // Set label's location

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            workoutPlan workoutPlan = new workoutPlan(memberType, memberID);
            this.Hide();
            workoutPlan.Show();
        }

        private void link3ClickedRows()
        {
            flowLayoutPanel1.Controls.Clear();

            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;";
            string memberTYPE = "";
            if (memberType)
            {
                memberTYPE = "Member";
            }
            else
            {
                memberTYPE = "Trainer";
            }
            string query = "select workoutName, Workout_plan$.id, CreatorType, CreatorID, CreationDate, STRING_AGG([name], ', ') AS exercises, ShareStatus,  " +
                "CASE         " +
                "WHEN CreatorType like 'trainer' " +
                "THEN concat(Trainer$.FirstName, ' ', Trainer$.LastName)        " +
                "ELSE concat(Member$.FirstName, ' ', Member$.LastName)  " +
                "END AS name  " +
                "from Workout_plan$  " +
                "join Workout_exercise$ on Workout_exercise$.WorkoutID = Workout_plan$.ID  " +
                "join Exercise$ on Exercise$.ID = Workout_exercise$.ExerciseID  " +
                "left join Trainer$ on Trainer$.ID = Workout_plan$.CreatorID  " +
                "left join Member$ on Member$.ID = Workout_plan$.CreatorID  " +
                "WHERE     (CreatorID != @memberID AND CreatorType NOT LIKE 'trainer')     OR     (CreatorID != @memberID AND CreatorType = 'trainer' AND ShareStatus like 'public')  " + (!orderBy ? filterBy : "") +
                "group by Workout_plan$.id, CreatorType, CreatorID, CreationDate, ShareStatus, Trainer$.FirstName, Trainer$.LastName, Member$.FirstName, Member$.LastName, workoutName " + (orderBy ? filterBy : "");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@memberTYPE", memberTYPE);
                    command.Parameters.AddWithValue("@memberID", memberID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bool alreadySubscribed = false;
                            if (memberType)
                            {
                                query = "select * from Workout_Followers$ " +
                                    "where WorkoutID = @workoutID and MemberID = @memberID";

                                using (SqlConnection connection1 = new SqlConnection(connectionString))
                                {
                                    using (SqlCommand command1 = new SqlCommand(query, connection1))
                                    {
                                        command1.Parameters.AddWithValue("@workoutID", Convert.ToInt32(reader["id"]));
                                        command1.Parameters.AddWithValue("@memberID", memberID);

                                        connection1.Open();

                                        using (SqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            if (reader1.HasRows)
                                            {
                                                alreadySubscribed = true;
                                            }
                                        }
                                    }
                                }
                            }

                            Panel panel = new Panel();
                            panel.AutoSize = true;
                            panel.Dock = DockStyle.Top;
                            panel.AutoSize = true;

                            Label wIDLabel = new Label();
                            wIDLabel.Name = "wIDLabel";
                            wIDLabel.Text = reader["id"].ToString();
                            wIDLabel.AutoSize = true;
                            wIDLabel.Visible = false;
                            panel.Controls.Add(wIDLabel);
                            Label workoutLabel = new Label();
                            workoutLabel.Text = "|     " + reader["workoutName"].ToString() + "     |";
                            workoutLabel.AutoSize = true;
                            panel.Controls.Add(workoutLabel);

                            Label exerciseLabel = new Label();
                            exerciseLabel.Text = reader["exercises"].ToString();
                            exerciseLabel.AutoSize = true;
                            panel.Controls.Add(exerciseLabel);

                            Label cID = new Label();
                            cID.Name = "cID";
                            cID.Text = reader["CreatorID"].ToString();
                            cID.AutoSize = true;
                            cID.Visible = false;
                            Label cT = new Label();
                            cT.Name = "cT";
                            cT.Text = reader["CreatorType"].ToString();
                            cT.AutoSize = true;
                            cT.Visible = false;
                            panel.Controls.Add(cID);
                            Label authorLabel = new Label();
                            authorLabel.Text = "|     " + reader["name"].ToString() + "     |";
                            authorLabel.AutoSize = true;
                            panel.Controls.Add(authorLabel);

                            int maxSize = flowLayoutPanel1.Width - workoutLabel.Width - authorLabel.Width;

                            LinkLabel addWorkout = new LinkLabel();
                            addWorkout.Name = "addWorkout";
                            if (!memberType)
                            {
                                addWorkout.Text = "View Report";
                                addWorkout.Click += (sender, e) =>
                                {
                                    viewWorkoutReport viewPlanReport = new viewWorkoutReport(memberType, int.Parse(wIDLabel.Text), memberID);
                                    this.Hide();
                                    viewPlanReport.Show();
                                };
                            }
                            else
                            {
                                if (alreadySubscribed)
                                {
                                    addWorkout.Text = "Unsubscribe";
                                }
                                else
                                {
                                    addWorkout.Text = "Subscribe";
                                }
                                if (addWorkout.Text == "Subscribe")
                                {
                                    addWorkout.Click += (sender, e) =>
                                    {
                                        DialogResult result = MessageBox.Show("Subscribe to plan?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (result == DialogResult.Yes)
                                        {
                                            // add to db
                                            query = "insert into Workout_Followers$ values (@workoutID, @memberID, GETDATE())";

                                            using (SqlConnection connection1 = new SqlConnection(connectionString))
                                            {
                                                connection1.Open();

                                                using (SqlCommand command1 = new SqlCommand(query, connection1))
                                                {
                                                    command1.Parameters.AddWithValue("@workoutID", int.Parse(wIDLabel.Text));
                                                    command1.Parameters.AddWithValue("@memberID", memberID);

                                                    command1.ExecuteNonQuery();
                                                }
                                            }
                                        }

                                    };
                                }
                                else
                                {
                                    addWorkout.Click += (sender, e) =>
                                    {
                                        DialogResult result = MessageBox.Show("Unubscribe to plan?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (result == DialogResult.Yes)
                                        {
                                            // remove from db
                                        }

                                    };
                                }
                            }
                            addWorkout.AutoSize = true;
                            panel.Controls.Add(addWorkout);

                            exerciseLabel.MaximumSize = new Size(flowLayoutPanel1.Width - workoutLabel.Width - authorLabel.Width - addWorkout.Width - 15, 0);

                            int xOffset = workoutLabel.Width + 5;
                            exerciseLabel.Location = new Point(xOffset, 0); // Set label's location
                            xOffset += exerciseLabel.Width + 5;
                            authorLabel.Location = new Point(xOffset, 0); // Set label's location
                            xOffset += authorLabel.Width + 5;
                            addWorkout.Location = new Point(xOffset, 0);

                            // Add the panel to the FlowLayoutPanel
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
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            link3ClickedRows();
            linkLabel3.Enabled = false;
            linkLabel1.Enabled = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.Enabled = false;
            linkLabel3.Enabled = true;
            showRows();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    filterBy = " and creatortype like 'trainer' ";
                    orderBy = false;
                    break;
                case 1:
                    filterBy = " and creatortype like 'member'";
                    orderBy = false;
                break;
                case 2:
                    filterBy = " and goal like 'bulking' ";
                    orderBy = false;
                break;
                case 3:
                    filterBy = " and goal like 'cutting' ";
                    orderBy = false;
                break;
                case 4:
                    filterBy = " and goal like 'Weight Loss' ";
                    orderBy = false;
                break;
                case 5:
                    filterBy = " and experienceLevel like 'beginner' ";
                    orderBy = false;
                break;
                case 6:
                    filterBy = " and experienceLevel like 'Intermediate' ";
                    orderBy = false;
                break;
                case 7:
                    filterBy = " and experienceLevel like 'Advanced' ";
                    orderBy = false;
                break;
                case 8:
                    filterBy = " order by creationdate ";
                    orderBy = true;
                break;
                case 9:
                    filterBy = " order by creationdate desc ";
                    orderBy = true;
                break;
                default:
                    filterBy = "";
                    orderBy = false;
                break;
            }

            if (comboBox1.SelectedIndex != -1)
            {
                if (linkLabel1.Enabled == true)
                {
                    link3ClickedRows();
                }
                else
                {
                    showRows();
                }
            }
        }
    }
}
