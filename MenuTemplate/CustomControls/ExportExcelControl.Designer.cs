namespace RegistryTime.CustomControls
{
    partial class ExportExcelControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExportExcelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExportExcelButton
            // 
            this.ExportExcelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(69)))));
            this.ExportExcelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExportExcelButton.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HotTrack;
            this.ExportExcelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportExcelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportExcelButton.ForeColor = System.Drawing.Color.White;
            this.ExportExcelButton.Image = global::RegistryTime.Properties.Resources.Excel_icon;
            this.ExportExcelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExportExcelButton.Location = new System.Drawing.Point(0, 0);
            this.ExportExcelButton.Name = "ExportExcelButton";
            this.ExportExcelButton.Size = new System.Drawing.Size(121, 42);
            this.ExportExcelButton.TabIndex = 11;
            this.ExportExcelButton.Text = "Exportar";
            this.ExportExcelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExportExcelButton.UseVisualStyleBackColor = false;
            this.ExportExcelButton.Click += new System.EventHandler(this.ExportExcelButton_Click);
            // 
            // ExportExcelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ExportExcelButton);
            this.Name = "ExportExcelControl";
            this.Size = new System.Drawing.Size(121, 42);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExportExcelButton;
    }
}
