using db_project_bois;
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
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Db_project_1
{
    public partial class dietPlan : Form
    {
        private bool memberType;
        private int memberID;
        public dietPlan(bool memberType, int memberID)
        {
            InitializeComponent();
            linkLabel1.Enabled = false;
            this.memberType = memberType;
            this.memberID = memberID;
            showRows();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.Enabled = false;
            linkLabel3.Enabled = true;
            comboBox1.SelectedIndex = -1;
            showRows();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manageDietPlan manageDietPlan = new manageDietPlan(memberType, memberID);
        }
        private void showRows()
        {
            flowLayoutPanel1.Controls.Clear();

            string[] data =
            {
                "Plan1, Meal1.1 Meal1.2 Meal1.3 Meal1.3 Meal1.3 Meal1.3 Meal1.3 Meal1.3 Meal1.3 Meal1.3 Meal1.3 Meal1.3 Meal1.3 Meal1.3, Author1",
                "Plan2, Meal2.1 Meal2.2 Meal2.3, Author2",
                "Plan3, Meal3.1 Meal3.2 Meal3.3, Author3",
                "Plan4, Meal4.1 Meal4.2 Meal4.3, Author4",
                "Plan5, Meal5.1 Meal5.2 Meal5.3, Author5",
                "Plan6, Meal6.1 Meal6.2 Meal6.3, Author6",
                "Plan7, Meal7.1 Meal7.2 Meal7.3, Author7",
                "Plan8, Meal8.1 Meal8.2 Meal8.3, Author8",
                "Plan9, Meal9.1 Meal9.2 Meal9.3, Author9",
                "Plan10, Meal10.1 Meal10.2 Meal10.3, Author10",
                "Plan11, Meal11.1 Meal11.2 Meal11.3, Author11",
                "Plan12, Meal12.1 Meal12.2 Meal12.3, Author12",
                "Plan13, Meal13.1 Meal13.2 Meal13.3, Author13",
                "Plan14, Meal14.1 Meal14.2 Meal14.3, Author14",
                "Plan15, Meal15.1 Meal15.2 Meal15.3, Author15",
                "Plan16, Meal16.1 Meal16.2 Meal16.3, Author16",
                "Plan17, Meal17.1 Meal17.2 Meal17.3, Author17",
                "Plan18, Meal18.1 Meal18.2 Meal18.3, Author18",
                "Plan19, Meal19.1 Meal19.2 Meal19.3, Author19",
                "Plan20, Meal20.1 Meal20.2 Meal20.3, Author20",
                "Plan21, Meal21.1 Meal21.2 Meal21.3, Author21",
                "Plan22, Meal22.1 Meal22.2 Meal22.3, Author22",
                "Plan23, Meal23.1 Meal23.2 Meal23.3, Author23",
                "Plan24, Meal24.1 Meal24.2 Meal24.3, Author24",
                "Plan25, Meal25.1 Meal25.2 Meal25.3, Author25"

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

                Label planLabel = new Label();
                planLabel.Text = plan;
                planLabel.AutoSize = true;
                panel.Controls.Add(planLabel);

                Label mealLabel = new Label();
                mealLabel.Text = meals;
                mealLabel.AutoSize = true;
                panel.Controls.Add(mealLabel);

                Label authorLabel = new Label();
                authorLabel.Text = authors;
                authorLabel.AutoSize = true;
                panel.Controls.Add(authorLabel);

                int maxSize = flowLayoutPanel1.Width - planLabel.Width - authorLabel.Width;

                // if author == self then do follwoing:
                LinkLabel editLink = new LinkLabel();
                editLink.Text = "Edit";
                editLink.AutoSize = true;
                editLink.Click += (sender, e) =>
                {
                    editPlan editPlan = new editPlan(memberType, memberID);
                    this.Hide();
                    editPlan.Show();
                };
                panel.Controls.Add(editLink);
                maxSize -= editLink.Width;

                mealLabel.MaximumSize = new Size(maxSize - 15, 0);

                int xOffset = planLabel.Width + 5;
                mealLabel.Location = new Point(xOffset, 0); // Set label's location
                xOffset += mealLabel.Width + 5;
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // display all shared members plans
            comboBox1.SelectedIndex = -1;
            flowLayoutPanel1.Controls.Clear();

            string[] data =
            {
                "Plan1, Meal1.1 Meal1.2 Meal1.3 Meal1.3 Meal1.3 Meal1.3 Meal1.3 Meal1.3 Meal1.3 Meal1.3 Meal1.3 Meal1.3 Meal1.3 Meal1.3, Author1",
                "Plan2, Meal2.1 Meal2.2 Meal2.3, Author2",
                "Plan3, Meal3.1 Meal3.2 Meal3.3, Author3",
                "Plan4, Meal4.1 Meal4.2 Meal4.3, Author4",
                "Plan5, Meal5.1 Meal5.2 Meal5.3, Author5",
                "Plan6, Meal6.1 Meal6.2 Meal6.3, Author6",
                "Plan7, Meal7.1 Meal7.2 Meal7.3, Author7",
                "Plan8, Meal8.1 Meal8.2 Meal8.3, Author8",
                "Plan9, Meal9.1 Meal9.2 Meal9.3, Author9",
                "Plan10, Meal10.1 Meal10.2 Meal10.3, Author10",
                "Plan11, Meal11.1 Meal11.2 Meal11.3, Author11",
                "Plan12, Meal12.1 Meal12.2 Meal12.3, Author12",
                "Plan13, Meal13.1 Meal13.2 Meal13.3, Author13",
                "Plan14, Meal14.1 Meal14.2 Meal14.3, Author14",
                "Plan15, Meal15.1 Meal15.2 Meal15.3, Author15",
                "Plan16, Meal16.1 Meal16.2 Meal16.3, Author16",
                "Plan17, Meal17.1 Meal17.2 Meal17.3, Author17",
                "Plan18, Meal18.1 Meal18.2 Meal18.3, Author18",
                "Plan19, Meal19.1 Meal19.2 Meal19.3, Author19",
                "Plan20, Meal20.1 Meal20.2 Meal20.3, Author20",
                "Plan21, Meal21.1 Meal21.2 Meal21.3, Author21",
                "Plan22, Meal22.1 Meal22.2 Meal22.3, Author22",
                "Plan23, Meal23.1 Meal23.2 Meal23.3, Author23",
                "Plan24, Meal24.1 Meal24.2 Meal24.3, Author24",
                "Plan25, Meal25.1 Meal25.2 Meal25.3, Author25"

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

                Label planLabel = new Label();
                planLabel.Text = plan;
                planLabel.AutoSize = true;
                panel.Controls.Add(planLabel);

                Label mealLabel = new Label();
                mealLabel.Text = meals;
                mealLabel.AutoSize = true;
                panel.Controls.Add(mealLabel);

                Label authorLabel = new Label();
                authorLabel.Text = authors;
                authorLabel.AutoSize = true;
                panel.Controls.Add(authorLabel);

                LinkLabel addPlan = new LinkLabel();
                if (memberType == false)
                {
                    addPlan.Text = "View Report";
                    addPlan.Click += (sender, e) =>
                    {
                        viewPlanReport viewPlanReport = new viewPlanReport(memberType, memberID);
                        this.Hide();
                        viewPlanReport.Show();
                    };
                }
                else
                {
                    // // if user already subscribed to plan
                    // addPlan.Text = "Unubscribe";
                    addPlan.Text = "Subscribe";
                    if (addPlan.Text == "Subscribe")
                    {
                        addPlan.Click += (sender, e) =>
                        {
                            DialogResult result = MessageBox.Show("Subscribe to " + planLabel.Text + " by " + authorLabel.Text + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                // add to db
                            }

                        };
                    }
                    else
                    {
                        addPlan.Click += (sender, e) =>
                        {
                            DialogResult result = MessageBox.Show("Unubscribe to plan?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                // remove from db
                            }

                        };
                    }
                }
                addPlan.AutoSize = true;
                panel.Controls.Add(addPlan);

                mealLabel.MaximumSize = new Size(flowLayoutPanel1.Width - planLabel.Width - authorLabel.Width - addPlan.Width - 15, 0);

                int xOffset = planLabel.Width + 5;
                mealLabel.Location = new Point(xOffset, 0); // Set label's location
                xOffset += mealLabel.Width + 5;
                authorLabel.Location = new Point(xOffset, 0); // Set label's location
                xOffset += authorLabel.Width + 5;
                addPlan.Location = new Point(xOffset, 0);

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // depending on value chosen, sort values in table

            // if memberType == false then it's a trainer
            if (memberType == false)
            {

            }
            else
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
