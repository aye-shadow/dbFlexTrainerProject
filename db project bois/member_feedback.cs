using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Db_project_1
{
    public partial class member_feedback : Form
    {
        public member_feedback()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Members form = new Members();
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Fields cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Feedback submitted!");
                Members members = new Members();
                this.Hide();
                members.Show();
            }
        }
    }
}
