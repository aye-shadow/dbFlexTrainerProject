using db_project_bois;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Numerics;
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
        private string filterBy;
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
            col.Text = "Edit";
            col.UseColumnTextForLinkValue = true;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;

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

        private void showRows(string filterBy = "", bool orderBy = false)
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
            string query = "SELECT [Dietplan$].id as [Plan ID], planName as [Plan Name], STRING_AGG([name], ', ') AS Meals, creationDate " +
                "FROM [Dietplan$] " +
                "FULL JOIN [Ditplan_meals$] ON [Ditplan_meals$].DietPlanID = [Dietplan$].ID " +
                "FULL JOIN meal$ ON [Ditplan_meals$].MealID = meal$.id " +
                "FULL JOIN Trainer$ AS trainer ON [Dietplan$].CreatorID = trainer.ID " +
                "FULL JOIN Member$ ON [Dietplan$].CreatorID = Member$.ID " +
                "WHERE [Dietplan$].CreatorID = @memberID AND [Dietplan$].CreatorType like @memberTYPE " + (!orderBy ? filterBy : "") +
                "GROUP BY [Dietplan$].id, planName, creationDate " +
                " UNION " +
                "SELECT Diet_plan_followers$.DietPlanID AS [Plan ID], planName as [Plan Name], STRING_AGG([name], ', ') AS Meals, creationDate " +
                "FROM Diet_plan_followers$ " +
                "FULL JOIN [Dietplan$] ON Diet_plan_followers$.DietPlanID = [Dietplan$].id " +
                "FULL JOIN [Ditplan_meals$] ON [Ditplan_meals$].DietPlanID = [Dietplan$].ID " +
                "FULL JOIN meal$ ON [Ditplan_meals$].MealID = meal$.id " +
                "FULL JOIN Trainer$ AS trainer ON Diet_plan_followers$.MemberID = trainer.ID " +
                "FULL JOIN Member$ ON Diet_plan_followers$.MemberID = Member$.ID " +
                "WHERE Diet_plan_followers$.MemberID = @memberID " + (!orderBy ? filterBy : "") +
                "GROUP BY Diet_plan_followers$.DietPlanID, planName, creationDate" +
                (orderBy ? filterBy : "") + ";";

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
                col.Text = "(Un)subscribe";

                string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int planID = Convert.ToInt32(row.Cells["Plan ID"].Value);
                    string query = "SELECT * FROM Diet_plan_followers$ JOIN Member$ ON Member$.ID = Diet_plan_followers$.MemberID WHERE DietPlanID = @planID and MemberID = @memberID";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@memberID", memberID);
                            command.Parameters.AddWithValue("@planID", planID);

                            connection.Open();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    row.Cells["Link"].Value = "Unsubscribe";

                                }
                                else
                                {
                                    row.Cells["Link"].Value = "Subscribe";
                                }
                            }
                        }
                    }
                }
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
                    else if (dataGridView1[e.ColumnIndex, e.RowIndex].Value?.ToString() == "(Un)subscribe")
                    {
                        string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
                        string query = "SELECT * FROM Diet_plan_followers$ JOIN Member$ ON Member$.ID = Diet_plan_followers$.MemberID WHERE DietPlanID = @planID and MemberID = @memberID";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@memberID", memberID);
                                command.Parameters.AddWithValue("@planID", planID);

                                connection.Open();

                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        // unsubscribe
                                        query = "DELETE FROM [Diet_plan_followers$] WHERE [DietPlanID] = @planID and [MemberID] = @memberID;";
                                        using (SqlConnection connection1 = new SqlConnection(connectionString))
                                        {
                                            using (SqlCommand command1 = new SqlCommand(query, connection1))
                                            {
                                                command1.Parameters.AddWithValue("@memberID", memberID);
                                                command1.Parameters.AddWithValue("@planID", planID);

                                                connection1.Open();

                                                command1.ExecuteNonQuery();
                                            }
                                        }
                                        MessageBox.Show("Plan successfuly unsubscribed!");
                                    }
                                    else
                                    {
                                        // subscribe
                                        query = "INSERT INTO [Diet_plan_followers$] VALUES (@planID, @memberID, GETDATE());";
                                        using (SqlConnection connection1 = new SqlConnection(connectionString))
                                        {
                                            using (SqlCommand command1 = new SqlCommand(query, connection1))
                                            {
                                                command1.Parameters.AddWithValue("@memberID", memberID);
                                                command1.Parameters.AddWithValue("@planID", planID);

                                                connection1.Open();

                                                command1.ExecuteNonQuery();
                                            }
                                        }
                                        MessageBox.Show("Plan successfuly subscribed!");
                                    }
                                }
                            }
                        }
                        manageDietPlan manageDietPlan = new manageDietPlan(memberType, memberID);
                        this.Hide();
                        manageDietPlan.Show();
                    }
                    else if (dataGridView1[e.ColumnIndex, e.RowIndex].Value?.ToString() == "Edit")
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
                        string query = "SELECT * FROM Dietplan$ where id = @planID and CreatorID = @memberID and CreatorType like @memberTYPE";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@memberID", memberID);
                                command.Parameters.AddWithValue("@planID", planID);
                                command.Parameters.AddWithValue("@memberTYPE", memberTYPE);

                                connection.Open();

                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        editPlan editPlan = new editPlan(memberType, memberID, planID);
                                        this.Hide();
                                        editPlan.Show();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void linkLabel3ShowRows(string filterBy = "", bool orderBy = false)
        {
            dataGridView1.CellContentClick -= DataGridView1_CellContentClick;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string memberTYPE = "";
                if (memberType)
                {
                    memberTYPE = "Member";
                }
                else
                {
                    memberTYPE = "Trainer";
                }
                string query = "SELECT [Dietplan$].id as [Plan ID], planName as [Plan Name], STRING_AGG([name], ', ') AS Meals, " +
                    "CONCAT(" +
                    "CASE WHEN CreatorType = 'Trainer' THEN trainer.firstname ELSE member.firstname END, ' ', " +
                    "CASE WHEN CreatorType = 'Trainer' THEN trainer.lastname ELSE member.lastname END) AS Author, " +
                    "CreatorType FROM [Dietplan$] " +
                    "JOIN [Ditplan_meals$] ON [Ditplan_meals$].DietPlanID = [Dietplan$].ID " +
                    "JOIN meal$ ON [Ditplan_meals$].MealID = meal$.id " +
                    "LEFT JOIN Trainer$ AS trainer ON [Dietplan$].CreatorID = trainer.ID AND CreatorType = 'Trainer' " +
                    "LEFT JOIN Member$ AS member ON [Dietplan$].CreatorID = member.ID AND CreatorType = 'Member' " +
                    "WHERE ShareStatus LIKE 'public' AND creatorID <> @memberID AND creatorType <> @memberTYPE " + (!orderBy ? filterBy : "") +
                    "GROUP BY [Dietplan$].id, planName, CreatorType, trainer.firstname, trainer.lastname, member.firstname, member.lastname, creationDate" +
                    (orderBy ? filterBy : ";");

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@memberID", memberID);
                command.Parameters.AddWithValue("@memberType", memberTYPE);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }

            AddLinkColumn();
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel3ShowRows();

            linkLabel3.Enabled = false;
            linkLabel1.Enabled = true;
            comboBox1.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool orderBy = false;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    filterBy = " and creatorType like 'Trainer' ";
                    break;
                case 1:
                    filterBy = " and creatorType like 'Member' ";
                    break;
                case 2:
                    filterBy = " and Dietplan$.type like 'Vegetarian' ";
                    break;
                case 3:
                    filterBy = " and Dietplan$.type like 'Vegan' ";
                    break;
                case 4:
                    filterBy = " and Dietplan$.type like 'Pescatarian' ";
                    break;
                case 5:
                    filterBy = " and Dietplan$.type like 'Keto' ";
                    break;
                case 6:
                    filterBy = " and Dietplan$.type like 'Paleo' ";
                    break;
                case 7:
                    filterBy = " and purpose like 'Muscle Gain' ";
                    break;
                case 8:
                    filterBy = " and purpose like 'Weight Loss' ";
                    break;
                case 9:
                    filterBy = " and purpose like 'Maintenance' ";
                    break;
                case 10:
                    filterBy = " order by creationDate desc ";
                    orderBy = true;
                    break;
                case 11:
                    filterBy = " order by creationDate ";
                    orderBy = true;
                    break;
                default:
                    filterBy = "";
                    break;
            }

            if (comboBox1.SelectedIndex != -1)
            {
                if (linkLabel1.Enabled == true)
                {
                    dataGridView1.CellContentClick -= DataGridView1_CellContentClick;
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    linkLabel3ShowRows(filterBy, orderBy);
                }
                else
                {
                    dataGridView1.CellContentClick -= DataGridView1_CellContentClick;
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    showRows(filterBy, orderBy);
                }
            }
        }
    }
}
