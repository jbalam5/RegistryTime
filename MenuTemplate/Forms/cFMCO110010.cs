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
    public partial class cFMCO110010 : Form
    {
        public int IdAbsenteeism = 0;
        AbsenteeismBLL AbsenteeismBLL = new AbsenteeismBLL();

        public cFMCO110010()
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
            textBoxClave.Text = String.Empty;
            textBoxConcepto.Text = String.Empty;
            textBoxDescripcion.Text = String.Empty;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBoxClave.Text))
                {
                    AbsenteeismML Absenteeism = new AbsenteeismML();
                    if (IdAbsenteeism == 0)
                    {
                        Absenteeism.IsKey = textBoxClave.Text;
                        Absenteeism.Concept = textBoxConcepto.Text;
                        Absenteeism.description = textBoxDescripcion.Text;
                    }
                    else
                    {
                        Absenteeism.Id = IdAbsenteeism;
                        Absenteeism.IsKey = textBoxClave.Text;
                        Absenteeism.Concept = textBoxConcepto.Text;
                        Absenteeism.description = textBoxDescripcion.Text;
                        Absenteeism.IdUserUpdate = 1;
                    }
                    AbsenteeismBLL.Save(Absenteeism);

                    cFMCO100010 FrmDataGrid = this.Owner as cFMCO100010;
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

        private void textBoxConcepto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
