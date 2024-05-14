using Db_project_1;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace db_project_bois
{
    public partial class editWorkout : Form
    {
        private bool memberType;
        private int memberID, workoutID;
        public editWorkout(bool memberType, int memberID, int workoutID)
        {
            InitializeComponent();
            this.memberType = memberType;
            this.memberID = memberID;
            this.workoutID = workoutID;
            linkLabel1.Enabled = false;
            loadWorkout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.No;
            if (linkLabel1.Enabled == true)
            {
                result = MessageBox.Show("Changes will be lost. GO BACK?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (linkLabel1.Enabled == false || result == DialogResult.Yes)
            {
                viewWorkout dietplan = new viewWorkout(memberType, memberID);
                this.Hide();
                dietplan.Show();
            }
        }
        
        private void loadWorkout()
        {
            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;";

            string query = "select workoutname, goal, experienceLevel, ShareStatus " +
                "from Workout_plan$ " +
                "where id = @workoutID";
            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();

                using (SqlCommand command2 = new SqlCommand(query, connection2))
                {
                    command2.Parameters.AddWithValue("@workoutID", workoutID);

                    using (SqlDataReader reader2 = command2.ExecuteReader())
                    {
                        if (reader2.HasRows)
                        {
                            while(reader2.Read())
                            {
                                textBox2.Text = reader2["workoutname"].ToString();
                                comboBox2.SelectedIndex = comboBox2.FindStringExact(reader2["goal"].ToString());
                                comboBox1.SelectedIndex = comboBox1.FindStringExact(reader2["experienceLevel"].ToString());
                                if (reader2["ShareStatus"].ToString() == "Public")
                                {
                                    radioButton2.Checked = true;
                                }
                                else
                                {
                                    radioButton1.Checked = true;
                                }
                                break;
                            }
                        }
                    }
                }
            }


            query = "select Exercise$.ID as exID, Exercise$.Name as exName " +
                "from Exercise$";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int exID = int.Parse(reader["exID"].ToString()), setsNum = 0, repsNum = 0, restIntNum = 0;
                                bool exInWorkout = false;
                                query = "select ExerciseID, Sets, reps, RestInterval " +
                                    "from Workout_exercise$ " +
                                    "where WorkoutID = @workoutID and ExerciseID = @exID";
                                using (SqlConnection connection1 = new SqlConnection(connectionString))
                                {
                                    connection1.Open();

                                    using (SqlCommand command1 = new SqlCommand(query, connection1))
                                    {
                                        command1.Parameters.AddWithValue("@workoutID", workoutID);
                                        command1.Parameters.AddWithValue("@exID", exID);

                                        using (SqlDataReader reader1 = command1.ExecuteReader())
                                        {
                                            if (reader1.HasRows)
                                            {
                                                while(reader1.Read())
                                                {
                                                    exInWorkout = true;
                                                    setsNum = Convert.ToInt32(reader1["sets"]);
                                                    repsNum = Convert.ToInt32(reader1["reps"]);
                                                    restIntNum = Convert.ToInt32(reader1["RestInterval"]);
                                                }
                                            }
                                        }
                                    }
                                }

                                Panel panel = new Panel();
                                panel.AutoSize = true;
                                panel.Dock = DockStyle.Top;
                                panel.AutoSize = true;

                                Label exIDLabel = new Label();
                                exIDLabel.Name = "exIDLabel";
                                exIDLabel.Text = exID.ToString();
                                exIDLabel.AutoSize = true;
                                exIDLabel.Visible = false;
                                panel.Controls.Add(exIDLabel);
                                Label exerciseLabel = new Label();
                                exerciseLabel.Text = reader["exName"].ToString();
                                exerciseLabel.AutoSize = true;
                                panel.Controls.Add(exerciseLabel);

                                Label setsLabel = new Label();
                                setsLabel.Text = "Sets:";
                                setsLabel.AutoSize = true;
                                panel.Controls.Add(setsLabel);
                                NumericUpDown setsCounter = new NumericUpDown();
                                setsCounter.Name = "setsCounter";
                                setsCounter.Minimum = 1;
                                setsCounter.Maximum = 100; // Adjust as needed
                                setsCounter.Value = 1; // Initial value
                                if (exInWorkout)
                                {
                                    setsCounter.Value = setsNum;
                                }
                                panel.Controls.Add(setsCounter);

                                Label repsLabel = new Label();
                                repsLabel.Text = "Reps:";
                                repsLabel.AutoSize = true;
                                panel.Controls.Add(repsLabel);
                                NumericUpDown repsCounter = new NumericUpDown();
                                repsCounter.Name = "repsCounter";
                                repsCounter.Minimum = 1;
                                repsCounter.Maximum = 100; // Adjust as needed
                                repsCounter.Value = 1; // Initial value
                                if (exInWorkout)
                                {
                                    repsCounter.Value = repsNum; // Initial value
                                }
                                panel.Controls.Add(repsCounter);

                                Label restIntLabel = new Label();
                                restIntLabel.Text = "Reps:";
                                restIntLabel.AutoSize = true;
                                panel.Controls.Add(restIntLabel);
                                NumericUpDown restIntCounter = new NumericUpDown();
                                restIntCounter.Name = "restIntCounter";
                                restIntCounter.Increment = 5; // Set the increment value to 5
                                restIntCounter.Minimum = 1;
                                restIntCounter.Maximum = 3600; // Adjust as needed
                                restIntCounter.Value = 10; // Initial value
                                if (exInWorkout)
                                {
                                    restIntCounter.Value = restIntNum; // Initial value
                                }
                                panel.Controls.Add(restIntCounter);


                                CheckBox subPlan = new CheckBox();
                                subPlan.Text = "Add";
                                subPlan.AutoSize = true;
                                if (exInWorkout)
                                {
                                    subPlan.Checked = true;
                                }
                                if (linkLabel1.Enabled == false)
                                {
                                    subPlan.CheckedChanged += (sender, e) =>
                                    {
                                        linkLabel1.Enabled = true;
                                    };
                                }
                                panel.Controls.Add(subPlan);

                                int xOffset = exerciseLabel.Width + 5;
                                setsLabel.Location = new Point(xOffset, 0);
                                xOffset += setsLabel.Width;
                                setsCounter.Location = new Point(xOffset, 0);
                                xOffset += setsCounter.Width + 5;
                                repsLabel.Location = new Point(xOffset, 0);
                                xOffset += repsLabel.Width;
                                repsCounter.Location = new Point(xOffset, 0);
                                xOffset += repsCounter.Width + 5;
                                restIntLabel.Location = new Point(xOffset, 0);
                                xOffset += restIntLabel.Width;
                                restIntCounter.Location = new Point(xOffset, 0);
                                xOffset += restIntCounter.Width + 5;
                                subPlan.Location = new Point(xOffset, 0);

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
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            linkLabel1.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            linkLabel1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            linkLabel1.Enabled = true;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to delete this plan?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;";
                string query = "  delete from Workout_plan$" +
                    "  where ID = @workoutID;" +
                    "  delete from Workout_exercise$" +
                    "  where WorkoutID = @workoutID;" +
                    "  delete from Workout_Followers$" +
                    "  where WorkoutID = @workoutID";
                using (SqlConnection connection2 = new SqlConnection(connectionString))
                {
                    connection2.Open();

                    using (SqlCommand command2 = new SqlCommand(query, connection2))
                    {
                        command2.Parameters.AddWithValue("@workoutID", workoutID);
                        command2.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Plan deleted!");
                viewWorkout dietplan = new viewWorkout(memberType, memberID);
                this.Hide();
                dietplan.Show();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Update current plan?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // udpate existing plan in db
                string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;";
                string newName = textBox2.Text, status = "";
                if (radioButton2.Checked)
                {
                    status = "Public";
                }
                else
                {
                    status = "Private";
                }
                string query = "update Workout_plan$ " +
                    "set workoutName = @newName, sharestatus = @status " +
                    "where id = @workoutID; " +
                    "delete from Workout_exercise$ " +
                    "where WorkoutID = @workoutID;";
                MessageBox.Show(workoutID.ToString());
                using (SqlConnection connection2 = new SqlConnection(connectionString))
                {
                    connection2.Open();

                    using (SqlCommand command2 = new SqlCommand(query, connection2))
                    {
                        command2.Parameters.AddWithValue("@workoutID", workoutID);
                        command2.Parameters.AddWithValue("@newName", newName);
                        command2.Parameters.AddWithValue("@status", status);
                        command2.ExecuteNonQuery();
                    }
                }

                foreach (Control control in flowLayoutPanel1.Controls)
                {

                    if (control is Panel panel)
                    {
                        CheckBox checkBox = panel.Controls.OfType<CheckBox>().FirstOrDefault();

                        int exID = 0, setsNum = 0, repsNum = 0, restInt = 0;

                        if (checkBox != null && checkBox.Checked)
                        {
                            Label label = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "exIDLabel");
                            if (label != null)
                            {
                                exID = int.Parse(label.Text);
                            }

                            NumericUpDown numericUpDown = panel.Controls.OfType<NumericUpDown>().FirstOrDefault(l => l.Name == "setsCounter");
                            if (numericUpDown != null)
                            {
                                setsNum = (int)numericUpDown.Value;
                            }

                            numericUpDown = panel.Controls.OfType<NumericUpDown>().FirstOrDefault(l => l.Name == "repsCounter");
                            if (numericUpDown != null)
                            {
                                repsNum = (int)numericUpDown.Value;
                            }

                            numericUpDown = panel.Controls.OfType<NumericUpDown>().FirstOrDefault(l => l.Name == "restCounter");
                            if (numericUpDown != null)
                            {
                                restInt = (int)numericUpDown.Value;
                            }

                            query = "insert into Workout_exercise$ values (@workoutID, @exID, @setsNum, @repsNum, @setInt);";
                            using (SqlConnection connection1 = new SqlConnection(connectionString))
                            {
                                using (SqlCommand command1 = new SqlCommand(query, connection1))
                                {
                                    connection1.Open();

                                    command1.Parameters.AddWithValue("@workoutID", workoutID);
                                    command1.Parameters.AddWithValue("@exID", exID);
                                    command1.Parameters.AddWithValue("@setsNum", setsNum);
                                    command1.Parameters.AddWithValue("@repsNum", repsNum);
                                    command1.Parameters.AddWithValue("@setInt", restInt);

                                    command1.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("Plan updated successfully!");
                viewWorkout dietplan = new viewWorkout(memberType, memberID);
                this.Hide();
                dietplan.Show();
            }
        }
    }
}
