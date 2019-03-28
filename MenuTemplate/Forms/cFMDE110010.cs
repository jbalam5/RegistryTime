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
    public partial class cFMDE110010 : Form
    {
        public int IdDepartament = 0;
        DepartamentBLL DepartamentBLL = new DepartamentBLL();
        
        

        public cFMDE110010()
        {
            InitializeComponent();
        }

        private void cFRT140010_Load(object sender, EventArgs e)
        {
            if(IdDepartament > 0)
            {
                DepartamentML Departament = DepartamentBLL.GetIdEntity(IdDepartament);
                if(Departament == null)
                {
                    textBoxNombre.Text = Departament.Name.ToString();
                    textBoxEncargado.Text = Departament.Manager.ToString();
                    textBoxDescripcion.Text = Departament.Description.ToString();
                }
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            textBoxNombre.Text = String.Empty;
            textBoxEncargado.Text = String.Empty;
            textBoxDescripcion.Text = String.Empty;
        }

        public bool FormValidate()
        {
            try
            {
                bool Valid = true;

                if (string.IsNullOrEmpty(textBoxNombre.Text))
                {
                    Valid = false;
                    throw new Exception("Ingrese Nombre");
                }
                return Valid;
            }
            catch (Exception ex)
            {
                cFAT100010 alr = new Alerts.cFAT100010("EROR", string.Format("{0}", ex.Message), MessageBoxIcon.Error);
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
                    DepartamentML Departament = new DepartamentML();
                    Departament.Name = textBoxNombre.Text;
                    Departament.Manager = textBoxEncargado.Text;
                    Departament.Description = textBoxDescripcion.Text;

                    if (IdDepartament > 0)
                    {
                        Departament.Id = IdDepartament;
                    }
                    
                    DepartamentBLL.Save(Departament);

                    cFMDE100010 FrmDataGrid = this.Owner as cFMDE100010;
                    FrmDataGrid.LoadDataGridView();

                    cFAT100010 Alert = new cFAT100010("Información","Información Guardado con exito!!", MessageBoxIcon.Information);
                    Alert.ShowDialog();
                    
                    Clear();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonGuardar_Click: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
