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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace db_project_bois
{
    public partial class memberSignup : Form
    {
        public memberSignup()
        {
            InitializeComponent();
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT GymName FROM Gym$";
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                comboBox3.Items.Clear();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader["GymName"].ToString());
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT distinct MembershipType FROM Member_Gym$";
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["MembershipType"].ToString());
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void fnameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void contactLabel_Click(object sender, EventArgs e)
        {

        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            signUpPage signUpPage = new signUpPage();
            this.Hide();
            signUpPage.Show();
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
            string m = emailTextBox.Text;
            string f = fnameTextBox.Text;
            string l = lnameTextBox.Text;
            string c = contactTextBox.Text;
            string p1 = passwordTextBox.Text;
            string p2 = confirmPasswordTextBox.Text;
            int weight = (int)numericUpDown1.Value;
            int height = (int)yearsOfExperienceUpDown.Value;
            string gym = comboBox3.SelectedItem != null ? comboBox3.SelectedItem.ToString() : "";
            string membershipType = comboBox1.SelectedItem != null ? comboBox1.SelectedItem.ToString() : "";
            string fitnessGoal = comboBox4.SelectedItem != null ? comboBox4.SelectedItem.ToString() : "";

            if (string.IsNullOrEmpty(m) || string.IsNullOrEmpty(f) || string.IsNullOrEmpty(l) || string.IsNullOrEmpty(c) || string.IsNullOrEmpty(p1) || string.IsNullOrEmpty(p2))
            {
                MessageBox.Show("Enter all inputs.");
                return;
            }
            if (p1 != p2)
            {
                MessageBox.Show("Password does not match, Enter again.");
                return;
            }
            conn.Open();
            SqlCommand command;
            string query = "INSERT INTO Member$ (FirstName, LastName, Email, Contact, Password, Weight, Height,  RegistrationDate, FitnessGoal) " +
                "VALUES (@fname, @lname, @email, @contactnum, @password, @weight, @height, GETDATE(), @f);";

            using (command = new SqlCommand(query, conn))
            {
                int rowsAffected;
                command.Parameters.AddWithValue("@fname", f);
                command.Parameters.AddWithValue("@lname", l);
                command.Parameters.AddWithValue("@email", m);
                command.Parameters.AddWithValue("@contactnum", c);
                command.Parameters.AddWithValue("@password", p1);
                command.Parameters.AddWithValue("@weight", weight);
                command.Parameters.AddWithValue("@height", height);
                command.Parameters.AddWithValue("@f", fitnessGoal);
                command.Parameters.AddWithValue("@membershiptype", membershipType);
                // Execute the query
                rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    MessageBox.Show("Member registered successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to register member.");
                }
                command.Parameters.AddWithValue("@rowsaffected", rowsAffected);
            }
            string query4 = "SELECT max(ID) FROM Member$ ";
            object r;
            command = new SqlCommand(query4, conn);
            r = command.ExecuteScalar();
            int memberID = Convert.ToInt32(r);
            string query2 = "SELECT top 1 GymID FROM Gym$ WHERE GymName = @gym";
            object result;
            using (command = new SqlCommand(query2, conn))
            {
                command.Parameters.AddWithValue("@gym", gym);
                result = command.ExecuteScalar();
            }
            int gymID = Convert.ToInt32(result);
            string query3 = "INSERT INTO Member_gym$ (MemberID, GymID, MembershipType, JoinDate ) VALUES (@rowsaffected, @gymID, @membershipType, GETDATE())";
            int rows;
            using (command = new SqlCommand(query3, conn))
            {
                command.Parameters.AddWithValue("@rowsaffected", memberID);
                command.Parameters.AddWithValue("@membershipType", membershipType);
                command.Parameters.AddWithValue("@gymID", gymID);

                rows = command.ExecuteNonQuery();
            }
            conn.Close();
        }

        private void lnameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void contactTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmPasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void yearsOfExperienceUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
