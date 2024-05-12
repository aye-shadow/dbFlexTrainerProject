using Db_project_1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace db_project_bois
{
    public partial class viewPlanReport : Form
    {
        private bool memberType;
        private int memberID, planID;
        public viewPlanReport(bool memberType, int memberID, int planID)
        {
            InitializeComponent();
            this.memberType = memberType;
            this.memberID = memberID;
            this.planID = planID;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial Rounded MT Bold", 8);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.DefaultCellStyle.Font = new Font("Arial Rounded MT Bold", 8);
            dataGridView2.AllowUserToAddRows = false;
            displayMealsAndSubscribedClients();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dietPlan memberDietplan = new dietPlan(memberType, memberID);
            this.Hide();
            memberDietplan.Show();
        }

        private void displayMealsAndSubscribedClients()
        {
            string connectionString = "Data Source=laptop\\SQLEXPRESS02;Initial Catalog=flexTrainer;Integrated Security=True;"; // Replace with your connection string
            string query = "SELECT planName, purpose, type FROM [Dietplan$] WHERE [Dietplan$].ID = @planID";
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
                            textBox1.Text = reader["purpose"].ToString();
                            textBox3.Text = reader["type"].ToString(); 
                        }
                    }
                }
            }

            query = "SELECT name as Meal, fats as [Fats(g)], protein as [Protein(g)], carbs as [Carbs(g)], fibre as [Fibre(g)], calories as [Calories(kcal)], Ditplan_meals$.type as Type FROM [Dietplan$] FULL JOIN Ditplan_meals$ ON Dietplan$.ID = Ditplan_meals$.DietPlanID FULL JOIN meal$ ON meal$.id = Ditplan_meals$.MealID WHERE [Dietplan$].ID = @planID;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@planID", planID);

                    connection.Open();

                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    dataGridView1.DataSource = dataTable;

                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.Resizable = DataGridViewTriState.False;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
            }

            query = "SELECT concat(firstname, ' ', lastname) as [Client Name], GymName as Gym FROM Diet_plan_followers$ JOIN Member$ ON Member$.ID = Diet_plan_followers$.MemberID JOIN Member_gym$ on Member_gym$.MemberID = Member$.ID JOIN Gym$ on Gym$.GymID = Member_gym$.MemberID WHERE Diet_plan_followers$.DietPlanID = @planID and Member$.Status like 'active'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@planID", planID);

                    connection.Open();

                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    dataGridView2.DataSource = dataTable;

                    foreach (DataGridViewColumn column in dataGridView2.Columns)
                    {
                        column.Resizable = DataGridViewTriState.False;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
            }
        }
    }
}
