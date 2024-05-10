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

namespace WindowsFormsApp1
{
    public partial class view_feedback_trainer : Form
    {
        private string gymName;
        private int ID;
        private int gid;
        public view_feedback_trainer(string gymName, int gid, int iD)
        {
            this.ID = iD;
            InitializeComponent();
            this.gymName = gymName;
            label1.Text = gymName + " Rating:";

            Size labelSize = label1.Size;
            textBox1.Size = new Size(528 - labelSize.Width, textBox1.Height);
            Point labelLocation = label1.Location;
            textBox1.Location = new Point(labelSize.Width + labelLocation.X, textBox1.Location.Y);
            this.gid = gid;
            queries();
           
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT distinct Member_name FROM Member_trainer where Trainerid = " + ID;
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["Member_name"].ToString());
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void queries()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
            conn.Open();
            SqlCommand cm;

            string q = "select avg(stars) \r\nfrom [Feedback$]\r\nwhere trainerid = " + ID;
            cm = new SqlCommand(q, conn);
            SqlDataReader r;//= cm.ExecuteReader();
            string n = cm.ExecuteScalar().ToString();
            //r.GetOrdinal("C").ToString();
            textBox3.Text = n;
            if (string.IsNullOrEmpty(n))
            {
                MessageBox.Show("error");
            }
            cm.Dispose();
            q = "select avg(stars) \r\nfrom [Feedback$]\r\njoin [member_trainer] \r\non member_trainer.Trainerid = [feedback$].trainerid\r\nwhere [feedback$].trainerid =" + ID + " and gymid ="+gid;
            cm = new SqlCommand(q, conn);
            n = cm.ExecuteScalar().ToString();
            textBox1.Text = n;
            cm.Dispose();
            conn.Close() ;       
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Trainer_home trainer_Home = new Trainer_home(ID);
            this.Hide();
            trainer_Home.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // depending on member chosen, edit textbox4 with member comments/rating from db

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
            conn.Open();
            SqlCommand cm;
            string a = comboBox1.SelectedItem.ToString();
            string q = "select comment\r\nfrom [Feedback$]\r\njoin [member_trainer] \r\non member_trainer.Trainerid = [feedback$].trainerid\r\nwhere [feedback$].trainerid = " + ID + " and Member_name = '" + a + "'";
            cm = new SqlCommand(q, conn);
            SqlDataReader r;//= cm.ExecuteReader();
            string n = cm.ExecuteScalar().ToString();
            textBox4.Text = n;
            if (string.IsNullOrEmpty(n))
            {
                MessageBox.Show("error");
            }
            cm.Dispose();         
            n = cm.ExecuteScalar().ToString();
            textBox4.Text = n;
            cm.Dispose();
            conn.Close();
        }

        private void view_feedback_trainer_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

       
        }
    }
}
