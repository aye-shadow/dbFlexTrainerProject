namespace db_project_bois
{
    partial class typeOfLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(typeOfLogin));
            goBackButton = new Button();
            ownerSignupButton = new Button();
            trainerSignupButton = new Button();
            memberSignupButton = new Button();
            button1 = new Button();
            fnameLabel = new Label();
            SuspendLayout();
            // 
            // goBackButton
            // 
            goBackButton.BackColor = Color.FromArgb(239, 170, 188);
            goBackButton.FlatStyle = FlatStyle.Flat;
            goBackButton.Font = new Font("Arial Rounded MT Bold", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            goBackButton.Location = new Point(592, 373);
            goBackButton.Name = "goBackButton";
            goBackButton.Size = new Size(144, 36);
            goBackButton.TabIndex = 9;
            goBackButton.Text = "GO BACK";
            goBackButton.UseVisualStyleBackColor = false;
            goBackButton.Click += goBackButton_Click;
            // 
            // ownerSignupButton
            // 
            ownerSignupButton.BackColor = Color.FromArgb(128, 102, 167);
            ownerSignupButton.FlatStyle = FlatStyle.Flat;
            ownerSignupButton.Font = new Font("Arial Rounded MT Bold", 8F);
            ownerSignupButton.Location = new Point(189, 235);
            ownerSignupButton.Name = "ownerSignupButton";
            ownerSignupButton.Size = new Size(277, 70);
            ownerSignupButton.TabIndex = 8;
            ownerSignupButton.Text = "Login as GYM OWNER";
            ownerSignupButton.UseVisualStyleBackColor = false;
            ownerSignupButton.Click += ownerSignupButton_Click;
            // 
            // trainerSignupButton
            // 
            trainerSignupButton.BackColor = Color.FromArgb(128, 102, 167);
            trainerSignupButton.FlatStyle = FlatStyle.Flat;
            trainerSignupButton.Font = new Font("Arial Rounded MT Bold", 8F);
            trainerSignupButton.Location = new Point(189, 130);
            trainerSignupButton.Name = "trainerSignupButton";
            trainerSignupButton.Size = new Size(277, 70);
            trainerSignupButton.TabIndex = 7;
            trainerSignupButton.Text = "Login as TRAINER";
            trainerSignupButton.UseVisualStyleBackColor = false;
            trainerSignupButton.Click += trainerSignupButton_Click;
            // 
            // memberSignupButton
            // 
            memberSignupButton.BackColor = Color.FromArgb(128, 102, 167);
            memberSignupButton.FlatStyle = FlatStyle.Flat;
            memberSignupButton.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            memberSignupButton.Location = new Point(189, 26);
            memberSignupButton.Name = "memberSignupButton";
            memberSignupButton.Size = new Size(277, 70);
            memberSignupButton.TabIndex = 6;
            memberSignupButton.Text = "Login as MEMBER";
            memberSignupButton.UseVisualStyleBackColor = false;
            memberSignupButton.Click += memberSignupButton_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(128, 102, 167);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Rounded MT Bold", 8F);
            button1.Location = new Point(189, 339);
            button1.Name = "button1";
            button1.Size = new Size(277, 70);
            button1.TabIndex = 10;
            button1.Text = "Login as ADMIN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // fnameLabel
            // 
            fnameLabel.AutoSize = true;
            fnameLabel.BackColor = Color.White;
            fnameLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fnameLabel.ForeColor = SystemColors.ControlLightLight;
            fnameLabel.Location = new Point(133, 26);
            fnameLabel.MinimumSize = new Size(400, 400);
            fnameLabel.Name = "fnameLabel";
            fnameLabel.Size = new Size(400, 400);
            fnameLabel.TabIndex = 11;
            fnameLabel.Text = "First Name";
            // 
            // typeOfLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.signUpPageJPG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(778, 444);
            Controls.Add(button1);
            Controls.Add(goBackButton);
            Controls.Add(ownerSignupButton);
            Controls.Add(trainerSignupButton);
            Controls.Add(memberSignupButton);
            Controls.Add(fnameLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "typeOfLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button goBackButton;
        private Button ownerSignupButton;
        private Button trainerSignupButton;
        private Button memberSignupButton;
        private Button button1;
        private Label fnameLabel;
    }
}