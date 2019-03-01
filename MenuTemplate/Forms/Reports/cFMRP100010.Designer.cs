namespace RegistryTime.Forms.Reports
{
    partial class cFMRP100010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cFMRP100010));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PrincipalPanel = new System.Windows.Forms.Panel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ParentPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.ChildContentPanel = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ChildLeftPanel = new System.Windows.Forms.Panel();
            this.buttonNuevo = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseFilterButton = new System.Windows.Forms.Button();
            this.TopPanel.SuspendLayout();
            this.PrincipalPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.ParentPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.ChildContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.ChildLeftPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(844, 37);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reportes";
            // 
            // PrincipalPanel
            // 
            this.PrincipalPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PrincipalPanel.Controls.Add(this.MainPanel);
            this.PrincipalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrincipalPanel.Location = new System.Drawing.Point(0, 0);
            this.PrincipalPanel.Name = "PrincipalPanel";
            this.PrincipalPanel.Size = new System.Drawing.Size(846, 540);
            this.PrincipalPanel.TabIndex = 1;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ParentPanel);
            this.MainPanel.Controls.Add(this.TopPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(844, 538);
            this.MainPanel.TabIndex = 5;
            // 
            // ParentPanel
            // 
            this.ParentPanel.Controls.Add(this.panel3);
            this.ParentPanel.Controls.Add(this.panel1);
            this.ParentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParentPanel.Location = new System.Drawing.Point(0, 37);
            this.ParentPanel.Name = "ParentPanel";
            this.ParentPanel.Size = new System.Drawing.Size(844, 501);
            this.ParentPanel.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ContentPanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(844, 447);
            this.panel3.TabIndex = 12;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.ChildContentPanel);
            this.ContentPanel.Controls.Add(this.ChildLeftPanel);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(844, 447);
            this.ContentPanel.TabIndex = 0;
            // 
            // ChildContentPanel
            // 
            this.ChildContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChildContentPanel.Controls.Add(this.dataGridView1);
            this.ChildContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChildContentPanel.Location = new System.Drawing.Point(299, 0);
            this.ChildContentPanel.Name = "ChildContentPanel";
            this.ChildContentPanel.Padding = new System.Windows.Forms.Padding(5);
            this.ChildContentPanel.Size = new System.Drawing.Size(545, 447);
            this.ChildContentPanel.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(5, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(533, 435);
            this.dataGridView1.TabIndex = 14;
            // 
            // ChildLeftPanel
            // 
            this.ChildLeftPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ChildLeftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChildLeftPanel.Controls.Add(this.buttonNuevo);
            this.ChildLeftPanel.Controls.Add(this.comboBox2);
            this.ChildLeftPanel.Controls.Add(this.label5);
            this.ChildLeftPanel.Controls.Add(this.label4);
            this.ChildLeftPanel.Controls.Add(this.label3);
            this.ChildLeftPanel.Controls.Add(this.dateTimePicker2);
            this.ChildLeftPanel.Controls.Add(this.dateTimePicker1);
            this.ChildLeftPanel.Controls.Add(this.comboBox1);
            this.ChildLeftPanel.Controls.Add(this.label2);
            this.ChildLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ChildLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.ChildLeftPanel.Name = "ChildLeftPanel";
            this.ChildLeftPanel.Size = new System.Drawing.Size(299, 447);
            this.ChildLeftPanel.TabIndex = 1;
            // 
            // buttonNuevo
            // 
            this.buttonNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(69)))));
            this.buttonNuevo.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNuevo.ForeColor = System.Drawing.Color.White;
            this.buttonNuevo.Location = new System.Drawing.Point(6, 296);
            this.buttonNuevo.Name = "buttonNuevo";
            this.buttonNuevo.Size = new System.Drawing.Size(287, 40);
            this.buttonNuevo.TabIndex = 9;
            this.buttonNuevo.Text = "Buscar";
            this.buttonNuevo.UseVisualStyleBackColor = false;
            this.buttonNuevo.Click += new System.EventHandler(this.buttonNuevo_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 236);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(285, 28);
            this.comboBox2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Empleado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Departamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Final";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(8, 105);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(285, 26);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(8, 38);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(285, 26);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(8, 169);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(285, 28);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha Inicial";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.CloseFilterButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(844, 54);
            this.panel1.TabIndex = 11;
            // 
            // CloseFilterButton
            // 
            this.CloseFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(69)))));
            this.CloseFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseFilterButton.ForeColor = System.Drawing.Color.White;
            this.CloseFilterButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseFilterButton.Image")));
            this.CloseFilterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CloseFilterButton.Location = new System.Drawing.Point(8, 6);
            this.CloseFilterButton.Name = "CloseFilterButton";
            this.CloseFilterButton.Size = new System.Drawing.Size(106, 42);
            this.CloseFilterButton.TabIndex = 0;
            this.CloseFilterButton.Text = "Filtros";
            this.CloseFilterButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CloseFilterButton.UseVisualStyleBackColor = false;
            this.CloseFilterButton.Click += new System.EventHandler(this.CloseFilterButton_Click);
            // 
            // cFMRP100010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 540);
            this.Controls.Add(this.PrincipalPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cFMRP100010";
            this.Text = "cFMRP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.PrincipalPanel.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.ParentPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            this.ChildContentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ChildLeftPanel.ResumeLayout(false);
            this.ChildLeftPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PrincipalPanel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.Panel ChildContentPanel;
        private System.Windows.Forms.Panel ChildLeftPanel;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CloseFilterButton;
        private System.Windows.Forms.Button buttonNuevo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel ParentPanel;
        private System.Windows.Forms.Panel panel3;
    }
}