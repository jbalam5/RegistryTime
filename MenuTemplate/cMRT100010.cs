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


namespace RegistryTime
{
    public partial class cMRT100010 : Form
    {
        #region "GLOBAL VARIABLES"
        private Rectangle sizeGripRectangle;
        private int tolerance = 15;
        int lx, ly;
        int sw, sh;
        #endregion

        public cMRT100010()
        {
            InitializeComponent();
            MetodMax();

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

        }

        private void MaxWindowsPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void MinWindowsPictureBox_Click(object sender, EventArgs e)
        {

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
            Application.Exit();
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

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            //OpenFormChild(new RegistryTime.Forms.cFRT100010());
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

        private void ClearPanelContainer()
        {
            if (this.ContainerPanel.Controls.Count > 0)
                this.ContainerPanel.Controls.RemoveAt(0);
        }
        #endregion

        private void SettingsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
