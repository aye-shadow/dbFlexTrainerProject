namespace WindowsFormsApp1
{
    partial class ownerViewAllMembers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ownerViewAllMembers));
            listBox1 = new ListBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Arial Rounded MT Bold", 9F);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 21;
            listBox1.Items.AddRange(new object[] { "Dummy Member1", "Dummy Member2", "Dummy Member3", "Dummy Member4", "Dummy Member5", "Dummy Member6", "Dummy Member7", "Dummy Member8", "Dummy Member9", "Dummy Member10", "Dummy Member11", "Dummy Member12", "Dummy Member13", "Dummy Member14", "Dummy Member15", "Dummy Member16", "Dummy Member17", "Dummy Member18", "Dummy Member19", "Dummy Member20", "Dummy Member21", "Dummy Member22", "Dummy Member23", "Dummy Member24", "Dummy Member25" });
            listBox1.Location = new Point(265, 128);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(484, 340);
            listBox1.TabIndex = 23;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(240, 170, 189);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Rounded MT Bold", 8F);
            button1.Location = new Point(672, 476);
            button1.Name = "button1";
            button1.Size = new Size(158, 43);
            button1.TabIndex = 22;
            button1.Text = "GO BACK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(171, 151, 160);
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.Location = new Point(270, 70);
            label1.MinimumSize = new Size(200, 50);
            label1.Name = "label1";
            label1.Size = new Size(221, 50);
            label1.TabIndex = 20;
            label1.Text = "Members at GymX";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(171, 151, 160);
            label2.Font = new Font("Arial Rounded MT Bold", 12F);
            label2.Location = new Point(351, 60);
            label2.MinimumSize = new Size(200, 50);
            label2.Name = "label2";
            label2.Size = new Size(200, 50);
            label2.TabIndex = 21;
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ownerViewAllMembers
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = db_project_bois.Properties.Resources.reportPageJPG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(880, 566);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(label2);
            Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ownerViewAllMembers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View Members";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}