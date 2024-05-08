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
    public partial class manage_gym : Form
    {
        public manage_gym()
        {
            InitializeComponent();
        }

        private void manage_gym_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            viewGyms viewGyms = new viewGyms();
            this.Hide();
            viewGyms.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_home admin_Home = new admin_home();
            this.Hide();
            admin_Home.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            removeGyms removeGyms = new removeGyms();
            this.Hide();
            removeGyms.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addGym addGym = new addGym();
            this.Hide(); 
            addGym.Show();
        }
    }
}
