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
        public CFRT140010()
        {
            InitializeComponent();
        }

        private void CFRT140010_Load(object sender, EventArgs e)
        {
            SetTimer();
        }

        private void SetTimer()
        {
            RegistroTimer.Interval = 1000;
            RegistroTimer.Tick += (sender, e) =>
            {
                HoraActualLabel.Text = DateTime.Now.ToLongTimeString();
                FechaActualLabel.Text = DateTime.Now.ToLongDateString();
            };

            RegistroTimer.Start();
        }

        private void SetMessage(String Message)
        {
            MensajePanel.Visible = true;
            MensajeLabel.Text = Message;
        }

        private void Minimizebutton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
