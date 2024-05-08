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
    public partial class joinNewGym : Form
    {
        private bool memberType;
        public joinNewGym(bool memberType)
        {
            InitializeComponent();
            this.memberType = memberType;
            if (memberType == false)
            {
                label1.Visible = false;
                comboBox2.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            trainerMemberManageGym trainerMemberManageGym = new trainerMemberManageGym(memberType);
            this.Hide();
            trainerMemberManageGym.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || (memberType && comboBox2.SelectedIndex == -1))
            {
                MessageBox.Show("Fields cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (memberType)
                {
                    // enter into member db
                }
                else
                {
                    // enter into trainer db
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
