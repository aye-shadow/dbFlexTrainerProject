namespace db_project_bois
{
    partial class viewWorkout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewWorkout));
            comboBox1 = new ComboBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button1 = new Button();
            linkLabel3 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            label2 = new Label();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Trainer", "Member", "Goal: Bulking", "Goal: Cutting", "Goal: Weight Loss", "Experience Level: Beginner", "Experience Level: Intermediate", "Experience Level: Advanced", "Oldest to Newest", "Newest to Oldest" });
            comboBox1.Location = new Point(315, 78);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(240, 26);
            comboBox1.TabIndex = 29;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(58, 112);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(497, 282);
            flowLayoutPanel1.TabIndex = 33;
            flowLayoutPanel1.WrapContents = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(247, 86, 126);
            button1.DialogResult = DialogResult.No;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(606, 242);
            button1.Name = "button1";
            button1.Size = new Size(144, 36);
            button1.TabIndex = 32;
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
            linkLabel3.Location = new Point(647, 162);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(75, 39);
            linkLabel3.TabIndex = 31;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Shared Plans";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // linkLabel1
            // 
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.Font = new Font("Arial Rounded MT Bold", 8F);
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(647, 93);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(103, 22);
            linkLabel1.TabIndex = 30;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Your Plans";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial Rounded MT Bold", 8F);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(239, 81);
            label2.Name = "label2";
            label2.Size = new Size(70, 18);
            label2.TabIndex = 106;
            label2.Text = "Sort by:";
            // 
            // viewWorkout
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.workoutPageFRJPG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(778, 444);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button1);
            Controls.Add(linkLabel3);
            Controls.Add(linkLabel1);
            Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "viewWorkout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View Workouts";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel1;
        private Label label2;
    }
}