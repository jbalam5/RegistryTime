using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLayer;

namespace RegistryTime.Forms.Migrate
{
    public partial class cFMMI100010 : Form
    {
        #region "GLOBAL VARIABLES"
        int lx, ly;
        int sw, sh;
        int _type;
        int _dividendo;
        DateTime _startDate;
        DateTime _endDate;
        #endregion

        #region "CONSTRUCTOR"
        public cFMMI100010(int _type, int dividendo, DateTime startDate, DateTime endDate )
        {
            this._type = _type;
            this._startDate = startDate;
            this._endDate = endDate;
            this._dividendo = dividendo;

            InitializeComponent();
        }
        #endregion

        #region "EVENTS"
        private void Minimizebutton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void cFMMI100010_Load(object sender, EventArgs e)
        {
            try
            {
                Application.EnableVisualStyles();
                
                MigrateBackgroundWorker.DoWork += MigrateBackgroundWorker_DoWork;
                MigrateBackgroundWorker.ProgressChanged += MigrateBackgroundWorker_ProgressChanged;
                MigrateBackgroundWorker.RunWorkerCompleted += MigrateBackgroundWorker_RunWorkerCompleted;
                MigrateBackgroundWorker.WorkerReportsProgress = true;

                MigrateBackgroundWorker.RunWorkerAsync();
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("cFMMI100010_Load: {0}", ex.Message), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MigrateBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.Invoke(new Action(() => { MessageLabel.Text = "Iniciando proceso"; } ));

                MigrateBackgroundWorker.ReportProgress(0);
                
                CheckInHoursBLL CheckInoursBLL = new CheckInHoursBLL();
                ZKTecoHourAssistanceBLL zKTecoHourAssistanceBLL = new ZKTecoHourAssistanceBLL();

                MigrateBackgroundWorker.ReportProgress(10);

                this.Invoke(new Action(() => { MessageLabel.Text = "Paso 1: Migrando información a la Base de datos"; }));

                string start = string.Empty;
                string end = string.Empty;
                
                try
                {
                    MigrationHistoryBLL migrationHistoryBLL = new MigrationHistoryBLL();
                    string dateLastRecord = migrationHistoryBLL.LastRecord();
                    
                    if (!string.IsNullOrEmpty(dateLastRecord))
                    {
                        start = DateTime.Parse(dateLastRecord).AddMinutes(1).ToString();
                        DateTime _Today = DateTime.Now;
                        MigrateBackgroundWorker.ReportProgress(20);

                        if (DateTime.Parse(dateLastRecord).AddMinutes(1) <= _Today)
                        {
                            end = _Today.ToString();
                            zKTecoHourAssistanceBLL.MigrateHoursToBD(start, end);
                        }
                    }
                    else
                    {
                        List<string> dateMigrate = zKTecoHourAssistanceBLL.MigrateHoursToBD();
                        if (dateMigrate != null && dateMigrate.Count == 2)
                        {
                            start = dateMigrate[0];
                            end = dateMigrate[1];
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("cFMMI100010_Load: Error al conectar al lector.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MigrateBackgroundWorker.ReportProgress(50);
                this.Invoke(new Action(() => { MessageLabel.Text = "Paso 2: Actualizando horarios de asistencia"; }));

                CheckInoursBLL.Migrate2(start, end);

                //if (this._type == 0)
                //{
                    //ProcessMigrate(Convert.ToInt32(ArgumentsList[4].ToString()));
                    //CheckInoursBLL.Migrate2(_dividendo);
                //}
                //if (Convert.ToInt32(ArgumentsList[3].ToString()) == 1)
                //{
                //    if (ArgumentsList.Length > 3 && Convert.ToDateTime(ArgumentsList[4].ToString()) > Convert.ToDateTime(ArgumentsList[3].ToString()))
                //        ProcessMigrate(Convert.ToDateTime(ArgumentsList[3]), Convert.ToDateTime(ArgumentsList[4]), Convert.ToInt32(ArgumentsList[5]));
                //}
                MigrateBackgroundWorker.ReportProgress(100);

                this.Invoke(new Action(() => { MessageLabel.Text = "Finalizando proceso"; }));
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("cFMMI100010_Load: {0}", ex.Message), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                this.Invoke(new Action(() => { this.Close(); }));
            }
        }

        private void MigrateBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Application.DoEvents();
            MigrateProgressBar.Value = e.ProgressPercentage;
            
            PercentageLabel.Text = string.Format("{0}%", e.ProgressPercentage);
        }

        private void MigrateBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Alerts.cFAT100010 alr = new Alerts.cFAT100010("Migración", "Proceso completo", MessageBoxIcon.Information);
            alr.ShowDialog();
            //this.Invoke(new Action(() => { false; } ));
        }
        #endregion

        #region "METHODS"
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wsmg, int wparam, int lparam);
        #endregion
    }
}
