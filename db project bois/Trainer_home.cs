using Db_project_1;
using db_project_bois;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using db_project_bois;
using WindowsFormsApp1;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using db_project_bois;
using WindowsFormsApp1;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Collections;


namespace WindowsFormsApp1
{
    public partial class Trainer_home : Form
    {
        public int id,gid;
        public Trainer_home(int id = 1)
        {
            InitializeComponent();
            this.id = id;
            Dat();
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT GymName FROM Gym$ join trainer_gym$ on gym$.gymid = trainer_gym$.gymid where trainerid = " + id;
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
        public void Dat()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
            conn.Open();
            SqlCommand cm;

            string q = "SELECT CONCAT(FirstName, ' ', LastName) As C FROM trainer$ WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
            SqlDataReader r;
            string n = cm.ExecuteScalar().ToString();
            //r.GetOrdinal("C").ToString();
            textBox1.Text = n;
            if (string.IsNullOrEmpty(n))
            {
                MessageBox.Show("error");
            }
            cm.Dispose();
            q = "SELECT [email] as C FROM trainer$  WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox3.Text = n;

            cm.Dispose();
            q = "SELECT Password as C FROM trainer$  WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox4.Text = n;

            cm.Dispose();
            q = "SELECT CAST(AVG(stars) AS INT) FROM Feedback$ WHERE trainerid = " + id + " GROUP BY trainerid";
            cm = new SqlCommand(q, conn);
            int a = Convert.ToInt32(cm.ExecuteScalar());
            textBox5.Text = a.ToString();

            cm.Dispose();
            conn.Close();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gymSelected())
            {
                // view members page go to
                view_members_trainer view_Members_Trainer = new view_members_trainer(selectGymName(), gid, id);
                this.Hide();
                view_Members_Trainer.Show();
            }
            else
            {
                MessageBox.Show("Please select a gym first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void resetValues()
        {
            button1.Visible = false;
            button2.Visible = false;

            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

            linkLabel4.Enabled = true;
            linkLabel12.Enabled = true;
            linkLabel11.Enabled = true;
            linkLabel3.Enabled = true;
            linkLabel5.Enabled = true;

            linkLabel6.Visible = true;
            linkLabel7.Visible = true;
        }

        private bool gymSelected()
        {
            return comboBox1.SelectedItem == null || comboBox1.SelectedIndex == -1;
        }

        private string selectGymName()
        {
            return comboBox1.SelectedItem.ToString();
        }

        private string ogName, ogEmail, ogPassword;

        private void button2_Click(object sender, EventArgs e)
        {
            // reset values back to original
            textBox1.Text = ogName;
            textBox3.Text = ogEmail;
            textBox4.Text = ogPassword;
            resetValues();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            homePage homePage = new homePage();
            this.Hide();
            homePage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool textBoxEmpty = false;

            foreach (Control control in Controls)
            {
                if (control is System.Windows.Forms.TextBox textBox && textBox != textBox5)
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        textBoxEmpty = true;
                        MessageBox.Show("Fields cannot be left empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }

            if (!textBoxEmpty)
            {
                // textboxes not empty
                if (!Regex.IsMatch(textBox3.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    // validate email format
                    MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // email is also valid
                    // update personal details in db
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                    string m = textBox3.Text;
                    string f = textBox1.Text;
                    string l;
                    string p1 = textBox4.Text;
                    string fullName = f.Trim();

                    string[] parts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string firstName = "";
                    string lastName = "";

                    if (parts.Length > 0)
                    {
                        firstName = parts[0];
                        for (int i = 1; i < parts.Length; i++)
                        {
                            lastName += parts[i] + " ";
                        }

                        lastName = lastName.Trim();
                    }

                    conn.Open();
                    SqlCommand command;
                    string query = " UPDATE trainer$ " +
               "SET FirstName = @fname, LastName = @lname, Email = @email, " +
               "  Password = @password  " +
               "WHERE ID = @id";
                    using (command = new SqlCommand(query, conn))
                    {
                        int rowsAffected;
                        command.Parameters.AddWithValue("@fname", firstName);
                        command.Parameters.AddWithValue("@lname", lastName);
                        command.Parameters.AddWithValue("@email", m);
                        command.Parameters.AddWithValue("@password", p1);
                        command.Parameters.AddWithValue("@id", id);
                        // Execute the query
                        rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            MessageBox.Show("Owner information updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update owner information.");
                        }
                    }
                    resetValues();
                }
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // can view all appointments regardless of gym
            if (!gymSelected())
            {
                string a = comboBox1.SelectedItem.ToString();

                manage_appointments_trainer manage_Appointments_Trainer = new manage_appointments_trainer(id, a);
                this.Hide();
                manage_Appointments_Trainer.Show();
            }
            else
            {
                MessageBox.Show("Please select a gym first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gymSelected())
            {
                workoutPlan workoutPlan = new workoutPlan(false);
                this.Hide();
                workoutPlan.Show();
            }
            else
            {
                MessageBox.Show("Please select a gym first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gymSelected())
            {
                manageDietPlan dietPlan = new manageDietPlan(false);
                this.Hide();
                dietPlan.Show();
            }
            else
            {
                MessageBox.Show("Please select a gym first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gymSelected())
            {
                // go to view feedback page
                //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                //string query = "SELECT top 1 GymID FROM Gym$ WHERE GymName = @gym";
                //SqlCommand command;
                //conn.Open();   
                //object result;
                //using (command = new SqlCommand(query, conn))
                //{
                //    command.Parameters.AddWithValue("@gym", selectGymName());
                //    result = command.ExecuteScalar();
                //}
                //int gymID = Convert.ToInt32(result);

                view_feedback_trainer view_Feedback_Trainer = new view_feedback_trainer(selectGymName(), gid, id);
                this.Hide();
                view_Feedback_Trainer.Show();
            }
            else
            {
                MessageBox.Show("Please select a gym first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;

            textBox1.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;

            linkLabel4.Enabled = false;
            linkLabel12.Enabled = false;
            linkLabel11.Enabled = false;
            linkLabel3.Enabled = false;
            linkLabel5.Enabled = false;

            linkLabel6.Visible = false;
            linkLabel7.Visible = false;

            ogName = textBox1.Text;
            ogEmail = textBox3.Text;
            ogPassword = textBox4.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trainerMemberManageGym trainer_Manage_Gym = new trainerMemberManageGym(false, id);
            this.Hide();
            trainer_Manage_Gym.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
            string query = "SELECT top 1 GymID FROM Gym$ WHERE GymName = @gym";
            SqlCommand command;
            conn.Open();
            object result;
            using (command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@gym", selectGymName());
                result = command.ExecuteScalar();
            }
            gid = Convert.ToInt32(result);
            command.Dispose();
            conn.Close();
        }
    }
}
