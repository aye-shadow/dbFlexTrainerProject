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

namespace Db_project_1
{
    public partial class Members : Form
    {
        public int id;
        public Members(int ID = 1)
        {
            this.id = ID;
            InitializeComponent();
            textBox5.KeyPress += textBox5_KeyPressed;
            Dat();
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT distinct GymName FROM Gym$ join member_gym$ on gym$.gymid = member_gym$.gymid where memberid = " +id;
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

            string q = "SELECT CONCAT(FirstName, ' ', LastName) As C FROM Member$ WHERE ID = " + id;
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
            q = "SELECT [email] as C FROM Member$ WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
             n = cm.ExecuteScalar().ToString();
            textBox3.Text = n;

            cm.Dispose();
            q = "SELECT Password as C FROM Member$ WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox4.Text = n;

            cm.Dispose();
            q = "SELECT Contact as C FROM Member$ WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox5.Text = n;


            cm.Dispose();
            q = "SELECT Height as C FROM Member$ WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            numericUpDown1.Text = n;

            cm.Dispose();
            q = "SELECT Weight as C FROM Member$ WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            numericUpDown2.Text = n;

            cm.Dispose();
            q = "select gymname from gym$\r\njoin member_gym$ on gym$.gymId = member_gym$.gymid\r\nwhere member_gym$.memberid = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            comboBox1.Text = n;

            cm.Dispose();
            q = "select MembershipType \r\nfrom gym$\r\njoin member_gym$ on gym$.gymId = member_gym$.gymid\r\nwhere member_gym$.memberid = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            comboBox2.Text = n;


            conn.Close();

        }

        private bool gymSelected()
        {
            return comboBox1.SelectedItem == null || comboBox1.SelectedIndex == -1;
        }

        private string selectGymName()
        {
            return comboBox1.SelectedItem.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            homePage homePage = new homePage();
            this.Hide();
            homePage.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            textBox1.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;
            linkLabel4.Enabled = false;
            linkLabel6.Enabled = false;
            linkLabel7.Enabled = false;
            linkLabel8.Visible = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         //   if (!gymSelected())
            {
                workoutPlan form = new workoutPlan(true );
                this.Hide();
                form.ShowDialog();
            }
         //   else
            {
        //        MessageBox.Show("Please select a gym first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gymSelected())
            {
                manageDietPlan dietPlan = new manageDietPlan(true, id);
                this.Hide();
                dietPlan.Show();
            }
            else
            {
                MessageBox.Show("Please select a gym first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            appointmentdetails memberManageAppointments = new appointmentdetails();
            this.Hide();
            memberManageAppointments.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            member_feedback form = new member_feedback(id);
            this.Hide();
            form.ShowDialog();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void resetValues()
        {
            button1.Visible = false;
            button2.Visible = false;

            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            comboBox2.Enabled = false;

            linkLabel1.Enabled = true;
            linkLabel2.Enabled = true;
            linkLabel4.Enabled = true;
            linkLabel6.Enabled = true;
            linkLabel7.Enabled = true;
            linkLabel8.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetValues();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool textBoxEmpty = false;

            foreach (Control control in Controls)
            {
                if (control is System.Windows.Forms.TextBox textBox)
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

                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                    string m = textBox3.Text;
                    string f = textBox1.Text;
                    string l;
                    string c = textBox5.Text;
                    string p1 = textBox4.Text;
                    int weight = (int)numericUpDown2.Value;
                    int height = (int)numericUpDown1.Value;
                    string gym = comboBox1.SelectedItem != null ? comboBox1.SelectedItem.ToString() : "";
                    string membershipType = comboBox2.SelectedItem != null ? comboBox2.SelectedItem.ToString() : "";
                    
                    string fullName = f.Trim(); 

                    string[] parts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string firstName = ""; 
                    string lastName = ""; 

                    if (parts.Length > 0)
                    {
                        firstName = parts[0]; // First part is the first name

                        // Concatenate remaining parts (if any) to form the last name
                        for (int i = 1; i < parts.Length; i++)
                        {
                            lastName += parts[i] + " ";
                        }

                        lastName = lastName.Trim(); // Remove trailing whitespace
                    }

                    // Now 'firstName' and 'lastName' contain the separated first name and last name, respectively

                    // You can then use these variables to insert into the database


                    conn.Open();
                    SqlCommand command;
                    string query = " UPDATE Member$ " +
               "SET FirstName = @fname, LastName = @lname, Email = @email, " +
               " Contact = @contactnum, Password = @password, Weight = @weight, " +
               " Height = @height,  " +
               " RegistrationDate = GETDATE()  " +
               "WHERE ID = @memberID";
                    using (command = new SqlCommand(query, conn))
                    {
                        int rowsAffected;
                        command.Parameters.AddWithValue("@fname", firstName);
                        command.Parameters.AddWithValue("@lname", lastName);
                        command.Parameters.AddWithValue("@email", m);
                        command.Parameters.AddWithValue("@contactnum", c);
                        command.Parameters.AddWithValue("@password", p1);
                        command.Parameters.AddWithValue("@weight", weight);
                        command.Parameters.AddWithValue("@height", height);
                        command.Parameters.AddWithValue("@memberID", id); 

                        // Execute the query
                        rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            MessageBox.Show("Member information updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update member information.");
                        }
                    }

                    resetValues();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trainerMemberManageGym trainerMemberManageGym = new trainerMemberManageGym(true, id);
            this.Hide();
            trainerMemberManageGym.Show();
        }

        private void Members_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPressed(object sender, KeyPressEventArgs e)
        {
            // only allow numeric input
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If not a control key or a digit, ignore the key press event
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
