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
    public partial class ownerAddNewGym : Form
    {
        public ownerAddNewGym()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ownerAndHisGyms ownerAndHisGyms = new ownerAndHisGyms();
            this.Hide();
            ownerAndHisGyms.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fnameTextBox.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Fields cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // insert into database with status = "pending"

                MessageBox.Show("Gym registration succesfull!");
                ownerAndHisGyms ownerAndHisGyms = new ownerAndHisGyms();
                this.Hide();
                ownerAndHisGyms.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
