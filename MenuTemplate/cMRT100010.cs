using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using BussinesLayer;
using ModelLayer;
using System.Configuration;

namespace RegistryTime
{
    public partial class cMRT100010 : Form
    {
        #region "GLOBAL VARIABLES"
        int lx, ly;
        int sw, sh;
        private new bool Visible = false;

        private CompanyBLL companyBLL;
        #endregion

        public cMRT100010()
        {
            

            InitializeComponent();
            MetodMax();

        }

        #region "EVENTS"
        private void cMRT100010_Load(object sender, EventArgs e)
        {
            try
            {
                getLogin();
                getCompany();
                DatetoolStripStatusLabel.Text = DateTime.Now.ToLongDateString().ToUpper();
                //ReportsButton_Click
                //panelSubMenu.Visible = !Visible;

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("cMRT100010_Load: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MenuPictureBox_Click(object sender, EventArgs e)
        {
            if (MenuLeftPanel.Width > 50)
            {
                LogoPictureBox.Visible = false;
                MenuLeftPanel.Width = 50;
                panelSubMenu.Left = panelSubMenu.Left - 165;
            }
            else
            {
                panelSubMenu.Left = panelSubMenu.Left + 165;
                LogoPictureBox.Visible = true;
                MenuLeftPanel.Width = 220;
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
            this.StartPosition = FormStartPosition.CenterScreen;
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

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            MetodMax();

            //lx = this.Location.X;
            //ly = this.Location.Y;
            //sw = this.Size.Width;
            //sh = this.Size.Height;
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            //this.NormalButton.Visible = true;
            //this.MaximizeButton.Visible = false;

            //if (this.WindowState == FormWindowState.Maximized)
            //    this.WindowState = FormWindowState.Normal;
            //else
            //    this.WindowState = FormWindowState.Maximized;
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            getLogin();
            getCompany();
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void DepartamentoButton_Click(object sender, EventArgs e)
        {
            OpenFormChild(new RegistryTime.Forms.cFMDE100010());
        }

        private void EmploymentsButton_Click(object sender, EventArgs e)
        {
            OpenFormChild(new RegistryTime.Forms.cFMEM100010());
        }

        private void TurnosButton_Click(object sender, EventArgs e)
        {
            //RegistryTime.Forms.cFMTU140010 frm = new Forms.cFMTU140010();
            //frm.ShowDialog();
            OpenFormChild(new RegistryTime.Forms.cFMTU100010());

        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            ClearPanelContainer();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFormChild(new RegistryTime.Forms.cFMPU100010());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFormChild(new RegistryTime.Forms.cFMCO100010());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFormChild(new RegistryTime.Forms.cFMAA100010());
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Forms.cFMSE110010 frm = new Forms.cFMSE110010();
            OpenFormChild(frm);
        }

        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            getLogin();
            getCompany();
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            //OpenFormChild(new RegistryTime.Forms.Reports.cFMRP100010());
            panelSubMenu.Visible = !Visible;
            Visible = !Visible;
        }

        //protected override void OnSizeChanged(EventArgs e)
        //{
        //    base.OnSizeChanged(e);
        //    var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

        //    sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

        //    region.Exclude(sizeGripRectangle);
        //    this.PrincipalPanel.Region = region;
        //    this.Invalidate();
        //}
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        //protected override void OnPaint(PaintEventArgs e)
        //{

        //    SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
        //    e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

        //    base.OnPaint(e);
        //    ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        //}
        #endregion

        #region "Methods"
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wsmg, int wparam, int lparam);

        private void OpenFormChild(object frmChild)
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("OpenFormChild: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearPanelContainer()
        {
            if (this.ContainerPanel.Controls.Count > 0)
                this.ContainerPanel.Controls.RemoveAt(0);
        }

        private void cMRT100010_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void getLogin()
        {
            ClearPanelContainer();
            Forms.cFRT150010 frmLogin = new Forms.cFRT150010();
            //this.Hide();
            frmLogin.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //OpenFormChild(new RegistryTime.Forms.Reports.cFMRP120010());
            //panelSubMenu.Visible = !Visible;

            //Visible = !Visible;
        }

        private void buttonReporteHrsExtras_Click(object sender, EventArgs e)
        {
            OpenFormChild(new RegistryTime.Forms.Reports.cFMRP130010());
            panelSubMenu.Visible = !Visible;

            Visible = !Visible;
        }

        private void buttonReporteHrsJornadas_Click(object sender, EventArgs e)
        {
            OpenFormChild(new RegistryTime.Forms.Reports.cFMRP140010());
            panelSubMenu.Visible = !Visible;

            Visible = !Visible;
        }

        private void panelSubMenu_ChangeUICues(object sender, UICuesEventArgs e)
        {
            //panelSubMenu.Visible = !Visible;

            //Visible = !Visible;
        }

        private void buttonReporteAusentimos_Click(object sender, EventArgs e)
        {
            OpenFormChild(new RegistryTime.Forms.Reports.cFMRP120010());
            panelSubMenu.Visible = !Visible;

            Visible = !Visible;
        }

        private void buttonAdmissionDate_Click(object sender, EventArgs e)
        {
            OpenFormChild(new RegistryTime.Forms.Reports.cFMRP150010());
            panelSubMenu.Visible = !Visible;

            Visible = !Visible;
        }

        private void SetTimer()
        {
            StateTimer.Interval = 60000;
            StateTimer.Tick += (sender, e) =>
            {
                DatetoolStripStatusLabel.Text = DateTime.Now.ToLongDateString();
            };

            StateTimer.Start();
        }

        private void getCompany()
        {
            try
            {
                if (BussinesLayer.GlobalBLL.userML != null)
                {
                    UsertoolStripStatusLabel.Text = BussinesLayer.GlobalBLL.userML.UserName.ToUpper();
                    toolStripStatusLabelVersion.Text = String.Format("V.O. {0}", ConfigurationManager.AppSettings.Get("version"));
                    companyBLL = new CompanyBLL();
                    GlobalBLL.companyML = companyBLL.GetEntity();

                    if (GlobalBLL.companyML != null)
                    {
                        CompanyNameToolStripStatusLabel.Text = !string.IsNullOrEmpty(GlobalBLL.companyML.BusinessName.ToUpper()) ? GlobalBLL.companyML.BusinessName.ToUpper() : string.Empty;
                        if (!string.IsNullOrEmpty(GlobalBLL.companyML.Image))
                        {
                            string PathFileName = string.Format("{0}\\{1}", System.IO.Path.GetFullPath(GlobalBLL.DirectoryFiles), GlobalBLL.companyML.Image);

                            if (System.IO.File.Exists(PathFileName))
                            {
                                if (LogoPictureBox.BackgroundImage != null)
                                    LogoPictureBox.BackgroundImage.Dispose();

                                LogoPictureBox.BackgroundImage = new Bitmap(PathFileName);
                            }
                        }
                    }
                    else
                    {
                        CompanyNameToolStripStatusLabel.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("No ha iniciado sesión", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("getCompany: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
