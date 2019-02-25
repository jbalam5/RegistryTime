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
                        cFMTU110010 Catalogo = new cFMTU110010();
                        Catalogo.IdTurn = Int32.Parse(dataGridViewData.Rows[IdRowSelect].Cells["Id"].Value.ToString());
                        Catalogo.textBoxTurno.Text = dataGridViewData.Rows[IdRowSelect].Cells["Turno"].Value.ToString();
                        Catalogo.textBoxDescripcion.Text = dataGridViewData.Rows[IdRowSelect].Cells["Descripcion"].Value.ToString();
                        Catalogo.dateTimeHoraEntrada.Text = dataGridViewData.Rows[IdRowSelect].Cells["HoraEntrada"].Value.ToString();
                        Catalogo.dateTimeIniciaEntrada.Text = dataGridViewData.Rows[IdRowSelect].Cells["IniciaEntrada"].Value.ToString();
                        Catalogo.dateTimeLimiteEntrada.Text = dataGridViewData.Rows[IdRowSelect].Cells["LimiteEntrada"].Value.ToString();
                        Catalogo.dateTimeHoraSalida.Text = dataGridViewData.Rows[IdRowSelect].Cells["HoraSalida"].Value.ToString();
                        Catalogo.dateTimeLimiteSalida.Text = dataGridViewData.Rows[IdRowSelect].Cells["LimiteSalida"].Value.ToString();
                        Catalogo.textBoxHorasJornada.Text = dataGridViewData.Rows[IdRowSelect].Cells["HorasJornada"].Value.ToString();
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
                    IdRowSelect = dataGridViewData.CurrentRow.Index;
                    TurnML Turn = new TurnML();
                    Turn.Id = Int32.Parse(dataGridViewData.Rows[IdRowSelect].Cells["Id"].Value.ToString());
                    Turn.IdUserDelete = 1;
                    TurnBLL.Delete(Turn);
                    dataGridViewData.Rows.Remove(dataGridViewData.CurrentRow);
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
