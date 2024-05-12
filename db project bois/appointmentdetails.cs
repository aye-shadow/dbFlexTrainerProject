using db_project_bois;
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
using System.Xml.Linq;
using WindowsFormsApp1;

namespace Db_project_1
{

    public partial class appointmentdetails : Form
    {
        private int memberID;
        public appointmentdetails(int memberID = 1)
        {
            InitializeComponent();
            this.memberID = memberID;
            loadAllAppointments();
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
            string[] data =
            {
                "Trainer15, 01/01/2024",
                "Trainer12, 01/28/2024",
                "Trainer23, 02/11/2024",
                "Trainer7, 02/21/2024",
                "Trainer11, 03/09/2024",
                "Trainer16, 03/20/2024",
                "Trainer5, 04/12/2024",
                "Trainer21, 04/26/2024",
                "Trainer13, 05/16/2024",
                "Trainer9, 06/14/2024",
                "Trainer1, 06/23/2024",
                "Trainer18, 06/29/2024",
                "Trainer3, 07/08/2024",
                "Trainer24, 07/22/2024",
                "Trainer20, 08/15/2024",
                "Trainer8, 08/19/2024",
                "Trainer2, 09/17/2024",
                "Trainer19, 09/25/2024",
                "Trainer6, 10/05/2024",
                "Trainer17, 10/10/2024",
                "Trainer14, 11/07/2024",
                "Trainer4, 11/20/2024",
                "Trainer10, 12/03/2024",
                "Trainer22, 12/18/2024"
            };

            foreach (string row in data)
            {
                string[] parts = row.Split(',');
                string plan = parts[0].Trim();
                string meals = parts[1].Trim();

                Panel panel = new Panel();
                panel.AutoSize = true;
                panel.Dock = DockStyle.Top;
                panel.AutoSize = true;

                Label memberLabel = new Label();
                memberLabel.Text = plan;
                memberLabel.AutoSize = true;
                panel.Controls.Add(memberLabel);

                Label dateLabel = new Label();
                dateLabel.Text = meals;
                dateLabel.AutoSize = true;
                panel.Controls.Add(dateLabel);

                // if author == self then do follwoing:
                LinkLabel viewScheduleLink = new LinkLabel();
                viewScheduleLink.Text = "View";
                viewScheduleLink.AutoSize = true;
                viewScheduleLink.Click += (sender, e) =>
                {
                    memberViewSpecificAppointment editPlan = new memberViewSpecificAppointment(dateLabel.Text, true, memberID);
                    this.Hide();
                    editPlan.Show();
                };
                panel.Controls.Add(viewScheduleLink);

                int xOffset = memberLabel.Width + 5;
                dateLabel.Location = new Point(xOffset, 0); // Set label's location
                xOffset += dateLabel.Width + 5;
                viewScheduleLink.Location = new Point(xOffset, 0); // Set label's location

                // Add the panel to the FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(panel);

                Panel linePanel = new Panel();
                linePanel.BackColor = Color.Black; // Set line color
                linePanel.Height = 1; // Set line height
                linePanel.Dock = DockStyle.Top; // Dock to top of the panels
                flowLayoutPanel1.Controls.Add(linePanel);
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
    }
}
