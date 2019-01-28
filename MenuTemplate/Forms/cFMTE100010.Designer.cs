namespace RegistryTime.Forms
{
    partial class cFMTE100010
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 37);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empleado";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.buttonEliminar);
            this.panel2.Controls.Add(this.buttonEditar);
            this.panel2.Controls.Add(this.ButtonSave);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBoxDescripcion);
            this.panel2.Controls.Add(this.textBoxNombre);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 413);
            this.panel2.TabIndex = 2;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(115, 61);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(291, 20);
            this.textBoxNombre.TabIndex = 22;
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(115, 87);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(291, 20);
            this.textBoxDescripcion.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Nombre";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Descripcion";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.BackColor = System.Drawing.Color.Transparent;
            this.buttonEliminar.BackgroundImage = global::RegistryTime.Properties.Resources.CircleDeletex421;
            this.buttonEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonEliminar.FlatAppearance.BorderSize = 0;
            this.buttonEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEliminar.Location = new System.Drawing.Point(121, 4);
            this.buttonEliminar.Margin = new System.Windows.Forms.Padding(1);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(35, 36);
            this.buttonEliminar.TabIndex = 28;
            this.buttonEliminar.UseVisualStyleBackColor = false;
            // 
            // buttonEditar
            // 
            this.buttonEditar.BackColor = System.Drawing.Color.Transparent;
            this.buttonEditar.BackgroundImage = global::RegistryTime.Properties.Resources.CircleEditx421;
            this.buttonEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonEditar.FlatAppearance.BorderSize = 0;
            this.buttonEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditar.Location = new System.Drawing.Point(81, 4);
            this.buttonEditar.Margin = new System.Windows.Forms.Padding(1);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(35, 36);
            this.buttonEditar.TabIndex = 27;
            this.buttonEditar.UseVisualStyleBackColor = false;
            // 
            // ButtonSave
            // 
            this.ButtonSave.BackColor = System.Drawing.Color.Transparent;
            this.ButtonSave.BackgroundImage = global::RegistryTime.Properties.Resources.CircleSavex48;
            this.ButtonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonSave.FlatAppearance.BorderSize = 0;
            this.ButtonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ButtonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSave.Location = new System.Drawing.Point(40, 4);
            this.ButtonSave.Margin = new System.Windows.Forms.Padding(1);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(35, 36);
            this.ButtonSave.TabIndex = 26;
            this.ButtonSave.UseVisualStyleBackColor = false;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(50, 152);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(672, 150);
            this.dataGridView1.TabIndex = 29;
            // 
            // cFMTE100010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cFMTE100010";
            this.Text = "cFMTE100010";
            this.Load += new System.EventHandler(this.cFMTE100010_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}