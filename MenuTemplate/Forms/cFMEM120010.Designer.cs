namespace RegistryTime.Forms
{
    partial class cFMEM120010
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
            this.label1 = new System.Windows.Forms.Label();
            this.PrincipalPanel = new System.Windows.Forms.Panel();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.exportExcelUsers = new RegistryTime.CustomControls.ExportExcelControl();
            this.dataGridViewDataUser = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.PrincipalPanel.SuspendLayout();
            this.ContainerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 37);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuarios";
            // 
            // PrincipalPanel
            // 
            this.PrincipalPanel.Controls.Add(this.ContainerPanel);
            this.PrincipalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrincipalPanel.Location = new System.Drawing.Point(0, 0);
            this.PrincipalPanel.Name = "PrincipalPanel";
            this.PrincipalPanel.Size = new System.Drawing.Size(800, 450);
            this.PrincipalPanel.TabIndex = 1;
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.Controls.Add(this.exportExcelUsers);
            this.ContainerPanel.Controls.Add(this.dataGridViewDataUser);
            this.ContainerPanel.Controls.Add(this.panel1);
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(800, 450);
            this.ContainerPanel.TabIndex = 5;
            // 
            // exportExcelUsers
            // 
            this.exportExcelUsers.BackColor = System.Drawing.Color.Transparent;
            this.exportExcelUsers.data = null;
            this.exportExcelUsers.Location = new System.Drawing.Point(12, 43);
            this.exportExcelUsers.Margin = new System.Windows.Forms.Padding(5);
            this.exportExcelUsers.Name = "exportExcelUsers";
            this.exportExcelUsers.Size = new System.Drawing.Size(111, 40);
            this.exportExcelUsers.TabIndex = 12;
            this.exportExcelUsers.Title = null;
            // 
            // dataGridViewDataUser
            // 
            this.dataGridViewDataUser.AllowUserToAddRows = false;
            this.dataGridViewDataUser.AllowUserToDeleteRows = false;
            this.dataGridViewDataUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDataUser.EnableHeadersVisualStyles = false;
            this.dataGridViewDataUser.Location = new System.Drawing.Point(12, 99);
            this.dataGridViewDataUser.Name = "dataGridViewDataUser";
            this.dataGridViewDataUser.ReadOnly = true;
            this.dataGridViewDataUser.RowHeadersVisible = false;
            this.dataGridViewDataUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDataUser.Size = new System.Drawing.Size(776, 339);
            this.dataGridViewDataUser.TabIndex = 11;
            // 
            // cFMEM120010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PrincipalPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cFMEM120010";
            this.Text = "DataGrid1";
            this.Load += new System.EventHandler(this.cFRT100010_Load);
            this.Resize += new System.EventHandler(this.cFRT100010_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PrincipalPanel.ResumeLayout(false);
            this.ContainerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PrincipalPanel;
        private System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.DataGridView dataGridViewDataUser;
        private CustomControls.ExportExcelControl exportExcelUsers;
    }
}