using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLayer.Connection;
using System.IO;
using System.Configuration;
using System.Runtime.InteropServices;

namespace MenuTemplate.Forms
{
    public partial class cFMCX000010 : Form
    {
        ConnectionBLL connection = new ConnectionBLL();
        public cFMCX000010()
        {
            InitializeComponent();
        }

        private void cFMCX000010_Load(object sender, EventArgs e)
        {
            try
            {


                String path = String.Format(@"C:\{0}\ConnectionString.config", ConfigurationManager.AppSettings.Get("nameSystem"));
                if (File.Exists(path))
                {

                    CollectionConneccionString dataconexion = connection.openConexionFile();
                    textBoxServer.Text = dataconexion.Instancia.ToString();
                    textBoxUserName.Text = dataconexion.username.ToString();
                    textBoxPassword.Text = dataconexion.password.ToString();
                    textBoxDatabase.Text = dataconexion.database.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Form1_Load: {0}", ex), "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if(!String.IsNullOrEmpty(textBoxServer.Text) && !String.IsNullOrEmpty(textBoxUserName.Text) && !String.IsNullOrEmpty(textBoxPassword.Text) && !String.IsNullOrEmpty(textBoxDatabase.Text))
                {
                    connection.saveConexion(textBoxServer.Text, textBoxUserName.Text, textBoxPassword.Text, textBoxDatabase.Text);
                    try
                    {
                        connection.CreateConnection();
                        MessageBox.Show("DATOS GUARDADOS", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Datos de Conexion incorrectos!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connection.DeleteConnection();
                        Clear();
                    }                    
                }

            }catch(Exception ex)
            {
                MessageBox.Show(String.Format("button1_Click: {0}", ex), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Clear()
        {
            try
            {
                textBoxServer.Text = String.Empty;
                textBoxUserName.Text = String.Empty;
                textBoxPassword.Text = String.Empty;
                textBoxDatabase.Text = String.Empty;

            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("Clear: {0}", ex), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //FUNCION PARA MOVER VENTANA 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
