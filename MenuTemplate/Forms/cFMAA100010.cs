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
    public partial class cFMAA100010 : Form
    {
        #region "Declaracion Variables"
        AbsenteeismAssignmentBLL AbsenteeismAssignmentBLL = new AbsenteeismAssignmentBLL();
        public int IdRowSelect;
        #endregion

        public cFMAA100010()
        {
            InitializeComponent();
        }


        private void cFRT100010_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataGridView();
                dataGridViewData.AutoResizeColumns();
                dataGridViewData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewData.ClearSelection();
                AlterColorDataGridView(dataGridViewData);

                exportExcelControl1.data = dataGridViewData;
                exportExcelControl1.Title = "Empleado";
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("cFRT100010_Load: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cFRT100010_Resize(object sender, EventArgs e)
        {
            dataGridViewData.Width = this.Width - 50;
            dataGridViewData.Height = this.Height - 170;
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
                cFMAA110010 Catalogo = new cFMAA110010();
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
                if (dataGridViewData.RowCount > 0)
                {
                    IdRowSelect = dataGridViewData.CurrentRow.Index;
                    if (IdRowSelect >= 0)
                    {
                        cFMAA110010 Catalogo = new cFMAA110010//();
                        {
                            IdAbsenteeismAssignment = Int32.Parse(dataGridViewData.Rows[IdRowSelect].Cells["Id"].Value.ToString())
                        };
                        //Catalogo.IdAbsenteeismAssignment = Int32.Parse(dataGridViewData.Rows[IdRowSelect].Cells["Id"].Value.ToString());
                        Catalogo.textBoxNumControl.Text = dataGridViewData.Rows[IdRowSelect].Cells["Id"].Value.ToString();
                        Catalogo.comboBoxAusentismo.Text = dataGridViewData.Rows[IdRowSelect].Cells["ClaveAusentismo"].Value.ToString();
                        Catalogo.comboBoxEstadoAsig.Text = dataGridViewData.Rows[IdRowSelect].Cells["Estado"].Value.ToString();
                        Catalogo.textBoxDescripcion.Text = dataGridViewData.Rows[IdRowSelect].Cells["Descripcion"].Value.ToString();
                        Catalogo.dateTimeFechaInicio.Text = dataGridViewData.Rows[IdRowSelect].Cells["FechaInicio"].Value.ToString();
                        Catalogo.dateTimeFechaFin.Text = dataGridViewData.Rows[IdRowSelect].Cells["FechaFinal"].Value.ToString();
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
                        MessageBox.Show("No tiene Seleccionado un Registro", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dataGridViewData.DataSource = AbsenteeismAssignmentBLL.All();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewData.RowCount > 0)
                {
                    IdRowSelect = dataGridViewData.CurrentRow.Index;
                    cFAT100010 Alert = new cFAT100010("INFORMACION", String.Format("¿Desea eliminar el registro {0}?", dataGridViewData.Rows[IdRowSelect].Cells["Id"].Value.ToString()), MessageBoxIcon.Question);
                    Alert.ShowDialog();
                    if (Alert.DialogResult == DialogResult.Yes)
                    {
                        AbsenteeismAssignmentML AbsenteeismAssignment = new AbsenteeismAssignmentML
                        {
                            Id = Int32.Parse(dataGridViewData.Rows[IdRowSelect].Cells["Id"].Value.ToString()),
                        };
                        AbsenteeismAssignmentBLL.Delete(AbsenteeismAssignment);
                        dataGridViewData.Rows.Remove(dataGridViewData.CurrentRow);
                    }
                }
                else
                {
                    cFAT100010 Alert = new cFAT100010("Información", "No hay datos", MessageBoxIcon.Information);
                    Alert.ShowDialog();
                }
                //IdRowSelect = dataGridViewData.CurrentRow.Index;
                //AbsenteeismAssignmentML Catalogo = new AbsenteeismAssignmentML();
                //Catalogo.Id = Int32.Parse(dataGridViewData.Rows[IdRowSelect].Cells["Id"].Value.ToString());
                //Catalogo.IdUserDelete = 1;
                //AbsenteeismAssignmentBLL.Delete(Catalogo);
                //dataGridViewData.Rows.Remove(dataGridViewData.CurrentRow);

                //cFAT100010 Alert = new cFAT100010("INFORMACION", String.Format("¿Desea eliminar el registro {0}?", dataGridViewData.Rows[IdRowSelect].Cells["Id"].Value.ToString()), MessageBoxIcon.Question);
                //Alert.ShowDialog();
                //if (Alert.DialogResult == DialogResult.Yes)
                //{
                //    AbsenteeismAssignmentML AbsenteeismAssignment = new AbsenteeismAssignmentML
                //    {
                //        Id = Int32.Parse(dataGridViewData.Rows[IdRowSelect].Cells["Id"].Value.ToString()),
                //        IdUserDelete = 1
                //    };
                //    AbsenteeismAssignmentBLL.Delete(AbsenteeismAssignment);
                //    dataGridViewData.Rows.Remove(dataGridViewData.CurrentRow);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonEliminar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
