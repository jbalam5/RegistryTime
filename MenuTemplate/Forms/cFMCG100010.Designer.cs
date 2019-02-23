namespace RegistryTime.Forms
{
    partial class cFMCG100010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cFMCG100010));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PrincipalPanel = new System.Windows.Forms.Panel();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ModelComboBox = new System.Windows.Forms.ComboBox();
            this.IPtextBox = new System.Windows.Forms.TextBox();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.ConectioncomboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NameConectiontextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.DefaultCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.PrincipalPanel.SuspendLayout();
            this.ContainerPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 144);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(714, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = " Configurar Lector";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PrincipalPanel
            // 
            this.PrincipalPanel.Controls.Add(this.ContainerPanel);
            this.PrincipalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrincipalPanel.Location = new System.Drawing.Point(0, 0);
            this.PrincipalPanel.Name = "PrincipalPanel";
            this.PrincipalPanel.Size = new System.Drawing.Size(714, 428);
            this.PrincipalPanel.TabIndex = 1;
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.BackColor = System.Drawing.Color.White;
            this.ContainerPanel.Controls.Add(this.ContentPanel);
            this.ContainerPanel.Controls.Add(this.panel1);
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(714, 428);
            this.ContainerPanel.TabIndex = 5;
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(69)))));
            this.DeleteButton.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HotTrack;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.ForeColor = System.Drawing.Color.White;
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.Location = new System.Drawing.Point(452, 13);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(149, 83);
            this.DeleteButton.TabIndex = 10;
            this.DeleteButton.Text = "Eliminar";
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(69)))));
            this.EditButton.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HotTrack;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.ForeColor = System.Drawing.Color.White;
            this.EditButton.Image = ((System.Drawing.Image)(resources.GetObject("EditButton.Image")));
            this.EditButton.Location = new System.Drawing.Point(308, 13);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(145, 83);
            this.EditButton.TabIndex = 9;
            this.EditButton.Text = "Editar";
            this.EditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(69)))));
            this.SaveButton.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HotTrack;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.Location = new System.Drawing.Point(20, 13);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(145, 83);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Guardar";
            this.SaveButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Dirección IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(350, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Puerto";
            // 
            // ModelComboBox
            // 
            this.ModelComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ModelComboBox.FormattingEnabled = true;
            this.ModelComboBox.Location = new System.Drawing.Point(354, 112);
            this.ModelComboBox.Name = "ModelComboBox";
            this.ModelComboBox.Size = new System.Drawing.Size(296, 28);
            this.ModelComboBox.TabIndex = 15;
            this.ModelComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // IPtextBox
            // 
            this.IPtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IPtextBox.Location = new System.Drawing.Point(14, 181);
            this.IPtextBox.Name = "IPtextBox";
            this.IPtextBox.Size = new System.Drawing.Size(300, 26);
            this.IPtextBox.TabIndex = 16;
            // 
            // PortTextBox
            // 
            this.PortTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PortTextBox.Location = new System.Drawing.Point(354, 181);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(296, 26);
            this.PortTextBox.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DefaultCheckBox);
            this.groupBox1.Controls.Add(this.NameConectiontextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ConectioncomboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.PortTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.IPtextBox);
            this.groupBox1.Controls.Add(this.ModelComboBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 244);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel2.Controls.Add(this.AddButton);
            this.panel2.Controls.Add(this.EditButton);
            this.panel2.Controls.Add(this.DeleteButton);
            this.panel2.Controls.Add(this.SaveButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(714, 107);
            this.panel2.TabIndex = 1;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.groupBox1);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 144);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Padding = new System.Windows.Forms.Padding(20);
            this.ContentPanel.Size = new System.Drawing.Size(714, 284);
            this.ContentPanel.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Conexión";
            // 
            // ConectioncomboBox
            // 
            this.ConectioncomboBox.FormattingEnabled = true;
            this.ConectioncomboBox.Location = new System.Drawing.Point(14, 49);
            this.ConectioncomboBox.Name = "ConectioncomboBox";
            this.ConectioncomboBox.Size = new System.Drawing.Size(300, 28);
            this.ConectioncomboBox.TabIndex = 19;
            this.ConectioncomboBox.SelectedIndexChanged += new System.EventHandler(this.ConectioncomboBox_SelectedIndexChanged);
            this.ConectioncomboBox.SelectedValueChanged += new System.EventHandler(this.ConectioncomboBox_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Nombre de conexión";
            // 
            // NameConectiontextBox
            // 
            this.NameConectiontextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameConectiontextBox.Location = new System.Drawing.Point(14, 112);
            this.NameConectiontextBox.Name = "NameConectiontextBox";
            this.NameConectiontextBox.Size = new System.Drawing.Size(300, 26);
            this.NameConectiontextBox.TabIndex = 21;
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(69)))));
            this.AddButton.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HotTrack;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.ForeColor = System.Drawing.Color.White;
            this.AddButton.Image = ((System.Drawing.Image)(resources.GetObject("AddButton.Image")));
            this.AddButton.Location = new System.Drawing.Point(164, 13);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(145, 83);
            this.AddButton.TabIndex = 21;
            this.AddButton.Text = "Nuevo";
            this.AddButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DefaultCheckBox
            // 
            this.DefaultCheckBox.AutoSize = true;
            this.DefaultCheckBox.Location = new System.Drawing.Point(354, 51);
            this.DefaultCheckBox.Name = "DefaultCheckBox";
            this.DefaultCheckBox.Size = new System.Drawing.Size(87, 24);
            this.DefaultCheckBox.TabIndex = 22;
            this.DefaultCheckBox.Text = "Default";
            this.DefaultCheckBox.UseVisualStyleBackColor = true;
            // 
            // cFMCG100010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 428);
            this.Controls.Add(this.PrincipalPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cFMCG100010";
            this.Text = "cFMCG100010";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.cFMCG100010_Load);
            this.panel1.ResumeLayout(false);
            this.PrincipalPanel.ResumeLayout(false);
            this.ContainerPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PrincipalPanel;
        private System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IPtextBox;
        private System.Windows.Forms.ComboBox ModelComboBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.TextBox NameConectiontextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ConectioncomboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.CheckBox DefaultCheckBox;
    }
}