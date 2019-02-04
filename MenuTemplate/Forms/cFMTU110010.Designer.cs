namespace RegistryTime.Forms
{
    partial class cFMTU110010
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numericUpDownJornada = new System.Windows.Forms.NumericUpDown();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.numericUpDownLimiteSalida = new System.Windows.Forms.NumericUpDown();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.numericUpDownHoraSalida = new System.Windows.Forms.NumericUpDown();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel14 = new MaterialSkin.Controls.MaterialLabel();
            this.numericUpDownTiempoComida = new System.Windows.Forms.NumericUpDown();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.numericUpDownEntradaComida = new System.Windows.Forms.NumericUpDown();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.numericUpDownSalidaComida = new System.Windows.Forms.NumericUpDown();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.numericUpDownLimiteEntrada = new System.Windows.Forms.NumericUpDown();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.numericUpDownIniciaEntrada = new System.Windows.Forms.NumericUpDown();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.numericUpDownHoraEntrada = new System.Windows.Forms.NumericUpDown();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxTurno = new System.Windows.Forms.TextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBoxDepartamento = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.dateTimeFecha = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownJornada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLimiteSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHoraSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTiempoComida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEntradaComida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSalidaComida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLimiteEntrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIniciaEntrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHoraEntrada)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Turno";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.buttonCancelar);
            this.panel2.Controls.Add(this.buttonLimpiar);
            this.panel2.Controls.Add(this.buttonGuardar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 413);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tabControl1.Location = new System.Drawing.Point(12, 61);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 349);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Captura Turno";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.numericUpDownJornada);
            this.panel3.Controls.Add(this.materialLabel11);
            this.panel3.Controls.Add(this.numericUpDownLimiteSalida);
            this.panel3.Controls.Add(this.materialLabel12);
            this.panel3.Controls.Add(this.numericUpDownHoraSalida);
            this.panel3.Controls.Add(this.materialLabel13);
            this.panel3.Controls.Add(this.materialLabel14);
            this.panel3.Controls.Add(this.numericUpDownTiempoComida);
            this.panel3.Controls.Add(this.materialLabel7);
            this.panel3.Controls.Add(this.numericUpDownEntradaComida);
            this.panel3.Controls.Add(this.materialLabel8);
            this.panel3.Controls.Add(this.numericUpDownSalidaComida);
            this.panel3.Controls.Add(this.materialLabel9);
            this.panel3.Controls.Add(this.materialLabel10);
            this.panel3.Controls.Add(this.numericUpDownLimiteEntrada);
            this.panel3.Controls.Add(this.materialLabel6);
            this.panel3.Controls.Add(this.numericUpDownIniciaEntrada);
            this.panel3.Controls.Add(this.materialLabel5);
            this.panel3.Controls.Add(this.numericUpDownHoraEntrada);
            this.panel3.Controls.Add(this.materialLabel4);
            this.panel3.Controls.Add(this.materialLabel3);
            this.panel3.Controls.Add(this.textBoxDescripcion);
            this.panel3.Controls.Add(this.materialLabel2);
            this.panel3.Controls.Add(this.textBoxTurno);
            this.panel3.Controls.Add(this.materialLabel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(786, 312);
            this.panel3.TabIndex = 13;
            // 
            // numericUpDownJornada
            // 
            this.numericUpDownJornada.Location = new System.Drawing.Point(475, 225);
            this.numericUpDownJornada.Name = "numericUpDownJornada";
            this.numericUpDownJornada.Size = new System.Drawing.Size(172, 24);
            this.numericUpDownJornada.TabIndex = 67;
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(471, 203);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(108, 19);
            this.materialLabel11.TabIndex = 66;
            this.materialLabel11.Text = "Horas Jornada";
            // 
            // numericUpDownLimiteSalida
            // 
            this.numericUpDownLimiteSalida.Location = new System.Drawing.Point(283, 225);
            this.numericUpDownLimiteSalida.Name = "numericUpDownLimiteSalida";
            this.numericUpDownLimiteSalida.Size = new System.Drawing.Size(172, 24);
            this.numericUpDownLimiteSalida.TabIndex = 65;
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(279, 203);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(96, 19);
            this.materialLabel12.TabIndex = 64;
            this.materialLabel12.Text = "Limite Salida";
            // 
            // numericUpDownHoraSalida
            // 
            this.numericUpDownHoraSalida.Location = new System.Drawing.Point(89, 225);
            this.numericUpDownHoraSalida.Name = "numericUpDownHoraSalida";
            this.numericUpDownHoraSalida.Size = new System.Drawing.Size(172, 24);
            this.numericUpDownHoraSalida.TabIndex = 63;
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel13.Location = new System.Drawing.Point(-1, 202);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(50, 19);
            this.materialLabel13.TabIndex = 62;
            this.materialLabel13.Text = "Salida";
            // 
            // materialLabel14
            // 
            this.materialLabel14.AutoSize = true;
            this.materialLabel14.Depth = 0;
            this.materialLabel14.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel14.Location = new System.Drawing.Point(85, 203);
            this.materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(87, 19);
            this.materialLabel14.TabIndex = 61;
            this.materialLabel14.Text = "Hora Salida";
            // 
            // numericUpDownTiempoComida
            // 
            this.numericUpDownTiempoComida.Location = new System.Drawing.Point(475, 175);
            this.numericUpDownTiempoComida.Name = "numericUpDownTiempoComida";
            this.numericUpDownTiempoComida.Size = new System.Drawing.Size(172, 24);
            this.numericUpDownTiempoComida.TabIndex = 60;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(471, 153);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(116, 19);
            this.materialLabel7.TabIndex = 59;
            this.materialLabel7.Text = "Tiempo Comida";
            // 
            // numericUpDownEntradaComida
            // 
            this.numericUpDownEntradaComida.Location = new System.Drawing.Point(283, 175);
            this.numericUpDownEntradaComida.Name = "numericUpDownEntradaComida";
            this.numericUpDownEntradaComida.Size = new System.Drawing.Size(172, 24);
            this.numericUpDownEntradaComida.TabIndex = 58;
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(279, 153);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(60, 19);
            this.materialLabel8.TabIndex = 57;
            this.materialLabel8.Text = "Entrada";
            // 
            // numericUpDownSalidaComida
            // 
            this.numericUpDownSalidaComida.Location = new System.Drawing.Point(89, 175);
            this.numericUpDownSalidaComida.Name = "numericUpDownSalidaComida";
            this.numericUpDownSalidaComida.Size = new System.Drawing.Size(172, 24);
            this.numericUpDownSalidaComida.TabIndex = 56;
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(-1, 152);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(61, 19);
            this.materialLabel9.TabIndex = 55;
            this.materialLabel9.Text = "Comida";
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(85, 153);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(50, 19);
            this.materialLabel10.TabIndex = 54;
            this.materialLabel10.Text = "Salida";
            // 
            // numericUpDownLimiteEntrada
            // 
            this.numericUpDownLimiteEntrada.Location = new System.Drawing.Point(475, 122);
            this.numericUpDownLimiteEntrada.Name = "numericUpDownLimiteEntrada";
            this.numericUpDownLimiteEntrada.Size = new System.Drawing.Size(172, 24);
            this.numericUpDownLimiteEntrada.TabIndex = 53;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(471, 100);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(106, 19);
            this.materialLabel6.TabIndex = 52;
            this.materialLabel6.Text = "Limite Entrada";
            // 
            // numericUpDownIniciaEntrada
            // 
            this.numericUpDownIniciaEntrada.Location = new System.Drawing.Point(283, 122);
            this.numericUpDownIniciaEntrada.Name = "numericUpDownIniciaEntrada";
            this.numericUpDownIniciaEntrada.Size = new System.Drawing.Size(172, 24);
            this.numericUpDownIniciaEntrada.TabIndex = 51;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(279, 100);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(100, 19);
            this.materialLabel5.TabIndex = 50;
            this.materialLabel5.Text = "Inicia Entrada";
            // 
            // numericUpDownHoraEntrada
            // 
            this.numericUpDownHoraEntrada.Location = new System.Drawing.Point(89, 122);
            this.numericUpDownHoraEntrada.Name = "numericUpDownHoraEntrada";
            this.numericUpDownHoraEntrada.Size = new System.Drawing.Size(172, 24);
            this.numericUpDownHoraEntrada.TabIndex = 49;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(-1, 99);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(60, 19);
            this.materialLabel4.TabIndex = 48;
            this.materialLabel4.Text = "Entrada";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(85, 100);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(97, 19);
            this.materialLabel3.TabIndex = 47;
            this.materialLabel3.Text = "Hora Entrada";
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(3, 72);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(335, 24);
            this.textBoxDescripcion.TabIndex = 44;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(-1, 50);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(89, 19);
            this.materialLabel2.TabIndex = 45;
            this.materialLabel2.Text = "Descripcion";
            // 
            // textBoxTurno
            // 
            this.textBoxTurno.Location = new System.Drawing.Point(3, 23);
            this.textBoxTurno.Name = "textBoxTurno";
            this.textBoxTurno.Size = new System.Drawing.Size(335, 24);
            this.textBoxTurno.TabIndex = 42;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(-1, 1);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(48, 19);
            this.materialLabel1.TabIndex = 43;
            this.materialLabel1.Text = "Turno";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 318);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dia Festivo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.comboBoxDepartamento);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.dateTimeFecha);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.textBoxNombre);
            this.panel4.Location = new System.Drawing.Point(6, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(774, 291);
            this.panel4.TabIndex = 14;
            // 
            // comboBoxDepartamento
            // 
            this.comboBoxDepartamento.FormattingEnabled = true;
            this.comboBoxDepartamento.Location = new System.Drawing.Point(3, 115);
            this.comboBoxDepartamento.Name = "comboBoxDepartamento";
            this.comboBoxDepartamento.Size = new System.Drawing.Size(335, 26);
            this.comboBoxDepartamento.TabIndex = 40;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(0, 96);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(102, 18);
            this.label24.TabIndex = 34;
            this.label24.Text = "Departamento";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimeFecha
            // 
            this.dateTimeFecha.Location = new System.Drawing.Point(3, 21);
            this.dateTimeFecha.Name = "dateTimeFecha";
            this.dateTimeFecha.Size = new System.Drawing.Size(335, 24);
            this.dateTimeFecha.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(-1, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 18);
            this.label11.TabIndex = 22;
            this.label11.Text = "Nombre";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 18);
            this.label13.TabIndex = 20;
            this.label13.Text = "Fecha";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(2, 69);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(335, 24);
            this.textBoxNombre.TabIndex = 15;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(69)))));
            this.buttonCancelar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.White;
            this.buttonCancelar.Location = new System.Drawing.Point(177, 6);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(91, 40);
            this.buttonCancelar.TabIndex = 13;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(69)))));
            this.buttonLimpiar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLimpiar.ForeColor = System.Drawing.Color.White;
            this.buttonLimpiar.Location = new System.Drawing.Point(96, 6);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(82, 40);
            this.buttonLimpiar.TabIndex = 12;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = false;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(83)))), ((int)(((byte)(69)))));
            this.buttonGuardar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuardar.ForeColor = System.Drawing.Color.White;
            this.buttonGuardar.Location = new System.Drawing.Point(12, 6);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(90, 40);
            this.buttonGuardar.TabIndex = 11;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // cFMTU110010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "cFMTU110010";
            this.Load += new System.EventHandler(this.cFRT140010_Load);
            this.Resize += new System.EventHandler(this.cFMDE110010_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownJornada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLimiteSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHoraSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTiempoComida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEntradaComida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSalidaComida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLimiteEntrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIniciaEntrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHoraEntrada)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        public System.Windows.Forms.TextBox textBoxDescripcion;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        public System.Windows.Forms.TextBox textBoxTurno;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBoxDepartamento;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker dateTimeFecha;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.NumericUpDown numericUpDownJornada;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private System.Windows.Forms.NumericUpDown numericUpDownLimiteSalida;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private System.Windows.Forms.NumericUpDown numericUpDownHoraSalida;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private MaterialSkin.Controls.MaterialLabel materialLabel14;
        private System.Windows.Forms.NumericUpDown numericUpDownTiempoComida;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private System.Windows.Forms.NumericUpDown numericUpDownEntradaComida;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private System.Windows.Forms.NumericUpDown numericUpDownSalidaComida;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private System.Windows.Forms.NumericUpDown numericUpDownLimiteEntrada;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.NumericUpDown numericUpDownIniciaEntrada;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.NumericUpDown numericUpDownHoraEntrada;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
    }
}