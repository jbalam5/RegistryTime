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
    public partial class cFMCG100010 : Form
    {
        public ReaderConnectionML readerConnectionML;
        public ReaderConnectionBLL readerConnectionBLL;
        public DataTable dtConnection;
        public DataTable dtModelReader;

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

                if (ConectioncomboBox.Items.Count > 0)
                    readerConnectionML.id = int.Parse(ConectioncomboBox.SelectedValue.ToString());
                else
                    readerConnectionML.id = 0;

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

            }catch(Exception ex)
            {
                MessageBox.Show(string.Format("SaveButton_Click: {0}", ex.Message), "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            EnabledControls(true);
            readerConnectionML = new ReaderConnectionML();
            readerConnectionML.id = 0;
            SaveButton.Enabled = true;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            readerConnectionML = new ReaderConnectionML();
            EnabledControls(true);
            SaveButton.Enabled = true;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void cFMCG100010_Load(object sender, EventArgs e)
        {
            try
            {
                BussinesLayer.ModelReaderBLL modelReaderBLL = new BussinesLayer.ModelReaderBLL();
                readerConnectionBLL = new ReaderConnectionBLL();

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
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("cFMCG100010_Load: {0}", ex.Message), "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConectioncomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

           
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
                
            }catch(Exception ex)
            {
                MessageBox.Show(string.Format("LoadConnection: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
