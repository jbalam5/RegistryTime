﻿namespace MenuTemplate.Forms
{
    partial class cFMCX000010
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDatabase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.buttonGUARDAR = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 27);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MenuTemplate.Properties.Resources.close32;
            this.pictureBox1.Location = new System.Drawing.Point(378, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(182)))), ((int)(((byte)(191)))));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Location = new System.Drawing.Point(0, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(410, 285);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(99, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "DATOS DE CONEXION";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonGUARDAR);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBoxDatabase);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBoxPassword);
            this.panel2.Controls.Add(this.textBoxUserName);
            this.panel2.Controls.Add(this.textBoxServer);
            this.panel2.Location = new System.Drawing.Point(40, 44);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 217);
            this.panel2.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(20, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "Instancia";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(17, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 21;
            this.label4.Text = "Username";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(17, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 19);
            this.label6.TabIndex = 20;
            this.label6.Text = "Password";
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.Location = new System.Drawing.Point(92, 144);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(220, 20);
            this.textBoxDatabase.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(20, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "Database";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(92, 108);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(220, 20);
            this.textBoxPassword.TabIndex = 17;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(92, 67);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(220, 20);
            this.textBoxUserName.TabIndex = 16;
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(92, 25);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(220, 20);
            this.textBoxServer.TabIndex = 15;
            // 
            // buttonGUARDAR
            // 
            this.buttonGUARDAR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.buttonGUARDAR.FlatAppearance.BorderSize = 0;
            this.buttonGUARDAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGUARDAR.ForeColor = System.Drawing.Color.White;
            this.buttonGUARDAR.Location = new System.Drawing.Point(237, 191);
            this.buttonGUARDAR.Name = "buttonGUARDAR";
            this.buttonGUARDAR.Size = new System.Drawing.Size(75, 23);
            this.buttonGUARDAR.TabIndex = 23;
            this.buttonGUARDAR.Text = "Guardar";
            this.buttonGUARDAR.UseVisualStyleBackColor = false;
            this.buttonGUARDAR.Click += new System.EventHandler(this.buttonGUARDAR_Click);
            // 
            // cFMCX000010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 312);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cFMCX000010";
            this.Text = "cFMCX000010";
            this.Load += new System.EventHandler(this.cFMCX000010_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonGUARDAR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDatabase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxServer;
    }
}