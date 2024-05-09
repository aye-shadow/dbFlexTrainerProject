namespace db_project_bois
{
    partial class trainerSignupPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(trainerSignupPage));
            goBackButton = new Button();
            fnameTextBox = new TextBox();
            fnameLabel = new Label();
            lnameLabel = new Label();
            lnameTextBox = new TextBox();
            emailLabel = new Label();
            emailTextBox = new TextBox();
            passwordLabel = new Label();
            passwordTextBox = new TextBox();
            confirmPasswordLabel = new Label();
            confirmPasswordTextBox = new TextBox();
            contactLabel = new Label();
            contactTextBox = new TextBox();
            gymLabel = new Label();
            comboBox1 = new ComboBox();
            yearsOfExperienceUpDown = new NumericUpDown();
            label1 = new Label();
            signupButton = new Button();
            comboBox2 = new ComboBox();
            specialtyLabel = new Label();
            qualificationsLabel = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)yearsOfExperienceUpDown).BeginInit();
            SuspendLayout();
            // 
            // goBackButton
            // 
            goBackButton.BackColor = Color.FromArgb(239, 170, 188);
            goBackButton.FlatStyle = FlatStyle.Flat;
            goBackButton.Font = new Font("Arial Rounded MT Bold", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            goBackButton.Location = new Point(593, 372);
            goBackButton.Name = "goBackButton";
            goBackButton.Size = new Size(144, 36);
            goBackButton.TabIndex = 6;
            goBackButton.Text = "GO BACK";
            goBackButton.UseVisualStyleBackColor = false;
            goBackButton.Click += goBackButton_Click;
            // 
            // fnameTextBox
            // 
            fnameTextBox.Location = new Point(67, 91);
            fnameTextBox.Name = "fnameTextBox";
            fnameTextBox.Size = new Size(219, 31);
            fnameTextBox.TabIndex = 7;
            // 
            // fnameLabel
            // 
            fnameLabel.AutoSize = true;
            fnameLabel.BackColor = Color.Transparent;
            fnameLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fnameLabel.ForeColor = SystemColors.ControlLightLight;
            fnameLabel.Location = new Point(72, 69);
            fnameLabel.Name = "fnameLabel";
            fnameLabel.Size = new Size(94, 18);
            fnameLabel.TabIndex = 8;
            fnameLabel.Text = "First Name";
            // 
            // lnameLabel
            // 
            lnameLabel.AutoSize = true;
            lnameLabel.BackColor = Color.Transparent;
            lnameLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnameLabel.ForeColor = SystemColors.ControlLightLight;
            lnameLabel.Location = new Point(311, 69);
            lnameLabel.Name = "lnameLabel";
            lnameLabel.Size = new Size(93, 18);
            lnameLabel.TabIndex = 10;
            lnameLabel.Text = "Last Name";
            // 
            // lnameTextBox
            // 
            lnameTextBox.Location = new Point(306, 91);
            lnameTextBox.Name = "lnameTextBox";
            lnameTextBox.Size = new Size(219, 31);
            lnameTextBox.TabIndex = 9;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.BackColor = Color.Transparent;
            emailLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailLabel.ForeColor = SystemColors.ControlLightLight;
            emailLabel.Location = new Point(72, 127);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(51, 18);
            emailLabel.TabIndex = 12;
            emailLabel.Text = "Email";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(67, 149);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(219, 31);
            emailTextBox.TabIndex = 11;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.BackColor = Color.Transparent;
            passwordLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordLabel.ForeColor = SystemColors.ControlLightLight;
            passwordLabel.Location = new Point(72, 185);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(87, 18);
            passwordLabel.TabIndex = 14;
            passwordLabel.Text = "Password";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(67, 207);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(219, 31);
            passwordTextBox.TabIndex = 13;
            // 
            // confirmPasswordLabel
            // 
            confirmPasswordLabel.AutoSize = true;
            confirmPasswordLabel.BackColor = Color.Transparent;
            confirmPasswordLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmPasswordLabel.ForeColor = SystemColors.ControlLightLight;
            confirmPasswordLabel.Location = new Point(311, 185);
            confirmPasswordLabel.Name = "confirmPasswordLabel";
            confirmPasswordLabel.Size = new Size(153, 18);
            confirmPasswordLabel.TabIndex = 16;
            confirmPasswordLabel.Text = "Confirm Password";
            // 
            // confirmPasswordTextBox
            // 
            confirmPasswordTextBox.Location = new Point(306, 207);
            confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            confirmPasswordTextBox.PasswordChar = '*';
            confirmPasswordTextBox.Size = new Size(219, 31);
            confirmPasswordTextBox.TabIndex = 15;
            // 
            // contactLabel
            // 
            contactLabel.AutoSize = true;
            contactLabel.BackColor = Color.Transparent;
            contactLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contactLabel.ForeColor = SystemColors.ControlLightLight;
            contactLabel.Location = new Point(311, 127);
            contactLabel.Name = "contactLabel";
            contactLabel.Size = new Size(139, 18);
            contactLabel.TabIndex = 18;
            contactLabel.Text = "Contact Number";
            contactLabel.Click += label1_Click;
            // 
            // contactTextBox
            // 
            contactTextBox.Location = new Point(306, 149);
            contactTextBox.Name = "contactTextBox";
            contactTextBox.Size = new Size(219, 31);
            contactTextBox.TabIndex = 17;
            contactTextBox.TextChanged += textBox1_TextChanged;
            // 
            // gymLabel
            // 
            gymLabel.AutoSize = true;
            gymLabel.BackColor = Color.Transparent;
            gymLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gymLabel.ForeColor = SystemColors.ControlLightLight;
            gymLabel.Location = new Point(72, 242);
            gymLabel.Name = "gymLabel";
            gymLabel.Size = new Size(109, 18);
            gymLabel.TabIndex = 20;
            gymLabel.Text = "Choose Gym";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(67, 263);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(219, 33);
            comboBox1.TabIndex = 21;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // yearsOfExperienceUpDown
            // 
            yearsOfExperienceUpDown.Location = new Point(306, 264);
            yearsOfExperienceUpDown.Name = "yearsOfExperienceUpDown";
            yearsOfExperienceUpDown.Size = new Size(98, 31);
            yearsOfExperienceUpDown.TabIndex = 22;
            yearsOfExperienceUpDown.Value = new decimal(new int[] { 5, 0, 0, 0 });
            yearsOfExperienceUpDown.ValueChanged += yearsOfExperienceUpDown_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(306, 243);
            label1.Name = "label1";
            label1.Size = new Size(167, 18);
            label1.TabIndex = 23;
            label1.Text = "Years of Experience";
            // 
            // signupButton
            // 
            signupButton.BackColor = Color.FromArgb(239, 170, 188);
            signupButton.FlatStyle = FlatStyle.Flat;
            signupButton.Font = new Font("Arial Rounded MT Bold", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signupButton.Location = new Point(593, 320);
            signupButton.Name = "signupButton";
            signupButton.Size = new Size(144, 36);
            signupButton.TabIndex = 24;
            signupButton.Text = "SIGN UP";
            signupButton.UseVisualStyleBackColor = false;
            signupButton.Click += signupButton_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "HIIT", "Yoga", "Pilates", "Calisthenics", "Powerlifting", "Bodybuilding", "Zumba", "CrossFit" });
            comboBox2.Location = new Point(67, 322);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(219, 33);
            comboBox2.TabIndex = 26;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // specialtyLabel
            // 
            specialtyLabel.AutoSize = true;
            specialtyLabel.BackColor = Color.Transparent;
            specialtyLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            specialtyLabel.ForeColor = SystemColors.ControlLightLight;
            specialtyLabel.Location = new Point(72, 301);
            specialtyLabel.Name = "specialtyLabel";
            specialtyLabel.Size = new Size(82, 18);
            specialtyLabel.TabIndex = 25;
            specialtyLabel.Text = "Specialty";
            // 
            // qualificationsLabel
            // 
            qualificationsLabel.AutoSize = true;
            qualificationsLabel.BackColor = Color.Transparent;
            qualificationsLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            qualificationsLabel.ForeColor = SystemColors.ControlLightLight;
            qualificationsLabel.Location = new Point(311, 300);
            qualificationsLabel.Name = "qualificationsLabel";
            qualificationsLabel.Size = new Size(117, 18);
            qualificationsLabel.TabIndex = 28;
            qualificationsLabel.Text = "Qualifications";
            qualificationsLabel.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(306, 322);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(219, 59);
            textBox1.TabIndex = 27;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // trainerSignupPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.specificSignUpPageJPG1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(778, 444);
            Controls.Add(qualificationsLabel);
            Controls.Add(textBox1);
            Controls.Add(comboBox2);
            Controls.Add(specialtyLabel);
            Controls.Add(signupButton);
            Controls.Add(label1);
            Controls.Add(yearsOfExperienceUpDown);
            Controls.Add(comboBox1);
            Controls.Add(gymLabel);
            Controls.Add(contactLabel);
            Controls.Add(contactTextBox);
            Controls.Add(confirmPasswordLabel);
            Controls.Add(confirmPasswordTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(emailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(lnameLabel);
            Controls.Add(lnameTextBox);
            Controls.Add(fnameLabel);
            Controls.Add(fnameTextBox);
            Controls.Add(goBackButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "trainerSignupPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trainer Signup";
            Load += memberSignup_Load;
            ((System.ComponentModel.ISupportInitialize)yearsOfExperienceUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button goBackButton;
        private TextBox fnameTextBox;
        private Label fnameLabel;
        private Label lnameLabel;
        private TextBox lnameTextBox;
        private Label emailLabel;
        private TextBox emailTextBox;
        private Label passwordLabel;
        private TextBox passwordTextBox;
        private Label confirmPasswordLabel;
        private TextBox confirmPasswordTextBox;
        private Label contactLabel;
        private TextBox contactTextBox;
        private Label gymLabel;
        private ComboBox comboBox1;
        private NumericUpDown yearsOfExperienceUpDown;
        private Label label1;
        private Button signupButton;
        private ComboBox comboBox2;
        private Label specialtyLabel;
        private Label qualificationsLabel;
        private TextBox textBox1;
    }
}