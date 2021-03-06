﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RegistryTime
{
    public partial class cMRT1000101 : Form
    {
        public CustomControls.LoaderControl loader;
        public cMRT1000101()
        {
            InitializeComponent();
        }

        #region "EVENTS"

        private void MenuPictureBox_Click(object sender, EventArgs e)
        {
            if (MenuLeftPanel.Width > 50)
                MenuLeftPanel.Width = 50;
            else
                MenuLeftPanel.Width = 200;
        }

        private void CloseWindowsPictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MaxWindowsPictureBox_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void MinWindowsPictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void DepartamentoButton_Click(object sender, EventArgs e)
        {
            //MenuTemplate.Forms.cFRT120010 frm = new Forms.cFRT120010();
            //frm.ShowDialog();
            OpenFormChild(new RegistryTime.Forms.cFMDE100010());
        }

        private void EmploymentsButton_Click(object sender, EventArgs e)
        {
            OpenFormChild(new RegistryTime.Forms.cFRT110010());
        }

        private void TurnosButton_Click(object sender, EventArgs e)
        {
            RegistryTime.Forms.cFRT130010 frm = new Forms.cFRT130010();
            frm.ShowDialog();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            ClearPanelContainer();
        }

        #endregion
        
        #region "Methods"
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wsmg, int wparam, int lparam);

        public void OpenFormChild(object frmChild)
        {
            try
            {
                if (this.ContainerPanel.Controls.Count > 0)
                    this.ContainerPanel.Controls.RemoveAt(0);

                Form frm = frmChild as Form;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                this.ContainerPanel.Controls.Add(frm);
                this.ContainerPanel.Tag = frm;
                frm.Show();

            }catch (Exception ex)
            {
                MessageBox.Show(String.Format("OpenFormChild: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearPanelContainer()
        {
            if (this.ContainerPanel.Controls.Count > 0)
                this.ContainerPanel.Controls.RemoveAt(0);
        }
        #endregion

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cMRT100010_Load(object sender, EventArgs e)
        {
            loader = new CustomControls.LoaderControl();
            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonTurno_Click(object sender, EventArgs e)
        {
            OpenFormChild(new RegistryTime.Forms.cFRT110010());
        }

        private void test_Click(object sender, EventArgs e)
        {
            BussinesLayer.ZKTecoDeviceBLL obj = new BussinesLayer.ZKTecoDeviceBLL();

            BiometricCore.UserInfo user = new BiometricCore.UserInfo();
            user = obj.GetUserInfoById(175);
        }

        private void Migrarbutton_Click(object sender, EventArgs e)
        {
            BussinesLayer.ZKTecoHourAssistanceBLL obj = new BussinesLayer.ZKTecoHourAssistanceBLL();
            obj.MigrateHoursToBD();
        }

        private void NewUserbutton_Click(object sender, EventArgs e)
        {
            BussinesLayer.ZKTecoDeviceBLL obj = new BussinesLayer.ZKTecoDeviceBLL();

            BiometricCore.UserInfo user = new BiometricCore.UserInfo();
            int id = obj.SetUserInfo(177, "dchan", 1, "", "177177");
            MessageBox.Show(string.Format("{0}", id));
            
        }

        private void ListUserbutton_Click(object sender, EventArgs e)
        {
            BussinesLayer.ZKTecoDeviceBLL obj = new BussinesLayer.ZKTecoDeviceBLL();

            BiometricCore.UserInfo user = new BiometricCore.UserInfo();
            ICollection<BiometricCore.UserInfo> users = obj.GetAllUserInfo();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loader.title = "Espera esto es un titulo";
            loader.description = "Procesando: esto es un titulo de procesando";
            loader.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loader.title = "Espera esto es un titulo2";
            loader.description = "Procesando: esto es un titulo de procesando2";
            loader.Visible = false;
        }
    }
}
