using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelLayer;
using BussinesLayer;

namespace RegistryTime.Forms
{
    public partial class cFMSE110010 : Form
    {
        private String DirectoryFiles = "ImagenTMP";
        private CompanyBLL companyBLL;
        private CompanyML companyML;

        public cFMSE110010()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                String filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Title = "Buscar Imagen";
                    openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if(LogoPictureBox.BackgroundImage != null)
                            LogoPictureBox.BackgroundImage.Dispose();
                        //LogoPictureBox.BackgroundImage = null;
                        //LogoPictureBox.Update();
                        
                        LogoPictureBox.BackgroundImage = new Bitmap(openFileDialog.FileName);
                        PathFileNameTextBox.Text = openFileDialog.FileName;
                        //openFileDialog.SafeFileName
                        //System.IO.Path.GetFileName(openFileDialog.FileName)
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("SearchButton_Click: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormValidate())
                {

                    string lastImage = companyML.Image;
                    if (!string.IsNullOrEmpty(PathFileNameTextBox.Text) && !System.IO.File.Exists(PathFileNameTextBox.Text))
                        throw new Exception("La imagen seleccionada no existe");

                    companyML.Rfc = RFCTextBox.Text;
                    companyML.BusinessName = RazonSocialTextBox.Text;
                    companyML.Street = CalleTextBox.Text;
                    companyML.Municipality = MunicipioTextBox.Text;
                    companyML.Country = PaisTextBox.Text;
                    companyML.Email = CorreoTextBox.Text;
                    companyML.State = EstadoTextBox.Text;
                    companyML.PostalCode = CodigoPostalTextBox.Text;
                    companyML.Telephone = TelefonoTextBox.Text;
                    companyML.Image = System.IO.Path.GetFileName(PathFileNameTextBox.Text);
                    

                    if (companyBLL.Save(companyML) > 0)
                    {
                        if (!string.IsNullOrEmpty(PathFileNameTextBox.Text)){
                            if (!System.IO.Directory.Exists(DirectoryFiles)) System.IO.Directory.CreateDirectory(DirectoryFiles);
                            
                            System.IO.File.Delete(string.Format("{0}/{1}", DirectoryFiles, lastImage));
                            System.IO.File.Copy(PathFileNameTextBox.Text, string.Format("{0}/{1}",DirectoryFiles, System.IO.Path.GetFileName(PathFileNameTextBox.Text)));
                        }

                        Alerts.cFAT100010 alr = new Alerts.cFAT100010("Información", "Guardado correctamente", MessageBoxIcon.Information);
                        alr.ShowDialog();
                        clearFields();
                    }
                    else
                    {
                        Alerts.cFAT100010 alr = new Alerts.cFAT100010("Información", "No se ha guardado los cambios", MessageBoxIcon.Error);
                        alr.ShowDialog();
                    }
                }

            } catch (Exception ex)
            {
                Alerts.cFAT100010 alr = new Alerts.cFAT100010("EROR", string.Format("buttonNuevo_Click: {0}", ex.Message), MessageBoxIcon.Error);
                alr.ShowDialog();
            }
        } 

        public bool FormValidate()
        {
            try
            {
                bool Valid = true;

                if (string.IsNullOrEmpty(RFCTextBox.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingesar el RFC");
                }
                else if (string.IsNullOrEmpty(RazonSocialTextBox.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingresar la razón social");
                }
                else if (string.IsNullOrEmpty(CalleTextBox.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingesar la calle");
                }
                else if (string.IsNullOrEmpty(MunicipioTextBox.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingesar el Municipio");
                }
                else if (string.IsNullOrEmpty(RFCTextBox.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingesar el estado");
                }
                else if (string.IsNullOrEmpty(TelefonoTextBox.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingesar el Teléfono");
                }
                else if (string.IsNullOrEmpty(CorreoTextBox.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingesar el Correo Electrónico");
                }

                return Valid;
            }
            catch (Exception ex)
            {
                Alerts.cFAT100010 alr = new Alerts.cFAT100010("EROR", string.Format("{0}", ex.Message), MessageBoxIcon.Error);
                alr.ShowDialog();
                return false;
            }

        }

        public void clearFields()
        {
            try
            {
                RFCTextBox.Text = string.Empty;
                RazonSocialTextBox.Text = string.Empty;
                CalleTextBox.Text = string.Empty;
                MunicipioTextBox.Text = string.Empty;
                PaisTextBox.Text = string.Empty;
                CorreoTextBox.Text = string.Empty;
                EstadoTextBox.Text = string.Empty;
                CodigoPostalTextBox.Text = string.Empty;
                TelefonoTextBox.Text = string.Empty;
                PathFileNameTextBox.Text = string.Empty;
                LogoPictureBox.BackgroundImage = null;
                LogoPictureBox.Update();
            }
            catch
            {

            }
        }

        private void cFMSE110010_Load(object sender, EventArgs e)
        {
            try
            {
                companyBLL = new CompanyBLL();
                companyML = companyBLL.GetEntity();

                if(companyML != null)
                {
                    RFCTextBox.Text = companyML.Rfc;
                    RazonSocialTextBox.Text = companyML.BusinessName;
                    CalleTextBox.Text = companyML.Street;
                    MunicipioTextBox.Text = companyML.Municipality;
                    PaisTextBox.Text = companyML.Country;
                    CorreoTextBox.Text = companyML.Email;
                    EstadoTextBox.Text = companyML.State;
                    CodigoPostalTextBox.Text = companyML.PostalCode;
                    TelefonoTextBox.Text = companyML.Telephone;


                    if (!string.IsNullOrEmpty(companyML.Image))
                    {
                        PathFileNameTextBox.Text = string.Format("{0}\\{1}", System.IO.Path.GetFullPath(DirectoryFiles), companyML.Image);

                        if (System.IO.File.Exists(PathFileNameTextBox.Text))
                            LogoPictureBox.BackgroundImage = new Bitmap(PathFileNameTextBox.Text);
                        else
                            throw new Exception("No se encontró la imagen");
                    }
                }
                else
                {
                    companyML = new CompanyML();
                }

                if (!System.IO.Directory.Exists(DirectoryFiles)) System.IO.Directory.CreateDirectory(DirectoryFiles);
            }
            catch(Exception ex)
            {
                Alerts.cFAT100010 alr = new Alerts.cFAT100010("EROR", string.Format("cFMSE110010_Load: {0}", ex.Message), MessageBoxIcon.Error);
                alr.ShowDialog();
            }
        }
    }
}
