namespace MenuTemplate.Forms
{
    partial class cFRT120010
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.PrincipalPanel = new System.Windows.Forms.Panel();
            this.StatusPanel = new System.Windows.Forms.Panel();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.DatetoolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.UsertoolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CloseWindowsPictureBox = new System.Windows.Forms.PictureBox();
            this.MaxWindowsPictureBox = new System.Windows.Forms.PictureBox();
            this.MinWindowsPictureBox = new System.Windows.Forms.PictureBox();
            this.TopPanel.SuspendLayout();
            this.PrincipalPanel.SuspendLayout();
            this.StatusPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseWindowsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxWindowsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinWindowsPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.White;
            this.TopPanel.Controls.Add(this.CloseWindowsPictureBox);
            this.TopPanel.Controls.Add(this.MaxWindowsPictureBox);
            this.TopPanel.Controls.Add(this.MinWindowsPictureBox);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(800, 30);
            this.TopPanel.TabIndex = 2;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            // 
            // PrincipalPanel
            // 
            this.PrincipalPanel.Controls.Add(this.ContainerPanel);
            this.PrincipalPanel.Controls.Add(this.StatusPanel);
            this.PrincipalPanel.Controls.Add(this.TopPanel);
            this.PrincipalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrincipalPanel.Location = new System.Drawing.Point(0, 0);
            this.PrincipalPanel.Name = "PrincipalPanel";
            this.PrincipalPanel.Size = new System.Drawing.Size(800, 450);
            this.PrincipalPanel.TabIndex = 3;
            // 
            // StatusPanel
            // 
            this.StatusPanel.Controls.Add(this.statusStrip1);
            this.StatusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StatusPanel.Location = new System.Drawing.Point(0, 428);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(800, 22);
            this.StatusPanel.TabIndex = 3;
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(0, 30);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(800, 398);
            this.ContainerPanel.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UsertoolStripStatusLabel,
            this.DatetoolStripStatusLabel,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // DatetoolStripStatusLabel
            // 
            this.DatetoolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.DatetoolStripStatusLabel.Name = "DatetoolStripStatusLabel";
            this.DatetoolStripStatusLabel.Size = new System.Drawing.Size(132, 17);
            this.DatetoolStripStatusLabel.Text = "29/12/2018 12:40 P.M.";
            this.DatetoolStripStatusLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // UsertoolStripStatusLabel
            // 
            this.UsertoolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.UsertoolStripStatusLabel.Image = global::MenuTemplate.Properties.Resources.user24;
            this.UsertoolStripStatusLabel.Name = "UsertoolStripStatusLabel";
            this.UsertoolStripStatusLabel.Size = new System.Drawing.Size(69, 17);
            this.UsertoolStripStatusLabel.Text = "JBALAM";
            // 
            // CloseWindowsPictureBox
            // 
            this.CloseWindowsPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseWindowsPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseWindowsPictureBox.Image = global::MenuTemplate.Properties.Resources.close32;
            this.CloseWindowsPictureBox.Location = new System.Drawing.Point(760, 0);
            this.CloseWindowsPictureBox.Name = "CloseWindowsPictureBox";
            this.CloseWindowsPictureBox.Size = new System.Drawing.Size(33, 30);
            this.CloseWindowsPictureBox.TabIndex = 3;
            this.CloseWindowsPictureBox.TabStop = false;
            this.CloseWindowsPictureBox.Click += new System.EventHandler(this.CloseWindowsPictureBox_Click);
            // 
            // MaxWindowsPictureBox
            // 
            this.MaxWindowsPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxWindowsPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaxWindowsPictureBox.Image = global::MenuTemplate.Properties.Resources.maximizar32;
            this.MaxWindowsPictureBox.Location = new System.Drawing.Point(727, 0);
            this.MaxWindowsPictureBox.Name = "MaxWindowsPictureBox";
            this.MaxWindowsPictureBox.Size = new System.Drawing.Size(33, 30);
            this.MaxWindowsPictureBox.TabIndex = 2;
            this.MaxWindowsPictureBox.TabStop = false;
            this.MaxWindowsPictureBox.Click += new System.EventHandler(this.MaxWindowsPictureBox_Click);
            // 
            // MinWindowsPictureBox
            // 
            this.MinWindowsPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinWindowsPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinWindowsPictureBox.Image = global::MenuTemplate.Properties.Resources.minimizar32;
            this.MinWindowsPictureBox.Location = new System.Drawing.Point(694, 0);
            this.MinWindowsPictureBox.Name = "MinWindowsPictureBox";
            this.MinWindowsPictureBox.Size = new System.Drawing.Size(33, 30);
            this.MinWindowsPictureBox.TabIndex = 1;
            this.MinWindowsPictureBox.TabStop = false;
            this.MinWindowsPictureBox.Click += new System.EventHandler(this.MinWindowsPictureBox_Click);
            // 
            // cFRT120010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PrincipalPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cFRT120010";
            this.Text = "cFRT120010";
            this.TopPanel.ResumeLayout(false);
            this.PrincipalPanel.ResumeLayout(false);
            this.StatusPanel.ResumeLayout(false);
            this.StatusPanel.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseWindowsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxWindowsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinWindowsPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.PictureBox CloseWindowsPictureBox;
        private System.Windows.Forms.PictureBox MaxWindowsPictureBox;
        private System.Windows.Forms.PictureBox MinWindowsPictureBox;
        private System.Windows.Forms.Panel PrincipalPanel;
        private System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.Panel StatusPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel UsertoolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel DatetoolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}