using Db_project_1;
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
    public partial class viewWorkoutReport : Form
    {
        private bool memberType;
        public viewWorkoutReport(bool memberType)
        {
            InitializeComponent();
            this.memberType = memberType;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            viewWorkout memberDietplan = new viewWorkout(memberType);
            this.Hide();
            memberDietplan.Show();
        }
    }
}
