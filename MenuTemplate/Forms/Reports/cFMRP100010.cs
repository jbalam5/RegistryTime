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

namespace RegistryTime.Forms.Reports
{
    public partial class cFMRP100010 : Form
    {
        public cFMRP100010()
        {
            InitializeComponent();
            LoadTurn();
            LoadDepartament();
            LoadEmployee();

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


        }

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
                    items.Add(new { Text = Empleado[2].ToString(), Value = Empleado[0].ToString() });
                }
                comboBoxEmpleado.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadEmployee: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
