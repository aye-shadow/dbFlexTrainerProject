namespace db_project_bois
{
    partial class homePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(homePage));
            loginButton = new Button();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.FromArgb(246, 87, 125);
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Arial Rounded MT Bold", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginButton.Location = new Point(287, 289);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(168, 36);
            loginButton.TabIndex = 6;
            loginButton.Text = "LOGIN";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // homePage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.homePage;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(778, 444);
            Controls.Add(loginButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "homePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Flex Trainer";
            Load += homePage_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button loginButton;
    }
}