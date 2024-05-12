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
    public partial class editPlan : Form
    {
        private bool memberType;
        private int memberID;
        public editPlan(bool memberType, int memberID)
        {
            InitializeComponent();
            linkLabel1.Enabled = false;
            this.memberType = memberType;
            this.memberID = memberID;
            loadMeal();
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
                dietPlan dietplan = new dietPlan(memberType, memberID);
                this.Hide();
                dietplan.Show();
            }
        }

        private void loadMeal()
        {
            string[] data =
            {
                "Meal1, Carbs1, Protein1, Fats1",
                "Meal2, Carbs2, Protein2, Fats2",
                "Meal3, Carbs3, Protein3, Fats3",
                "Meal4, Carbs4, Protein4, Fats4",
                "Meal5, Carbs5, Protein5, Fats5",
                "Meal6, Carbs6, Protein6, Fats6",
                "Meal7, Carbs7, Protein7, Fats7",
                "Meal8, Carbs8, Protein8, Fats8",
                "Meal9, Carbs9, Protein9, Fats9",
                "Meal10, Carbs10, Protein10, Fats10",
                "Meal11, Carbs11, Protein11, Fats11",
                "Meal12, Carbs12, Protein12, Fats12",
                "Meal13, Carbs13, Protein13, Fats13",
                "Meal14, Carbs14, Protein14, Fats14",
                "Meal15, Carbs15, Protein15, Fats15",
                "Meal16, Carbs16, Protein16, Fats16",
                "Meal17, Carbs17, Protein17, Fats17",
                "Meal18, Carbs18, Protein18, Fats18",
                "Meal19, Carbs19, Protein19, Fats19",
                "Meal20, Carbs20, Protein20, Fats20",
                "Meal21, Carbs21, Protein21, Fats21",
                "Meal22, Carbs22, Protein22, Fats22",
                "Meal23, Carbs23, Protein23, Fats23",
                "Meal24, Carbs24, Protein24, Fats24",
                "Meal25, Carbs25, Protein25, Fats25"
            };

            foreach (string row in data)
            {
                string[] parts = row.Split(',');
                string meal = parts[0].Trim();
                string carbs = parts[1].Trim();
                string protein = parts[2].Trim();
                string fats = parts[3].Trim();

                Panel panel = new Panel();
                panel.AutoSize = true;
                panel.Dock = DockStyle.Top;
                panel.AutoSize = true;

                Label mealLabel = new Label();
                mealLabel.Text = meal;
                mealLabel.AutoSize = true;
                panel.Controls.Add(mealLabel);

                Label carbsLabel = new Label();
                carbsLabel.Text = carbs;
                carbsLabel.AutoSize = true;
                panel.Controls.Add(carbsLabel);

                Label proteinLabel = new Label();
                proteinLabel.Text = protein;
                proteinLabel.AutoSize = true;
                panel.Controls.Add(proteinLabel);

                Label fatsLabel = new Label();
                fatsLabel.Text = fats;
                fatsLabel.AutoSize = true;
                panel.Controls.Add(fatsLabel);

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

                int xOffset = mealLabel.Width + 5;
                carbsLabel.Location = new Point(xOffset, 0); // Set label's location
                xOffset += carbsLabel.Width + 5;
                proteinLabel.Location = new Point(xOffset, 0); // Set label's location
                xOffset += proteinLabel.Width + 5;
                fatsLabel.Location = new Point(xOffset, 0);
                xOffset += proteinLabel.Width + 5;
                subPlan.Location = new Point(xOffset, 0);

                flowLayoutPanel1.Controls.Add(panel);

                Panel linePanel = new Panel();
                linePanel.BackColor = Color.Black; // Set line color
                linePanel.Height = 1; // Set line height
                linePanel.Dock = DockStyle.Top; // Dock to top of the panel
                flowLayoutPanel1.Controls.Add(linePanel);
            }
        }

        private void editPlan_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            linkLabel1.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            linkLabel1.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
                dietPlan dietPlan = new dietPlan(memberType, memberID);
                this.Hide();
                dietPlan.Show();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Update current plan?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // udpate existing plan in db

                MessageBox.Show("Plan updated successfully!");
                dietPlan dietPlan = new dietPlan(memberType, memberID);
                this.Hide();
                dietPlan.Show();
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
