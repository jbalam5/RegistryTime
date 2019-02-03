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
    public partial class cFMPU110010 : Form
    {
        public int IdJob = 0;
        JobBLL JobBLL = new JobBLL();

        public cFMPU110010()
        {
            InitializeComponent();
        }

        private void cFRT140010_Load(object sender, EventArgs e)
        {

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            textBoxPuesto.Text = String.Empty;
            textBoxDescripcion.Text = String.Empty;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBoxPuesto.Text))
                {
                    JobML Job = new JobML();
                    if (IdJob == 0)
                    {
                        Job.Name = textBoxPuesto.Text;
                        Job.Description = textBoxDescripcion.Text;
                    }
                    else
                    {
                        Job.Id = IdJob;
                        Job.Name = textBoxPuesto.Text;
                        Job.Description = textBoxDescripcion.Text;
                        Job.IdUserUpdate = 1;
                    }
                    JobBLL.Save(Job);

                    cFMPU100010 FrmDataGrid = this.Owner as cFMPU100010;
                    FrmDataGrid.LoadDataGridView();

                    MessageBox.Show("Guardado con Éxito");
                    Clear();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonGuardar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cFMDE110010_Resize(object sender, EventArgs e)
        {
            textBoxDescripcion.Width = this.Width - 150;
        }

        private void textBoxEncargado_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
