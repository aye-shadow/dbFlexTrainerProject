namespace WindowsFormsApp1
{
    partial class view_feedback_trainer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(view_feedback_trainer));
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox4
            // 
            textBox4.Enabled = false;
            textBox4.Location = new Point(330, 345);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.ScrollBars = ScrollBars.Vertical;
            textBox4.Size = new Size(452, 190);
            textBox4.TabIndex = 68;
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Location = new Point(367, 132);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(415, 31);
            textBox3.TabIndex = 67;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Arial Rounded MT Bold", 10F);
            label7.Location = new Point(196, 344);
            label7.Name = "label7";
            label7.Size = new Size(121, 23);
            label7.TabIndex = 66;
            label7.Text = "Comments:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Arial Rounded MT Bold", 10F);
            label8.Location = new Point(196, 131);
            label8.Name = "label8";
            label8.Size = new Size(154, 23);
            label8.TabIndex = 65;
            label8.Text = "Overall Rating:";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 172, 236);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Rounded MT Bold", 8F);
            button1.Location = new Point(756, 615);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(181, 54);
            button1.TabIndex = 69;
            button1.Text = "GO BACK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(352, 199);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(430, 31);
            textBox1.TabIndex = 71;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Rounded MT Bold", 10F);
            label1.Location = new Point(196, 198);
            label1.Name = "label1";
            label1.Size = new Size(141, 23);
            label1.TabIndex = 70;
            label1.Text = "GymX Rating:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial Rounded MT Bold", 10F);
            label2.Location = new Point(196, 270);
            label2.Name = "label2";
            label2.Size = new Size(165, 23);
            label2.TabIndex = 72;
            label2.Text = "Member Rating:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Dummy Member1", "Dummy Member2", "Dummy Member3", "Dummy Member4", "Dummy Member5", "Dummy Member6", "Dummy Member7", "Dummy Member8", "Dummy Member9", "Dummy Member10", "Dummy Member11", "Dummy Member12", "Dummy Member13", "Dummy Member14", "Dummy Member15", "Dummy Member16", "Dummy Member17", "Dummy Member18", "Dummy Member19", "Dummy Member20", "Dummy Member21", "Dummy Member22", "Dummy Member23", "Dummy Member24", "Dummy Member25" });
            comboBox1.Location = new Point(379, 270);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(403, 33);
            comboBox1.TabIndex = 73;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(254, 233, 238);
            label3.Font = new Font("Arial Rounded MT Bold", 10F);
            label3.Location = new Point(283, 106);
            label3.MinimumSize = new Size(444, 125);
            label3.Name = "label3";
            label3.Size = new Size(444, 125);
            label3.TabIndex = 74;
            // 
            // view_feedback_trainer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = db_project_bois.Properties.Resources.feedbackJPG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1000, 702);
            Controls.Add(label8);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(label7);
            Controls.Add(label3);
            Controls.Add(button1);
            DoubleBuffered = true;
            Icon = Icon.FromHandle((global::db_project_bois.Properties.Resources.icon).GetHicon());
            Margin = new Padding(3, 5, 3, 5);
            Name = "view_feedback_trainer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View Feedback";
            Load += view_feedback_trainer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
    }
}