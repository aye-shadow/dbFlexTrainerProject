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
    public partial class trainerRequests : Form
    {
        private string gymName;
        int gid, id;
        public trainerRequests(string gymName, int gid, int id)
        {
            InitializeComponent();
            this.gymName = gymName;
            label3.Text = "Trainer Applications at " + gymName;
            this.id = id;
            this.gid = gid;

            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT  [email] from trainer$ join trainer_gym$ on trainer_Gym$.trainerid = trainer$.id  where gymID = " + gid + " and ApprovalStatus = 'Pending' ";
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                checkedListBox1.Items.Clear();
                while (reader.Read())
                {
                    checkedListBox1.Items.Add(reader["Email"].ToString());
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool loopBreaked = false;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    button1.Text = "REGISTER";
                    loopBreaked = true;
                    break;
                }
            }

            if (!loopBreaked)
            {
                button1.Text = "GO BACK";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text != "REGISTER")
            {
                manage_trainer manage_Trainer = new manage_trainer(gymName, gid, id);
                this.Hide();
                manage_Trainer.Show();
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                       
                        // also change status to "approve" in db

                        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                        conn.Open();
                        SqlCommand command;
                        String s = checkedListBox1.Items[i].ToString();
                        SqlCommand cm;
                        string query4 = "SELECT ID FROM trainer$ where [Email] ='" + s + "'";
                        object r;
                        cm = new SqlCommand(query4, conn);
                        r = cm.ExecuteScalar();
                       int  t_id = Convert.ToInt32(r);

                        string query = " UPDATE trainer_Gym$ Set ApprovalStatus = 'Approved' where trainerId =  " + t_id;
                        command = new SqlCommand(query, conn);
                        object a = command.ExecuteNonQuery();
                        conn.Close();

                        checkedListBox1.Items.RemoveAt(i);
                        --i;
                    }
                }
                button1.Text = "GO BACK";
            }
        }
    }
}
