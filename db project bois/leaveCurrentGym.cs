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

namespace WindowsFormsApp1
{
    public partial class leaveCurrentGym : Form
    {
        private bool memberType;
        int id, gid;
        public leaveCurrentGym(bool memberType, int id)
        {
            InitializeComponent();
            this.memberType = memberType;
            this.id = id;

            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT GymName\r\nFROM Gym$\r\nJOIN Trainer_gym$ ON Trainer_gym$.GymID = Gym$.GymID where Trainer_gym$.TrainerID = " + id;
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

        private void button3_Click(object sender, EventArgs e)
        {
            trainerMemberManageGym trainerMemberManageGym = new trainerMemberManageGym(memberType, id);
            this.Hide();
            trainerMemberManageGym.Show();
        }

        private void leaveCurrentGym_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter a gym to leave!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (memberType)
                {
                    // remove from member db
                }
                else
                {
                    // remove from trainer db
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                    conn.Open();
                    SqlCommand command;
                    string query3 = "DELETE FROM Trainer_gym$\r\nWHERE GymID ="+ gid+" AND TrainerID = "+id;
                    int rows;
                    using (command = new SqlCommand(query3, conn))
                    {
                        rows = command.ExecuteNonQuery();
                    }
                    if (rows >= 1)
                    {
                        MessageBox.Show("GYm removed successfully.");
                    }
                    conn.Close();
                    trainerMemberManageGym trainerMemberManageGym = new trainerMemberManageGym(memberType, id);
                    this.Hide();
                    trainerMemberManageGym.Show();
                }
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
    }
}
