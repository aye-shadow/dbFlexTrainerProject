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
    public partial class view_members_trainer : Form
    {
        private string gymName;
        public view_members_trainer(string gymName)
        {
            InitializeComponent();
            this.gymName = gymName;
            label1.Text = "Clients in " + gymName;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Trainer_home trainer_Home = new Trainer_home();
            this.Hide();
            trainer_Home.Show();
        }
    }
}
