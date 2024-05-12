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
    public partial class Manage_member : Form
    {
        private string gymName;
        public int id, gid;
        public Manage_member(string gym, int gid, int id)
        {
            InitializeComponent();
            gymName = gym;
            label1.Text = "Mange members at " + gymName;
            this.gid = gid;
            this.id = id;
        }

        private void manage_account_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ownerRemoveMemberAccounts ownerManageMemberAccounts = new ownerRemoveMemberAccounts(gymName,gid,id);
            this.Hide();
            ownerManageMemberAccounts.Show();
        }

        private void view_members_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ownerViewAllMembers ownerViewAllMembers = new ownerViewAllMembers(gymName, gid, id);
            this.Hide();
            ownerViewAllMembers.Show();
        }

        private void Manage_member_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            db_project_bois.ownerHome ownerHome = new db_project_bois.ownerHome(id);
            this.Close();
            ownerHome.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
