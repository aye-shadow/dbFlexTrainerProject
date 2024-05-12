using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace db_project_bois
{
    public partial class createDietPlan : Form
    {
        private bool memberType;
        private int memberID;
        public createDietPlan(bool memberType, int memberID)
        {
            InitializeComponent();
            this.memberType = memberType;
            this.memberID = memberID;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial Rounded MT Bold", 8);
            dataGridView1.AllowUserToAddRows = false;
            linkLabel1.Enabled = false;
        }

        private bool AreAllMealTypesSelected()
        {
            bool breakfastSelected = false;
            bool lunchSelected = false;
            bool dinnerSelected = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewComboBoxCell comboBoxCell = row.Cells["comboBoxColumn"] as DataGridViewComboBoxCell;
                if (comboBoxCell != null && comboBoxCell.Value != null)
                {
                    string selectedMeal = comboBoxCell.Value.ToString();
                    if (selectedMeal == "Breakfast")
                    {
                        breakfastSelected = true;
                    }
                    else if (selectedMeal == "Lunch")
                    {
                        lunchSelected = true;
                    }
                    else if (selectedMeal == "Dinner")
                    {
                        dinnerSelected = true;
                    }
                }
            }

            // Check if all three meal types are selected
            return breakfastSelected && lunchSelected && dinnerSelected;
        }
        private bool AreExactlyThreeComboBoxesSelected()
        {
            int selectedCount = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewComboBoxCell comboBoxCell = row.Cells["comboBoxColumn"] as DataGridViewComboBoxCell;
                if (comboBoxCell != null && comboBoxCell.Value != null)
                {
                    selectedCount++;
                    if (selectedCount > 3)
                    {
                        return false; // More than three ComboBoxes have selected items
                    }
                }
            }
            return selectedCount == 3; // Exactly three ComboBoxes have selected items
        }


        private bool ifNoneEmpty()
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1 && (radioButton1.Checked || radioButton2.Checked) && AreExactlyThreeComboBoxesSelected())
            {
                return true;
            }
            return false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ifNoneEmpty())
            {
                if (!AreAllMealTypesSelected())
                {
                    MessageBox.Show("Please select all 3 meal types!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string memberTYPE = "", planPurpose = comboBox2.Text, planType = comboBox1.Text, portionSize = comboBox3.Text, shareStatus = "";
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
                        shareStatus = radioButton1.Text;
                    }
                    else if (radioButton2.Checked)
                    {
                        shareStatus = radioButton2.Text;
                    }

                    string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;";
                    string query = "INSERT INTO Dietplan$ VALUES ((SELECT MAX(ID) FROM Dietplan$) + 1, @memberTYPE, @memberID, @planPurpose, @planType, @portionSize, @currentDate, @shareStatus)";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@memberTYPE", memberTYPE);
                            command.Parameters.AddWithValue("@memberID", memberID);
                            command.Parameters.AddWithValue("@planPurpose", planPurpose);
                            command.Parameters.AddWithValue("@planType", planType);
                            command.Parameters.AddWithValue("@portionSize", portionSize);
                            command.Parameters.Add("@currentDate", SqlDbType.DateTime).Value = DateTime.Now;
                            command.Parameters.AddWithValue("@shareStatus", shareStatus);

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Plan successfully created!");
                    manageDietPlan manageDietPlan = new manageDietPlan(memberType, memberID);
                    this.Hide();
                    manageDietPlan.Show();
                }
            }
            else
            {
                MessageBox.Show("Fields cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("All changes will be lost. CANCEL?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                manageDietPlan manageDietPlan = new manageDietPlan(memberType, memberID);
                this.Hide();
                manageDietPlan.Show();
            }
        }
        private void AddCheckBoxColumn()
        {
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "Type";
            comboBoxColumn.Name = "comboBoxColumn";
            comboBoxColumn.Items.AddRange("Breakfast", "Lunch", "Dinner");
            dataGridView1.Columns.Insert(0, comboBoxColumn);

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name == "comboBoxColumn") // Assuming the name of the CheckBox column is "checkBoxColumn"
                {
                    column.ReadOnly = false;
                }
                else
                {
                    column.ReadOnly = true;
                }
                column.Resizable = DataGridViewTriState.False;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = comboBox1.SelectedItem?.ToString(); // Ensure selectedType is properly set

            if (!string.IsNullOrEmpty(selectedType))
            {
                if (linkLabel1.Enabled == false)
                {
                    linkLabel1.Enabled = true;
                }

                AddCheckBoxColumn();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null)
                    {
                        checkBoxCell.Value = false;
                    }
                }

                string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT id as ID, name as [Meal Name], protein as [Protein(g)], carbs as [Carbs(g)], fats as [Fats(g)], fibre as [Fibre(g)], calories as Calories from Meal$ WHERE type = @selectedType";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@selectedType", selectedType); // Add parameter for selectedType
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    connection.Open();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
    }
}
