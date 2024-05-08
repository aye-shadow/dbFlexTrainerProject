using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db_project_bois
{
    public partial class typeOfLogin : Form
    {
        public typeOfLogin()
        {
            InitializeComponent();
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            homePage loginPage = new homePage();
            this.Hide();
            loginPage.Show();
        }

        private void memberSignupButton_Click(object sender, EventArgs e)
        {
            loginPage loginPage = new loginPage("member");
            this.Hide();
            loginPage.Show();
        }

        private void trainerSignupButton_Click(object sender, EventArgs e)
        {
            loginPage loginPage = new loginPage("trainer");
            this.Hide();
            loginPage.Show();
        }

        private void ownerSignupButton_Click(object sender, EventArgs e)
        {
            loginPage loginPage = new loginPage("owner");
            this.Hide();
            loginPage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginPage loginPage = new loginPage("admin");
            this.Hide();
            loginPage.Show();
        }
    }
}
