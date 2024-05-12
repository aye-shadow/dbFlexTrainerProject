using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace db_project_bois
{
    public partial class admin_home : Form
    {
        public int id;
        public admin_home(int id)
        {
            InitializeComponent();
            this.id = id;
            dat();
           
        }
        public void dat()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
            conn.Open();
            SqlCommand cm;

            string q = "SELECT CONCAT(First_Name, ' ', Last_Name) As C FROM admin$ WHERE ID = " + id;
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
            q = "SELECT [email] as C FROM admin$ WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox3.Text = n;

            cm.Dispose();
            q = "SELECT Password as C FROM admin$ WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox4.Text = n;
            cm.Dispose();
            q = "SELECT Contact as C FROM admin$ WHERE ID = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox5.Text = n;
            cm.Dispose();
            conn.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        string ogName, ogEmail, ogPassword, ogCOntact;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // edit personal details
            button1.Visible = true;
            button2.Visible = true;
            textBox1.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled  = true;
            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;
            linkLabel3.Enabled = false;
            linkLabel4.Enabled = false;

            ogName = textBox1.Text;
            ogEmail = textBox3.Text;
            ogPassword = textBox4.Text;
            ogCOntact = textBox5.Text;



        }

        private void admin_home_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            homePage homePage = new homePage();
            this.Hide();
            homePage.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            adminGymReport gym_Report = new adminGymReport(id);
            this.Hide();
            gym_Report.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            manage_gym manage_Gym = new manage_gym(id);
            this.Hide();
            manage_Gym.Show();
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
                    // update personal details
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
                        firstName = parts[0];
                        for (int i = 1; i < parts.Length; i++)
                        {
                            lastName += parts[i] + " ";
                        }
                        lastName = lastName.Trim();
                    }
                    conn.Open();
                    SqlCommand command;
                    string query = " UPDATE  Admin$ " +
               "SET First_Name = @fname, Last_Name = @lname, Email = @email, " +
               " Contact = @contactnum, Password = @password  " +
               "WHERE ID = @memberID";
                    using (command = new SqlCommand(query, conn))
                    {
                        int rowsAffected;
                        command.Parameters.AddWithValue("@fname", firstName);
                        command.Parameters.AddWithValue("@lname", lastName);
                        command.Parameters.AddWithValue("@email", m);
                        command.Parameters.AddWithValue("@contactnum", c);
                        command.Parameters.AddWithValue("@password", p1);
                        command.Parameters.AddWithValue("@memberID", id);
                        // Execute the query
                        rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            MessageBox.Show("Admin information updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update ADMIN information.");
                        }
                        resetValues();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // reset values back to original
            textBox1.Text = ogName;
            textBox3.Text = ogEmail;
            textBox4.Text = ogPassword;
            textBox5.Text = ogCOntact;
            resetValues();
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
    }
}
