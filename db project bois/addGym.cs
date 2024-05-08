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
    public partial class addGym : Form
    {
        public addGym()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool textBoxEmpty = false;

            foreach (Control control in Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        textBoxEmpty = true;
                        MessageBox.Show("Fields cannot be left empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }
            
            if (!textBoxEmpty)
            {
                // add gym to db
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text != "REGISTER")
            {
                manage_gym manage_Gym = new manage_gym();
                this.Hide();
                manage_Gym.Show();
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
    }
}
