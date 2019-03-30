using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLayer;
using ModelLayer;

namespace RegistryTime.Forms.Reports
{
    public partial class cFMRP120010 : Form
    {
        #region "EVENTS"
        public cFMRP120010()
        {
            InitializeComponent();
            //LoadTurn();
            LoadDepartament();
            LoadEmployee();

        }

        private void cFMRP120010_Load(object sender, EventArgs e)
        {
            try
            {
                loaderControl1.Visible = false;
                QueryBackgroundWorker.DoWork += QueryBackgroundWorker_DoWork;
                QueryBackgroundWorker.ProgressChanged += QueryBackgroundWorker_ProgressChanged;
                QueryBackgroundWorker.RunWorkerCompleted += QueryBackgroundWorker_RunWorkerCompleted;
                QueryBackgroundWorker.WorkerReportsProgress = true;
                dataGridViewReporteGeneral.AutoResizeColumns();
                dataGridViewReporteGeneral.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewReporteGeneral.ClearSelection();

                exportExcelControl1.data = dataGridViewReporteGeneral;
                exportExcelControl1.Title = "ReporteAusentismo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("cFMRP120010_Load: {0}", ex.Message), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseFilterButton_Click(object sender, EventArgs e)
        {
            if (ChildLeftPanel.Visible)
                ChildLeftPanel.Visible = false;
            else
                ChildLeftPanel.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChildLeftPanel.Visible = true;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            ChildLeftPanel.Visible = false;
            QueryBackgroundWorker.RunWorkerAsync();

            
        }

        private void QueryBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                buttonBuscar.Enabled = false;
                loaderControl1.title = "Por favor espere";
                loaderControl1.description = "Obteniendo información";
                loaderControl1.Visible = true;
            }
            ));

            System.Threading.Thread.Sleep(3000);
            ReportsBLL ReportsBLL = new ReportsBLL();

           
            //CheckInoursBLL CheckInoursBLL = new CheckInoursBLL();
            this.Invoke(new Action(() => dataGridViewReporteGeneral.DataSource = ReportsBLL.ReportAbsenteeism(dateTimeFechaInicio.Value, dateTimeFechaFin.Value, Convert.ToInt32(comboBoxDepartamento.SelectedValue.ToString()), Convert.ToInt32(comboBoxEmpleado.SelectedValue.ToString()))));
        }

        private void QueryBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage);
        }

        private void QueryBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                loaderControl1.Visible = false; buttonBuscar.Enabled = true;
            }));
        }
        #endregion

        #region "FUNCTIONS"
        //public void LoadTurn()
        //{
        //    try
        //    {
        //        TurnBLL TurnBLL = new TurnBLL();
        //        DataTable Turnos;
        //        Turnos = TurnBLL.All();
        //        comboBoxTurno.DisplayMember = "Text";
        //        comboBoxTurno.ValueMember = "Value";

        //        List<Object> items = new List<object>();
        //        items.Add(new { Text = "Todos", Value = "0" });
        //        foreach (DataRow Turno in Turnos.Rows)
        //        {
        //            items.Add(new { Text = Turno[1].ToString(), Value = Turno[0].ToString() });
        //        }
        //        comboBoxTurno.DataSource = items;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(String.Format("LoadTurn: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public void LoadDepartament()
        {
            try
            {
                DepartamentBLL DepartamentBLL = new DepartamentBLL();
                DataTable Departamentos;
                Departamentos = DepartamentBLL.All("ALL");
                comboBoxDepartamento.DisplayMember = "Text";
                comboBoxDepartamento.ValueMember = "Value";

                List<Object> items = new List<object>();
                items.Add(new { Text = "Todos", Value = "0" });
                foreach (DataRow Departamento in Departamentos.Rows)
                {
                    items.Add(new { Text = Departamento[DepartamentML.DataBase.Name].ToString(), Value = Departamento[DepartamentML.DataBase.Id].ToString() });
                }
                comboBoxDepartamento.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadDepartament: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadEmployee()
        {
            try
            {
                EmployeeBLL EmployeeBLL = new EmployeeBLL();
                DataTable Empleados;
                Empleados = EmployeeBLL.All();
                comboBoxEmpleado.DisplayMember = "Text";
                comboBoxEmpleado.ValueMember = "Value";

                List<Object> items = new List<object>();
                items.Add(new { Text = "Todos", Value = "0" });
                foreach (DataRow Empleado in Empleados.Rows)
                {
                    items.Add(new { Text = string.Format("{0} {1}", Empleado[EmployeeML.DataBase.Name].ToString(), Empleado[EmployeeML.DataBase.Lastname].ToString()), Value = Empleado[EmployeeML.DataBase.Id].ToString() });
                }
                comboBoxEmpleado.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadEmployee: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewReporteGeneral_SizeChanged(object sender, EventArgs e)
        {
            //dataGridViewReporteGeneral.Width = this.Width - 50;
            //dataGridViewReporteGeneral.Height = this.Height - 170;
        }

        private void exportExcelControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
