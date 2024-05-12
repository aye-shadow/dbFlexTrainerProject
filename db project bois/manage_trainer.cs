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
        int gid, id;
        public manage_trainer(string gymName, int gid, int id)
        {
            InitializeComponent();
            this.gymName = gymName;
            label1.Text = "Manage Trainers at " + gymName;
            this.gid   = gid;
            this.id = id;
        }

        private void view_members_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            trainerRequests trainerRequests = new trainerRequests(gymName, gid, id);
            this.Hide();
            trainerRequests.Show();
        }

        private void manage_account_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            removeTrainers removeTrainers = new removeTrainers(gymName, gid, id);
            this.Hide();
            removeTrainers.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db_project_bois.ownerHome o1 = new db_project_bois.ownerHome(id);
            this.Hide();
            o1.Show();
        }
    }
}
