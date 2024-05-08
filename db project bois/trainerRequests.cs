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
    public partial class trainerRequests : Form
    {
        private string gymName;
        public trainerRequests(string gymName)
        {
            InitializeComponent();
            this.gymName = gymName;
            label3.Text = "Trainer Applications at " + gymName;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool loopBreaked = false;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    button1.Text = "REGISTER";
                    loopBreaked = true;
                    break;
                }
            }

            if (!loopBreaked)
            {
                button1.Text = "GO BACK";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text != "REGISTER")
            {
                manage_trainer manage_Trainer = new manage_trainer(gymName);
                this.Hide();
                manage_Trainer.Show();
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        checkedListBox1.Items.RemoveAt(i);
                        // also change status to "approve" in db
                        --i;
                    }
                }
                button1.Text = "GO BACK";
            }
        }
    }
}
