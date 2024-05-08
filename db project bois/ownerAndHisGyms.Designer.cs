namespace db_project_bois
{
    partial class ownerAndHisGyms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ownerAndHisGyms));
            lname = new Label();
            linkLabel1 = new LinkLabel();
            linkLabel4 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            SuspendLayout();
            // 
            // lname
            // 
            lname.AutoSize = true;
            lname.BackColor = Color.White;
            lname.Font = new Font("Arial Rounded MT Bold", 10F);
            lname.Location = new Point(206, 10);
            lname.MinimumSize = new Size(400, 100);
            lname.Name = "lname";
            lname.Size = new Size(400, 100);
            lname.TabIndex = 64;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.LightCoral;
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(522, 153);
            linkLabel1.Margin = new Padding(4, 0, 4, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(127, 24);
            linkLabel1.TabIndex = 63;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Delete Gym";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel4
            // 
            linkLabel4.ActiveLinkColor = Color.LightCoral;
            linkLabel4.AutoSize = true;
            linkLabel4.BackColor = Color.Transparent;
            linkLabel4.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel4.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel4.LinkColor = Color.Black;
            linkLabel4.Location = new Point(187, 153);
            linkLabel4.Margin = new Padding(4, 0, 4, 0);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(103, 24);
            linkLabel4.TabIndex = 62;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "Add Gym";
            linkLabel4.LinkClicked += linkLabel4_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.ActiveLinkColor = Color.LightCoral;
            linkLabel2.AutoSize = true;
            linkLabel2.BackColor = Color.Transparent;
            linkLabel2.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel2.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel2.LinkColor = Color.Black;
            linkLabel2.Location = new Point(646, 385);
            linkLabel2.Margin = new Padding(4, 0, 4, 0);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(94, 24);
            linkLabel2.TabIndex = 61;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Go back";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // ownerAndHisGyms
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.managePages;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(778, 444);
            Controls.Add(lname);
            Controls.Add(linkLabel1);
            Controls.Add(linkLabel4);
            Controls.Add(linkLabel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ownerAndHisGyms";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Gyms";
            Load += ownerAndHisGyms_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lname;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel4;
        private LinkLabel linkLabel2;
    }
}