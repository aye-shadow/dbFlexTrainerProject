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
			if (memberType == "member")
			{
				Db_project_1.Members members = new Db_project_1.Members();
				this.Hide();
				members.Show();
			}
			else if (memberType == "owner")
			{
				ownerHome ownerHome = new ownerHome();
				this.Hide();
				ownerHome.Show();
			} 
			else if (memberType == "trainer")
			{
				Trainer_home trainer_Home = new Trainer_home();
				this.Hide();
				trainer_Home.Show();
			}
			else
			{
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
