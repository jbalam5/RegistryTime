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
    public partial class cFMCO100010 : Form
    {
        #region "Declaracion Variables"
        AbsenteeismBLL AbsenteeismBLL = new AbsenteeismBLL();
        public int IdRowSelect;
        #endregion
        public cFMCO100010()
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
                cFMCO110010 Catalogo = new cFMCO110010();
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
                IdRowSelect = dataGridViewData.CurrentRow.Index;
                if (IdRowSelect >= 0)
                {
                    cFMCO110010 Catalogo = new cFMCO110010();
                    Catalogo.IdAbsenteeism = Int32.Parse(dataGridViewData.Rows[IdRowSelect].Cells["Id"].Value.ToString());
                    Catalogo.textBoxClave.Text = dataGridViewData.Rows[IdRowSelect].Cells["Clave"].Value.ToString();
                    Catalogo.textBoxConcepto.Text = dataGridViewData.Rows[IdRowSelect].Cells["Concepto"].Value.ToString();
                    Catalogo.textBoxDescripcion.Text = dataGridViewData.Rows[IdRowSelect].Cells["Descripcion"].Value.ToString();
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
                    MessageBox.Show("No tiene Seleccionado un Concepto", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonEditar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDataGridView()
        {
            dataGridViewData.DataSource = AbsenteeismBLL.All();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                IdRowSelect = dataGridViewData.CurrentRow.Index;
                AbsenteeismML Absenteeism = new AbsenteeismML();
                Absenteeism.Id = Int32.Parse(dataGridViewData.Rows[IdRowSelect].Cells["Id"].Value.ToString());
                Absenteeism.IdUserDelete = 1;
                AbsenteeismBLL.Delete(Absenteeism);
                dataGridViewData.Rows.Remove(dataGridViewData.CurrentRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonEliminar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
