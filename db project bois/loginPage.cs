using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApp1;

namespace db_project_bois
{
	public partial class loginPage : Form
	{
		private string memberType;
		public loginPage(string memberType)
		{
			InitializeComponent();
			this.memberType = memberType;   
		}

		private void signupButton_Click(object sender, EventArgs e)
		{
			signUpPage signUpPage = new signUpPage();
			this.Hide();
			signUpPage.Show();
		}

		private void emailTextBox_TextChanged(object sender, EventArgs e)
		{

		}

		private void passwordTextBox_TextChanged(object sender, EventArgs e)
		{

		}

		private void loginButton_Click(object sender, EventArgs e)
		{
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TG8CNLH\\SQLEXPRESS;Initial Catalog=flexTrainer;Integrated Security=True");
            string a = emailTextBox.Text;

            if (string.IsNullOrEmpty(a))
            {
                MessageBox.Show(" Please Enter Email.");
                return;
            }
            conn.Open();
            SqlCommand cm;
            string b = passwordTextBox.Text;
            if (string.IsNullOrEmpty(b))
            {
                MessageBox.Show("Enter Password.");
                return;
            }


            if (memberType == "member")
            {
                string query = "SELECT count(*) as column1 FROM Member$ WHERE [Email] = '" + a + "' AND [PASSWORD] = '" + b + "'";
                cm = new SqlCommand(query, conn);
                SqlDataReader d = cm.ExecuteReader();
                int c = 0;
                while (d.Read())
                {
                    c = d.GetInt32(d.GetOrdinal("column1"));
                }
                d.Close();
                if (c == 0) { MessageBox.Show("invalid username or password"); return; }
                else MessageBox.Show("Login Successfully");
                cm.Dispose();

                string query4 = "SELECT ID FROM Member$ where [Email] ='"+a+"'";
                object r;
                cm = new SqlCommand(query4, conn);
                r = cm.ExecuteScalar();
                int ID = Convert.ToInt32(r);
                conn.Close();

                Db_project_1.Members members = new Db_project_1.Members(ID);
                this.Hide();
                members.Show();
            }
            else if (memberType == "owner")
            {
                string query = "SELECT count(*) as column1 FROM Gym_owner$ WHERE [Email] = '" + a + "' AND [PASSWORD] = '" + b + "'";
                cm = new SqlCommand(query, conn);
                SqlDataReader d = cm.ExecuteReader();
                int c = 0;
                while (d.Read())
                {
                    c = d.GetInt32(d.GetOrdinal("column1"));
                }
                d.Close();
                if (c == 0) { MessageBox.Show("invalid username or password"); return; }
                else MessageBox.Show("Login Successfully");
                string query4 = "SELECT ID FROM Gym_owner$ where [Email] ='" + a + "'";
                object r;
                cm = new SqlCommand(query4, conn);
                r = cm.ExecuteScalar();
                int ID = Convert.ToInt32(r);             
                cm.Dispose();
                conn.Close();

                ownerHome ownerHome = new ownerHome(ID);
                this.Hide();
                ownerHome.Show();
            }
            else if (memberType == "trainer")
            {
                string query = "SELECT count(*) as column1 FROM trainer$ WHERE [Email] = '" + a + "' AND [PASSWORD] = '" + b + "'";
                cm = new SqlCommand(query, conn);
                SqlDataReader d = cm.ExecuteReader();
                int c = 0;
                while (d.Read())
                {
                    c = d.GetInt32(d.GetOrdinal("column1"));
                }
                d.Close();
                if (c == 0) { MessageBox.Show("invalid username or password"); return; }
                else MessageBox.Show("Login Successfully");
                cm.Dispose();

                string query4 = "SELECT ID FROM trainer$ where [Email] ='" + a + "'";
                object r;
                cm = new SqlCommand(query4, conn);
                r = cm.ExecuteScalar();
                int ID = Convert.ToInt32(r);
                conn.Close();

                Trainer_home trainer_Home = new Trainer_home(ID);
                this.Hide();
                trainer_Home.Show();
            }
            else
            {
                string query = "SELECT count(*) as column1 FROM Admin$ WHERE [Email] = '" + a + "' AND [PASSWORD] = '" + b + "'";
                cm = new SqlCommand(query, conn);
                SqlDataReader d = cm.ExecuteReader();
                int c = 0;
                while (d.Read())
                {
                    c = d.GetInt32(d.GetOrdinal("column1"));
                }
                d.Close();
                if (c == 0) { MessageBox.Show("invalid username or password"); return; }
                else MessageBox.Show("Login Successfully");
                cm.Dispose();
                conn.Close();

                admin_home admin_Home = new admin_home();
                this.Hide();
                admin_Home.Show();
            }
        }

		private void goBackButton_Click(object sender, EventArgs e)
		{
			homePage homePage = new homePage();
			this.Hide();
			homePage.Show();
		}

		private void loginPage_Load(object sender, EventArgs e)
		{
		   
		}
	}
}
