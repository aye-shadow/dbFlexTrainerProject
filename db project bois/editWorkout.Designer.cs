namespace db_project_bois
{
    partial class editWorkout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editWorkout));
            flowLayoutPanel1 = new FlowLayoutPanel();
            comboBox2 = new ComboBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            textBox2 = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            button1 = new Button();
            linkLabel3 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            flowLayoutPanel1.Location = new Point(156, 200);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(382, 141);
            flowLayoutPanel1.TabIndex = 101;
            flowLayoutPanel1.WrapContents = false;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Enabled = false;
            comboBox2.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Weight Loss", "Bulking", "Cutting" });
            comboBox2.Location = new Point(123, 128);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(415, 26);
            comboBox2.TabIndex = 100;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial Rounded MT Bold", 8F);
            label2.Location = new Point(67, 132);
            label2.Name = "label2";
            label2.Size = new Size(50, 18);
            label2.TabIndex = 99;
            label2.Text = "Goal:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Enabled = false;
            comboBox1.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Beginner", "Intermediate\t", "Advanced" });
            comboBox1.Location = new Point(223, 165);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(315, 26);
            comboBox1.TabIndex = 98;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Arial Rounded MT Bold", 8F);
            textBox2.Location = new Point(204, 93);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(334, 26);
            textBox2.TabIndex = 97;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Rounded MT Bold", 8F);
            label1.Location = new Point(68, 96);
            label1.Name = "label1";
            label1.Size = new Size(130, 18);
            label1.TabIndex = 96;
            label1.Text = "Workout Name:";
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(214, 351);
            panel1.Name = "panel1";
            panel1.Size = new Size(324, 33);
            panel1.TabIndex = 95;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Arial Rounded MT Bold", 9F);
            radioButton2.Location = new Point(166, 4);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(90, 25);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Public";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButton1.Location = new Point(7, 4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(98, 25);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Private";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Arial Rounded MT Bold", 8F);
            label8.Location = new Point(67, 356);
            label8.Name = "label8";
            label8.Size = new Size(117, 18);
            label8.TabIndex = 94;
            label8.Text = "Share Status:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Arial Rounded MT Bold", 8F);
            label9.Location = new Point(68, 205);
            label9.Name = "label9";
            label9.Size = new Size(82, 18);
            label9.TabIndex = 93;
            label9.Text = "Exercise:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Arial Rounded MT Bold", 8F);
            label10.Location = new Point(67, 168);
            label10.Name = "label10";
            label10.Size = new Size(150, 18);
            label10.TabIndex = 92;
            label10.Text = "Experience Level:";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(247, 86, 126);
            button1.DialogResult = DialogResult.No;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(605, 243);
            button1.Name = "button1";
            button1.Size = new Size(144, 36);
            button1.TabIndex = 91;
            button1.Text = "GO BACK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // linkLabel3
            // 
            linkLabel3.BackColor = Color.Transparent;
            linkLabel3.Font = new Font("Arial Rounded MT Bold", 8F);
            linkLabel3.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel3.LinkColor = Color.Black;
            linkLabel3.Location = new Point(647, 170);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(75, 24);
            linkLabel3.TabIndex = 90;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Delete";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // linkLabel1
            // 
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.Font = new Font("Arial Rounded MT Bold", 8F);
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(647, 94);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(103, 22);
            linkLabel1.TabIndex = 89;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Update";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // editWorkout
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.workoutPageFRJPG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(778, 444);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(button1);
            Controls.Add(linkLabel3);
            Controls.Add(linkLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "editWorkout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Workout";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private ComboBox comboBox2;
        private Label label2;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private Label label1;
        private Panel panel1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button button1;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel1;
    }
}