namespace RegistryTime.Forms.Migrate
{
    partial class cFMMI100010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cFMMI100010));
            this.PrincipalPanel = new System.Windows.Forms.Panel();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.MigrateProgressBar = new System.Windows.Forms.ProgressBar();
            this.PercentageLabel = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.Minimizebutton = new System.Windows.Forms.Button();
            this.MigrateBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.PrincipalPanel.SuspendLayout();
            this.ContainerPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrincipalPanel
            // 
            this.PrincipalPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PrincipalPanel.Controls.Add(this.ContainerPanel);
            this.PrincipalPanel.Controls.Add(this.TopPanel);
            this.PrincipalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrincipalPanel.Location = new System.Drawing.Point(0, 0);
            this.PrincipalPanel.Name = "PrincipalPanel";
            this.PrincipalPanel.Size = new System.Drawing.Size(470, 167);
            this.PrincipalPanel.TabIndex = 0;
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.ContainerPanel.Controls.Add(this.MigrateProgressBar);
            this.ContainerPanel.Controls.Add(this.PercentageLabel);
            this.ContainerPanel.Controls.Add(this.MessageLabel);
            this.ContainerPanel.Controls.Add(this.panel1);
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(0, 30);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(468, 135);
            this.ContainerPanel.TabIndex = 5;
            // 
            // MigrateProgressBar
            // 
            this.MigrateProgressBar.ForeColor = System.Drawing.Color.ForestGreen;
            this.MigrateProgressBar.Location = new System.Drawing.Point(11, 84);
            this.MigrateProgressBar.MarqueeAnimationSpeed = 30;
            this.MigrateProgressBar.Name = "MigrateProgressBar";
            this.MigrateProgressBar.Size = new System.Drawing.Size(443, 23);
            this.MigrateProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.MigrateProgressBar.TabIndex = 4;
            this.MigrateProgressBar.UseWaitCursor = true;
            this.MigrateProgressBar.Value = 20;
            // 
            // PercentageLabel
            // 
            this.PercentageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PercentageLabel.Location = new System.Drawing.Point(413, 46);
            this.PercentageLabel.Name = "PercentageLabel";
            this.PercentageLabel.Size = new System.Drawing.Size(52, 23);
            this.PercentageLabel.TabIndex = 3;
            this.PercentageLabel.Text = "0%";
            this.PercentageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(9, 49);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(218, 20);
            this.MessageLabel.TabIndex = 2;
            this.MessageLabel.Text = "Paso 1: Migrando información";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 37);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Actualizando Información";
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.SystemColors.Control;
            this.TopPanel.Controls.Add(this.Minimizebutton);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(468, 30);
            this.TopPanel.TabIndex = 4;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            // 
            // Minimizebutton
            // 
            this.Minimizebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Minimizebutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Minimizebutton.BackgroundImage")));
            this.Minimizebutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Minimizebutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Minimizebutton.FlatAppearance.BorderSize = 0;
            this.Minimizebutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Minimizebutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Minimizebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimizebutton.Location = new System.Drawing.Point(438, 0);
            this.Minimizebutton.Name = "Minimizebutton";
            this.Minimizebutton.Size = new System.Drawing.Size(30, 30);
            this.Minimizebutton.TabIndex = 10;
            this.Minimizebutton.UseVisualStyleBackColor = true;
            this.Minimizebutton.Click += new System.EventHandler(this.Minimizebutton_Click);
            // 
            // cFMMI100010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 167);
            this.Controls.Add(this.PrincipalPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cFMMI100010";
            this.Text = "cFMMI100010";
            this.Load += new System.EventHandler(this.cFMMI100010_Load);
            this.PrincipalPanel.ResumeLayout(false);
            this.ContainerPanel.ResumeLayout(false);
            this.ContainerPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PrincipalPanel;
        private System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button Minimizebutton;
        private System.Windows.Forms.Label PercentageLabel;
        private System.Windows.Forms.Label MessageLabel;
        private System.ComponentModel.BackgroundWorker MigrateBackgroundWorker;
        private System.Windows.Forms.ProgressBar MigrateProgressBar;
    }
}