namespace WindowsFormsApp1
{
    partial class trainerRequests
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(trainerRequests));
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Dummy Trainer1",
            "Dummy Trainer2",
            "Dummy Trainer3",
            "Dummy Trainer4",
            "Dummy Trainer5",
            "Dummy Trainer6",
            "Dummy Trainer7",
            "Dummy Trainer8",
            "Dummy Trainer9",
            "Dummy Trainer10",
            "Dummy Trainer11",
            "Dummy Trainer12",
            "Dummy Trainer13",
            "Dummy Trainer14",
            "Dummy Trainer15",
            "Dummy Trainer16",
            "Dummy Trainer17",
            "Dummy Trainer18",
            "Dummy Trainer19",
            "Dummy Trainer20",
            "Dummy Trainer21",
            "Dummy Trainer22",
            "Dummy Trainer23",
            "Dummy Trainer24",
            "Dummy Trainer25"});
            this.checkedListBox1.Location = new System.Drawing.Point(266, 136);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(484, 329);
            this.checkedListBox1.TabIndex = 23;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(151)))), ((int)(((byte)(160)))));
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label3.Location = new System.Drawing.Point(270, 69);
            this.label3.MinimumSize = new System.Drawing.Size(200, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(350, 50);
            this.label3.TabIndex = 22;
            this.label3.Text = "Trainer Applications at GymX";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(170)))), ((int)(((byte)(189)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8F);
            this.button1.Location = new System.Drawing.Point(672, 474);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 44);
            this.button1.TabIndex = 21;
            this.button1.Text = "GO BACK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trainerRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::db_project_bois.Properties.Resources.reportPageJPG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(880, 566);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Icon = Icon.FromHandle((global::db_project_bois.Properties.Resources.icon).GetHicon());
            this.Name = "trainerRequests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Trainers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}