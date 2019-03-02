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
using RegistryTime.Forms;


namespace RegistryTime.Help
{
    public partial class cFHAA100010 : Form
    {
        #region "Declaracion Variables"
        EmployeeBLL EmployeeBLL = new EmployeeBLL();
        public int IdRowSelect;
        #endregion

        public cFHAA100010()
        {
            InitializeComponent();
        }


        private void cFRT100010_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataGridView();
                dataGridViewDataEmpleado.AutoResizeColumns();
                dataGridViewDataEmpleado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewDataEmpleado.ClearSelection();
                AlterColorDataGridView(dataGridViewDataEmpleado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("cFRT100010_Load: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cFRT100010_Resize(object sender, EventArgs e)
        {
            dataGridViewDataEmpleado.Width = this.Width - 50;
            dataGridViewDataEmpleado.Height = this.Height - 170;
        }

        public void AlterColorDataGridView(DataGridView Dgv)
        {
            Dgv.DefaultCellStyle.BackColor = Color.LightBlue;
            Dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (dataGridViewDataEmpleado.RowCount > 0)
                {
                    IdRowSelect = dataGridViewDataEmpleado.CurrentRow.Index;
                    if (IdRowSelect >= 0)
                    {
                        
                        cFMAA110010 Catalogo = this.Owner as cFMAA110010;
                        Catalogo.idObject = Int32.Parse(dataGridViewDataEmpleado.Rows[IdRowSelect].Cells["Id"].Value.ToString());
                        Catalogo.LoadObject();
                        this.Close();
                    }
                    else
                    {
                        cFAT100010 Alert = new cFAT100010("Información", "No tiene Seleccionado un Empleado", MessageBoxIcon.Information);
                        Alert.ShowDialog();
                    }
                }
                else
                {
                    cFAT100010 Alert = new cFAT100010("Información", "No hay datos registrados", MessageBoxIcon.Information);
                    Alert.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonSeleccionar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDataGridView()
        {
            dataGridViewDataEmpleado.DataSource = EmployeeBLL.All();
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
