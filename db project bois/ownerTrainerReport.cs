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
    public partial class ownerTrainerReport : Form
    {
        private string gymName;
        public int gid, id;
        public ownerTrainerReport(string gymName, int gid, int id)
        {
            InitializeComponent();
            this.gymName = gymName;
            label8.Text = "Trainer reports at " + gymName;
            this.gid = gid;
            this.id = id;

            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT  [email] from trainer$ join trainer_gym$ on trainer_Gym$.trainerid = trainer$.id  where ApprovalStatus = 'Approved' and  gymID = " + gid;
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["Email"].ToString());
                }
                reader.Close();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // match details from db and display in form

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
            conn.Open();
            string a = comboBox1.SelectedItem.ToString();
            SqlCommand cm;
            string query4 = "SELECT ID FROM trainer$ where [Email] ='" + a + "'";
            object r;
            cm = new SqlCommand(query4, conn);
            r = cm.ExecuteScalar();
            int tid = Convert.ToInt32(r);
            string q, n;

            cm.Dispose();
            q = "SELECT [email] as C FROM trainer$  WHERE ID = " + tid;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox3.Text = n;

            cm.Dispose();
            q = "SELECT Contact as C FROM trainer$  WHERE ID = " + tid;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox5.Text = n;

            cm.Dispose();
            q = "SELECT joindate as C FROM trainer$  WHERE ID = " + tid;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox2.Text = n;

            cm.Dispose();
            q = "SELECT specialties as C FROM trainer$  WHERE ID = " + tid;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox7.Text = n;

            cm.Dispose();
            q = "SELECT CAST(AVG(stars) AS INT) FROM Feedback$ WHERE trainerid = " + tid + " GROUP BY trainerid";
            cm = new SqlCommand(q, conn);
            int x = Convert.ToInt32(cm.ExecuteScalar());
            textBox6.Text = x.ToString();

            cm.Dispose();
            q = "select count(*) from \r\nmember$ where id in(\r\nselect distinct memberid\r\nfrom training_session$\r\nwhere trainerid = " + tid + " )";
            cm = new SqlCommand(q, conn);
            x = Convert.ToInt32(cm.ExecuteScalar());
            textBox1.Text = x.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db_project_bois.ownerHome o1 = new db_project_bois.ownerHome(id);
            this.Hide();
            o1.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
