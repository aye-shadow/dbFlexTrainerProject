using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class leaveCurrentGym : Form
    {
        private bool memberType;
        public leaveCurrentGym(bool memberType)
        {
            InitializeComponent();
            this.memberType = memberType;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trainerMemberManageGym trainerMemberManageGym = new trainerMemberManageGym(memberType);
            this.Hide();
            trainerMemberManageGym.Show();
        }

        private void leaveCurrentGym_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter a gym to leave!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (memberType)
                {
                    // remove from member db
                }
                else
                {
                    // remove from trainer db
                }
            }
        }
    }
}
