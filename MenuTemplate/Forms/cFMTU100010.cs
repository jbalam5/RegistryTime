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
    public partial class cFMTU100010 : Form
    {
        #region "Declaracion Variables"
        TurnBLL TurnBLL = new TurnBLL();
        public int IdRowSelect;
        #endregion
        public cFMTU100010()
        {
            InitializeComponent();
        }


        private void cFRT100010_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataGridView();
                dataGridViewData.AutoResizeColumns();
                dataGridViewData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewData.ClearSelection();
                AlterColorDataGridView(dataGridViewData);

                exportExcelControl1.data = dataGridViewData;
                exportExcelControl1.Title = "Turno";
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("cFRT100010_Load: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cFRT100010_Resize(object sender, EventArgs e)
        {
            dataGridViewData.Width = this.Width - 50;
            dataGridViewData.Height = this.Height - 170;
        }

        public void AlterColorDataGridView(DataGridView Dgv)
        {
            Dgv.DefaultCellStyle.BackColor = Color.LightBlue;
            Dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                cFMTU110010 Catalogo = new cFMTU110010();
                AddOwnedForm(Catalogo);
                Catalogo.FormBorderStyle = FormBorderStyle.None;
                Catalogo.TopLevel = false;
                Catalogo.Dock = DockStyle.Fill;
                this.Controls.Add(Catalogo);
                this.Tag = Catalogo;
                Catalogo.BringToFront();
                Catalogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonNuevo_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewData.RowCount > 0)
                {
                    IdRowSelect = dataGridViewData.CurrentRow.Index;
                    if (IdRowSelect >= 0)
                    {
                        cFMTU110010 Catalogo = new cFMTU110010()
                        {
                            IdTurn = Int32.Parse(dataGridViewData.Rows[IdRowSelect].Cells[TurnML.DataBase.Id].Value.ToString())
                        };

                        AddOwnedForm(Catalogo);
                        Catalogo.FormBorderStyle = FormBorderStyle.None;
                        Catalogo.TopLevel = false;
                        Catalogo.Dock = DockStyle.Fill;
                        this.Controls.Add(Catalogo);
                        this.Tag = Catalogo;
                        Catalogo.BringToFront();
                        Catalogo.Show();
                    }
                    else
                    {
                        cFAT100010 Alert = new cFAT100010("Información", "No tiene Seleccionado un Turno", MessageBoxIcon.Information);
                        Alert.ShowDialog();
                    }
                }
                else
                {
                    cFAT100010 Alert = new cFAT100010("Información", "No hay datos", MessageBoxIcon.Information);
                    Alert.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonEditar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDataGridView()
        {
            dataGridViewData.DataSource = TurnBLL.All();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewData.RowCount > 0)
                {
                    int IdTurno = Int32.Parse(dataGridViewData.Rows[IdRowSelect].Cells["Id"].Value.ToString());
                    cFAT100010 Alert = new cFAT100010("Información",String.Format("¿Desea eliminar el registro {0}?",IdTurno), MessageBoxIcon.Question);
                    Alert.ShowDialog();
                    if (Alert.DialogResult == DialogResult.Yes)
                    {
                        IdRowSelect = dataGridViewData.CurrentRow.Index;
                            TurnML Turn = new TurnML()
                            {
                                Id = IdTurno
                            };
                        TurnBLL.Delete(Turn);
                        dataGridViewData.Rows.Remove(dataGridViewData.CurrentRow);
                    }
                    
                }
                else
                {
                    cFAT100010 Alert = new cFAT100010("Información", "No hay datos", MessageBoxIcon.Information);
                    Alert.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonEliminar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ContainerPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
