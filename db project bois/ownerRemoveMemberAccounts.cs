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
    public partial class ownerRemoveMemberAccounts : Form
    {
        private string gymName;
        int id, gid;
        public ownerRemoveMemberAccounts(string gymName, int gid, int id )
        {
            InitializeComponent();
            this.gymName = gymName;
            label1.Text = "Remove Members at " + gymName;
            this.id = id;
            this. gid = gid;

            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                string query = "SELECT  Email from member$ join member_gym$ on member_Gym$.memberid = member$.id  where gymID = " + gid;
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "REMOVE")
            {
                DialogResult result = MessageBox.Show("Remove members permanently?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        if (checkedListBox1.GetItemChecked(i))
                        {
                            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
                            conn.Open();
                            string a = checkedListBox1.Items[i].ToString();
                            SqlCommand cm;
                            string query4 = "SELECT ID FROM member$ where [Email] ='" + a + "'";
                            object r;
                            cm = new SqlCommand(query4, conn);
                            r = cm.ExecuteScalar();
                            int  m_id = Convert.ToInt32(r);

                            string query = " UPDATE member$ Set Status = 'Banned' where Id =  " + m_id;
                            cm = new SqlCommand(query, conn);
                            object v = cm.ExecuteNonQuery();

                            string qu= " delete from member_gym$ where memberId =  " + m_id;
                            cm = new SqlCommand(qu, conn);
                             v = cm.ExecuteNonQuery();

                            conn.Close();
                            checkedListBox1.Items.RemoveAt(i);
                            --i;
                        }
                    }
                    // remove members from database
                    button1.Text = "GO BACK";
                } 
                else
                {
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                    button1.Text = "GO BACK";
                }
            }
            else
            {
                Manage_member manage_Member = new Manage_member(gymName, gid, id);
                this.Hide();
                manage_Member.Show();
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool loopBreaked = true;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    button1.Text = "REMOVE";
                    loopBreaked = false;
                    break;
                }
            }
            if (loopBreaked)
            {
                button1.Text = "GO BACK";
            }
        }

        private void ownerRemoveMemberAccounts_Load(object sender, EventArgs e)
        {

        }
    }
}
