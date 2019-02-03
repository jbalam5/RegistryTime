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

namespace Alerts
{
    public partial class cFAT100010 : Form
    {
        #region "Properties"
        private String _Title = String.Empty;
        private String _Description = String.Empty;
        private MessageBoxIcon _Type = MessageBoxIcon.Information;
        //        private String _Title = String.Empty;
        //        public string Title
        //        {
        //            get
        //{
        //                return _Title;
        //            }
        //            set
        //            {
        //                _Title = value;
        //            }
        //        }

        //        private String _Description = String.Empty;
        //        public String Description
        //        {
        //            get
        //            {
        //                return _Description;
        //            }
        //            set
        //            {
        //                _Description = value;
        //            }
        //        }

        //        private MessageBoxIcon _Type;
        //        public MessageBoxIcon Type
        //        {
        //            get
        //            {
        //                return _Type;
        //            }
        //            set
        //            {
        //                _Type = value;
        //            }
        //        }


        #endregion
        #region "EVENTS"
        public cFAT100010(String TitleMsg, String DescriptionMsg, MessageBoxIcon TypeMsg = MessageBoxIcon.None)
        {
            InitializeComponent();

            this._Title = TitleMsg;
            this._Description = DescriptionMsg;
            this._Type = TypeMsg;
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("", "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cFAT100010_Load(object sender, EventArgs e)
        {
            //Alerts.cFAT100010 frmAlert = new Alerts.cFAT100010("Información", "Esta es una información", MessageBoxIcon.Information);

            if (_Type != MessageBoxIcon.None)
            {
                if (_Type == MessageBoxIcon.Question) QuestionPanel.Visible = true;
                else InfoPanel.Visible = true;
            }
            else
            {
                IconPictureBox.Visible = false;
                InfoPanel.Visible = true;
            }
            this.TitleLabel.Text = _Title;
            this.DescriptionLabel.Text = _Description;
            this.Height = 150;

            ChangeIcon();
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region METHODS
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wsmg, int wparam, int lparam);

        private void ChangeIcon()
        {
            IconPictureBox.BackgroundImageLayout = ImageLayout.Zoom;

            switch (_Type)
            {
                case MessageBoxIcon.Information:
                    IconPictureBox.BackgroundImage = RegistryTime.Properties.Resources.IconInformation;
                    break;
                case MessageBoxIcon.Question:
                    IconPictureBox.BackgroundImage = RegistryTime.Properties.Resources.IconQuestion;
                    break;
                case MessageBoxIcon.Error:
                    IconPictureBox.BackgroundImage = RegistryTime.Properties.Resources.IconError;
                    break;
                case MessageBoxIcon.Warning:
                    IconPictureBox.BackgroundImage = RegistryTime.Properties.Resources.IconWarningOrnge;
                    break;
                default:
                    IconPictureBox.BackgroundImage = null;
                    break;
            }
        }
        #endregion
    }
}
