namespace RegistryTime.Forms
{
    partial class CFRT140010
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PrincipalPanel = new System.Windows.Forms.Panel();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.NormalButton = new System.Windows.Forms.Button();
            this.Closebutton = new System.Windows.Forms.Button();
            this.MaximizeButton = new System.Windows.Forms.Button();
            this.Minimizebutton = new System.Windows.Forms.Button();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FechaActualLabel = new System.Windows.Forms.Label();
            this.HoraActualLabel = new System.Windows.Forms.Label();
            this.MensajePanel = new System.Windows.Forms.Panel();
            this.MensajeLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PerfilPictureBox = new System.Windows.Forms.PictureBox();
            this.TipoEmpleadoTextBox = new System.Windows.Forms.TextBox();
            this.DepartamentosTextBox = new System.Windows.Forms.TextBox();
            this.ApellidosTtextBox = new System.Windows.Forms.TextBox();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NoControlTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RegistroTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.PrincipalPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.ContainerPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.MensajePanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PerfilPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panel1.Size = new System.Drawing.Size(800, 37);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registro de Asistencias";
            // 
            // PrincipalPanel
            // 
            this.PrincipalPanel.Controls.Add(this.TopPanel);
            this.PrincipalPanel.Controls.Add(this.ContainerPanel);
            this.PrincipalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrincipalPanel.Location = new System.Drawing.Point(0, 0);
            this.PrincipalPanel.Name = "PrincipalPanel";
            this.PrincipalPanel.Size = new System.Drawing.Size(800, 600);
            this.PrincipalPanel.TabIndex = 1;
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.White;
            this.TopPanel.Controls.Add(this.NormalButton);
            this.TopPanel.Controls.Add(this.Closebutton);
            this.TopPanel.Controls.Add(this.MaximizeButton);
            this.TopPanel.Controls.Add(this.Minimizebutton);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(800, 30);
            this.TopPanel.TabIndex = 11;
            // 
            // NormalButton
            // 
            this.NormalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NormalButton.BackColor = System.Drawing.Color.White;
            this.NormalButton.BackgroundImage = global::RegistryTime.Properties.Resources.iconSquared;
            this.NormalButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.NormalButton.FlatAppearance.BorderSize = 0;
            this.NormalButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.NormalButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.NormalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NormalButton.Location = new System.Drawing.Point(738, 0);
            this.NormalButton.Name = "NormalButton";
            this.NormalButton.Size = new System.Drawing.Size(30, 30);
            this.NormalButton.TabIndex = 7;
            this.NormalButton.UseVisualStyleBackColor = false;
            this.NormalButton.Visible = false;
            // 
            // Closebutton
            // 
            this.Closebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Closebutton.BackgroundImage = global::RegistryTime.Properties.Resources.iconDel;
            this.Closebutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Closebutton.FlatAppearance.BorderSize = 0;
            this.Closebutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.Closebutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.Closebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Closebutton.Location = new System.Drawing.Point(770, 0);
            this.Closebutton.Name = "Closebutton";
            this.Closebutton.Size = new System.Drawing.Size(30, 30);
            this.Closebutton.TabIndex = 6;
            this.Closebutton.UseVisualStyleBackColor = true;
            this.Closebutton.Click += new System.EventHandler(this.Closebutton_Click);
            // 
            // MaximizeButton
            // 
            this.MaximizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaximizeButton.BackgroundImage = global::RegistryTime.Properties.Resources.iconsmax15;
            this.MaximizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MaximizeButton.FlatAppearance.BorderSize = 0;
            this.MaximizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MaximizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MaximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeButton.Location = new System.Drawing.Point(739, 0);
            this.MaximizeButton.Name = "MaximizeButton";
            this.MaximizeButton.Size = new System.Drawing.Size(30, 30);
            this.MaximizeButton.TabIndex = 5;
            this.MaximizeButton.UseVisualStyleBackColor = true;
            this.MaximizeButton.Visible = false;
            // 
            // Minimizebutton
            // 
            this.Minimizebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Minimizebutton.BackgroundImage = global::RegistryTime.Properties.Resources.iconLineH;
            this.Minimizebutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Minimizebutton.FlatAppearance.BorderSize = 0;
            this.Minimizebutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Minimizebutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Minimizebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimizebutton.Location = new System.Drawing.Point(706, 0);
            this.Minimizebutton.Name = "Minimizebutton";
            this.Minimizebutton.Size = new System.Drawing.Size(30, 30);
            this.Minimizebutton.TabIndex = 4;
            this.Minimizebutton.UseVisualStyleBackColor = true;
            this.Minimizebutton.Click += new System.EventHandler(this.Minimizebutton_Click);
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.Controls.Add(this.panel2);
            this.ContainerPanel.Controls.Add(this.MensajePanel);
            this.ContainerPanel.Controls.Add(this.groupBox1);
            this.ContainerPanel.Controls.Add(this.panel1);
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.ContainerPanel.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.ContainerPanel.Size = new System.Drawing.Size(800, 600);
            this.ContainerPanel.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.FechaActualLabel);
            this.panel2.Controls.Add(this.HoraActualLabel);
            this.panel2.Location = new System.Drawing.Point(158, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(512, 112);
            this.panel2.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::RegistryTime.Properties.Resources.WorldTimex128;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 106);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // FechaActualLabel
            // 
            this.FechaActualLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FechaActualLabel.AutoSize = true;
            this.FechaActualLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaActualLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FechaActualLabel.Location = new System.Drawing.Point(149, 63);
            this.FechaActualLabel.Name = "FechaActualLabel";
            this.FechaActualLabel.Size = new System.Drawing.Size(133, 24);
            this.FechaActualLabel.TabIndex = 9;
            this.FechaActualLabel.Text = "Fecha Actual";
            this.FechaActualLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // HoraActualLabel
            // 
            this.HoraActualLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HoraActualLabel.AutoSize = true;
            this.HoraActualLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoraActualLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.HoraActualLabel.Location = new System.Drawing.Point(145, 0);
            this.HoraActualLabel.Name = "HoraActualLabel";
            this.HoraActualLabel.Size = new System.Drawing.Size(229, 44);
            this.HoraActualLabel.TabIndex = 8;
            this.HoraActualLabel.Text = "Hora Actual";
            this.HoraActualLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MensajePanel
            // 
            this.MensajePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MensajePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.MensajePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MensajePanel.Controls.Add(this.MensajeLabel);
            this.MensajePanel.Location = new System.Drawing.Point(161, 207);
            this.MensajePanel.Name = "MensajePanel";
            this.MensajePanel.Size = new System.Drawing.Size(509, 58);
            this.MensajePanel.TabIndex = 10;
            // 
            // MensajeLabel
            // 
            this.MensajeLabel.AutoSize = true;
            this.MensajeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MensajeLabel.Location = new System.Drawing.Point(3, 19);
            this.MensajeLabel.Name = "MensajeLabel";
            this.MensajeLabel.Size = new System.Drawing.Size(205, 22);
            this.MensajeLabel.TabIndex = 0;
            this.MensajeLabel.Text = "Asistencia Registrada";
            this.MensajeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.PerfilPictureBox);
            this.groupBox1.Controls.Add(this.TipoEmpleadoTextBox);
            this.groupBox1.Controls.Add(this.DepartamentosTextBox);
            this.groupBox1.Controls.Add(this.ApellidosTtextBox);
            this.groupBox1.Controls.Add(this.NombreTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NoControlTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 271);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 263);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Empleado";
            // 
            // PerfilPictureBox
            // 
            this.PerfilPictureBox.BackgroundImage = global::RegistryTime.Properties.Resources.anonimo;
            this.PerfilPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PerfilPictureBox.Location = new System.Drawing.Point(540, 25);
            this.PerfilPictureBox.Name = "PerfilPictureBox";
            this.PerfilPictureBox.Size = new System.Drawing.Size(184, 155);
            this.PerfilPictureBox.TabIndex = 8;
            this.PerfilPictureBox.TabStop = false;
            // 
            // TipoEmpleadoTextBox
            // 
            this.TipoEmpleadoTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.TipoEmpleadoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipoEmpleadoTextBox.Location = new System.Drawing.Point(158, 176);
            this.TipoEmpleadoTextBox.Name = "TipoEmpleadoTextBox";
            this.TipoEmpleadoTextBox.ReadOnly = true;
            this.TipoEmpleadoTextBox.Size = new System.Drawing.Size(251, 29);
            this.TipoEmpleadoTextBox.TabIndex = 10;
            // 
            // DepartamentosTextBox
            // 
            this.DepartamentosTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.DepartamentosTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartamentosTextBox.Location = new System.Drawing.Point(158, 145);
            this.DepartamentosTextBox.Name = "DepartamentosTextBox";
            this.DepartamentosTextBox.ReadOnly = true;
            this.DepartamentosTextBox.Size = new System.Drawing.Size(251, 29);
            this.DepartamentosTextBox.TabIndex = 9;
            // 
            // ApellidosTtextBox
            // 
            this.ApellidosTtextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ApellidosTtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApellidosTtextBox.Location = new System.Drawing.Point(158, 111);
            this.ApellidosTtextBox.Name = "ApellidosTtextBox";
            this.ApellidosTtextBox.ReadOnly = true;
            this.ApellidosTtextBox.Size = new System.Drawing.Size(346, 29);
            this.ApellidosTtextBox.TabIndex = 8;
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.NombreTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreTextBox.Location = new System.Drawing.Point(158, 79);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.ReadOnly = true;
            this.NombreTextBox.Size = new System.Drawing.Size(346, 29);
            this.NombreTextBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tipo Empleado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "No Control";
            // 
            // NoControlTextBox
            // 
            this.NoControlTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.NoControlTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoControlTextBox.Location = new System.Drawing.Point(158, 45);
            this.NoControlTextBox.Name = "NoControlTextBox";
            this.NoControlTextBox.ReadOnly = true;
            this.NoControlTextBox.Size = new System.Drawing.Size(134, 29);
            this.NoControlTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre(s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Apellidos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Departamento";
            // 
            // CFRT140010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.PrincipalPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CFRT140010";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CFRT140010";
            this.Load += new System.EventHandler(this.CFRT140010_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PrincipalPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.ContainerPanel.ResumeLayout(false);
            this.ContainerPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.MensajePanel.ResumeLayout(false);
            this.MensajePanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PerfilPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PrincipalPanel;
        private System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.TextBox NoControlTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer RegistroTimer;
        private System.Windows.Forms.PictureBox PerfilPictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TipoEmpleadoTextBox;
        private System.Windows.Forms.TextBox DepartamentosTextBox;
        private System.Windows.Forms.TextBox ApellidosTtextBox;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Panel MensajePanel;
        private System.Windows.Forms.Label MensajeLabel;
        private System.Windows.Forms.Label FechaActualLabel;
        private System.Windows.Forms.Label HoraActualLabel;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button NormalButton;
        private System.Windows.Forms.Button Closebutton;
        private System.Windows.Forms.Button MaximizeButton;
        private System.Windows.Forms.Button Minimizebutton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}