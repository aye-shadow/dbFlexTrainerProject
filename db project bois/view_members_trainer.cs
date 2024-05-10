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
    public partial class view_members_trainer : Form
    {
        private string gymName;
        public int gid, id;

        public view_members_trainer(string gymName, int gid, int ID)
        {
            InitializeComponent();
            this.gymName = gymName;
            label1.Text = "Clients in " + gymName;
            this.gid = gid;
            id = ID;

            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "select CONCAT(firstName,' ', LastName)\r\n as M from member$\r\njoin Member_gym$ \r\non member$.Id = member_gym$.MemberID\r\nwhere gymId =" + gid;
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                listBox1.Items.Clear();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader["M"].ToString());
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
            Trainer_home trainer_Home = new Trainer_home(id);
            this.Hide();
            trainer_Home.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
