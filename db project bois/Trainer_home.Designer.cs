namespace WindowsFormsApp1
{
    partial class Trainer_home
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
            linkLabel4 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            linkLabel5 = new LinkLabel();
            linkLabel6 = new LinkLabel();
            linkLabel7 = new LinkLabel();
            comboBox1 = new ComboBox();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            linkLabel11 = new LinkLabel();
            linkLabel12 = new LinkLabel();
            button2 = new Button();
            button1 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // linkLabel4
            // 
            linkLabel4.ActiveLinkColor = Color.LightCoral;
            linkLabel4.AutoSize = true;
            linkLabel4.BackColor = Color.Transparent;
            linkLabel4.Font = new Font("Arial Rounded MT Bold", 8F);
            linkLabel4.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel4.LinkColor = Color.Black;
            linkLabel4.Location = new Point(102, 82);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(68, 18);
            linkLabel4.TabIndex = 10;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "Log out";
            linkLabel4.LinkClicked += linkLabel4_LinkClicked;
            // 
            // linkLabel3
            // 
            linkLabel3.ActiveLinkColor = Color.LightCoral;
            linkLabel3.AutoSize = true;
            linkLabel3.BackColor = Color.Transparent;
            linkLabel3.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel3.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel3.LinkColor = Color.Black;
            linkLabel3.Location = new Point(103, 440);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(43, 36);
            linkLabel3.TabIndex = 13;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Diet\r\nPlan";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // linkLabel5
            // 
            linkLabel5.ActiveLinkColor = Color.LightCoral;
            linkLabel5.AutoSize = true;
            linkLabel5.BackColor = Color.Transparent;
            linkLabel5.Font = new Font("Arial Rounded MT Bold", 8F);
            linkLabel5.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel5.LinkColor = Color.Black;
            linkLabel5.Location = new Point(98, 555);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(119, 36);
            linkLabel5.TabIndex = 14;
            linkLabel5.TabStop = true;
            linkLabel5.Text = "Manage\r\nAppointments";
            linkLabel5.LinkClicked += linkLabel5_LinkClicked;
            // 
            // linkLabel6
            // 
            linkLabel6.ActiveLinkColor = Color.LightCoral;
            linkLabel6.AutoSize = true;
            linkLabel6.BackColor = Color.Transparent;
            linkLabel6.Font = new Font("Arial Rounded MT Bold", 8F);
            linkLabel6.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel6.LinkColor = Color.Black;
            linkLabel6.Location = new Point(332, 568);
            linkLabel6.Name = "linkLabel6";
            linkLabel6.Size = new Size(87, 18);
            linkLabel6.TabIndex = 15;
            linkLabel6.TabStop = true;
            linkLabel6.Text = "Feedback";
            linkLabel6.LinkClicked += linkLabel6_LinkClicked;
            // 
            // linkLabel7
            // 
            linkLabel7.ActiveLinkColor = Color.LightCoral;
            linkLabel7.AutoSize = true;
            linkLabel7.BackColor = Color.Transparent;
            linkLabel7.Font = new Font("Arial Rounded MT Bold", 8F);
            linkLabel7.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel7.LinkColor = Color.Black;
            linkLabel7.Location = new Point(549, 555);
            linkLabel7.Name = "linkLabel7";
            linkLabel7.Size = new Size(81, 36);
            linkLabel7.TabIndex = 16;
            linkLabel7.TabStop = true;
            linkLabel7.Text = "View \r\nMembers";
            linkLabel7.LinkClicked += linkLabel7_LinkClicked;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Dummy Gym1", "Dummy Gym2", "Dummy Gym3", "Dummy Gym4", "Dummy Gym5", "Dummy Gym6", "Dummy Gym7" });
            comboBox1.Location = new Point(390, 184);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(450, 33);
            comboBox1.TabIndex = 69;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox5
            // 
            textBox5.Enabled = false;
            textBox5.Location = new Point(411, 378);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(428, 31);
            textBox5.TabIndex = 66;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Arial Rounded MT Bold", 10F);
            label6.Location = new Point(319, 376);
            label6.Name = "label6";
            label6.Size = new Size(79, 23);
            label6.TabIndex = 65;
            label6.Text = "Rating:";
            // 
            // textBox4
            // 
            textBox4.Enabled = false;
            textBox4.Location = new Point(458, 316);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.PasswordChar = '*';
            textBox4.Size = new Size(382, 31);
            textBox4.TabIndex = 64;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Location = new Point(408, 250);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(432, 31);
            textBox3.TabIndex = 63;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Font = new Font("Arial Rounded MT Bold", 8F);
            textBox1.Location = new Point(411, 129);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(428, 26);
            textBox1.TabIndex = 62;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Arial Rounded MT Bold", 10F);
            label7.Location = new Point(319, 315);
            label7.Name = "label7";
            label7.Size = new Size(113, 23);
            label7.TabIndex = 61;
            label7.Text = "Password:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Arial Rounded MT Bold", 10F);
            label8.Location = new Point(319, 249);
            label8.Name = "label8";
            label8.Size = new Size(69, 23);
            label8.TabIndex = 60;
            label8.Text = "Email:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Arial Rounded MT Bold", 10F);
            label9.Location = new Point(319, 186);
            label9.Name = "label9";
            label9.Size = new Size(61, 23);
            label9.TabIndex = 59;
            label9.Text = "Gym:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Arial Rounded MT Bold", 10F);
            label10.Location = new Point(319, 128);
            label10.Name = "label10";
            label10.Size = new Size(73, 23);
            label10.TabIndex = 58;
            label10.Text = "Name:";
            // 
            // linkLabel11
            // 
            linkLabel11.ActiveLinkColor = Color.LightCoral;
            linkLabel11.AutoSize = true;
            linkLabel11.BackColor = Color.Transparent;
            linkLabel11.Font = new Font("Arial Rounded MT Bold", 8F);
            linkLabel11.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel11.LinkColor = Color.Black;
            linkLabel11.Location = new Point(101, 312);
            linkLabel11.MaximumSize = new Size(111, 0);
            linkLabel11.Name = "linkLabel11";
            linkLabel11.Size = new Size(79, 36);
            linkLabel11.TabIndex = 71;
            linkLabel11.TabStop = true;
            linkLabel11.Text = "Workout Plan";
            linkLabel11.LinkClicked += linkLabel11_LinkClicked;
            // 
            // linkLabel12
            // 
            linkLabel12.ActiveLinkColor = Color.LightCoral;
            linkLabel12.AutoSize = true;
            linkLabel12.BackColor = Color.Transparent;
            linkLabel12.Font = new Font("Arial Rounded MT Bold", 8F);
            linkLabel12.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel12.LinkColor = Color.Black;
            linkLabel12.Location = new Point(101, 184);
            linkLabel12.Name = "linkLabel12";
            linkLabel12.Size = new Size(118, 36);
            linkLabel12.TabIndex = 70;
            linkLabel12.TabStop = true;
            linkLabel12.Text = "Edit Personal \r\nDetails";
            linkLabel12.LinkClicked += linkLabel12_LinkClicked;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(128, 102, 165);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Arial Rounded MT Bold", 8F);
            button2.Location = new Point(272, 529);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(196, 98);
            button2.TabIndex = 74;
            button2.Text = "CANCEL";
            button2.UseVisualStyleBackColor = false;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(128, 102, 165);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Rounded MT Bold", 8F);
            button1.Location = new Point(489, 529);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(196, 98);
            button1.TabIndex = 73;
            button1.Text = "UPDATE";
            button1.UseVisualStyleBackColor = false;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(128, 102, 165);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Arial Rounded MT Bold", 8F);
            button3.Location = new Point(724, 13);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(242, 48);
            button3.TabIndex = 75;
            button3.Text = "MANAGE MEMBERSHIPS";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Trainer_home
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = db_project_bois.Properties.Resources.memberSpecificHomePages;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(978, 708);
            Controls.Add(button3);
            Controls.Add(linkLabel11);
            Controls.Add(linkLabel12);
            Controls.Add(comboBox1);
            Controls.Add(textBox5);
            Controls.Add(label6);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(linkLabel7);
            Controls.Add(linkLabel6);
            Controls.Add(linkLabel5);
            Controls.Add(linkLabel3);
            Controls.Add(linkLabel4);
            Controls.Add(button1);
            Controls.Add(button2);
            Margin = new Padding(3, 5, 3, 5);
            Name = "Trainer_home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trainer Home";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.LinkLabel linkLabel7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel linkLabel11;
        private System.Windows.Forms.LinkLabel linkLabel12;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Button button3;
    }
}