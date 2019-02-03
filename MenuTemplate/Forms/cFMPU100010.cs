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
    public partial class cFMPU100010 : Form
    {
        #region "Declaracion Variables"
        JobBLL JobBLL = new JobBLL();
        public int IdRowSelect;
        #endregion
        public cFMPU100010()
        {
            InitializeComponent();
        }


        private void cFRT100010_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataGridView();
                dataGridViewDataPuesto.AutoResizeColumns();
                dataGridViewDataPuesto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewDataPuesto.ClearSelection();
                AlterColorDataGridView(dataGridViewDataPuesto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("cFRT100010_Load: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cFRT100010_Resize(object sender, EventArgs e)
        {
            dataGridViewDataPuesto.Width = this.Width - 50;
            dataGridViewDataPuesto.Height = this.Height - 170;
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
                cFMPU110010 Catalogo = new cFMPU110010();
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
                IdRowSelect = dataGridViewDataPuesto.CurrentRow.Index;
                if (IdRowSelect >= 0)
                {
                    cFMPU110010 Catalogo = new cFMPU110010();
                    Catalogo.IdJob= Int32.Parse(dataGridViewDataPuesto.Rows[IdRowSelect].Cells["Id"].Value.ToString());
                    Catalogo.textBoxPuesto.Text = dataGridViewDataPuesto.Rows[IdRowSelect].Cells["Puesto"].Value.ToString();
                    Catalogo.textBoxDescripcion.Text = dataGridViewDataPuesto.Rows[IdRowSelect].Cells["Descripcion"].Value.ToString();
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
                    MessageBox.Show("No tiene Seleccionado un Puesto de Trabajo", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonEditar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDataGridView()
        {
            dataGridViewDataPuesto.DataSource = JobBLL.All();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                IdRowSelect = dataGridViewDataPuesto.CurrentRow.Index;
                JobML Job = new JobML();
                Job.Id = Int32.Parse(dataGridViewDataPuesto.Rows[IdRowSelect].Cells["Id"].Value.ToString());
                Job.IdUserDelete = 1;
                JobBLL.Delete(Job);
                dataGridViewDataPuesto.Rows.Remove(dataGridViewDataPuesto.CurrentRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonEliminar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
