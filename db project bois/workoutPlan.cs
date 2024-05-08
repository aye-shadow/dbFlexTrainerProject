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
using WindowsFormsApp1;

namespace Db_project_1
{
    public partial class workoutPlan : Form
    {
        private bool memberType;
        public workoutPlan(bool memberType)
        {
            InitializeComponent();
            this.memberType = memberType;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            viewWorkout viewWorkout = new viewWorkout(memberType);
            this.Hide();
            viewWorkout.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            createNewWorkout createNewWorkout = new createNewWorkout(memberType);
            this.Hide();
            createNewWorkout.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (memberType == true)
            {
                Members members = new Members();
                this.Hide();
                members.Show();
            }
            else
            {
                Trainer_home trainer_Home = new Trainer_home();
                this.Hide();
                trainer_Home.Show();
            }
        }
    }
}
