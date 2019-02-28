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


namespace RegistryTime.Help
{
    public partial class cFHAA100010 : Form
    {
        #region "Declaracion Variables"
        EmployeeBLL EmployeeBLL = new EmployeeBLL();
        public int IdRowSelect;
        #endregion

        public cFHAA100010()
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

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (dataGridViewDataEmpleado.RowCount > 0)
                {
                    IdRowSelect = dataGridViewDataEmpleado.CurrentRow.Index;
                    if (IdRowSelect >= 0)
                    {
                        Forms.cFMAA110010 Catalogo = new Forms.cFMAA110010();
                        Catalogo.IdAbsenteeismAssignment = Int32.Parse(dataGridViewDataEmpleado.Rows[IdRowSelect].Cells["Id"].Value.ToString());
                        Catalogo.textBoxNumControl.Text = dataGridViewDataEmpleado.Rows[IdRowSelect].Cells["NoControl"].Value.ToString();
                        Catalogo.textBoxNombre.Text = dataGridViewDataEmpleado.Rows[IdRowSelect].Cells["name"].Value.ToString();
                        Catalogo.textBoxApellidoP.Text = dataGridViewDataEmpleado.Rows[IdRowSelect].Cells["lastname"].Value.ToString();
                        Catalogo.textBoxApellidoM.Text = dataGridViewDataEmpleado.Rows[IdRowSelect].Cells["lastname"].Value.ToString();
                        Catalogo.textBoxDepartamento.Text = dataGridViewDataEmpleado.Rows[IdRowSelect].Cells["idDepartament"].Value.ToString();
                        Catalogo.textBoxPuesto.Text = dataGridViewDataEmpleado.Rows[IdRowSelect].Cells["idJob"].Value.ToString();
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
                        cFAT100010 Alert = new cFAT100010("Información", "No tiene Seleccionado un Empleado", MessageBoxIcon.Information);
                        Alert.ShowDialog();
                    }
                }
                else
                {
                    cFAT100010 Alert = new cFAT100010("Información", "No hay datos registrados", MessageBoxIcon.Information);
                    Alert.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonSeleccionar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDataGridView()
        {
            dataGridViewDataEmpleado.DataSource = EmployeeBLL.All();
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            this.Close();
=======
            try
            {
                
                IdRowSelect = dataGridViewData.CurrentRow.Index;
                DepartamentML Departament = new DepartamentML();
                Departament.Id = Int32.Parse(dataGridViewData.Rows[IdRowSelect].Cells["Id"].Value.ToString());
                DepartamentBLL.Delete(Departament);
                dataGridViewData.Rows.Remove(dataGridViewData.CurrentRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonEliminar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
>>>>>>> c90f21b194ef8bf6e3ae5a12bf9d940c86489d99
        }
    }
}
