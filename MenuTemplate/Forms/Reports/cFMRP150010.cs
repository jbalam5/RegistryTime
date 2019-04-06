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
    public partial class cFMRP150010 : Form
    {
        DataTable TMPTABLE;
        #region "EVENTS"
        public cFMRP150010()
        {
            InitializeComponent();
            LoadTurn();
            LoadDepartament();
            LoadEmployee();

        }

        private void cFMRP100010_Load(object sender, EventArgs e)
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
                dataGridViewReporteGeneral.ReadOnly = true;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("cFMRP100010_Load: {0}", ex.Message), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                ChildLeftPanel.Visible = false;
                
                QueryBackgroundWorker.RunWorkerAsync();
                dataGridViewReporteGeneral.DataSource = TMPTABLE;

            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("{0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QueryBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
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

                this.Invoke(new Action(() => LoadDataTable() ));
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("{0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDataTable()
        {
            ReportsBLL ReportsBLL = new ReportsBLL();
            TMPTABLE = ReportsBLL.DateReportsStartEntry(dateTimeFechaInicio.Value, dateTimeFechaFin.Value, (Convert.ToInt32(comboBoxTurno.SelectedValue.ToString()) == 0) ? "" : comboBoxTurno.Text.ToString(), (Convert.ToInt32(comboBoxDepartamento.SelectedValue.ToString()) == 0) ? "" : comboBoxDepartamento.Text.ToString());
            dataGridViewReporteGeneral.DataSource = TMPTABLE;

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
        public void LoadTurn()
        {
            try
            {
                TurnBLL TurnBLL = new TurnBLL();
                DataTable Turnos;
                Turnos = TurnBLL.All();
                comboBoxTurno.DisplayMember = "Text";
                comboBoxTurno.ValueMember = "Value";

                List<Object> items = new List<object>();
                items.Add(new { Text = "Todos", Value = "0" });
                foreach (DataRow Turno in Turnos.Rows)
                {
                    items.Add(new { Text = Turno[1].ToString(), Value = Turno[0].ToString() });
                }
                comboBoxTurno.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadTurn: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDepartament()
        {
            try
            {
                DepartamentBLL DepartamentBLL = new DepartamentBLL();
                DataTable Departamentos;
                Departamentos = DepartamentBLL.All();
                comboBoxDepartamento.DisplayMember = "Text";
                comboBoxDepartamento.ValueMember = "Value";

                List<Object> items = new List<object>();
                items.Add(new { Text = "Todos", Value = "0" });
                foreach (DataRow Departamento in Departamentos.Rows)
                {
                    items.Add(new { Text = Departamento[1].ToString(), Value = Departamento[0].ToString() });
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

        private void comboBoxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TMPTABLE != null)
                FilterGrid();
        }

        public void FilterGrid()
        {
            try
            {
                String Departamento = comboBoxDepartamento.Text;
                String Employee = comboBoxEmpleado.Text;
                //String Turno = comboBoxTurno.Text;
                if (Departamento == "Todos" && Employee == "Todos")
                {
                    dataGridViewReporteGeneral.DataSource = TMPTABLE;
                }
                else
                {
                                    
                    StringBuilder Query = new StringBuilder();
                    if (Departamento != "Todos")
                        Query.AppendFormat("Departamento = '{0}' ", Departamento.ToString());
                    else
                        Query.AppendLine("1 = 1 ");

                     Query.AppendLine(" AND ");

                    if (Employee != "Todos")
                        Query.AppendFormat("nombre = '{0}' ", Employee.ToString());
                    else
                        Query.AppendLine("1 = 1 ");
                    if (TMPTABLE.Select(Query.ToString()).Length > 0)
                        dataGridViewReporteGeneral.DataSource = (DataTable)TMPTABLE.Select(Query.ToString()).CopyToDataTable();
                    else
                        dataGridViewReporteGeneral.DataSource = null;
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(String.Format("{0}",ex.Message),"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Verifica tus Filtros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TMPTABLE != null)
                FilterGrid();
        }
    }
}
