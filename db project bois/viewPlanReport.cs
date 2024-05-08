﻿using Db_project_1;
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
    public partial class viewPlanReport : Form
    {
        private bool memberType;
        public viewPlanReport(bool memberType)
        {
            InitializeComponent();
            this.memberType = memberType;
            displayMealsAndSubscribedClients();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dietPlan memberDietplan = new dietPlan(memberType);
            this.Hide();
            memberDietplan.Show();
        }

        private void displayMealsAndSubscribedClients()
        {
            // load from db like in editPlan or dietPlan
        }
    }
}
