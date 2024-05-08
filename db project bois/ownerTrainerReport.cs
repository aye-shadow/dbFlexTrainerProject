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
    public partial class ownerTrainerReport : Form
    {
        private string gymName;
        public ownerTrainerReport(string gymName)
        {
            InitializeComponent();
            this.gymName = gymName;
            label8.Text = "Trainer reports at " + gymName;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // match details from db and display in form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db_project_bois.ownerHome o1 = new db_project_bois.ownerHome();
            this.Hide();
            o1.Show();
        }
    }
}
