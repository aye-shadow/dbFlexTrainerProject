using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ownerViewAllMembers : Form
    {
        private string gymName;
        public ownerViewAllMembers(string gymName)
        {
            InitializeComponent();
            this.gymName = gymName;
            label1.Text = "Members at " + gymName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manage_member manage_Member = new Manage_member(gymName);
            this.Hide();
            manage_Member.Show();
        }
    }
}
