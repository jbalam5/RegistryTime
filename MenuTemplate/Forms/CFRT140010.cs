using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistryTime.Forms
{
    public partial class CFRT140010 : Form
    {
        #region "Variables Global"
        private BussinesLayer.CheckInoursBLL checkInoursBLL;
        private BussinesLayer.EmployeeBLL employeeBLL;
        private ModelLayer.CheckInHoursML checkInHours;
        private ModelLayer.EmployeeML employeeML;
        private Timer tmr;
        #endregion

        public CFRT140010()
        {
            InitializeComponent();
        }

        #region "EVENTS"
        private void CFRT140010_Load(object sender, EventArgs e)
        {
            SetTimer();
            checkInoursBLL = new BussinesLayer.CheckInoursBLL();
            employeeBLL = new BussinesLayer.EmployeeBLL();
            tmr = new Timer();
        }

        private void Minimizebutton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            Forms.cFRT150010 frmLogin = new Forms.cFRT150010();
            this.Hide();
            frmLogin.ShowDialog();
        }

        #endregion

        #region "METHODS"

        private void SetTimer()
        {
            RegistroTimer.Interval = 500;
            RegistroTimer.Tick += (sender, e) =>
            {
                HoraActualLabel.Text = DateTime.Now.ToLongTimeString();
                FechaActualLabel.Text = DateTime.Now.ToLongDateString();
            };

            RegistroTimer.Start();
        }

        private void SetMessage(String Message, Color backgroud, Color text)
        {
            MensajePanel.Visible = true;
            MensajeLabel.Text = Message;
            tmr.Interval = 3000; 
            tmr.Tick += timerHandler; 
            tmr.Start();
        }
        #endregion

        private void CheckInButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(NoControlTextBox.Text))
                {
                    employeeML = employeeBLL.GetEntityByNoControl(int.Parse(NoControlTextBox.Text));

                    if (employeeML != null)
                    {
                        checkInHours.Date = DateTime.Now.ToString();
                        checkInHours.IdEmployee = employeeML.Id;

                        checkInoursBLL.Save(checkInHours);
                        //checkInHours = checkInoursBLL.GetIdEntity(int.Parse(NoControlTextBox.Text));
                        SetMessage("Se ha completado su registro", Color.Salmon, Color.White);
                    }
                    else
                    {
                        SetMessage("Número de control invalido", Color.Red, Color.White);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("CheckInButton_Click: {0}", ex.Message), "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerHandler(object sender, EventArgs e)
        {
            MensajePanel.Visible = false;
            tmr.Stop(); // Manually stop timer, or let run indefinitely
        }
    }
}
