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
    public partial class cFMEM120010 : Form
    {
        #region "Declaracion Variables"
        UsersBLL UsersBLL = new UsersBLL();
        public int IdRowSelect;
        #endregion

        public cFMEM120010()
        {
            InitializeComponent();
        }


        private void cFRT100010_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataGridView();
                dataGridViewDataUser.AutoResizeColumns();
                dataGridViewDataUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewDataUser.ClearSelection();
                AlterColorDataGridView(dataGridViewDataUser);

                exportExcelUsers.data = dataGridViewDataUser;
                exportExcelUsers.Title = "USUARIOS";
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("cFRT100010_Load: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cFRT100010_Resize(object sender, EventArgs e)
        {
            dataGridViewDataUser.Width = this.Width - 50;
            dataGridViewDataUser.Height = this.Height - 170;
        }

        public void AlterColorDataGridView(DataGridView Dgv)
        {
            Dgv.DefaultCellStyle.BackColor = Color.LightBlue;
            Dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        //private void buttonNuevo_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cFMEM110010 Catalogo = new cFMEM110010();
        //        AddOwnedForm(Catalogo);
        //        Catalogo.FormBorderStyle = FormBorderStyle.None;
        //        Catalogo.TopLevel = false;
        //        Catalogo.Dock = DockStyle.Fill;
        //        this.Controls.Add(Catalogo);
        //        this.Tag = Catalogo;
        //        Catalogo.BringToFront();
        //        Catalogo.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(String.Format("buttonNuevo_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void buttonEditar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (dataGridViewDataUser.RowCount > 0)
        //        {
        //            IdRowSelect = dataGridViewDataUser.CurrentRow.Index;
        //            if (IdRowSelect >= 0)
        //            {
        //                cFMEM110010 Catalogo = new cFMEM110010
        //                {
        //                    IdEmployee = Int32.Parse(dataGridViewDataUser.Rows[IdRowSelect].Cells["Id"].Value.ToString())
        //                };
        //                AddOwnedForm(Catalogo);
        //                Catalogo.FormBorderStyle = FormBorderStyle.None;
        //                Catalogo.TopLevel = false;
        //                Catalogo.Dock = DockStyle.Fill;
        //                this.Controls.Add(Catalogo);
        //                this.Tag = Catalogo;
        //                Catalogo.BringToFront();
        //                Catalogo.Show();
        //            }
        //            else
        //            {
        //                MessageBox.Show("No tiene Seleccionado un Empleado", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //        else
        //        {
        //            cFAT100010 Alert = new cFAT100010("Información", "No hay datos", MessageBoxIcon.Information);
        //            Alert.ShowDialog();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(String.Format("buttonEditar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public void LoadDataGridView()
        {
            dataGridViewDataUser.DataSource = UsersBLL.All();
        }

        //private void buttonEliminar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (dataGridViewDataUser.RowCount > 0)
        //        {
        //            IdRowSelect = dataGridViewDataUser.CurrentRow.Index;
        //            cFAT100010 Alert = new cFAT100010("INFORMACION", String.Format("¿Desea eliminar el registro {0}?", dataGridViewDataUser.Rows[IdRowSelect].Cells["Id"].Value.ToString()), MessageBoxIcon.Question);
        //            Alert.ShowDialog();
        //            if (Alert.DialogResult == DialogResult.Yes)
        //            {
        //                UsersML User = new UsersML
        //                {
        //                    Id = Int32.Parse(dataGridViewDataUser.Rows[IdRowSelect].Cells["Id"].Value.ToString()),
        //                };
        //                UsersBLL.Delete(User);
        //                dataGridViewDataUser.Rows.Remove(dataGridViewDataUser.CurrentRow);
        //            }
        //        }
        //        else
        //        {
        //            cFAT100010 Alert = new cFAT100010("Información", "No hay datos", MessageBoxIcon.Information);
        //            Alert.ShowDialog();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(String.Format("buttonEliminar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}
