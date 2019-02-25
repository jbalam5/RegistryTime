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
    public partial class cFMAA110010 : Form
    {
        public int IdDepartament = 0;
        AbsenteeismBLL AbsenteeismBLL = new AbsenteeismBLL();

        public cFMAA110010()
        {
            InitializeComponent();
        }

        private void cFRT140010_Load(object sender, EventArgs e)
        {
            LoadAbsenteissm();
            LoadStatus();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            textBoxNumControl.Text = String.Empty;
            textBoxNombre.Text = String.Empty;
            textBoxApePaterno.Text = String.Empty;
            textBoxDepartamento.Text = String.Empty;
            textBoxPuesto.Text = String.Empty;

            comboBoxAusentismo.Text = String.Empty;
            comboBoxEstadoAsig.Text = String.Empty;
            textBoxDescripcion.Text = String.Empty;
            dateTimeFechaInicio.Text = String.Empty;
            dateTimeFechaFin.Text = String.Empty;      
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!String.IsNullOrEmpty(textBoxNombre.Text) && !String.IsNullOrEmpty(textBoxEncargado.Text))
                //{
                //    DepartamentML Departament = new DepartamentML();
                //    if (IdDepartament == 0)
                //    {
                //        Departament.Name = textBoxNombre.Text;
                //        Departament.Manager = textBoxEncargado.Text;
                //        Departament.Description = textBoxDescripcion.Text;
                //    }
                //    else
                //    {
                //        Departament.Id = IdDepartament;
                //        Departament.Name = textBoxNombre.Text;
                //        Departament.Manager = textBoxEncargado.Text;
                //        Departament.Description = textBoxDescripcion.Text;
                //        Departament.IdUserUpdate = 1;
                //    }
                //    DepartamentBLL.Save(Departament);

                //    cFMDE100010 FrmDataGrid = this.Owner as cFMDE100010;
                //    FrmDataGrid.LoadDataGridView();

                //    MessageBox.Show("Guardado con Exito");
                //    Clear();
                //    this.Close();
                //}
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

        private void cFMAA110010_Resize(object sender, EventArgs e)
        {
            textBoxPuesto.Width = this.Width - 150;
            textBoxDescripcion.Width = this.Width - 150;
            textBoxDescripcion.Width = this.Width - 150;
        }

        private void textBoxNumControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Hola");
            }
        }

        public void LoadAbsenteissm()
        {
            try
            {
                AbsenteeismBLL AbsenteeismBLL = new AbsenteeismBLL();
                DataTable Conceptos;
                Conceptos = AbsenteeismBLL.All();
                comboBoxAusentismo.DisplayMember = "Text";
                comboBoxAusentismo.ValueMember = "Value";

                List<Object> items = new List<object>();
                items.Add(new { Text = "Seleccione una opción", Value = "0" });
                foreach (DataRow Concepto in Conceptos.Rows)
                {
                    items.Add(new { Text = Concepto[1].ToString(), Value = Concepto[0].ToString() });
                }
                comboBoxAusentismo.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadAbsenteissm: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadStatus()
        {
            try
            {

                comboBoxEstadoAsig.DisplayMember = "Text";
                comboBoxEstadoAsig.ValueMember = "Value";

                var items = new[] {
                    new { Text = "Seleccione una opción", Value = "" },
                    new { Text = "Aceptada", Value = "aceptada" },
                    new { Text = "Rechazada", Value = "rechazada" }
                };

                comboBoxEstadoAsig.DataSource = items;

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadStatus: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
