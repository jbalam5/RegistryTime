using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelLayer;
using BussinesLayer;

namespace MenuTemplate.Forms
{
    public partial class cFMDE100010 : Form
    {
        public DepartamentBLL DepartamentBLL = new DepartamentBLL();
        public cFMDE100010()
        {
            InitializeComponent();
        }

        private void cFMDE100010_Load(object sender, EventArgs e)
        {
            dataGridViewDepartamentos.DataSource = DepartamentBLL.All();
            dataGridViewDepartamentos.AutoResizeRows();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBoxNombre.Text) && !String.IsNullOrEmpty(textBoxEncargado.Text))
                {
                    DepartamentML departament = new DepartamentML
                    {
                        Id = 0,
                        Name = textBoxNombre.Text,
                        Manage = textBoxEncargado.Text,
                        Description = textBoxDescripcion.Text,
                        IdUserInsert = 1
                    };
                    DepartamentBLL.Save(departament);
                    MessageBox.Show("Guardado con Exito");
                    Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("ButtonSave_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public void Clear()
        {
            textBoxNombre.Text = String.Empty;
            textBoxEncargado.Text = String.Empty;
            textBoxDescripcion.Text = String.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DataTable data = dataGridViewDepartamentos.SelectedColumns.;
        }
    }
}
