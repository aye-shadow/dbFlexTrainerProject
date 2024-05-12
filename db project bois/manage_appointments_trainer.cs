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

namespace WindowsFormsApp1
{
    public partial class manage_appointments_trainer : Form
    {
        public int id;
        public string gname;
        public manage_appointments_trainer(int id, string gymname)
        {
            InitializeComponent();
            loadAppointmentDate();
            this.id = id;
            gname = gymname;
        }


        private void manage_appointments_trainer_Load(object sender, EventArgs e)
        {

        }

        private void loadAppointmentDate()
        {
            // load all appointments a trainer has from db into list

            flowLayoutPanel1.Controls.Clear();

            string[] data =
            {
                "Member15, 01/01/2024",
                "Member12, 01/28/2024",
                "Member23, 02/11/2024",
                "Member7, 02/21/2024",
                "Member11, 03/09/2024",
                "Member16, 03/20/2024",
                "Member5, 04/12/2024",
                "Member21, 04/26/2024",
                "Member13, 05/16/2024",
                "Member9, 06/14/2024",
                "Member1, 06/23/2024",
                "Member18, 06/29/2024",
                "Member3, 07/08/2024",
                "Member24, 07/22/2024",
                "Member20, 08/15/2024",
                "Member8, 08/19/2024",
                "Member2, 09/17/2024",
                "Member19, 09/25/2024",
                "Member6, 10/05/2024",
                "Member17, 10/10/2024",
                "Member14, 11/07/2024",
                "Member4, 11/20/2024",
                "Member10, 12/03/2024",
                "Member22, 12/18/2024"
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
                    trainerAppointmentDetails editPlan = new trainerAppointmentDetails(gname, true, id, dateLabel.Text);
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
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Trainer_home trainer_Home = new Trainer_home(id);
            this.Hide();
            trainer_Home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trainerAppointmentDetails editPlan = new trainerAppointmentDetails(gname, false, id);
            this.Hide();
            editPlan.Show();
        }
    }
}
