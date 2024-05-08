using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace db_project_bois
{
    public partial class admin_home : Form
    {
        public admin_home()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        string ogName, ogEmail, ogPassword;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // edit personal details
            button1.Visible = true;
            button2.Visible = true;
            textBox1.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;
            linkLabel3.Enabled = false;
            linkLabel4.Enabled = false;

            ogName = textBox1.Text;
            ogEmail = textBox3.Text;
            ogPassword = textBox4.Text;
        }

        private void admin_home_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            homePage homePage = new homePage();
            this.Hide();
            homePage.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            adminGymReport gym_Report = new adminGymReport();
            this.Hide();
            gym_Report.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            manage_gym manage_Gym = new manage_gym();
            this.Hide();
            manage_Gym.Show();
        }

        private void resetValues()
        {
            button1.Visible = false;
            button2.Visible = false;
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            linkLabel1.Enabled = true;
            linkLabel2.Enabled = true;
            linkLabel3.Enabled = true;
            linkLabel4.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
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
                // textboxes not empty
                if (!Regex.IsMatch(textBox3.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    // validate email format
                    MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
                else
                {
                    // email is also valid
                    // update personal details
                    resetValues();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // reset values back to original
            textBox1.Text = ogName;
            textBox3.Text = ogEmail;
            textBox4.Text = ogPassword;
            resetValues();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
