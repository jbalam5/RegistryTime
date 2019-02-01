namespace RegistryTime.Forms
{
    partial class cFRT150010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cFRT150010));
            this.PrincipalPanel = new System.Windows.Forms.Panel();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.DatetoolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Closebutton = new System.Windows.Forms.Button();
            this.Minimizebutton = new System.Windows.Forms.Button();
            this.PrincipalPanel.SuspendLayout();
            this.ContainerPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.PrincipalPanel.Size = new System.Drawing.Size(480, 285);
            this.PrincipalPanel.TabIndex = 0;
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.Controls.Add(this.ExitButton);
            this.ContainerPanel.Controls.Add(this.OkButton);
            this.ContainerPanel.Controls.Add(this.pictureBox1);
            this.ContainerPanel.Controls.Add(this.label3);
            this.ContainerPanel.Controls.Add(this.label2);
            this.ContainerPanel.Controls.Add(this.textBox2);
            this.ContainerPanel.Controls.Add(this.textBox1);
            this.ContainerPanel.Controls.Add(this.statusStrip1);
            this.ContainerPanel.Controls.Add(this.panel1);
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(0, 30);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(478, 253);
            this.ContainerPanel.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.panel1.Controls.Add(this.Closebutton);
            this.panel1.Controls.Add(this.Minimizebutton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 30);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Iniciar Sesión";
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.SystemColors.Control;
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(478, 30);
            this.TopPanel.TabIndex = 4;
            this.TopPanel.Visible = false;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DatetoolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 231);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(478, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // DatetoolStripStatusLabel
            // 
            this.DatetoolStripStatusLabel.Name = "DatetoolStripStatusLabel";
            this.DatetoolStripStatusLabel.Size = new System.Drawing.Size(75, 17);
            this.DatetoolStripStatusLabel.Text = "Fecha Actual";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(164, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(285, 26);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(164, 140);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(286, 26);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(161, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(161, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Contraseña";
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.Silver;
            this.OkButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Location = new System.Drawing.Point(164, 184);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(135, 36);
            this.OkButton.TabIndex = 7;
            this.OkButton.Text = "Aceptar";
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Silver;
            this.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Location = new System.Drawing.Point(316, 184);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(134, 36);
            this.ExitButton.TabIndex = 8;
            this.ExitButton.Text = "Salir";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RegistryTime.Properties.Resources.WorldTimex128;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(13, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 166);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
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
            this.Closebutton.Location = new System.Drawing.Point(449, 0);
            this.Closebutton.Name = "Closebutton";
            this.Closebutton.Size = new System.Drawing.Size(30, 30);
            this.Closebutton.TabIndex = 12;
            this.Closebutton.UseVisualStyleBackColor = true;
            this.Closebutton.Click += new System.EventHandler(this.Closebutton_Click);
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
            this.Minimizebutton.Location = new System.Drawing.Point(419, 0);
            this.Minimizebutton.Name = "Minimizebutton";
            this.Minimizebutton.Size = new System.Drawing.Size(30, 30);
            this.Minimizebutton.TabIndex = 10;
            this.Minimizebutton.UseVisualStyleBackColor = true;
            this.Minimizebutton.Click += new System.EventHandler(this.Minimizebutton_Click);
            // 
            // cFRT150010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 285);
            this.Controls.Add(this.PrincipalPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cFRT150010";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "cFRT150010";
            this.Load += new System.EventHandler(this.cFRT150010_Load);
            this.PrincipalPanel.ResumeLayout(false);
            this.ContainerPanel.ResumeLayout(false);
            this.ContainerPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PrincipalPanel;
        private System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button Closebutton;
        private System.Windows.Forms.Button Minimizebutton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel DatetoolStripStatusLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}