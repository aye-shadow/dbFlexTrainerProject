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
    public partial class signUpPage : Form
    {
        public signUpPage()
        {
            InitializeComponent();
        }
        private void signUpPage_Load(object sender, EventArgs e)
        {

        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            typeOfLogin loginPage = new typeOfLogin();
            this.Hide();
            loginPage.Show();
        }

        private void memberSignupButton_Click(object sender, EventArgs e)
        {
            memberSignup memberSignup = new memberSignup();
            this.Hide();
            memberSignup.Show();
        }

        private void trainerSignupButton_Click(object sender, EventArgs e)
        {
            trainerSignupPage memberSignup = new trainerSignupPage();
            this.Hide();
            memberSignup.Show();
        }

        private void ownerSignupButton_Click(object sender, EventArgs e)
        {
            ownerSignUpPage ownerSignUp = new ownerSignUpPage();
            this.Hide();
            ownerSignUp.Show();
        }
    }
}
