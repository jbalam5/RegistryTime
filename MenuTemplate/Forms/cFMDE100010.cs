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
                if (!String.IsNullOrEmpty(materialSingleLineTextFieldNombre.Text) && !String.IsNullOrEmpty(materialSingleLineTextFieldEncargado.Text))
                {
                    DepartamentML departament = new DepartamentML
                    {
                        Id = 0,
                        Name = materialSingleLineTextFieldNombre.Text,
                        Manage = materialSingleLineTextFieldEncargado.Text,
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
            materialSingleLineTextFieldNombre.Text = String.Empty;
            materialSingleLineTextFieldEncargado.Text = String.Empty;
            textBoxDescripcion.Text = String.Empty;
        }
    }
}
