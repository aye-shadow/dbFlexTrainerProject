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

namespace WindowsFormsApp1
{
    public partial class member_report : Form
    {
        private string gymName;
        int gid, id;
        public member_report(string gymName, int gid, int id)
        {
            InitializeComponent();
            this.gymName = gymName;
            label8.Text = "Member Reports at " + gymName;
            this.id = id;
            this.gid = gid;

            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT  Email  from member$ join member_gym$ on member_Gym$.memberid = member$.id  where  status = 'Active' and gymID = " + gid;
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

        private void goback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            db_project_bois.ownerHome o1 = new db_project_bois.ownerHome(id);
            this.Hide();
            o1.Show();
        }

        private void member_report_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // match details from db and display in form

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
            conn.Open();
            string a = comboBox1.SelectedItem.ToString();
            SqlCommand cm;
            string query4 = "SELECT ID FROM member$ where [Email] ='" + a + "'";
            object r;
            cm = new SqlCommand(query4, conn);
            r = cm.ExecuteScalar();
            int mid = Convert.ToInt32(r);
            string q, n;
            q = "SELECT [email] as C FROM Member$ WHERE ID = " + mid;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox3.Text = n;


            cm.Dispose();
            q = "SELECT Contact as C FROM Member$ WHERE ID = " + mid;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox5.Text = n;

            cm.Dispose();
            q = "SELECT RegistrationDate as C FROM Member$ WHERE ID = " + mid;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox2.Text = n;


            cm.Dispose();
            q = "SELECT Height as C FROM Member$ WHERE ID = " + mid;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox6.Text = n;

            cm.Dispose();
            q = "SELECT Weight as C FROM Member$ WHERE ID = " + mid;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox1.Text = n;

            cm.Dispose();
            q = "select MembershipType \r\nfrom gym$\r\njoin member_gym$ on gym$.gymId = member_gym$.gymid\r\nwhere member_gym$.memberid = " + id;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox7.Text = n;
            conn.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            db_project_bois.ownerHome o1 = new db_project_bois.ownerHome(id);
            this.Hide();
            o1.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
