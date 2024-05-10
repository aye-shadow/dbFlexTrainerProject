namespace Db_project_1
{
    partial class memberViewSpecificAppointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(memberViewSpecificAppointment));
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            monthCalendar1 = new MonthCalendar();
            comboBox1 = new ComboBox();
            label10 = new Label();
            comboBox2 = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(246, 87, 125);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Arial Rounded MT Bold", 8F);
            button3.Location = new Point(12, 13);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(98, 36);
            button3.TabIndex = 60;
            button3.Text = "GO BACK";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(246, 87, 125);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Arial Rounded MT Bold", 8F);
            button2.Location = new Point(628, 314);
            button2.Name = "button2";
            button2.Size = new Size(138, 55);
            button2.TabIndex = 101;
            button2.Text = "RESCHEDULE APPOINTMENT";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(246, 87, 125);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Rounded MT Bold", 8F);
            button1.Location = new Point(628, 376);
            button1.Name = "button1";
            button1.Size = new Size(138, 55);
            button1.TabIndex = 100;
            button1.Text = "CANCEL APPOINTMENT";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Enabled = false;
            monthCalendar1.Location = new Point(235, 121);
            monthCalendar1.Margin = new Padding(10, 11, 10, 11);
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 99;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged_1;
            // 
            // comboBox1
            // 
            comboBox1.Enabled = false;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Dummy Trainer1", "Dummy Trainer2", "Dummy Trainer3", "Dummy Trainer4", "Dummy Trainer5", "Dummy Trainer6", "Dummy Trainer7", "Dummy Trainer8", "Dummy Trainer9", "Dummy Trainer10", "Dummy Trainer11", "Dummy Trainer12", "Dummy Trainer13", "Dummy Trainer14", "Dummy Trainer15", "Dummy Trainer16", "Dummy Trainer17", "Dummy Trainer18", "Dummy Trainer19", "Dummy Trainer20", "Dummy Trainer21", "Dummy Trainer22", "Dummy Trainer23", "Dummy Trainer24", "Dummy Trainer25" });
            comboBox1.Location = new Point(242, 89);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(320, 26);
            comboBox1.TabIndex = 97;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Arial Rounded MT Bold", 10F);
            label10.ForeColor = SystemColors.ControlText;
            label10.Location = new Point(148, 89);
            label10.Name = "label10";
            label10.Size = new Size(88, 23);
            label10.TabIndex = 95;
            label10.Text = "Trainer:";
            // 
            // comboBox2
            // 
            comboBox2.Enabled = false;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Dummy Gym1", "Dummy Gym2", "Dummy Gym3", "Dummy Gym4", "Dummy Gym5", "Dummy Gym6", "Dummy Gym7", "Dummy Gym8", "Dummy Gym9", "Dummy Gym10", "Dummy Gym11", "Dummy Gym12", "Dummy Gym13", "Dummy Gym14", "Dummy Gym15", "Dummy Gym16", "Dummy Gym17", "Dummy Gym18", "Dummy Gym19", "Dummy Gym20", "Dummy Gym21", "Dummy Gym22", "Dummy Gym23", "Dummy Gym24", "Dummy Gym25" });
            comboBox2.Location = new Point(215, 55);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(347, 26);
            comboBox2.TabIndex = 104;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial Rounded MT Bold", 10F);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(148, 55);
            label2.Name = "label2";
            label2.Size = new Size(61, 23);
            label2.TabIndex = 103;
            label2.Text = "Gym:";
            // 
            // memberViewSpecificAppointment
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = db_project_bois.Properties.Resources.memberViewAppointmentsJPG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(778, 444);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(monthCalendar1);
            Controls.Add(comboBox1);
            Controls.Add(label10);
            Controls.Add(button3);
            Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "memberViewSpecificAppointment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Appointment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button3;
        private Button button2;
        private Button button1;
        private MonthCalendar monthCalendar1;
        private ComboBox comboBox1;
        private Label label10;
        private ComboBox comboBox2;
        private Label label2;
    }
}