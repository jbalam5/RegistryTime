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
    public partial class cFMDE100010 : Form
    {
        #region "Declaracion Variables"
        DepartamentBLL DepartamentBLL = new DepartamentBLL();
        public int IdRowSelect;
        #endregion
        public cFMDE100010()
        {
            InitializeComponent();
        }


        private void cFRT100010_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataGridView();
                dataGridViewDepartamento.AutoResizeColumns();
                dataGridViewDepartamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewDepartamento.ClearSelection();
                AlterColorDataGridView(dataGridViewDepartamento);

                exportExcelControl1.data = dataGridViewDepartamento;
                exportExcelControl1.Title = "Departamentos";
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("cFRT100010_Load: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cFRT100010_Resize(object sender, EventArgs e)
        {
            dataGridViewDepartamento.Width = this.Width - 50;
            dataGridViewDepartamento.Height = this.Height - 170;
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
                cFMDE110010 Catalogo = new cFMDE110010();
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
                if (dataGridViewDepartamento.RowCount > 0)
                {
                    IdRowSelect = dataGridViewDepartamento.CurrentRow.Index;
                    if (IdRowSelect >= 0)
                    {
                        cFMDE110010 Catalogo = new cFMDE110010();
                        Catalogo.IdDepartament = Int32.Parse(dataGridViewDepartamento.Rows[IdRowSelect].Cells["Id"].Value.ToString());
                        Catalogo.textBoxNombre.Text = dataGridViewDepartamento.Rows[IdRowSelect].Cells["Nombre"].Value.ToString();
                        Catalogo.textBoxEncargado.Text = dataGridViewDepartamento.Rows[IdRowSelect].Cells["Encargado"].Value.ToString();
                        Catalogo.textBoxDescripcion.Text = dataGridViewDepartamento.Rows[IdRowSelect].Cells["Descripcion"].Value.ToString();
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
                        cFAT100010 Alert = new cFAT100010("Información", "No tiene Seleccionado un Departamento", MessageBoxIcon.Information);
                        Alert.ShowDialog();
                    }
                }
                else
                {
                    cFAT100010 Alert = new cFAT100010("Información", "No hay datos", MessageBoxIcon.Information);
                    Alert.ShowDialog();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(String.Format("buttonEditar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDataGridView()
        {
            dataGridViewDepartamento.DataSource = DepartamentBLL.All();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDepartamento.RowCount > 0)
                { 
                    IdRowSelect = dataGridViewDepartamento.CurrentRow.Index;
                    int idDepartament = Int32.Parse(dataGridViewDepartamento.Rows[IdRowSelect].Cells["Id"].Value.ToString());
                    cFAT100010 Alert = new cFAT100010("Información", String.Format("¿Desea eliminar el registro {0}?", idDepartament), MessageBoxIcon.Question);
                    Alert.ShowDialog();
                    if (Alert.DialogResult == DialogResult.Yes)
                    {
                        DepartamentML Departament = new DepartamentML
                        {
                            Id = idDepartament,
                        };
                        DepartamentBLL.Delete(Departament);
                        dataGridViewDepartamento.Rows.Remove(dataGridViewDepartamento.CurrentRow);
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

        private void exportExcelControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
