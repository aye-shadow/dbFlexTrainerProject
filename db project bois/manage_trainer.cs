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
    public partial class manage_trainer : Form
    {
        private string gymName;
        public manage_trainer(string gymName)
        {
            InitializeComponent();
            this.gymName = gymName;
            label1.Text = "Manage Trainers at " + gymName;
        }

        private void view_members_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            trainerRequests trainerRequests = new trainerRequests(gymName);
            this.Hide();
            trainerRequests.Show();
        }

        private void manage_account_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            removeTrainers removeTrainers = new removeTrainers(gymName);
            this.Hide();
            removeTrainers.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db_project_bois.ownerHome o1 = new db_project_bois.ownerHome();
            this.Hide();
            o1.Show();
        }
    }
}
