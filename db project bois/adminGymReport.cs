using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db_project_bois
{
    public partial class adminGymReport : Form
    {
        public int id, gid, oid;
        public adminGymReport(int id)
        {
            InitializeComponent();
            this.id = id;

            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT  GymName FROM Gym$ where status = 'Active' AND Approval = 'Approved' ";
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["GymName"].ToString());
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_home admin_Home = new admin_home(id);
            this.Hide();
            admin_Home.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // queries 
            // name -> id 
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
            string query = "SELECT top 1 GymID FROM Gym$ WHERE GymName = @gym";
            SqlCommand command;
            conn.Open();
            object result;
            using (command = new SqlCommand(query, conn))
            {
                string s = comboBox1.SelectedItem.ToString();
                command.Parameters.AddWithValue("@gym", s);
                result = command.ExecuteScalar();
            }
            gid = Convert.ToInt32(result);
            command.Dispose();
            conn.Close();

            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox2.Text = "";

            queries();
        }
        public void queries()
        {
            // dsplay information 
            //  -> owner id 
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
            string query = "SELECT top 1 GymOwnerID FROM Gym$ WHERE GymName = @gym";
            SqlCommand command, cm;
            conn.Open();
            object result;
            using (command = new SqlCommand(query, conn))
            {
                string s = comboBox1.SelectedItem.ToString();
                command.Parameters.AddWithValue("@gym", s);
                result = command.ExecuteScalar();
            }
            oid = Convert.ToInt32(result);
            command.Dispose();
            //display owner information from owner
            string q = "SELECT CONCAT(FirstName, ' ', LastName) As C FROM Gym_owner$ WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
            SqlDataReader r;//= cm.ExecuteReader();
            string n = cm.ExecuteScalar().ToString();
            //r.GetOrdinal("C").ToString();
            textBox1.Text = n;
            if (string.IsNullOrEmpty(n))
            {
                MessageBox.Show("error");
            }
            cm.Dispose();
            q = "SELECT [email] as C FROM Gym_owner$ WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox3.Text = n;

            cm.Dispose();
            q = "SELECT Contact as C FROM Gym_owner$ WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox5.Text = n;

            cm.Dispose();
            q = "select avg(stars) from member_trainer where gymid =  " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox4.Text = n;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
