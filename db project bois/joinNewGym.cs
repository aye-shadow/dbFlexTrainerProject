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

namespace WindowsFormsApp1
{
    public partial class joinNewGym : Form
    {
        private bool memberType;
        int id, gid;
        public joinNewGym(bool memberType, int id)
        {
            InitializeComponent();
            this.memberType = memberType;
            if (memberType == false)
            {
                label1.Visible = false;
                comboBox2.Visible = false;
            }
            this.id = id;

            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT GymName\r\nFROM Gym$\r\nLEFT JOIN Trainer_gym$ ON Trainer_gym$.GymID = Gym$.GymID AND Trainer_gym$.TrainerID = "+ id+"   WHERE Trainer_gym$.TrainerID IS NULL";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
            string query = "SELECT top 1 GymID FROM Gym$ WHERE GymName = @gym";
            SqlCommand command;
            conn.Open();
            object result;
            using (command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@gym", comboBox1.Text);
                result = command.ExecuteScalar();
            }
            gid = Convert.ToInt32(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trainerMemberManageGym trainerMemberManageGym = new trainerMemberManageGym(memberType, id);
            this.Hide();
            trainerMemberManageGym.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || (memberType && comboBox2.SelectedIndex == -1))
            {
                MessageBox.Show("Fields cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (memberType)
                {
                    // enter into member db
                }
                else
                {
                    // enter into trainer db
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                    conn.Open();
                    SqlCommand command;
                    string query3 = "INSERT INTO Trainer_gym$ (TrainerID, GymID,ApprovalStatus,  RegistrationDate) VALUES (@rowsaffected, @gymID, 'Pending',  GETDATE())";
                    int rows;
                    using (command = new SqlCommand(query3, conn))
                    {
                        command.Parameters.AddWithValue("@rowsaffected", id);
                        command.Parameters.AddWithValue("@gymID", gid);
                        rows = command.ExecuteNonQuery();
                    }
                    if (rows >= 1)
                    {
                        MessageBox.Show("GYm registered successfully.");
                    }
                    conn.Close();
                    trainerMemberManageGym trainerMemberManageGym = new trainerMemberManageGym(memberType, id);
                    this.Hide();
                    trainerMemberManageGym.Show();
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
