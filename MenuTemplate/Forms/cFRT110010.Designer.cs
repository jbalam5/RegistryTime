namespace MenuTemplate.Forms
{
    partial class cFRT110010
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
            this.PrincipalPanel = new System.Windows.Forms.Panel();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.CloseWindowsPictureBox = new System.Windows.Forms.PictureBox();
            this.MaxWindowsPictureBox = new System.Windows.Forms.PictureBox();
            this.MinWindowsPictureBox = new System.Windows.Forms.PictureBox();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PrincipalPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseWindowsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxWindowsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinWindowsPictureBox)).BeginInit();
            this.ContainerPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrincipalPanel
            // 
            this.PrincipalPanel.Controls.Add(this.ContainerPanel);
            this.PrincipalPanel.Controls.Add(this.TopPanel);
            this.PrincipalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrincipalPanel.Location = new System.Drawing.Point(0, 0);
            this.PrincipalPanel.Name = "PrincipalPanel";
            this.PrincipalPanel.Size = new System.Drawing.Size(675, 450);
            this.PrincipalPanel.TabIndex = 0;
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.SystemColors.Control;
            this.TopPanel.Controls.Add(this.CloseWindowsPictureBox);
            this.TopPanel.Controls.Add(this.MaxWindowsPictureBox);
            this.TopPanel.Controls.Add(this.MinWindowsPictureBox);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(675, 30);
            this.TopPanel.TabIndex = 4;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            // 
            // CloseWindowsPictureBox
            // 
            this.CloseWindowsPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseWindowsPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CloseWindowsPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseWindowsPictureBox.Image = global::MenuTemplate.Properties.Resources.close32;
            this.CloseWindowsPictureBox.Location = new System.Drawing.Point(635, 0);
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
            this.MaxWindowsPictureBox.Location = new System.Drawing.Point(602, 0);
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
            this.MinWindowsPictureBox.Location = new System.Drawing.Point(569, 0);
            this.MinWindowsPictureBox.Name = "MinWindowsPictureBox";
            this.MinWindowsPictureBox.Size = new System.Drawing.Size(33, 30);
            this.MinWindowsPictureBox.TabIndex = 1;
            this.MinWindowsPictureBox.TabStop = false;
            this.MinWindowsPictureBox.Click += new System.EventHandler(this.MinWindowsPictureBox_Click);
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.Controls.Add(this.panel1);
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(0, 30);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(675, 420);
            this.ContainerPanel.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 37);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // cFRT110010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 450);
            this.Controls.Add(this.PrincipalPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cFRT110010";
            this.Text = "cFRT110010";
            this.PrincipalPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CloseWindowsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxWindowsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinWindowsPictureBox)).EndInit();
            this.ContainerPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PrincipalPanel;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.PictureBox CloseWindowsPictureBox;
        private System.Windows.Forms.PictureBox MaxWindowsPictureBox;
        private System.Windows.Forms.PictureBox MinWindowsPictureBox;
        private System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}