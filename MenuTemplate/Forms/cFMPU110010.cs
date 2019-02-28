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

        public bool FormValidate()
        {
            try
            {
                bool Valid = true;

                if (string.IsNullOrEmpty(textBoxPuesto.Text))
                {
                    Valid = false;
                    throw new Exception("Ingrese Nombre");
                }
                
                return Valid;
            }
            catch (Exception ex)
            {
                cFAT100010 alr = new Alerts.cFAT100010("ERROR", string.Format("{0}", ex.Message), MessageBoxIcon.Error);
                alr.ShowDialog();
                return false;
            }

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
                if (FormValidate())
                {
                    JobML Job = new JobML();
                    
                    Job.Name = textBoxPuesto.Text;
                    Job.Description = textBoxDescripcion.Text;

                    if (IdJob > 0)
                    {
                        Job.Id = IdJob;
                    }

                    JobBLL.Save(Job);

                    cFMPU100010 FrmDataGrid = this.Owner as cFMPU100010;
                    FrmDataGrid.LoadDataGridView();

                    cFAT100010 Alert = new cFAT100010("Información", "Información Guardado con exito!!", MessageBoxIcon.Information);
                    Alert.ShowDialog();

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
    }
}
