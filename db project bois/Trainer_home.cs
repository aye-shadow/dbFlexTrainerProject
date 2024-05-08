using Db_project_1;
using db_project_bois;
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
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Trainer_home : Form
    {
        public Trainer_home()
        {
            InitializeComponent();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gymSelected())
            {
                // view members page go to
                view_members_trainer view_Members_Trainer = new view_members_trainer(selectGymName());
                this.Hide();
                view_Members_Trainer.Show();
            }
            else
            {
                MessageBox.Show("Please select a gym first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void resetValues()
        {
            button1.Visible = false;
            button2.Visible = false;

            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

            linkLabel4.Enabled = true;
            linkLabel12.Enabled = true;
            linkLabel11.Enabled = true;
            linkLabel3.Enabled = true;
            linkLabel5.Enabled = true;

            linkLabel6.Visible = true;
            linkLabel7.Visible = true;
        }

        private bool gymSelected()
        {
            return comboBox1.SelectedItem == null || comboBox1.SelectedIndex == -1;
        }

        private string selectGymName()
        {
            return comboBox1.SelectedItem.ToString();
        }

        private string ogName, ogEmail, ogPassword;

        private void button2_Click(object sender, EventArgs e)
        {
            // reset values back to original
            textBox1.Text = ogName;
            textBox3.Text = ogEmail;
            textBox4.Text = ogPassword;
            resetValues();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            homePage homePage = new homePage();
            this.Hide();
            homePage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool textBoxEmpty = false;

            foreach (Control control in Controls)
            {
                if (control is TextBox textBox && textBox != textBox5)
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
                    // update personal details in db
                    resetValues();
                }
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // can view all appointments regardless of gym

            manage_appointments_trainer manage_Appointments_Trainer = new manage_appointments_trainer();
            this.Hide();
            manage_Appointments_Trainer.Show();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gymSelected())
            {
                workoutPlan workoutPlan = new workoutPlan(false);
                this.Hide();
                workoutPlan.Show();
            }
            else
            {
                MessageBox.Show("Please select a gym first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gymSelected())
            {
                manageDietPlan dietPlan = new manageDietPlan(false);
                this.Hide();
                dietPlan.Show();
            }
            else
            {
                MessageBox.Show("Please select a gym first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gymSelected())
            {
                // go to view feedback page
                view_feedback_trainer view_Feedback_Trainer = new view_feedback_trainer(selectGymName());
                this.Hide();
                view_Feedback_Trainer.Show();
            }
            else
            {
                MessageBox.Show("Please select a gym first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;

            textBox1.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;

            linkLabel4.Enabled = false;
            linkLabel12.Enabled = false;
            linkLabel11.Enabled = false;
            linkLabel3.Enabled = false;
            linkLabel5.Enabled = false;

            linkLabel6.Visible = false;
            linkLabel7.Visible = false;

            ogName = textBox1.Text;
            ogEmail = textBox3.Text;
            ogPassword = textBox4.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trainerMemberManageGym trainer_Manage_Gym = new trainerMemberManageGym(false);
            this.Hide();
            trainer_Manage_Gym.Show();
        }
    }
}
