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

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBoxNombre.Text) && !String.IsNullOrEmpty(textBoxEncargado.Text))
                {
                    DepartamentML Departament = new DepartamentML();
                    Departament.Name = textBoxNombre.Text;
                    Departament.Manager = textBoxEncargado.Text;
                    Departament.Description = textBoxDescripcion.Text;

                    if (IdDepartament > 0)
                    {
                        Departament.Id = IdDepartament;
                        Departament.IdUserUpdate = 1;
                    }
                    
                    DepartamentBLL.Save(Departament);

                    cFMDE100010 FrmDataGrid = this.Owner as cFMDE100010;
                    FrmDataGrid.LoadDataGridView();

                    MessageBox.Show("Guardado con Exito");
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
