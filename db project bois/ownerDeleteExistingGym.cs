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
    public partial class ownerDeleteExistingGym : Form
    {
        public ownerDeleteExistingGym()
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
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select gym to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // delete from db

                MessageBox.Show("Gym successfully deleted!");
                ownerAndHisGyms ownerAndHisGyms = new ownerAndHisGyms();
                this.Hide();
                ownerAndHisGyms.Show();
            }
        }
    }
}
