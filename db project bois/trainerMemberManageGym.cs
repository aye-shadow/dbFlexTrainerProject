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
    public partial class trainerMemberManageGym : Form
    {
        private bool memberType;
        public int ID;
        public trainerMemberManageGym(bool memberType, int id)
        {
            InitializeComponent();
            this.memberType = memberType;
            ID = id;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (memberType == false)
            {
                Trainer_home trainer_Home = new Trainer_home(ID);
                this.Hide();
                trainer_Home.Show();
            }
            else
            {
                Db_project_1.Members members = new Db_project_1.Members(ID);
                this.Hide();
                members.Show();
            }
            
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            joinNewGym trainer_Join_Gym = new joinNewGym(memberType, ID);
            this.Hide();
            trainer_Join_Gym.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            leaveCurrentGym trainer_Leave_Gym = new leaveCurrentGym(memberType, ID);
            this.Hide();
            trainer_Leave_Gym.Show();
        }
    }
}
