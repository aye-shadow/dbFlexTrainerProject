namespace db_project_bois
{
    partial class addGym
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
            button1 = new Button();
            checkedListBox1 = new CheckedListBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(240, 170, 189);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Rounded MT Bold", 8F);
            button1.Location = new Point(746, 594);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(177, 55);
            button1.TabIndex = 17;
            button1.Text = "GO BACK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.Font = new Font("Arial Rounded MT Bold", 9F);
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "Dummy Gym1", "Dummy Gym2", "Dummy Gym3", "Dummy Gym4", "Dummy Gym5", "Dummy Gym6", "Dummy Gym7", "Dummy Gym8", "Dummy Gym9", "Dummy Gym10", "Dummy Gym11", "Dummy Gym12", "Dummy Gym13", "Dummy Gym14", "Dummy Gym15", "Dummy Gym16", "Dummy Gym17", "Dummy Gym18", "Dummy Gym19", "Dummy Gym20", "Dummy Gym21", "Dummy Gym22", "Dummy Gym23", "Dummy Gym24", "Dummy Gym25" });
            checkedListBox1.Location = new Point(294, 171);
            checkedListBox1.Margin = new Padding(3, 4, 3, 4);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(537, 404);
            checkedListBox1.TabIndex = 20;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(171, 151, 160);
            label3.Font = new Font("Arial Rounded MT Bold", 12F);
            label3.Location = new Point(432, 89);
            label3.MinimumSize = new Size(222, 62);
            label3.Name = "label3";
            label3.Size = new Size(222, 62);
            label3.TabIndex = 19;
            label3.Text = "Gym Applications";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // addGym
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.reportPageJPG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(978, 708);
            Controls.Add(checkedListBox1);
            Controls.Add(label3);
            Controls.Add(button1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "addGym";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Gym";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label3;
    }
}