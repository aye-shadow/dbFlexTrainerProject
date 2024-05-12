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
            flowLayoutPanel1 = new FlowLayoutPanel();
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
            button2.Location = new Point(609, 378);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(157, 53);
            button2.TabIndex = 64;
            button2.Text = "SCHEDULE NEW APPOINTMENT";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(157, 142);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(455, 176);
            flowLayoutPanel1.TabIndex = 65;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // appointmentdetails
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = db_project_bois.Properties.Resources.memberViewAppointmentsJPG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(778, 444);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button2);
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
        private FlowLayoutPanel flowLayoutPanel1;
    }
}