using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Db_project_1
{
    public partial class member_feedback : Form
    {
        public int ID;
        public member_feedback(int id )
        {
            ID = id;
            InitializeComponent();

            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT distinct Trainer_name FROM Member_trainer where memberid = " + id;
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["Trainer_name"].ToString());
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Members form = new Members(ID);
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Fields cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // STORE DATA IN DB 
                string t = comboBox1.SelectedItem.ToString();
                int r = (int)numericUpDown1.Value;
                string c = textBox1.Text;

                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT TRAINERID FROM Member_trainer where memberid = " + ID + " and Trainer_name = '" + t + "'";
                SqlCommand cm;
                conn.Open();
                object a;
                cm = new SqlCommand(query, conn);
                a = cm.ExecuteScalar();
                int t_ID = Convert.ToInt32(a);
                cm.Dispose();
                string q1 = "SELECT count(*) FROM Feedback$ where memberid = " + ID + " and Trainerid = " + t_ID;
                object b;
                cm = new SqlCommand(q1, conn);
                b = cm.ExecuteScalar();
                cm.Dispose();
                if ((int)b != 0)
                {
                    MessageBox.Show("Feedback already submited. ");
                    return;
                }

                string query3 = "INSERT INTO Feedback$ (MemberId, TrainerID, Stars, Comment) " +
                 "VALUES (@id, @tid, @s , @c)";
                int rowsAffected;
                using (cm = new SqlCommand(query3, conn))
                {
                    cm.Parameters.AddWithValue("@id", ID);
                    cm.Parameters.AddWithValue("@tid", t_ID);
                    cm.Parameters.AddWithValue("@s", r);
                    cm.Parameters.AddWithValue("@c", c);
                    rowsAffected = cm.ExecuteNonQuery();
                }
                if (rowsAffected == 1)
                {
                    MessageBox.Show("Feedback submitted!");
                }
                else
                {
                    MessageBox.Show("Failed to submit feedback.");
                }
                Members members = new Members(ID);
                this.Hide();
                members.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
