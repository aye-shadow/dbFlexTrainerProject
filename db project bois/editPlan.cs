using Db_project_1;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace db_project_bois
{
    public partial class editPlan : Form
    {
        private bool memberType;
        private int memberID, planID;
        public editPlan(bool memberType, int memberID, int planID)
        {
            InitializeComponent();
            linkLabel1.Enabled = false;
            this.memberType = memberType;
            this.memberID = memberID;
            this.planID = planID;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial Rounded MT Bold", 8);
            dataGridView1.AllowUserToAddRows = false;
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

        private void AddCheckBoxColumn()
        {
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "Type";
            comboBoxColumn.Name = "comboBoxColumn";
            comboBoxColumn.Items.AddRange("", "Breakfast", "Lunch", "Dinner");
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

        private void loadMeal()
        {
            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
            string query = "SELECT planName, purpose, type, ShareStatus FROM [Dietplan$] WHERE [Dietplan$].ID = @planID", mealType = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@planID", planID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Check if there is a row returned
                        {
                            textBox2.Text = reader["planName"].ToString();
                            int index = comboBox2.FindStringExact(reader["purpose"].ToString());
                            if (index != -1)
                            {
                                comboBox2.SelectedIndex = index;
                            }
                            mealType = reader["type"].ToString();
                            index = comboBox1.FindStringExact(mealType);
                            if (index != -1)
                            {
                                comboBox1.SelectedIndex = index;
                            }
                            if (reader["ShareStatus"].ToString() == "Public")
                            {
                                radioButton2.Checked = true;
                            }
                            else
                            {
                                radioButton1.Checked = true;
                            }
                        }
                    }
                }
            }

            query = "select id as ID, name as Meal, protein as [Protein(g)], carbs as [Carbs(g)], fats as [Fats(g)], fibre as [Fibre(g)], calories as [Calories(kcal)] from meal$ where type like @mealType;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mealType", mealType);

                    connection.Open();

                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    dataGridView1.DataSource = dataTable;

                    AddCheckBoxColumn();

                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.Resizable = DataGridViewTriState.False;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
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
                string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
                string query = "delete from Dietplan$ where ID = @planID; delete from Ditplan_meals$ where DietPlanID = @planID; delete from Diet_plan_followers$ where DietPlanID = @planID;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@planID", planID);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Plan deleted!");
                dietPlan dietPlan = new dietPlan(memberType, memberID);
                this.Hide();
                dietPlan.Show();
            }
        }

        private bool ifNoneEmpty()
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && (radioButton1.Checked || radioButton2.Checked) && AreExactlyThreeComboBoxesSelected())
            {
                return true;
            }
            return false;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Update current plan?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (ifNoneEmpty())
                {
                    if (!AreAllMealTypesSelected())
                    {
                        MessageBox.Show("Please select all 3 meal types!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string planName = textBox2.Text, shareStatus = "";
                        if (radioButton1.Checked)
                        {
                            shareStatus = radioButton1.Text;
                        }
                        else if (radioButton2.Checked)
                        {
                            shareStatus = radioButton2.Text;
                        }

                        string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;";
                        string query = "update Dietplan$ set planName = @planName, ShareStatus = @shareStatus where id = @planID;";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@planID", planID);
                                command.Parameters.AddWithValue("@planName", planName);
                                command.Parameters.AddWithValue("@shareStatus", shareStatus);

                                connection.Open();
                                command.ExecuteNonQuery();
                            }
                        }

                        query = "delete from Ditplan_meals$ where DietPlanID = @planID;";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@planID", planID);

                                connection.Open();
                                command.ExecuteNonQuery();
                            }
                        }

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            DataGridViewComboBoxCell comboBoxCell = row.Cells["comboBoxColumn"] as DataGridViewComboBoxCell;

                            if (comboBoxCell != null && comboBoxCell.Value != null)
                            {
                                string typeMeal = comboBoxCell.Value.ToString();
                                int id = Convert.ToInt32(row.Cells["ID"].Value); // Assuming the ID is in a column named "ID"
                                query = "INSERT INTO [Ditplan_meals$] VALUES (@planID, @id, @typeMeal)";
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    using (SqlCommand command = new SqlCommand(query, connection))
                                    {
                                        command.Parameters.AddWithValue("@planID", planID);
                                        command.Parameters.AddWithValue("@id", id);
                                        command.Parameters.AddWithValue("@typeMeal", typeMeal);

                                        connection.Open();
                                        command.ExecuteNonQuery();
                                    }
                                }

                            }
                        }

                        MessageBox.Show("Plan updated successfully!");
                        dietPlan dietPlan = new dietPlan(memberType, memberID);
                        this.Hide();
                        dietPlan.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Fields cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
