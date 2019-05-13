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

        public void LoadDataGridView()
        {
            ReportsBLL ReportsBLL = new ReportsBLL();
            //dataGridViewDataUser.DataSource = UsersBLL.All();
            dataGridViewDataUser.DataSource = ReportsBLL.ReportUsers();
        }   
    }
}
