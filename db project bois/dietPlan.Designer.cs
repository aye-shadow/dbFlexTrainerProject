namespace Db_project_1
{
    partial class dietPlan
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            button1 = new Button();
            linkLabel1 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            comboBox1 = new ComboBox();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(247, 86, 126);
            button1.DialogResult = DialogResult.No;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(48, 361);
            button1.Name = "button1";
            button1.Size = new Size(144, 36);
            button1.TabIndex = 27;
            button1.Text = "GO BACK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.Font = new Font("Arial Rounded MT Bold", 8F);
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(89, 212);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(103, 22);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Your Plans";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel3
            // 
            linkLabel3.BackColor = Color.Transparent;
            linkLabel3.Font = new Font("Arial Rounded MT Bold", 8F);
            linkLabel3.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel3.LinkColor = Color.Black;
            linkLabel3.Location = new Point(89, 279);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(75, 39);
            linkLabel3.TabIndex = 26;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Shared Plans";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "By Trainer", "By User", "Nutritonal Value", "Diet Type", "Purpose" });
            comboBox1.Location = new Point(501, 67);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(240, 26);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial Rounded MT Bold", 8F);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(425, 70);
            label2.Name = "label2";
            label2.Size = new Size(70, 18);
            label2.TabIndex = 105;
            label2.Text = "Sort by:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(245, 109);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(496, 275);
            dataGridView1.TabIndex = 106;
            // 
            // dietPlan
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = db_project_bois.Properties.Resources.dietPageJPG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(778, 444);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(linkLabel3);
            Controls.Add(linkLabel1);
            Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "dietPlan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View Diet Plan";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private ComboBox comboBox1;
        private Label label2;
        private DataGridView dataGridView1;
    }
}