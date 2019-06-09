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
using Alerts;


namespace RegistryTime.Forms
{
    public partial class cFMEM100010 : Form
    {
        #region "Declaracion Variables"
        EmployeeBLL EmployeeBLL = new EmployeeBLL();
        public int IdRowSelect;
        #endregion

        public cFMEM100010()
        {
            InitializeComponent();
        }


        private void cFRT100010_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataGridView();
                dataGridViewDataEmpleado.AutoResizeColumns();
                dataGridViewDataEmpleado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewDataEmpleado.ClearSelection();
                AlterColorDataGridView(dataGridViewDataEmpleado);

                exportExcelControl1.data = dataGridViewDataEmpleado;
                exportExcelControl1.Title = "EMPLEADOS";
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("cFRT100010_Load: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cFRT100010_Resize(object sender, EventArgs e)
        {
            dataGridViewDataEmpleado.Width = this.Width - 50;
            dataGridViewDataEmpleado.Height = this.Height - 170;
        }

        public void AlterColorDataGridView(DataGridView Dgv)
        {
            Dgv.DefaultCellStyle.BackColor = Color.LightBlue;
            Dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                cFMEM110010 Catalogo = new cFMEM110010();
                AddOwnedForm(Catalogo);
                Catalogo.FormBorderStyle = FormBorderStyle.None;
                Catalogo.TopLevel = false;
                Catalogo.Dock = DockStyle.Fill;
                this.Controls.Add(Catalogo);
                this.Tag = Catalogo;
                Catalogo.BringToFront();
                Catalogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonNuevo_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDataEmpleado.RowCount > 0)
                {
                    IdRowSelect = dataGridViewDataEmpleado.CurrentRow.Index;
                    if (IdRowSelect >= 0)
                    {
                        cFMEM110010 Catalogo = new cFMEM110010
                        {
                            IdEmployee = Int32.Parse(dataGridViewDataEmpleado.Rows[IdRowSelect].Cells["Id"].Value.ToString())
                        };
                        AddOwnedForm(Catalogo);
                        Catalogo.FormBorderStyle = FormBorderStyle.None;
                        Catalogo.TopLevel = false;
                        Catalogo.Dock = DockStyle.Fill;
                        this.Controls.Add(Catalogo);
                        this.Tag = Catalogo;
                        Catalogo.BringToFront();
                        Catalogo.Show();
                    }
                    else
                    {
                        MessageBox.Show("No tiene Seleccionado un Empleado", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    cFAT100010 Alert = new cFAT100010("Información", "No hay datos", MessageBoxIcon.Information);
                    Alert.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonEditar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDataGridView()
        {
            dataGridViewDataEmpleado.DataSource = EmployeeBLL.All();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDataEmpleado.RowCount > 0)
                {
                    IdRowSelect = dataGridViewDataEmpleado.CurrentRow.Index;
                    cFAT100010 Alert = new cFAT100010("INFORMACION", String.Format("¿Desea eliminar el registro {0}?", dataGridViewDataEmpleado.Rows[IdRowSelect].Cells["Id"].Value.ToString()), MessageBoxIcon.Question);
                    Alert.ShowDialog();
                    if (Alert.DialogResult == DialogResult.Yes)
                    {
                        EmployeeML Employee = new EmployeeML
                        {
                            Id = Int32.Parse(dataGridViewDataEmpleado.Rows[IdRowSelect].Cells["Id"].Value.ToString()),
                        };
                        EmployeeBLL.Delete(Employee);
                        dataGridViewDataEmpleado.Rows.Remove(dataGridViewDataEmpleado.CurrentRow);
                    }
                }
                else
                {
                    cFAT100010 Alert = new cFAT100010("Información", "No hay datos", MessageBoxIcon.Information);
                    Alert.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonEliminar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDataEmpleado.RowCount > 0)
                {

                    cFMEM120010 Catalogo = new cFMEM120010();
                    AddOwnedForm(Catalogo);
                    Catalogo.FormBorderStyle = FormBorderStyle.None;
                    Catalogo.TopLevel = false;
                    Catalogo.Dock = DockStyle.Fill;
                    this.Controls.Add(Catalogo);
                    this.Tag = Catalogo;
                    Catalogo.BringToFront();
                    Catalogo.Show();

                }
                else
                {
                    cFAT100010 Alert = new cFAT100010("Información", "No hay datos", MessageBoxIcon.Information);
                    Alert.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonUser_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
