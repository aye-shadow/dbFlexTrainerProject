using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class ownerDeleteExistingGym : Form
    {
        int id,gid;
        string gname;
        public ownerDeleteExistingGym(int id)
        {
            InitializeComponent();
            this.id = id;

            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT distinct GymName FROM Gym$  where Status = 'Active' AND gymownerid = " + id;
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
            ownerAndHisGyms ownerAndHisGyms = new ownerAndHisGyms(id);
            this.Hide();
            ownerAndHisGyms.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select gym to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // delete from db
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                conn.Open();
                SqlCommand cm;
                string query4 = "Update gym$ set Status = 'Inactive' where gymname = '" + gname +"'";
                object r;
                cm = new SqlCommand(query4, conn);
                r = cm.ExecuteNonQuery();
                cm.Dispose();
                conn.Close();
                if((int)r >=1)
                MessageBox.Show("Gym successfully deleted!");
                ownerAndHisGyms ownerAndHisGyms = new ownerAndHisGyms(id);
                this.Hide();
                ownerAndHisGyms.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gname = comboBox1.SelectedItem.ToString();
        }
    }
}
