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
using WindowsFormsApp1;

namespace db_project_bois
{
    public partial class viewWorkout : Form
    {
        private bool memberType;
        public viewWorkout(bool memberType)
        {
            InitializeComponent();
            this.memberType = memberType;
            linkLabel1.Enabled = false;
            showRows();
        }

        private void showRows()
        {
            flowLayoutPanel1.Controls.Clear();

            string[] data =
            {
                "Workout1, Exercise1.1 Exercise1.2 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3, Author1",
                "Workout2, Exercise2.1 Exercise2.2 Exercise2.3, Author2",
                "Workout3, Exercise3.1 Exercise3.2 Exercise3.3, Author3",
                "Workout4, Exercise4.1 Exercise4.2 Exercise4.3, Author4",
                "Workout5, Exercise5.1 Exercise5.2 Exercise5.3, Author5",
                "Workout6, Exercise6.1 Exercise6.2 Exercise6.3, Author6",
                "Workout7, Exercise7.1 Exercise7.2 Exercise7.3, Author7",
                "Workout8, Exercise8.1 Exercise8.2 Exercise8.3, Author8",
                "Workout9, Exercise9.1 Exercise9.2 Exercise9.3, Author9",
                "Workout10, Exercise10.1 Exercise10.2 Exercise10.3, Author10",
                "Workout11, Exercise11.1 Exercise11.2 Exercise11.3, Author11",
                "Workout12, Exercise12.1 Exercise12.2 Exercise12.3, Author12",
                "Workout13, Exercise13.1 Exercise13.2 Exercise13.3, Author13",
                "Workout14, Exercise14.1 Exercise14.2 Exercise14.3, Author14",
                "Workout15, Exercise15.1 Exercise15.2 Exercise15.3, Author15",
                "Workout16, Exercise16.1 Exercise16.2 Exercise16.3, Author16",
                "Workout17, Exercise17.1 Exercise17.2 Exercise17.3, Author17",
                "Workout18, Exercise18.1 Exercise18.2 Exercise18.3, Author18",
                "Workout19, Exercise19.1 Exercise19.2 Exercise19.3, Author19",
                "Workout20, Exercise20.1 Exercise20.2 Exercise20.3, Author20",
                "Workout21, Exercise21.1 Exercise21.2 Exercise21.3, Author21",
                "Workout22, Exercise22.1 Exercise22.2 Exercise22.3, Author22",
                "Workout23, Exercise23.1 Exercise23.2 Exercise23.3, Author23",
                "Workout24, Exercise24.1 Exercise24.2 Exercise24.3, Author24",
                "Workout25, Exercise25.1 Exercise25.2 Exercise25.3, Author25"

            };

            foreach (string row in data)
            {
                string[] parts = row.Split(',');
                string plan = parts[0].Trim();
                string meals = parts[1].Trim();
                string authors = parts[2].Trim();

                Panel panel = new Panel();
                panel.AutoSize = true;
                panel.Dock = DockStyle.Top;
                panel.AutoSize = true;

                Label workoutLabel = new Label();
                workoutLabel.Text = plan;
                workoutLabel.AutoSize = true;
                panel.Controls.Add(workoutLabel);

                Label exerciseLabel = new Label();
                exerciseLabel.Text = meals;
                exerciseLabel.AutoSize = true;
                panel.Controls.Add(exerciseLabel);

                Label authorLabel = new Label();
                authorLabel.Text = authors;
                authorLabel.AutoSize = true;
                panel.Controls.Add(authorLabel);

                int maxSize = flowLayoutPanel1.Width - workoutLabel.Width - authorLabel.Width;

                // if author == self then do follwoing:
                LinkLabel editLink = new LinkLabel();
                editLink.Text = "Edit";
                editLink.AutoSize = true;
                editLink.Click += (sender, e) =>
                {
                    editWorkout editWorkout = new editWorkout(memberType);
                    this.Hide();
                    editWorkout.Show();
                };
                panel.Controls.Add(editLink);
                maxSize -= editLink.Width;

                exerciseLabel.MaximumSize = new Size(maxSize - 15, 0);

                int xOffset = workoutLabel.Width + 5;
                exerciseLabel.Location = new Point(xOffset, 0); // Set label's location
                xOffset += exerciseLabel.Width + 5;
                authorLabel.Location = new Point(xOffset, 0); // Set label's location
                xOffset += authorLabel.Width + 5;
                editLink.Location = new Point(xOffset, 0); // Set label's location

                // Add the panel to the FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(panel);

                Panel linePanel = new Panel();
                linePanel.BackColor = Color.Black; // Set line color
                linePanel.Height = 1; // Set line height
                linePanel.Dock = DockStyle.Top; // Dock to top of the panel
                flowLayoutPanel1.Controls.Add(linePanel);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            workoutPlan workoutPlan = new workoutPlan(memberType);
            this.Hide();
            workoutPlan.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            flowLayoutPanel1.Controls.Clear();

            string[] data =
            {
                "Workout1, Exercise1.1 Exercise1.2 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3 Exercise1.3, Author1",
                "Workout2, Exercise2.1 Exercise2.2 Exercise2.3, Author2",
                "Workout3, Exercise3.1 Exercise3.2 Exercise3.3, Author3",
                "Workout4, Exercise4.1 Exercise4.2 Exercise4.3, Author4",
                "Workout5, Exercise5.1 Exercise5.2 Exercise5.3, Author5",
                "Workout6, Exercise6.1 Exercise6.2 Exercise6.3, Author6",
                "Workout7, Exercise7.1 Exercise7.2 Exercise7.3, Author7",
                "Workout8, Exercise8.1 Exercise8.2 Exercise8.3, Author8",
                "Workout9, Exercise9.1 Exercise9.2 Exercise9.3, Author9",
                "Workout10, Exercise10.1 Exercise10.2 Exercise10.3, Author10",
                "Workout11, Exercise11.1 Exercise11.2 Exercise11.3, Author11",
                "Workout12, Exercise12.1 Exercise12.2 Exercise12.3, Author12",
                "Workout13, Exercise13.1 Exercise13.2 Exercise13.3, Author13",
                "Workout14, Exercise14.1 Exercise14.2 Exercise14.3, Author14",
                "Workout15, Exercise15.1 Exercise15.2 Exercise15.3, Author15",
                "Workout16, Exercise16.1 Exercise16.2 Exercise16.3, Author16",
                "Workout17, Exercise17.1 Exercise17.2 Exercise17.3, Author17",
                "Workout18, Exercise18.1 Exercise18.2 Exercise18.3, Author18",
                "Workout19, Exercise19.1 Exercise19.2 Exercise19.3, Author19",
                "Workout20, Exercise20.1 Exercise20.2 Exercise20.3, Author20",
                "Workout21, Exercise21.1 Exercise21.2 Exercise21.3, Author21",
                "Workout22, Exercise22.1 Exercise22.2 Exercise22.3, Author22",
                "Workout23, Exercise23.1 Exercise23.2 Exercise23.3, Author23",
                "Workout24, Exercise24.1 Exercise24.2 Exercise24.3, Author24",
                "Workout25, Exercise25.1 Exercise25.2 Exercise25.3, Author25"

            };

            foreach (string row in data)
            {
                string[] parts = row.Split(',');
                string plan = parts[0].Trim();
                string meals = parts[1].Trim();
                string authors = parts[2].Trim();

                Panel panel = new Panel();
                panel.AutoSize = true;
                panel.Dock = DockStyle.Top;
                panel.AutoSize = true;

                Label workoutLabel = new Label();
                workoutLabel.Text = plan;
                workoutLabel.AutoSize = true;
                panel.Controls.Add(workoutLabel);

                Label exerciseLabel = new Label();
                exerciseLabel.Text = meals;
                exerciseLabel.AutoSize = true;
                panel.Controls.Add(exerciseLabel);

                Label authorLabel = new Label();
                authorLabel.Text = authors;
                authorLabel.AutoSize = true;
                panel.Controls.Add(authorLabel);

                int maxSize = flowLayoutPanel1.Width - workoutLabel.Width - authorLabel.Width;

                LinkLabel addWorkout = new LinkLabel();
                if (memberType == false)
                {
                    addWorkout.Text = "View Report";
                    addWorkout.Click += (sender, e) =>
                    {
                        viewWorkoutReport viewPlanReport = new viewWorkoutReport(memberType);
                        this.Hide();
                        viewPlanReport.Show();
                    };
                }
                else
                {
                    // // if user already subscribed to plan
                    // addWorkout.Text = "Unubscribe";
                    addWorkout.Text = "Subscribe";
                    if (addWorkout.Text == "Subscribe")
                    {
                        addWorkout.Click += (sender, e) =>
                        {
                            DialogResult result = MessageBox.Show("Subscribe to " + workoutLabel.Text + " by " + authorLabel.Text + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                // add to db
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

            linkLabel3.Enabled = false;
            linkLabel1.Enabled = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.Enabled = false;
            linkLabel3.Enabled = true;
            comboBox1.SelectedIndex = -1;
            showRows();
        }
    }
}
