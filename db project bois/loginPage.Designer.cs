namespace db_project_bois
{
    partial class loginPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginPage));
            loginButton = new Button();
            signupButton = new Button();
            goBackButton = new Button();
            emailTextBox = new TextBox();
            passwordTextBox = new TextBox();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.FromArgb(253, 173, 236);
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Arial Rounded MT Bold", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginButton.Location = new Point(404, 294);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(144, 36);
            loginButton.TabIndex = 0;
            loginButton.Text = "LOGIN";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // signupButton
            // 
            signupButton.BackColor = Color.FromArgb(253, 173, 236);
            signupButton.FlatStyle = FlatStyle.Flat;
            signupButton.Font = new Font("Arial Rounded MT Bold", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signupButton.Location = new Point(202, 294);
            signupButton.Name = "signupButton";
            signupButton.Size = new Size(144, 36);
            signupButton.TabIndex = 1;
            signupButton.Text = "NEW HERE? SIGNUP";
            signupButton.UseVisualStyleBackColor = false;
            signupButton.Click += signupButton_Click;
            // 
            // goBackButton
            // 
            goBackButton.BackColor = Color.FromArgb(253, 173, 236);
            goBackButton.FlatStyle = FlatStyle.Flat;
            goBackButton.Font = new Font("Arial Rounded MT Bold", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            goBackButton.Location = new Point(593, 372);
            goBackButton.Name = "goBackButton";
            goBackButton.Size = new Size(144, 36);
            goBackButton.TabIndex = 2;
            goBackButton.Text = "GO BACK";
            goBackButton.UseVisualStyleBackColor = false;
            goBackButton.Click += goBackButton_Click;
            // 
            // emailTextBox
            // 
            emailTextBox.BackColor = Color.FromArgb(246, 87, 125);
            emailTextBox.BorderStyle = BorderStyle.None;
            emailTextBox.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailTextBox.Location = new Point(212, 161);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.PlaceholderText = "EMAIL ID:";
            emailTextBox.Size = new Size(322, 19);
            emailTextBox.TabIndex = 3;
            emailTextBox.TextChanged += emailTextBox_TextChanged;
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = Color.FromArgb(246, 87, 125);
            passwordTextBox.BorderStyle = BorderStyle.None;
            passwordTextBox.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordTextBox.Location = new Point(212, 218);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.PlaceholderText = "PASSWORD:";
            passwordTextBox.Size = new Size(322, 19);
            passwordTextBox.TabIndex = 4;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            // 
            // loginPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.loginPageJPG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(778, 444);
            Controls.Add(passwordTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(goBackButton);
            Controls.Add(signupButton);
            Controls.Add(loginButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "loginPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += loginPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginButton;
        private Button signupButton;
        private Button goBackButton;
        private TextBox emailTextBox;
        private TextBox passwordTextBox;
    }
}
