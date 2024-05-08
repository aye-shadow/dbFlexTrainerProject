using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace db_project_bois
{
    public partial class createDietPlan : Form
    {
        private bool memberType;
        public createDietPlan(bool memberType)
        {
            InitializeComponent();
            this.memberType = memberType;
            loadMeals();
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
            if (!string.IsNullOrEmpty(textBox2.Text) || comboBox1.SelectedIndex != -1 || comboBox2.SelectedIndex != -1 || comboBox3.SelectedIndex != -1 || (radioButton1.Checked || radioButton2.Checked) || IsAnyCheckBoxChecked())
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
            if (!string.IsNullOrEmpty(textBox2.Text) && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1 && (radioButton1.Checked || radioButton2.Checked) && IsAnyCheckBoxChecked())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ifNoneEmpty())
            {
                MessageBox.Show("Plan successfully created!");
                manageDietPlan manageDietPlan = new manageDietPlan(memberType);
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
                manageDietPlan manageDietPlan = new manageDietPlan(memberType);
                this.Hide();
                manageDietPlan.Show();
            }
        }

        private void loadMeals()
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
                subPlan.Text = "Add";
                subPlan.AutoSize = true;
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
