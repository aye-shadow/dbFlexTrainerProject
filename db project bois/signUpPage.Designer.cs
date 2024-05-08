namespace db_project_bois
{
    partial class signUpPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(signUpPage));
            memberSignupButton = new Button();
            trainerSignupButton = new Button();
            ownerSignupButton = new Button();
            goBackButton = new Button();
            SuspendLayout();
            // 
            // memberSignupButton
            // 
            memberSignupButton.BackColor = Color.FromArgb(128, 102, 167);
            memberSignupButton.FlatStyle = FlatStyle.Flat;
            memberSignupButton.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            memberSignupButton.Location = new Point(189, 94);
            memberSignupButton.Name = "memberSignupButton";
            memberSignupButton.Size = new Size(277, 70);
            memberSignupButton.TabIndex = 2;
            memberSignupButton.Text = "Signup as MEMBER";
            memberSignupButton.UseVisualStyleBackColor = false;
            memberSignupButton.Click += memberSignupButton_Click;
            // 
            // trainerSignupButton
            // 
            trainerSignupButton.BackColor = Color.FromArgb(128, 102, 167);
            trainerSignupButton.FlatStyle = FlatStyle.Flat;
            trainerSignupButton.Font = new Font("Arial Rounded MT Bold", 8F);
            trainerSignupButton.Location = new Point(189, 198);
            trainerSignupButton.Name = "trainerSignupButton";
            trainerSignupButton.Size = new Size(277, 70);
            trainerSignupButton.TabIndex = 3;
            trainerSignupButton.Text = "Signup as TRAINER";
            trainerSignupButton.UseVisualStyleBackColor = false;
            trainerSignupButton.Click += trainerSignupButton_Click;
            // 
            // ownerSignupButton
            // 
            ownerSignupButton.BackColor = Color.FromArgb(128, 102, 167);
            ownerSignupButton.FlatStyle = FlatStyle.Flat;
            ownerSignupButton.Font = new Font("Arial Rounded MT Bold", 8F);
            ownerSignupButton.Location = new Point(189, 303);
            ownerSignupButton.Name = "ownerSignupButton";
            ownerSignupButton.Size = new Size(277, 70);
            ownerSignupButton.TabIndex = 4;
            ownerSignupButton.Text = "Signup as GYM OWNER";
            ownerSignupButton.UseVisualStyleBackColor = false;
            ownerSignupButton.Click += ownerSignupButton_Click;
            // 
            // goBackButton
            // 
            goBackButton.BackColor = Color.FromArgb(239, 170, 188);
            goBackButton.FlatStyle = FlatStyle.Flat;
            goBackButton.Font = new Font("Arial Rounded MT Bold", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            goBackButton.Location = new Point(593, 372);
            goBackButton.Name = "goBackButton";
            goBackButton.Size = new Size(144, 36);
            goBackButton.TabIndex = 5;
            goBackButton.Text = "GO BACK";
            goBackButton.UseVisualStyleBackColor = false;
            goBackButton.Click += goBackButton_Click;
            // 
            // signUpPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.signUpPageJPG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(778, 444);
            Controls.Add(goBackButton);
            Controls.Add(ownerSignupButton);
            Controls.Add(trainerSignupButton);
            Controls.Add(memberSignupButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "signUpPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sign Up";
            Load += signUpPage_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button memberSignupButton;
        private Button trainerSignupButton;
        private Button ownerSignupButton;
        private Button goBackButton;
    }
}