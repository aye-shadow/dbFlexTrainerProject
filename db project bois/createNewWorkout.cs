using Db_project_1;
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

namespace db_project_bois
{
    public partial class createNewWorkout : Form
    {
        private bool memberType;
        public createNewWorkout(bool memberType)
        {
            InitializeComponent();
            this.memberType = memberType;   
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
            string[] data =
            {
                "Workout1",
                "Workout2",
                "Workout3",
                "Workout4",
                "Workout5",
                "Workout6",
                "Workout7",
                "Workout8",
                "Workout9",
                "Workout10",
                "Workout11",
                "Workout12",
                "Workout13",
                "Workout14",
                "Workout15",
                "Workout16",
                "Workout17",
                "Workout18",
                "Workout19",
                "Workout20",
                "Workout21",
                "Workout22",
                "Workout23",
                "Workout24",
                "Workout25"
            };


            foreach (string meal in data)
            {
                Panel panel = new Panel();
                panel.AutoSize = true;
                panel.Dock = DockStyle.Top;
                panel.AutoSize = true;

                Label exerciseLabel = new Label();
                exerciseLabel.Text = meal;
                exerciseLabel.AutoSize = true;
                panel.Controls.Add(exerciseLabel);

                Label setsLabel = new Label();
                setsLabel.Text = "Sets:";
                setsLabel.AutoSize = true;
                panel.Controls.Add(setsLabel);

                NumericUpDown setsCounter = new NumericUpDown();
                setsCounter.Minimum = 1;
                setsCounter.Maximum = 100; // Adjust as needed
                setsCounter.Value = 1; // Initial value
                panel.Controls.Add(setsCounter);

                Label repsLabel = new Label();
                repsLabel.Text = "Reps:";
                repsLabel.AutoSize = true;
                panel.Controls.Add(repsLabel);

                NumericUpDown repsCounter = new NumericUpDown();
                repsCounter.Minimum = 1;
                repsCounter.Maximum = 100; // Adjust as needed
                repsCounter.Value = 1; // Initial value
                panel.Controls.Add(repsCounter);

                CheckBox subPlan = new CheckBox();
                // if meal already in plan
                // subPlan.Checked = true;
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
                xOffset += exerciseLabel.Width;
                setsCounter.Location = new Point(xOffset, 0);
                xOffset += setsCounter.Width + 5;
                repsLabel.Location = new Point(xOffset, 0);
                xOffset += exerciseLabel.Width;
                repsCounter.Location = new Point(xOffset, 0);
                xOffset += setsCounter.Width + 5;
                subPlan.Location = new Point(xOffset, 0);

                flowLayoutPanel1.Controls.Add(panel);

                Panel linePanel = new Panel();
                linePanel.BackColor = Color.Black; // Set line color
                linePanel.Height = 1; // Set line height
                linePanel.Dock = DockStyle.Top; // Dock to top of the panel
                flowLayoutPanel1.Controls.Add(linePanel);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ifNoneEmpty())
            {
                MessageBox.Show("Plan successfully created!");
                workoutPlan manageDietPlan = new workoutPlan(memberType);
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
                workoutPlan manageDietPlan = new workoutPlan(memberType);
                this.Hide();
                manageDietPlan.Show();
            }
        }
    }
}
