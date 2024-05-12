using Db_project_1;
using db_project_bois;
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
    public partial class manageDietPlan : Form
    {
        private bool memberType;
        private int memberID;
        // if 1 = trainer, 0 = member
        public manageDietPlan(bool memberType, int memberID)
        {
            InitializeComponent();
            this.memberType = memberType;
            this.memberID = memberID;   
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dietPlan dietplan = new dietPlan(memberType, memberID);
            this.Hide();
            dietplan.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            createDietPlan dietplan = new createDietPlan(memberType, memberID);
            this.Hide();
            dietplan.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (memberType == false)
            {
                Trainer_home trainer = new Trainer_home(memberID);
                this.Hide();
                trainer.Show();
            }
            else
            {
                Members members = new Members(memberID);
                this.Hide(); 
                members.Show();
            }
        }

        private void manageDietPlan_Load(object sender, EventArgs e)
        {

        }
    }
}
