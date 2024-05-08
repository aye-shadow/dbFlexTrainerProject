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
    public partial class removeGyms : Form
    {
        public removeGyms()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool loopBreaked = true;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    button1.Text = "REMOVE";
                    loopBreaked = false;
                    break;
                }
            }
            if (loopBreaked)
            {
                button1.Text = "GO BACK";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "REMOVE")
            {
                DialogResult result = MessageBox.Show("Remove gyms permanently?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        if (checkedListBox1.GetItemChecked(i))
                        {
                            checkedListBox1.Items.RemoveAt(i);
                            --i;
                        }
                    }
                    // remove gyms from database
                    button1.Text = "GO BACK";
                }
                else
                {
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                    button1.Text = "GO BACK";
                }
            }
            else
            {
                manage_gym manage_Gym = new manage_gym();
                this.Hide();    
                manage_Gym.Show();
            }
        }
    }
}
