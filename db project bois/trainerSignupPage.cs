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
    public partial class trainerSignupPage : Form
    {
        public trainerSignupPage()
        {
            InitializeComponent();

                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT distinct GymName FROM Gym$ where status = 'Active' ";
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

        private void memberSignup_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            signUpPage signUpPage = new signUpPage();
            this.Hide();
            signUpPage.Show();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            string q = textBox1.Text;
            int exp = (int)yearsOfExperienceUpDown.Value;
            string gym = comboBox1.SelectedItem != null ? comboBox1.SelectedItem.ToString() : "";
            string s = comboBox2.SelectedItem != null ? comboBox2.SelectedItem.ToString() : "";

            if (string.IsNullOrEmpty(m) || string.IsNullOrEmpty(f) || string.IsNullOrEmpty(l) || string.IsNullOrEmpty(c) || string.IsNullOrEmpty(p1) || string.IsNullOrEmpty(p2) || string.IsNullOrEmpty(q))
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
            SqlCommand command, cm;

            string qry = "SELECT count(*) as column1 FROM trainer$ WHERE [Email] = '" + m + "'";
            cm = new SqlCommand(qry, conn);
            SqlDataReader d = cm.ExecuteReader();
            int cyui = 0;
            while (d.Read())
            {
                cyui = d.GetInt32(d.GetOrdinal("column1"));
            }
            d.Close();
            if (cyui > 0)
            {
                MessageBox.Show("ENter unique email address .");
                return;
            }

            string query = "INSERT INTO Trainer$ (FirstName, LastName, Email, Contact, Password, Specialties, Experience, JoinDate) " +
               "VALUES (@fname, @lname, @email, @contactnum, @password, @specialties, @experience, GETDATE() );";
            using (command = new SqlCommand(query, conn))
            {
                int rowsAffected;
                command.Parameters.AddWithValue("@fname", f);
                command.Parameters.AddWithValue("@lname", l);
                command.Parameters.AddWithValue("@email", m);
                command.Parameters.AddWithValue("@contactnum", c);
                command.Parameters.AddWithValue("@password", p1);
                command.Parameters.AddWithValue("@specialties", s);
                command.Parameters.AddWithValue("@experience", exp);
                //        command.Parameters.AddWithValue("@q", q);
                rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    MessageBox.Show("TRAINER registered successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to register TRAINER.");
                }
            }
            string query4 = "SELECT max(ID) FROM Trainer$ ";
            object r;
            command = new SqlCommand(query4, conn);
            r = command.ExecuteScalar();
            int tID = Convert.ToInt32(r);
            string query2 = "SELECT top 1 GymID FROM Gym$ WHERE GymName = @gym";
            object result;
            using (command = new SqlCommand(query2, conn))
            {
                command.Parameters.AddWithValue("@gym", gym);
                result = command.ExecuteScalar();
            }
            int gymID = Convert.ToInt32(result);
            string query3 = "INSERT INTO Trainer_gym$ (TrainerID, GymID,ApprovalStatus,  RegistrationDate) VALUES (@rowsaffected, @gymID, 'Pending',  GETDATE())";
            int rows;
            using (command = new SqlCommand(query3, conn))
            {
                command.Parameters.AddWithValue("@rowsaffected", tID);
                command.Parameters.AddWithValue("@gymID", gymID);
                rows = command.ExecuteNonQuery();
            }

            conn.Close();
        }

        private void yearsOfExperienceUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
