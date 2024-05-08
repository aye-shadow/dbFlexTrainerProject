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
    public partial class view_feedback_trainer : Form
    {
        private string gymName;
        public view_feedback_trainer(string gymName)
        {
            InitializeComponent();
            this.gymName = gymName;
            label1.Text = gymName + " Rating:";

            Size labelSize = label1.Size;
            textBox1.Size = new Size(528 - labelSize.Width, textBox1.Height);

            Point labelLocation = label1.Location;
            textBox1.Location = new Point(labelSize.Width + labelLocation.X, textBox1.Location.Y);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Trainer_home trainer_Home = new Trainer_home();
            this.Hide();
            trainer_Home.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // depending on member chosen, edit textbox4 with member comments/rating from db
        }

        private void view_feedback_trainer_Load(object sender, EventArgs e)
        {

        }
    }
}
