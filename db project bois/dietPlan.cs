using db_project_bois;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            dataGridView1.DefaultCellStyle.Font = new Font("Arial Rounded MT Bold", 8);
            dataGridView1.AllowUserToAddRows = false;
            showRows();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dataGridView1.CellContentClick -= DataGridView1_CellContentClick;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            linkLabel1.Enabled = false;
            linkLabel3.Enabled = true;
            comboBox1.SelectedIndex = -1;
            showRows();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manageDietPlan manageDietPlan = new manageDietPlan(memberType, memberID);
            this.Hide();
            manageDietPlan.Show();
        }

        private void AddEditColumn()
        {
            DataGridViewLinkColumn col = new DataGridViewLinkColumn();
            dataGridView1.Columns.Insert(0, col);
            col.HeaderText = "Action";
            col.Name = "Link";
            col.UseColumnTextForLinkValue = true;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;

            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                // if planAuthorID == memberID
                int planID = Convert.ToInt32(dataGridView1.Rows[i].Cells["Plan ID"].Value);
                string query = "SELECT creatorID, creatorType FROM [Dietplan$] WHERE [Dietplan$].[ID] = @planID", memberTYPE = "";
                if (memberType)
                {
                    memberTYPE = "Member";
                }
                else
                {
                    memberTYPE = "Trainer";
                }
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
                                int creatorID = Convert.ToInt32(reader["creatorID"]);
                                string creatorType = reader["creatorType"].ToString();

                                if (creatorID == memberID && creatorType == memberTYPE)
                                {
                                   col.Text = "Edit";
                                }
                            }
                        }
                    }
                }
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name == "Link") // Assuming the name of the CheckBox column is "checkBoxColumn"
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

        private void showRows()
        {
            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
            string memberTYPE = "";
            if (memberType)
            {
                memberTYPE = "Member";
            }
            else
            {
                memberTYPE = "Trainer";
            }
            string query = "SELECT [Dietplan$].id as [Plan ID], planName as [Plan Name], STRING_AGG([name], ', ') AS Meals FROM [Dietplan$] FULL JOIN [Ditplan_meals$] ON [Ditplan_meals$].DietPlanID = [Dietplan$].ID FULL JOIN meal$ ON [Ditplan_meals$].MealID = meal$.id FULL JOIN Trainer$ AS trainer ON [Dietplan$].CreatorID = trainer.ID FULL JOIN Member$ ON [Dietplan$].CreatorID = Member$.ID WHERE [Dietplan$].CreatorID = @memberID AND [Dietplan$].CreatorType like @memberTYPE GROUP BY [Dietplan$].id, planName UNION SELECT Diet_plan_followers$.DietPlanID AS [Plan ID], planName as [Plan Name], STRING_AGG([name], ', ') AS Meals FROM Diet_plan_followers$ FULL JOIN [Dietplan$] ON Diet_plan_followers$.DietPlanID = [Dietplan$].id FULL JOIN [Ditplan_meals$] ON [Ditplan_meals$].DietPlanID = [Dietplan$].ID FULL JOIN meal$ ON [Ditplan_meals$].MealID = meal$.id FULL JOIN Trainer$ AS trainer ON Diet_plan_followers$.MemberID = trainer.ID FULL JOIN Member$ ON Diet_plan_followers$.MemberID = Member$.ID WHERE Diet_plan_followers$.MemberID = @memberID AND [Dietplan$].CreatorType like @memberTYPE GROUP BY Diet_plan_followers$.DietPlanID, planName;";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@memberID", memberID);
                    command.Parameters.AddWithValue("@memberType", memberTYPE);

                    connection.Open();

                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    dataGridView1.DataSource = dataTable;
                }
            }

            AddEditColumn();
        }

        private void AddLinkColumn()
        {
            DataGridViewLinkColumn col = new DataGridViewLinkColumn();
            dataGridView1.Columns.Insert(0, col);
            col.HeaderText = "Action";
            col.Name = "Link";
            if (!memberType)
            {
                col.Text = "View Report";
            }
            else
            {
                // if member not already subscribed
                    col.Text = "Subscribe";
            }
            col.UseColumnTextForLinkValue = true;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name == "Link") 
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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the DataGridViewLinkColumn
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.RowIndex >= 0)
            {
                // Perform the desired action when a link is clicked
                if (dataGridView1[e.ColumnIndex, e.RowIndex] is DataGridViewLinkCell)
                {
                    string cellValue = dataGridView1[e.ColumnIndex, e.RowIndex].Value?.ToString();
                    int planID;
                    int.TryParse(dataGridView1["Plan ID", e.RowIndex].Value?.ToString(), out planID);

                    if (dataGridView1[e.ColumnIndex, e.RowIndex].Value?.ToString() == "View Report")
                    {
                        viewPlanReport viewPlanReport = new viewPlanReport(memberType, memberID, planID);
                        this.Hide();
                        viewPlanReport.Show();
                    }
                    else if (dataGridView1[e.ColumnIndex, e.RowIndex].Value?.ToString() == "Subscribe")
                    {

                    }
                    else if (dataGridView1[e.ColumnIndex, e.RowIndex].Value?.ToString() == "Unsubscribe")
                    {

                    }
                    else if (dataGridView1[e.ColumnIndex, e.RowIndex].Value?.ToString() == "Edit")
                    {
                        editPlan editPlan = new editPlan(memberType, memberID, planID);
                        this.Hide();
                        editPlan.Show();
                    }
                    MessageBox.Show("Link clicked!");
                }
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dataGridView1.CellContentClick -= DataGridView1_CellContentClick;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT [Dietplan$].id as [Plan ID], planName as [Plan Name], STRING_AGG([name], ', ') AS Meals, CONCAT(CASE WHEN CreatorType = 'Trainer' THEN trainer.firstname ELSE member.firstname END, ' ', CASE WHEN CreatorType = 'Trainer' THEN trainer.lastname ELSE member.lastname END) AS Author, CreatorType FROM [Dietplan$] JOIN [Ditplan_meals$] ON [Ditplan_meals$].DietPlanID = [Dietplan$].ID JOIN meal$ ON [Ditplan_meals$].MealID = meal$.id LEFT JOIN Trainer$ AS trainer ON [Dietplan$].CreatorID = trainer.ID AND CreatorType = 'Trainer' LEFT JOIN Member$ AS member ON [Dietplan$].CreatorID = member.ID AND CreatorType = 'Member' WHERE ShareStatus LIKE 'public' GROUP BY [Dietplan$].id, planName, CreatorType, trainer.firstname, trainer.lastname, member.firstname, member.lastname;";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }

            AddLinkColumn();

            linkLabel3.Enabled = false;
            linkLabel1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
