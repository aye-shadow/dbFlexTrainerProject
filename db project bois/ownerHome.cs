using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace db_project_bois
{
    public partial class ownerHome : Form
    {
        public int id , gid;
        public ownerHome(int id )
        {
            InitializeComponent();
            textBox5.KeyPress += textBox5_KeyPressed;
            this.id = id;
            Dat();
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT distinct GymName FROM Gym$  where Status = 'Active' AND  gymownerid = " + id;
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
            q = "SELECT Password as C FROM Gym_owner$ WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox4.Text = n;

            cm.Dispose();
            q = "SELECT Contact as C FROM Gym_owner$ WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox5.Text = n;

            cm.Dispose();
            q = "SELECT RegistrationDate as C FROM Gym_owner$ WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox6.Text = n;
        }

        private void ownerHome_Load(object sender, EventArgs e)
        {

        }

        private bool gymSelected()
        {
            return comboBox1.SelectedItem == null || comboBox1.SelectedIndex == -1;
        }

        private string selectGymName()
        {
            return comboBox1.SelectedItem.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private string ogName, ogEmail, ogPassword, ogContact;

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            textBox1.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;
            linkLabel3.Enabled = false;
            linkLabel4.Enabled = false;
            linkLabel5.Enabled = false;
            linkLabel6.Visible = false;
            linkLabel6.Enabled = false;

            ogName = textBox1.Text;
            ogEmail = textBox3.Text;
            ogPassword = textBox4.Text;
            ogContact = textBox5.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            homePage homePage = new homePage();
            this.Hide();
            homePage.Show();
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gymSelected())
            {
                WindowsFormsApp1.Manage_member manage_Member = new WindowsFormsApp1.Manage_member(selectGymName(), gid , id  ) ;
                this.Hide();
                manage_Member.Show();
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
                WindowsFormsApp1.manage_trainer manage_Trainer = new WindowsFormsApp1.manage_trainer(selectGymName(), gid, id );
                this.Hide();
                manage_Trainer.Show();
            }
            else
            {
                MessageBox.Show("Please select a gym first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gymSelected())
            {
                WindowsFormsApp1.member_report member_Report = new WindowsFormsApp1.member_report(selectGymName() , gid, id );
                this.Hide();
                member_Report.Show();
            }
            else
            {
                MessageBox.Show("Please select a gym first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gymSelected())
            {
                WindowsFormsApp1.ownerTrainerReport trainer_Report = new WindowsFormsApp1.ownerTrainerReport(selectGymName(), gid, id );
                this.Hide();
                trainer_Report.Show();
            }
            else
            {
                MessageBox.Show("Please select a gym first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // reset values back to original
            textBox1.Text = ogName;
            textBox3.Text = ogEmail;
            textBox4.Text = ogPassword;
            textBox5.Text = ogContact;
            resetValues();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool textBoxEmpty = false;

            foreach (Control control in Controls)
            {

                if (control is System.Windows.Forms.TextBox textBox && textBox != textBox6)
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
                    string query = " UPDATE gym_owner$ " +
               "SET FirstName = @fname, LastName = @lname, Email = @email, " +
               " Contact = @contactnum, Password = @password  " +
               "WHERE ID = @id";
                    using (command = new SqlCommand(query, conn))
                    {
                        int rowsAffected;
                        command.Parameters.AddWithValue("@fname", firstName);
                        command.Parameters.AddWithValue("@lname", lastName);
                        command.Parameters.AddWithValue("@email", m);
                        command.Parameters.AddWithValue("@contactnum", c);
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
                    // update personal details
                    resetValues();
                }
            }
        }

        private void resetValues()
        {
            button1.Visible = false;
            button2.Visible = false;
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            linkLabel1.Enabled = true;
            linkLabel2.Enabled = true;
            linkLabel3.Enabled = true;
            linkLabel4.Enabled = true;
            linkLabel5.Enabled = true;
            linkLabel6.Enabled = true;
            linkLabel6.Visible = true;
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ownerManageGyms ownerManageGyms = new ownerManageGyms(id);
            this.Hide();
            ownerManageGyms.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ownerAndHisGyms ownerAndHisGyms = new ownerAndHisGyms(id);
            this.Hide();
            ownerAndHisGyms.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
