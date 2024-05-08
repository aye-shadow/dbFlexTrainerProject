using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using db_project_bois;
using WindowsFormsApp1;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Db_project_1
{
    public partial class Members : Form
    {
        public Members()
        {
            InitializeComponent();
            textBox5.KeyPress += textBox5_KeyPressed;
        }

        private bool gymSelected()
        {
            return comboBox1.SelectedItem == null || comboBox1.SelectedIndex == -1;
        }

        private string selectGymName()
        {
            return comboBox1.SelectedItem.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            homePage homePage = new homePage();
            this.Hide();
            homePage.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;

            textBox1.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            comboBox1.Enabled = true;

            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;
            linkLabel4.Enabled = false;
            linkLabel6.Enabled = false;
            linkLabel7.Enabled = false;
            linkLabel8.Visible = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gymSelected())
            {
                workoutPlan form = new workoutPlan(true);
                this.Hide();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a gym first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gymSelected())
            {
                manageDietPlan dietPlan = new manageDietPlan(true);
                this.Hide();
                dietPlan.Show();
            }
            else
            {
                MessageBox.Show("Please select a gym first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            appointmentdetails memberManageAppointments = new appointmentdetails();
            this.Hide();
            memberManageAppointments.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            member_feedback form = new member_feedback();
            this.Hide();
            form.ShowDialog();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void resetValues()
        {
            button1.Visible = false;
            button2.Visible = false;

            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            comboBox1.Enabled = false;

            linkLabel1.Enabled = true;
            linkLabel2.Enabled = true;
            linkLabel4.Enabled = true;
            linkLabel6.Enabled = true;
            linkLabel7.Enabled = true;
            linkLabel8.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetValues();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool textBoxEmpty = false;

            foreach (Control control in Controls)
            {
                if (control is System.Windows.Forms.TextBox textBox)
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

        private void button3_Click(object sender, EventArgs e)
        {
            trainerMemberManageGym trainerMemberManageGym = new trainerMemberManageGym(true);
            this.Hide();
            trainerMemberManageGym.Show();
        }

        private void Members_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPressed(object sender, KeyPressEventArgs e)
        {
            // only allow numeric input
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If not a control key or a digit, ignore the key press event
                e.Handled = true;
            }
        }
    }
}
