namespace WindowsFormsApp1
{
    partial class view_members_trainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(view_members_trainer));
            button1 = new Button();
            label2 = new Label();
            listBox1 = new ListBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 172, 236);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Rounded MT Bold", 8F);
            button1.Location = new Point(755, 615);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(181, 54);
            button1.TabIndex = 79;
            button1.Text = "GO BACK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(254, 233, 238);
            label2.Location = new Point(368, 64);
            label2.MinimumSize = new Size(278, 62);
            label2.Name = "label2";
            label2.Size = new Size(278, 62);
            label2.TabIndex = 87;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Arial Rounded MT Bold", 10F);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 23;
            listBox1.Items.AddRange(new object[] { "Dummy Member1", "Dummy Member2", "Dummy Member3", "Dummy Member4", "Dummy Member5", "Dummy Member6", "Dummy Member7", "Dummy Member8", "Dummy Member9", "Dummy Member10", "Dummy Member11", "Dummy Member12", "Dummy Member13", "Dummy Member14", "Dummy Member15", "Dummy Member16", "Dummy Member17", "Dummy Member18", "Dummy Member19", "Dummy Member20", "Dummy Member21", "Dummy Member22", "Dummy Member23", "Dummy Member24", "Dummy Member25" });
            listBox1.Location = new Point(251, 140);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(586, 372);
            listBox1.TabIndex = 85;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(254, 233, 238);
            label1.Font = new Font("Arial Rounded MT Bold", 14F);
            label1.Location = new Point(300, 86);
            label1.Name = "label1";
            label1.Size = new Size(228, 32);
            label1.TabIndex = 86;
            label1.Text = "Clients in GymX";
            // 
            // view_members_trainer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = db_project_bois.Properties.Resources.somePageBruhJPG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1000, 702);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Controls.Add(label2);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 5, 3, 5);
            Name = "view_members_trainer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View Clients";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
    }
}