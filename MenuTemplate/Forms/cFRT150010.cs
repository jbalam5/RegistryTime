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

namespace RegistryTime.Forms
{
    public partial class cFRT150010 : Form
    {
        #region "Properties"
        private Form _frm = null;
        public Form FormToOpen
        {
            get
            {
                return _frm;
            }
            set
            {
                _frm = value;
            }
        }
        #endregion

            #region "CONSTRUCTOR"
        public cFRT150010()
        {
            InitializeComponent();
        }
        #endregion

        #region "EVENTS"

        private void cFRT150010_Load(object sender, EventArgs e)
        {
            BussinesLayer.GlobalBLL.userML = null;
            DatetoolStripStatusLabel.Text = DateTime.Now.ToLongDateString();
        }

        private void Minimizebutton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormValidate() > 0)
                {
                    BussinesLayer.UsersBLL UserBLL = new BussinesLayer.UsersBLL();
                    ModelLayer.UsersML UsersML = new ModelLayer.UsersML() { UserName = UserNameTextBox.Text, Password = PasswordTextBox.Text };
                    UsersML = UserBLL.IsUser(UsersML);

                    if (UsersML != null && UsersML.Id > 0)
                    {
                        BussinesLayer.RoleBLL roleBLL = new BussinesLayer.RoleBLL();
                        ModelLayer.RoleML roleML = roleBLL.GetIdEntity(UsersML.Rol);

                        if (roleML == null) throw new Exception("No se encontro el rol del usuario");
                        
                        if (roleML.Name.ToUpper() == "ADMIN")
                        {
                            //_frm = new cMRT100010();

                            BussinesLayer.GlobalBLL.userML = UsersML;

                            //cMRT100010 frm = new cMRT100010();
                            //this.Hide();
                            //frm.Show();
                            this.Hide();

                        }
                        else {

                            Alerts.cFAT100010 frmAlert = new Alerts.cFAT100010("Información", "No cuenta con los privilegios suficientes", MessageBoxIcon.Error);
                            frmAlert.ShowDialog();
                            //_frm = new Forms.CFRT140010();

                            //Abre el formulario de registro
                            //Forms.CFRT140010 frm = new Forms.CFRT140010();
                            //this.Hide();
                            //frm.Show();
                        }
                    }
                    else
                    {
                        Alerts.cFAT100010 frmAlert = new Alerts.cFAT100010("Información", "El Usuario/contraseña no es valido", MessageBoxIcon.Error);
                        frmAlert.ShowDialog();
                    }
                }

            }catch(Exception ex)
            {
                MessageBox.Show(String.Format("OkButton_Click: {0}", ex), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "METHODS"
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wsmg, int wparam, int lparam);

        private int FormValidate()
        {
            try
            {
                if (string.IsNullOrEmpty(UserNameTextBox.Text))
                {
                    Alerts.cFAT100010 frmAlert = new Alerts.cFAT100010("Información", "Ingrese su Usuario", MessageBoxIcon.Information);
                    frmAlert.ShowDialog();
                    return 0;
                }

                if (string.IsNullOrEmpty(PasswordTextBox.Text))
                {
                    Alerts.cFAT100010 frmAlert = new Alerts.cFAT100010("Información", "Ingrese su Contraseña", MessageBoxIcon.Information);
                    frmAlert.ShowDialog();
                    return 0;
                }

                return 1;

            }catch(Exception ex)
            {
                MessageBox.Show(String.Format("formValidate: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        #endregion

        private void cFRT150010_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
