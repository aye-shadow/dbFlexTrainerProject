namespace db_project_bois
{
    partial class ownerManageGyms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ownerManageGyms));
            button3 = new Button();
            lname = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(171, 151, 160);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Arial Rounded MT Bold", 8F);
            button3.Location = new Point(620, 380);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(146, 35);
            button3.TabIndex = 55;
            button3.Text = "GO BACK";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // lname
            // 
            lname.AutoSize = true;
            lname.BackColor = Color.Transparent;
            lname.Font = new Font("Arial Rounded MT Bold", 10F);
            lname.Location = new Point(187, 153);
            lname.Name = "lname";
            lname.Size = new Size(98, 23);
            lname.TabIndex = 56;
            lname.Text = "Add New";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Rounded MT Bold", 10F);
            label1.Location = new Point(520, 153);
            label1.Name = "label1";
            label1.Size = new Size(89, 23);
            label1.TabIndex = 57;
            label1.Text = "Remove";
            // 
            // ownerManageGyms
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.managePages;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(778, 444);
            Controls.Add(label1);
            Controls.Add(lname);
            Controls.Add(button3);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ownerManageGyms";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Gyms";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Label lname;
        private Label label1;
    }
}