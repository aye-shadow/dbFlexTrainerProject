namespace WindowsFormsApp1
{
    partial class manage_trainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(manage_trainer));
            this.manage_account = new System.Windows.Forms.LinkLabel();
            this.view_members = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // manage_account
            // 
            this.manage_account.ActiveLinkColor = System.Drawing.Color.DarkMagenta;
            this.manage_account.AutoSize = true;
            this.manage_account.BackColor = System.Drawing.Color.Transparent;
            this.manage_account.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manage_account.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.manage_account.LinkColor = System.Drawing.Color.Black;
            this.manage_account.Location = new System.Drawing.Point(229, 180);
            this.manage_account.MaximumSize = new System.Drawing.Size(110, 0);
            this.manage_account.Name = "manage_account";
            this.manage_account.Size = new System.Drawing.Size(103, 58);
            this.manage_account.TabIndex = 1;
            this.manage_account.TabStop = true;
            this.manage_account.Text = "RemoveTrainers";
            this.manage_account.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.manage_account_LinkClicked);
            // 
            // view_members
            // 
            this.view_members.ActiveLinkColor = System.Drawing.Color.DarkMagenta;
            this.view_members.AutoSize = true;
            this.view_members.BackColor = System.Drawing.Color.Transparent;
            this.view_members.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.view_members.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.view_members.LinkColor = System.Drawing.Color.Black;
            this.view_members.Location = new System.Drawing.Point(598, 181);
            this.view_members.Name = "view_members";
            this.view_members.Size = new System.Drawing.Size(103, 58);
            this.view_members.TabIndex = 2;
            this.view_members.TabStop = true;
            this.view_members.Text = "Add\r\nTrainers";
            this.view_members.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.view_members_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(143, 65);
            this.label1.MinimumSize = new System.Drawing.Size(200, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 42);
            this.label1.TabIndex = 57;
            this.label1.Text = "Manage Trainers at GymX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(228, 47);
            this.label2.MinimumSize = new System.Drawing.Size(500, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 100);
            this.label2.TabIndex = 58;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(151)))), ((int)(((byte)(160)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8F);
            this.button3.Location = new System.Drawing.Point(704, 484);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 44);
            this.button3.TabIndex = 59;
            this.button3.Text = "GO BACK";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // manage_trainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = db_project_bois.Properties.Resources.managePages;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(880, 566);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.view_members);
            this.Controls.Add(this.manage_account);
            this.Icon = Icon.FromHandle((global::db_project_bois.Properties.Resources.icon).GetHicon());
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "manage_trainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Trainers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel manage_account;
        private System.Windows.Forms.LinkLabel view_members;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
    }
}