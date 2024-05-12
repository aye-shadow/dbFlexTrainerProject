using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ownerViewAllMembers : Form
    {
        private string gymName;
        int id, gid;
        public ownerViewAllMembers(string gymName, int gid, int id)
        {
            InitializeComponent();
            this.gymName = gymName;
            label1.Text = "Members at " + gymName;
            this.gid = gid;
            this.id = id;

            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT  Concat(Firstname,' ', Lastname) as Member_Name from member$ join member_gym$ on member_Gym$.memberid = member$.id  where  status = 'Active' and gymID = " + gid;
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                listBox1.Items.Clear();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader["Member_Name"].ToString());
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manage_member manage_Member = new Manage_member(gymName, gid, id);
            this.Hide();
            manage_Member.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
