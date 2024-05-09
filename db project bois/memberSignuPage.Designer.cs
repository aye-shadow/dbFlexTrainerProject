namespace db_project_bois
{
    partial class memberSignup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(memberSignup));
            signupButton = new Button();
            heightLabel = new Label();
            yearsOfExperienceUpDown = new NumericUpDown();
            comboBox1 = new ComboBox();
            membershipTypeLabel = new Label();
            contactLabel = new Label();
            contactTextBox = new TextBox();
            confirmPasswordLabel = new Label();
            confirmPasswordTextBox = new TextBox();
            passwordLabel = new Label();
            passwordTextBox = new TextBox();
            emailLabel = new Label();
            emailTextBox = new TextBox();
            lnameLabel = new Label();
            lnameTextBox = new TextBox();
            fnameLabel = new Label();
            fnameTextBox = new TextBox();
            goBackButton = new Button();
            weightLabel = new Label();
            numericUpDown1 = new NumericUpDown();
            comboBox3 = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)yearsOfExperienceUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // signupButton
            // 
            signupButton.BackColor = Color.FromArgb(239, 170, 188);
            signupButton.FlatStyle = FlatStyle.Flat;
            signupButton.Font = new Font("Arial Rounded MT Bold", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signupButton.Location = new Point(593, 320);
            signupButton.Name = "signupButton";
            signupButton.Size = new Size(144, 36);
            signupButton.TabIndex = 46;
            signupButton.Text = "SIGN UP";
            signupButton.UseVisualStyleBackColor = false;
            signupButton.Click += signupButton_Click;
            // 
            // heightLabel
            // 
            heightLabel.AutoSize = true;
            heightLabel.BackColor = Color.Transparent;
            heightLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            heightLabel.ForeColor = SystemColors.ControlLightLight;
            heightLabel.Location = new Point(306, 259);
            heightLabel.Name = "heightLabel";
            heightLabel.Size = new Size(100, 18);
            heightLabel.TabIndex = 45;
            heightLabel.Text = "Height (cm)";
            // 
            // yearsOfExperienceUpDown
            // 
            yearsOfExperienceUpDown.Location = new Point(306, 280);
            yearsOfExperienceUpDown.Maximum = new decimal(new int[] { 250, 0, 0, 0 });
            yearsOfExperienceUpDown.Minimum = new decimal(new int[] { 120, 0, 0, 0 });
            yearsOfExperienceUpDown.Name = "yearsOfExperienceUpDown";
            yearsOfExperienceUpDown.Size = new Size(98, 31);
            yearsOfExperienceUpDown.TabIndex = 44;
            yearsOfExperienceUpDown.Value = new decimal(new int[] { 120, 0, 0, 0 });
            yearsOfExperienceUpDown.ValueChanged += yearsOfExperienceUpDown_ValueChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "ijoi", "uh", "uooh" });
            comboBox1.Location = new Point(306, 346);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(219, 33);
            comboBox1.TabIndex = 43;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // membershipTypeLabel
            // 
            membershipTypeLabel.AutoSize = true;
            membershipTypeLabel.BackColor = Color.Transparent;
            membershipTypeLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            membershipTypeLabel.ForeColor = SystemColors.ControlLightLight;
            membershipTypeLabel.Location = new Point(311, 324);
            membershipTypeLabel.Name = "membershipTypeLabel";
            membershipTypeLabel.Size = new Size(148, 18);
            membershipTypeLabel.TabIndex = 42;
            membershipTypeLabel.Text = "Membership Type";
            // 
            // contactLabel
            // 
            contactLabel.AutoSize = true;
            contactLabel.BackColor = Color.Transparent;
            contactLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contactLabel.ForeColor = SystemColors.ControlLightLight;
            contactLabel.Location = new Point(311, 131);
            contactLabel.Name = "contactLabel";
            contactLabel.Size = new Size(139, 18);
            contactLabel.TabIndex = 41;
            contactLabel.Text = "Contact Number";
            contactLabel.Click += contactLabel_Click;
            // 
            // contactTextBox
            // 
            contactTextBox.Location = new Point(306, 154);
            contactTextBox.Name = "contactTextBox";
            contactTextBox.Size = new Size(219, 31);
            contactTextBox.TabIndex = 40;
            contactTextBox.TextChanged += contactTextBox_TextChanged;
            // 
            // confirmPasswordLabel
            // 
            confirmPasswordLabel.AutoSize = true;
            confirmPasswordLabel.BackColor = Color.Transparent;
            confirmPasswordLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmPasswordLabel.ForeColor = SystemColors.ControlLightLight;
            confirmPasswordLabel.Location = new Point(311, 194);
            confirmPasswordLabel.Name = "confirmPasswordLabel";
            confirmPasswordLabel.Size = new Size(153, 18);
            confirmPasswordLabel.TabIndex = 39;
            confirmPasswordLabel.Text = "Confirm Password";
            // 
            // confirmPasswordTextBox
            // 
            confirmPasswordTextBox.Location = new Point(306, 216);
            confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            confirmPasswordTextBox.PasswordChar = '*';
            confirmPasswordTextBox.Size = new Size(219, 31);
            confirmPasswordTextBox.TabIndex = 38;
            confirmPasswordTextBox.TextChanged += confirmPasswordTextBox_TextChanged;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.BackColor = Color.Transparent;
            passwordLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordLabel.ForeColor = SystemColors.ControlLightLight;
            passwordLabel.Location = new Point(72, 194);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(87, 18);
            passwordLabel.TabIndex = 37;
            passwordLabel.Text = "Password";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(67, 216);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(219, 31);
            passwordTextBox.TabIndex = 36;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.BackColor = Color.Transparent;
            emailLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailLabel.ForeColor = SystemColors.ControlLightLight;
            emailLabel.Location = new Point(72, 131);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(51, 18);
            emailLabel.TabIndex = 35;
            emailLabel.Text = "Email";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(67, 154);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(219, 31);
            emailTextBox.TabIndex = 34;
            emailTextBox.TextChanged += emailTextBox_TextChanged;
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
            lnameLabel.TabIndex = 33;
            lnameLabel.Text = "Last Name";
            // 
            // lnameTextBox
            // 
            lnameTextBox.Location = new Point(306, 91);
            lnameTextBox.Name = "lnameTextBox";
            lnameTextBox.Size = new Size(219, 31);
            lnameTextBox.TabIndex = 32;
            lnameTextBox.TextChanged += lnameTextBox_TextChanged;
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
            fnameLabel.TabIndex = 31;
            fnameLabel.Text = "First Name";
            // 
            // fnameTextBox
            // 
            fnameTextBox.Location = new Point(67, 91);
            fnameTextBox.Name = "fnameTextBox";
            fnameTextBox.Size = new Size(219, 31);
            fnameTextBox.TabIndex = 30;
            fnameTextBox.TextChanged += fnameTextBox_TextChanged;
            // 
            // goBackButton
            // 
            goBackButton.BackColor = Color.FromArgb(239, 170, 188);
            goBackButton.FlatStyle = FlatStyle.Flat;
            goBackButton.Font = new Font("Arial Rounded MT Bold", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            goBackButton.Location = new Point(593, 372);
            goBackButton.Name = "goBackButton";
            goBackButton.Size = new Size(144, 36);
            goBackButton.TabIndex = 29;
            goBackButton.Text = "GO BACK";
            goBackButton.UseVisualStyleBackColor = false;
            goBackButton.Click += goBackButton_Click;
            // 
            // weightLabel
            // 
            weightLabel.AutoSize = true;
            weightLabel.BackColor = Color.Transparent;
            weightLabel.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            weightLabel.ForeColor = SystemColors.ControlLightLight;
            weightLabel.Location = new Point(72, 259);
            weightLabel.Name = "weightLabel";
            weightLabel.Size = new Size(102, 18);
            weightLabel.TabIndex = 50;
            weightLabel.Text = "Weight (lbs)";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(67, 280);
            numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(98, 31);
            numericUpDown1.TabIndex = 49;
            numericUpDown1.Value = new decimal(new int[] { 120, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "dd", "dfsdf", "cxc", "sdf" });
            comboBox3.Location = new Point(67, 346);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(219, 33);
            comboBox3.TabIndex = 52;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(72, 324);
            label1.Name = "label1";
            label1.Size = new Size(109, 18);
            label1.TabIndex = 51;
            label1.Text = "Choose Gym";
            // 
            // memberSignup
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.specificSignUpPageJPG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(778, 444);
            Controls.Add(comboBox3);
            Controls.Add(label1);
            Controls.Add(weightLabel);
            Controls.Add(numericUpDown1);
            Controls.Add(signupButton);
            Controls.Add(heightLabel);
            Controls.Add(yearsOfExperienceUpDown);
            Controls.Add(comboBox1);
            Controls.Add(membershipTypeLabel);
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
            Name = "memberSignup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Member Signup";
            ((System.ComponentModel.ISupportInitialize)yearsOfExperienceUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label qualificationsLabel;
        private TextBox textBox1;
        private ComboBox comboBox2;
        private Label specialtyLabel;
        private Button signupButton;
        private Label heightLabel;
        private NumericUpDown yearsOfExperienceUpDown;
        private ComboBox comboBox1;
        private Label membershipTypeLabel;
        private Label contactLabel;
        private TextBox contactTextBox;
        private Label confirmPasswordLabel;
        private TextBox confirmPasswordTextBox;
        private Label passwordLabel;
        private TextBox passwordTextBox;
        private Label emailLabel;
        private TextBox emailTextBox;
        private Label lnameLabel;
        private TextBox lnameTextBox;
        private Label fnameLabel;
        private TextBox fnameTextBox;
        private Button goBackButton;
        private Label weightLabel;
        private NumericUpDown numericUpDown1;
        private ComboBox comboBox3;
        private Label label1;
    }
}