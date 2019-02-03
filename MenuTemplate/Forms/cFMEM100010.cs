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


namespace RegistryTime.Forms
{
    public partial class cFMEM100010 : Form
    {
        #region "Declaracion Variables"
        DepartamentBLL DepartamentBLL = new DepartamentBLL();
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
                IdRowSelect = dataGridViewDataEmpleado.CurrentRow.Index;
                if (IdRowSelect >= 0)
                {
                    cFMDE110010 Catalogo = new cFMDE110010();
                    Catalogo.IdDepartament = Int32.Parse(dataGridViewDataEmpleado.Rows[IdRowSelect].Cells["Id"].Value.ToString());
                    Catalogo.textBoxNombre.Text = dataGridViewDataEmpleado.Rows[IdRowSelect].Cells["Nombre"].Value.ToString();
                    Catalogo.textBoxEncargado.Text = dataGridViewDataEmpleado.Rows[IdRowSelect].Cells["Encargado"].Value.ToString();
                    Catalogo.textBoxDescripcion.Text = dataGridViewDataEmpleado.Rows[IdRowSelect].Cells["Descripcion"].Value.ToString();
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
                    MessageBox.Show("No tiene Seleccionado un Departamento", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonEditar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDataGridView()
        {
            dataGridViewDataEmpleado.DataSource = DepartamentBLL.All();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                IdRowSelect = dataGridViewDataEmpleado.CurrentRow.Index;
                DepartamentML Departament = new DepartamentML();
                Departament.Id = Int32.Parse(dataGridViewDataEmpleado.Rows[IdRowSelect].Cells["Id"].Value.ToString());
                Departament.IdUserDelete = 1;
                DepartamentBLL.Delete(Departament);
                dataGridViewDataEmpleado.Rows.Remove(dataGridViewDataEmpleado.CurrentRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonEliminar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewDataEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
