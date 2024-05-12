using Db_project_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db_project_bois
{
    public partial class editWorkout : Form
    {
        private bool memberType;
        public editWorkout(bool memberType)
        {
            InitializeComponent();
            this.memberType = memberType;
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
                viewWorkout dietplan = new viewWorkout(memberType);
                this.Hide();
                dietplan.Show();
            }
        }

        private void loadWorkout()
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
                // delete from db

                MessageBox.Show("Plan deleted!");
                viewWorkout dietplan = new viewWorkout(memberType);
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

                MessageBox.Show("Plan updated successfully!");
                viewWorkout dietplan = new viewWorkout(memberType);
                this.Hide();
                dietplan.Show();
            }
        }
    }
}
