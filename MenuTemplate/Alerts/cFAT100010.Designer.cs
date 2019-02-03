namespace Alerts
{
    partial class cFAT100010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cFAT100010));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.Closebutton = new System.Windows.Forms.Button();
            this.PrincipalPanel = new System.Windows.Forms.Panel();
            this.DescriptionPanel = new System.Windows.Forms.Panel();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.IconPictureBox = new System.Windows.Forms.PictureBox();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.QuestionPanel = new System.Windows.Forms.Panel();
            this.NoButton = new System.Windows.Forms.Button();
            this.YesButton = new System.Windows.Forms.Button();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.OkButton = new System.Windows.Forms.Button();
            this.TopPanel.SuspendLayout();
            this.PrincipalPanel.SuspendLayout();
            this.DescriptionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
            this.ButtonPanel.SuspendLayout();
            this.QuestionPanel.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.TopPanel.Controls.Add(this.TitleLabel);
            this.TopPanel.Controls.Add(this.Closebutton);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(456, 30);
            this.TopPanel.TabIndex = 5;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(8, 6);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(86, 18);
            this.TitleLabel.TabIndex = 13;
            this.TitleLabel.Text = "Información";
            // 
            // Closebutton
            // 
            this.Closebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Closebutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Closebutton.BackgroundImage")));
            this.Closebutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Closebutton.CausesValidation = false;
            this.Closebutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Closebutton.FlatAppearance.BorderSize = 0;
            this.Closebutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.Closebutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.Closebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Closebutton.Location = new System.Drawing.Point(426, 0);
            this.Closebutton.Name = "Closebutton";
            this.Closebutton.Size = new System.Drawing.Size(30, 30);
            this.Closebutton.TabIndex = 12;
            this.Closebutton.UseVisualStyleBackColor = true;
            this.Closebutton.Visible = false;
            this.Closebutton.Click += new System.EventHandler(this.Closebutton_Click);
            // 
            // PrincipalPanel
            // 
            this.PrincipalPanel.BackColor = System.Drawing.Color.Transparent;
            this.PrincipalPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PrincipalPanel.Controls.Add(this.DescriptionPanel);
            this.PrincipalPanel.Controls.Add(this.IconPictureBox);
            this.PrincipalPanel.Controls.Add(this.ButtonPanel);
            this.PrincipalPanel.Controls.Add(this.TopPanel);
            this.PrincipalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrincipalPanel.Location = new System.Drawing.Point(0, 0);
            this.PrincipalPanel.Name = "PrincipalPanel";
            this.PrincipalPanel.Size = new System.Drawing.Size(458, 272);
            this.PrincipalPanel.TabIndex = 6;
            // 
            // DescriptionPanel
            // 
            this.DescriptionPanel.Controls.Add(this.DescriptionLabel);
            this.DescriptionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DescriptionPanel.Location = new System.Drawing.Point(114, 30);
            this.DescriptionPanel.Name = "DescriptionPanel";
            this.DescriptionPanel.Size = new System.Drawing.Size(342, 42);
            this.DescriptionPanel.TabIndex = 10;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.Location = new System.Drawing.Point(3, 20);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(242, 20);
            this.DescriptionLabel.TabIndex = 7;
            this.DescriptionLabel.Text = "Proceso realizado correctamente";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IconPictureBox
            // 
            this.IconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.IconPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.IconPictureBox.Location = new System.Drawing.Point(0, 30);
            this.IconPictureBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.IconPictureBox.Name = "IconPictureBox";
            this.IconPictureBox.Padding = new System.Windows.Forms.Padding(10);
            this.IconPictureBox.Size = new System.Drawing.Size(114, 240);
            this.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconPictureBox.TabIndex = 9;
            this.IconPictureBox.TabStop = false;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.QuestionPanel);
            this.ButtonPanel.Controls.Add(this.InfoPanel);
            this.ButtonPanel.Location = new System.Drawing.Point(1, 71);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(457, 282);
            this.ButtonPanel.TabIndex = 8;
            // 
            // QuestionPanel
            // 
            this.QuestionPanel.Controls.Add(this.NoButton);
            this.QuestionPanel.Controls.Add(this.YesButton);
            this.QuestionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.QuestionPanel.Location = new System.Drawing.Point(0, 100);
            this.QuestionPanel.Name = "QuestionPanel";
            this.QuestionPanel.Size = new System.Drawing.Size(457, 100);
            this.QuestionPanel.TabIndex = 8;
            this.QuestionPanel.Visible = false;
            // 
            // NoButton
            // 
            this.NoButton.FlatAppearance.BorderSize = 0;
            this.NoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoButton.Location = new System.Drawing.Point(338, 20);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(106, 47);
            this.NoButton.TabIndex = 2;
            this.NoButton.Text = "No";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // YesButton
            // 
            this.YesButton.FlatAppearance.BorderSize = 0;
            this.YesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YesButton.Location = new System.Drawing.Point(226, 20);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(106, 47);
            this.YesButton.TabIndex = 1;
            this.YesButton.Text = "Si";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // InfoPanel
            // 
            this.InfoPanel.Controls.Add(this.OkButton);
            this.InfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InfoPanel.Location = new System.Drawing.Point(0, 0);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(457, 100);
            this.InfoPanel.TabIndex = 7;
            this.InfoPanel.Visible = false;
            // 
            // OkButton
            // 
            this.OkButton.FlatAppearance.BorderSize = 0;
            this.OkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkButton.Location = new System.Drawing.Point(338, 26);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(106, 47);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "Aceptar";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cFAT100010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 272);
            this.Controls.Add(this.PrincipalPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cFAT100010";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "cFAT100010";
            this.Load += new System.EventHandler(this.cFAT100010_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.PrincipalPanel.ResumeLayout(false);
            this.DescriptionPanel.ResumeLayout(false);
            this.DescriptionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
            this.ButtonPanel.ResumeLayout(false);
            this.QuestionPanel.ResumeLayout(false);
            this.InfoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button Closebutton;
        private System.Windows.Forms.Panel PrincipalPanel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Panel QuestionPanel;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Button NoButton;
        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.PictureBox IconPictureBox;
        private System.Windows.Forms.Panel DescriptionPanel;
    }
}