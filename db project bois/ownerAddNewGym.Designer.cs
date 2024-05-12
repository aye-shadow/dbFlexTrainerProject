namespace db_project_bois
{
    partial class ownerAddNewGym
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ownerAddNewGym));
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button3 = new Button();
            fnameTextBox = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Rounded MT Bold", 10F);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(187, 218);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 111;
            label1.Text = "Location:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(244, 242, 243);
            label2.Font = new Font("Arial Rounded MT Bold", 10F);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(187, 164);
            label2.Name = "label2";
            label2.Size = new Size(123, 23);
            label2.TabIndex = 110;
            label2.Text = "Gym Name:";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(246, 87, 125);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Rounded MT Bold", 8F);
            button1.Location = new Point(532, 337);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(105, 36);
            button1.TabIndex = 108;
            button1.Text = "REGISTER";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(246, 87, 125);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Arial Rounded MT Bold", 8F);
            button3.Location = new Point(16, 13);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(98, 36);
            button3.TabIndex = 107;
            button3.Text = "GO BACK";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // fnameTextBox
            // 
            fnameTextBox.Location = new Point(317, 161);
            fnameTextBox.Name = "fnameTextBox";
            fnameTextBox.Size = new Size(270, 31);
            fnameTextBox.TabIndex = 112;
            fnameTextBox.TextChanged += fnameTextBox_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(293, 215);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(294, 31);
            textBox1.TabIndex = 113;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(244, 242, 243);
            label3.Font = new Font("Arial Rounded MT Bold", 10F);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(235, 48);
            label3.MinimumSize = new Size(300, 100);
            label3.Name = "label3";
            label3.Size = new Size(300, 100);
            label3.TabIndex = 114;
            label3.Click += label3_Click;
            // 
            // ownerAddNewGym
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.makeAppointmentJPG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(fnameTextBox);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(button3);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ownerAddNewGym";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add New Gym";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private Button button3;
        private TextBox fnameTextBox;
        private TextBox textBox1;
        private Label label3;
    }
}