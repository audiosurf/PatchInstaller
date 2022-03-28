namespace PatchInstallerUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeBtn = new System.Windows.Forms.Button();
            this.locationGroupBox = new System.Windows.Forms.GroupBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.autoFindBtn = new System.Windows.Forms.Button();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.installGroupBox = new System.Windows.Forms.GroupBox();
            this.statusProgressBar = new System.Windows.Forms.ProgressBar();
            this.installBtn = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.locationGroupBox.SuspendLayout();
            this.installGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlText;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(441, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.BackColor = System.Drawing.Color.Red;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(406, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(35, 24);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // locationGroupBox
            // 
            this.locationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.locationGroupBox.Controls.Add(this.browseBtn);
            this.locationGroupBox.Controls.Add(this.autoFindBtn);
            this.locationGroupBox.Controls.Add(this.locationTextBox);
            this.locationGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.locationGroupBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationGroupBox.ForeColor = System.Drawing.SystemColors.Control;
            this.locationGroupBox.Location = new System.Drawing.Point(12, 30);
            this.locationGroupBox.Name = "locationGroupBox";
            this.locationGroupBox.Size = new System.Drawing.Size(417, 86);
            this.locationGroupBox.TabIndex = 2;
            this.locationGroupBox.TabStop = false;
            this.locationGroupBox.Text = "Audiosurf 2 Location";
            // 
            // browseBtn
            // 
            this.browseBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.browseBtn.Location = new System.Drawing.Point(297, 49);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(112, 27);
            this.browseBtn.TabIndex = 2;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // autoFindBtn
            // 
            this.autoFindBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.autoFindBtn.Location = new System.Drawing.Point(6, 49);
            this.autoFindBtn.Name = "autoFindBtn";
            this.autoFindBtn.Size = new System.Drawing.Size(285, 27);
            this.autoFindBtn.TabIndex = 1;
            this.autoFindBtn.Text = "Find Automatically";
            this.autoFindBtn.UseVisualStyleBackColor = true;
            this.autoFindBtn.Click += new System.EventHandler(this.autoFindBtn_Click);
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(6, 21);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(404, 22);
            this.locationTextBox.TabIndex = 0;
            this.locationTextBox.TextChanged += new System.EventHandler(this.locationTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Audiosurf 2 Community Patch Installer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            // 
            // installGroupBox
            // 
            this.installGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.installGroupBox.Controls.Add(this.statusProgressBar);
            this.installGroupBox.Controls.Add(this.installBtn);
            this.installGroupBox.Controls.Add(this.statusLabel);
            this.installGroupBox.Controls.Add(this.label2);
            this.installGroupBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installGroupBox.ForeColor = System.Drawing.SystemColors.Control;
            this.installGroupBox.Location = new System.Drawing.Point(12, 124);
            this.installGroupBox.Name = "installGroupBox";
            this.installGroupBox.Size = new System.Drawing.Size(416, 111);
            this.installGroupBox.TabIndex = 4;
            this.installGroupBox.TabStop = false;
            this.installGroupBox.Text = "Install";
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.BackColor = System.Drawing.SystemColors.ControlText;
            this.statusProgressBar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.statusProgressBar.Location = new System.Drawing.Point(7, 84);
            this.statusProgressBar.MarqueeAnimationSpeed = 10;
            this.statusProgressBar.Maximum = 10000;
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusProgressBar.Size = new System.Drawing.Size(402, 14);
            this.statusProgressBar.Step = 1;
            this.statusProgressBar.TabIndex = 3;
            // 
            // installBtn
            // 
            this.installBtn.Enabled = false;
            this.installBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.installBtn.Location = new System.Drawing.Point(297, 18);
            this.installBtn.Name = "installBtn";
            this.installBtn.Size = new System.Drawing.Size(112, 60);
            this.installBtn.TabIndex = 2;
            this.installBtn.Text = "Install";
            this.installBtn.UseVisualStyleBackColor = true;
            this.installBtn.Click += new System.EventHandler(this.installBtn_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.statusLabel.Location = new System.Drawing.Point(7, 36);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(284, 42);
            this.statusLabel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(7, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Status:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(441, 247);
            this.Controls.Add(this.installGroupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.locationGroupBox);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.locationGroupBox.ResumeLayout(false);
            this.locationGroupBox.PerformLayout();
            this.installGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ProgressBar statusProgressBar;

        private System.Windows.Forms.Button installBtn;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label statusLabel;

        private System.Windows.Forms.GroupBox installGroupBox;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Button autoFindBtn;
        private System.Windows.Forms.Button browseBtn;

        private System.Windows.Forms.GroupBox locationGroupBox;

        private System.Windows.Forms.Button closeBtn;

        private System.Windows.Forms.MenuStrip menuStrip1;

        #endregion

    }
}
