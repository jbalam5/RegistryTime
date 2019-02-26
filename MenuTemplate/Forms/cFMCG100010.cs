using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLayer;
using ModelLayer;
namespace RegistryTime.Forms
{
    public partial class cFMCG100010 : Form
    {
        #region "GLOBAL VARIABLES"
        int lx, ly;
        int sw, sh;
        public ReaderConnectionML readerConnectionML;
        public ReaderConnectionBLL readerConnectionBLL;
        public DataTable dtConnection;
        public DataTable dtModelReader;
        #endregion

        #region "EVENTS"
        public cFMCG100010()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormValidate())
                {
                    readerConnectionML.idReader = int.Parse(ModelComboBox.SelectedValue.ToString());
                    readerConnectionML.ip = IPtextBox.Text;
                    readerConnectionML.name = NameConectiontextBox.Text;
                    readerConnectionML.port = PortTextBox.Text;
                    readerConnectionML.isDefault = DefaultCheckBox.Checked;

                    if (readerConnectionBLL.save(readerConnectionML) > 0)
                    {
                        Alerts.cFAT100010 alr = new Alerts.cFAT100010("Información", " La información se ha guardado correctamente", MessageBoxIcon.Information);
                        alr.ShowDialog();
                        EnabledControls(false);
                    }
                    else
                    {
                        Alerts.cFAT100010 alr = new Alerts.cFAT100010("Información", " La información no se ha guardado correctamente", MessageBoxIcon.Error);
                        alr.ShowDialog();
                    }

                    CancelButton.Visible = false;
                    AddButton.Enabled = true;

                    LoadData();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(string.Format("SaveButton_Click: {0}", ex.Message), "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            CancelButton.Visible = true;
            AddButton.Enabled = false;
            ClearControls();
            ConectioncomboBox.Enabled = false;
            EnabledControls(true);
            readerConnectionML = new ReaderConnectionML();
            readerConnectionML.id = 0;
            SaveButton.Enabled = true;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {            
            readerConnectionML = new ReaderConnectionML();
            readerConnectionML.id = int.Parse(ConectioncomboBox.SelectedValue.ToString());
            EnabledControls(true);
            SaveButton.Enabled = true;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConectioncomboBox.Enabled)
                {
                    int id = int.Parse(ConectioncomboBox.SelectedValue.ToString());

                    if (id > 0)
                    {
                        Alerts.cFAT100010 alr = new Alerts.cFAT100010("Información", "¿Desea eliminar la conexión?", MessageBoxIcon.Question);
                        if (alr.ShowDialog() == DialogResult.Yes)
                        {
                            if (readerConnectionBLL.Delete(id) > 0)
                                alr = new Alerts.cFAT100010("Información", "Se ha eliminado correctamente", MessageBoxIcon.Information);
                            else
                                alr = new Alerts.cFAT100010("Información", "No se ha eliminado la conexión", MessageBoxIcon.Error);
                            LoadData();
                        }
                    }
                }

            }catch(Exception ex)
            {
                MessageBox.Show(String.Format("DeleteButton_Click: {0}", ex.Message), "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cFMCG100010_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("cFMCG100010_Load: {0}", ex.Message), "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConectioncomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        private void ConectioncomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (ConectioncomboBox != null && ConectioncomboBox.Items.Count > 0)
                {
                    LoadConnection(int.Parse(ConectioncomboBox.SelectedValue.ToString()));
                }

            }catch(Exception ex)
            {
                MessageBox.Show(string.Format("ConectioncomboBox_SelectedValueChanged: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Minimizebutton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void NormalButton_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            this.MaximizeButton.Visible = true;
            this.NormalButton.Visible = false;
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            MetodMax();
        }
        #endregion

        #region "METHODS"

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wsmg, int wparam, int lparam);

        private void LoadData()
        {
            try
            {
                BussinesLayer.ModelReaderBLL modelReaderBLL = new BussinesLayer.ModelReaderBLL();
                readerConnectionBLL = new ReaderConnectionBLL();
                readerConnectionML = new ReaderConnectionML();

                dtModelReader = modelReaderBLL.All();
                ModelComboBox.DisplayMember = ModelReaderML.DataBase.brand;
                ModelComboBox.ValueMember = ModelReaderML.DataBase.id;
                ModelComboBox.DataSource = dtModelReader;

                dtConnection = readerConnectionBLL.All();
                ConectioncomboBox.DisplayMember = ReaderConnectionML.DataBase.name;
                ConectioncomboBox.ValueMember = ReaderConnectionML.DataBase.id;

                ConectioncomboBox.DataSource = dtConnection;

                LoadControls();
                EnabledControls(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("LoadData: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void MetodMax()
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.NormalButton.Visible = true;
            this.MaximizeButton.Visible = false;
        }

        private void LoadControls()
        {
            SaveButton.Enabled = false;
            AddButton.Enabled = true;

            bool enabled = (dtConnection != null && dtConnection.Rows.Count > 0) ? true : false;

            ConectioncomboBox.Enabled = enabled;
            EditButton.Enabled = enabled;
            DeleteButton.Enabled = enabled;

        }

        private bool FormValidate()
        {
            Alerts.cFAT100010 alr;
            if (string.IsNullOrEmpty(NameConectiontextBox.Text))
            {
                alr = new Alerts.cFAT100010("Información", "Debe ingresar el nombre de la conexíon", MessageBoxIcon.Error);
                alr.ShowDialog();
                return false;
            }else if (string.IsNullOrEmpty(IPtextBox.Text))
            {
                alr = new Alerts.cFAT100010("Información", "Debe ingresar la dirección IP", MessageBoxIcon.Error);
                alr.ShowDialog();
                return false;
            }
            else if (string.IsNullOrEmpty(PortTextBox.Text))
            {
                alr = new Alerts.cFAT100010("Información", "Debe ingresar el puerto de la conexión", MessageBoxIcon.Error);
                alr.ShowDialog();
                return false;
            }

            return true;
        }
        private void ClearControls()
        {
            IPtextBox.Text = string.Empty;
            PortTextBox.Text = string.Empty;
            NameConectiontextBox.Text = string.Empty;
            DefaultCheckBox.Checked = false;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CancelButton.Visible = false;
            AddButton.Enabled = true;
            ClearControls();
            LoadData();
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void EnabledControls(bool allow)
        {
            NameConectiontextBox.ReadOnly = !allow;
            IPtextBox.ReadOnly = !allow;
            PortTextBox.ReadOnly = !allow;
            DefaultCheckBox.Enabled = allow;
            ModelComboBox.Enabled = allow;
        }

        private void LoadConnection(int id)
        {
            try
            {
                ReaderConnectionBLL readerConnectionBLL = new ReaderConnectionBLL();
                ReaderConnectionML readerConnectionML = readerConnectionBLL.GetConnectionById(id);

                NameConectiontextBox.Text = readerConnectionML.name;
                IPtextBox.Text = readerConnectionML.ip;
                PortTextBox.Text = readerConnectionML.port;
                DefaultCheckBox.Checked = readerConnectionML.isDefault;
                ModelComboBox.SelectedItem = readerConnectionML.idReader;

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("LoadConnection: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
