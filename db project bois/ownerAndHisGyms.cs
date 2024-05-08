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
    public partial class ownerAndHisGyms : Form
    {
        public ownerAndHisGyms()
        {
            InitializeComponent();
        }

        private void ownerAndHisGyms_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ownerHome ownerHome = new ownerHome();
            this.Hide();
            ownerHome.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ownerAddNewGym ownerAddNewGym = new ownerAddNewGym();
            this.Hide();
            ownerAddNewGym.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ownerDeleteExistingGym ownerDeleteExistingGym = new ownerDeleteExistingGym();
            this.Hide();
            ownerDeleteExistingGym.Show();
        }
    }
}
