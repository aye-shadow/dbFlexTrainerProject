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
    public partial class createNewWorkout : Form
    {
        private bool memberType;
        private int memberID;
        public createNewWorkout(bool memberType, int memberID)
        {
            InitializeComponent();
            this.memberType = memberType;   
            this.memberID = memberID;
            loadWorkouts();
        }

        private bool IsAnyCheckBoxChecked()
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control innerControl in panel.Controls)
                    {
                        if (innerControl is CheckBox checkBox && checkBox.Checked)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool ifOneFull()
        {
            if (!string.IsNullOrEmpty(textBox2.Text) || comboBox1.SelectedIndex != -1 || comboBox2.SelectedIndex != -1 || (radioButton1.Checked || radioButton2.Checked) || IsAnyCheckBoxChecked())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ifNoneEmpty()
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && (radioButton1.Checked || radioButton2.Checked) && IsAnyCheckBoxChecked())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void loadWorkouts()
        {
            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
            string query = "select * from exercise$";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
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
                            idLabel.Name = "idLabel";
                            idLabel.Text = reader["id"].ToString();
                            idLabel.AutoSize = true;
                            idLabel.Visible = false;
                            panel.Controls.Add(idLabel);

                            Label exerciseLabel = new Label();
                            exerciseLabel.Text = reader["name"].ToString();
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
                            panel.Controls.Add(repsCounter);

                            Label restLabel = new Label();
                            restLabel.Text = "Rest Interval(s):";
                            restLabel.AutoSize = true;
                            panel.Controls.Add(restLabel);

                            NumericUpDown restCounter = new NumericUpDown();
                            restCounter.Name = "restCounter";
                            restCounter.Minimum = 1;
                            restCounter.Maximum = 3600; // Adjust as needed
                            restCounter.Value = 10; // Initial value
                            panel.Controls.Add(restCounter);

                            CheckBox subPlan = new CheckBox();
                            // if meal already in plan
                            // subPlan.Checked = true;
                            subPlan.Name = "subPlan";
                            subPlan.Text = "Add";
                            subPlan.AutoSize = true;
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
                            restLabel.Location = new Point(xOffset, 0);
                            xOffset += restLabel.Width;
                            restCounter.Location = new Point(xOffset, 0);
                            xOffset += restCounter.Width + 5;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ifNoneEmpty())
            {
                string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
                string memberTYPE = "", status = "";
                if (memberType)
                {
                    memberTYPE = "Member";
                }
                else
                {
                    memberTYPE = "Trainer";
                }
                if (radioButton1.Checked)
                {
                    status = "Private";
                }
                else
                {
                    status = "Public";
                }
                string query = "insert into Workout_plan$ values ((select max(id) from Workout_plan$) + 1, @memberTYPE, @memberID, GETDATE(), @status, @workoutName, @goal, @experienceLevel);";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@memberTYPE", memberTYPE);
                        command.Parameters.AddWithValue("@memberID", memberID);
                        command.Parameters.AddWithValue("@status", status);
                        command.Parameters.AddWithValue("@workoutName", textBox2.Text);
                        command.Parameters.AddWithValue("@goal", comboBox2.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@experienceLevel", comboBox1.SelectedItem.ToString());

                        command.ExecuteNonQuery();
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
                            Label label = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "idLabel");
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

                            query = "insert into Workout_exercise$ values ((select max(id) from Workout_plan$), @exID, @setsNum, @repsNum, @setInt);";
                            using (SqlConnection connection1 = new SqlConnection(connectionString))
                            {
                                using (SqlCommand command1 = new SqlCommand(query, connection1))
                                {
                                    connection1.Open();

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

                MessageBox.Show("Plan successfully created!");
                workoutPlan manageDietPlan = new workoutPlan(memberType, memberID);
                this.Hide();
                manageDietPlan.Show();
            }
            else
            {
                MessageBox.Show("Fields cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = DialogResult.No;
            if (ifOneFull())
            {
                result = MessageBox.Show("All changes will be lost. CANCEL?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (result == DialogResult.Yes || !ifOneFull())
            {
                workoutPlan manageDietPlan = new workoutPlan(memberType, memberID);
                this.Hide();
                manageDietPlan.Show();
            }
        }
    }
}
