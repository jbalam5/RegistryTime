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

        public bool FormValidate()
        {
            try
            {
                bool Valid = true;

                if (string.IsNullOrEmpty(textBoxClave.Text))
                {
                    Valid = false;
                    throw new Exception("Ingrese una clave para el concepto");
                }
                else if (string.IsNullOrEmpty(textBoxConcepto.Text))
                {
                    Valid = false;
                    throw new Exception("Ingrese un nombre para el concepto");
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
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormValidate())
                {
                    AbsenteeismML Absenteeism = new AbsenteeismML();
                    
                        Absenteeism.IsKey = textBoxClave.Text;
                        Absenteeism.Concept = textBoxConcepto.Text;
                        Absenteeism.description = textBoxDescripcion.Text;

                    if (IdAbsenteeism > 0)
                    {
                        Absenteeism.Id = IdAbsenteeism;
                    }

                    AbsenteeismBLL.Save(Absenteeism);

                    cFMCO100010 FrmDataGrid = this.Owner as cFMCO100010;
                    FrmDataGrid.LoadDataGridView();

                    cFAT100010 Alert = new cFAT100010("Información", "Información Guardado con éxito!!", MessageBoxIcon.Information);
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

