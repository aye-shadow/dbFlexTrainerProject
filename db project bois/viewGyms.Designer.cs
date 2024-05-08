namespace db_project_bois
{
    partial class viewGyms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewGyms));
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(171, 151, 160);
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.Location = new Point(433, 88);
            label1.MinimumSize = new Size(222, 62);
            label1.Name = "label1";
            label1.Size = new Size(222, 62);
            label1.TabIndex = 0;
            label1.Text = "Registered Gyms";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(171, 151, 160);
            label2.Font = new Font("Arial Rounded MT Bold", 12F);
            label2.Location = new Point(390, 75);
            label2.MinimumSize = new Size(222, 62);
            label2.Name = "label2";
            label2.Size = new Size(222, 62);
            label2.TabIndex = 2;
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(240, 170, 189);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Rounded MT Bold", 8F);
            button1.Location = new Point(747, 595);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(176, 54);
            button1.TabIndex = 15;
            button1.Text = "GO BACK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Arial Rounded MT Bold", 9F);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 21;
            listBox1.Items.AddRange(new object[] { "Dummy Gym1", "Dummy Gym2", "Dummy Gym3", "Dummy Gym4", "Dummy Gym5", "Dummy Gym6", "Dummy Gym7", "Dummy Gym8", "Dummy Gym9", "Dummy Gym10", "Dummy Gym11", "Dummy Gym12", "Dummy Gym13", "Dummy Gym14", "Dummy Gym15", "Dummy Gym16", "Dummy Gym17", "Dummy Gym18", "Dummy Gym19", "Dummy Gym20" });
            listBox1.Location = new Point(294, 160);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(537, 424);
            listBox1.TabIndex = 19;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // viewGyms
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.reportPageJPG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(978, 708);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(label2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "viewGyms";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View Gyms";
            Load += viewGyms_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
    }
}