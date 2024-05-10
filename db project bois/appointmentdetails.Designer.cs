namespace Db_project_1
{
    partial class appointmentdetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(appointmentdetails));
            button3 = new Button();
            button2 = new Button();
            monthCalendar1 = new MonthCalendar();
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
            button3.TabIndex = 61;
            button3.Text = "GO BACK";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(246, 87, 125);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Arial Rounded MT Bold", 8F);
            button2.Location = new Point(618, 378);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(148, 53);
            button2.TabIndex = 64;
            button2.Text = "SCHEDULE APPOINTMENT";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(228, 132);
            monthCalendar1.Margin = new Padding(11, 14, 11, 14);
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 62;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // appointmentdetails
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = db_project_bois.Properties.Resources.memberViewAppointmentsJPG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(778, 444);
            Controls.Add(button2);
            Controls.Add(monthCalendar1);
            Controls.Add(button3);
            Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "appointmentdetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Appointments";
            Load += appointmentdetails_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button button3;
        private Button button2;
        private MonthCalendar monthCalendar1;
    }
}