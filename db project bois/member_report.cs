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
    public partial class member_report : Form
    {
        private string gymName;
        public member_report(string gymName)
        {
            InitializeComponent();
            this.gymName = gymName; 
            label8.Text = "Member Reports at " + gymName;
        }

        private void goback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            db_project_bois.ownerHome o1 = new db_project_bois.ownerHome(); 
            this.Hide();
            o1.Show();
        }

        private void member_report_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // match details from db and display in form
        }
    }
}
