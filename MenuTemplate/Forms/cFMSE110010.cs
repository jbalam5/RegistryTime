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
        private CompanyBLL companyBLL;
        private EmployeeBLL employeeBLL;
        private CompanyML companyML;
        private EmployeeML employeeML;

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
                    //openFileDialog.RestoreDirectory = true;

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
                if (FormValidateEnterprise())
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
                        GlobalBLL.companyML = companyML;

                        if (!string.IsNullOrEmpty(PathFileNameTextBox.Text)){
                            if (!System.IO.Directory.Exists(GlobalBLL.DirectoryFiles)) System.IO.Directory.CreateDirectory(GlobalBLL.DirectoryFiles);

                            string lastPathFile = string.Format("{0}/{1}", GlobalBLL.DirectoryFiles, lastImage);
                            if (System.IO.Path.GetFullPath(lastPathFile) != PathFileNameTextBox.Text)
                            {
                                System.IO.File.Delete(lastPathFile);
                                System.IO.File.Copy(PathFileNameTextBox.Text, string.Format("{0}/{1}", GlobalBLL.DirectoryFiles, System.IO.Path.GetFileName(PathFileNameTextBox.Text)));
                            }
                        }

                        Alerts.cFAT100010 alr = new Alerts.cFAT100010("Información", "Guardado correctamente", MessageBoxIcon.Information);
                        alr.ShowDialog();
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

        public bool FormValidateEnterprise()
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
                Alerts.cFAT100010 alr = new Alerts.cFAT100010("ERROR", string.Format("{0}", ex.Message), MessageBoxIcon.Error);
                alr.ShowDialog();
                return false;
            }

        }

        public bool FormValidateUser()
        {
            try
            {
                bool Valid = true;

                if (string.IsNullOrEmpty(NameTextBox.Text))
                {
                    Valid = false;
                    throw new Exception("Ingrese el Nombre del Usuario");
                }
                else if (string.IsNullOrEmpty(LastNameTextBox.Text))
                {
                    Valid = false;
                    throw new Exception("Ingrese el apellido");
                }
                else if (string.IsNullOrEmpty(UserNameTextBox.Text))
                {
                    Valid = false;
                    throw new Exception("Ingrese un Nombre de Usuario Valido");
                }
                else if (string.IsNullOrEmpty(PasswordTextBox.Text))
                {
                    Valid = false;
                    throw new Exception("Ingrese la contraseña");
                }

                return Valid;
            }
            catch (Exception ex)
            {
                Alerts.cFAT100010 alr = new Alerts.cFAT100010("ERROR", string.Format("{0}", ex.Message), MessageBoxIcon.Error);
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
            catch {}
        }

        public void LoadUser()
        {
            try
            {
                employeeBLL = new EmployeeBLL();
                employeeML = employeeBLL.GetEmploymentByIdUser(BussinesLayer.GlobalBLL.userML.Id);

                if (employeeML != null)
                {
                    NameTextBox.Text = employeeML.Name;
                    LastNameTextBox.Text = employeeML.LastName;

                }

                if (GlobalBLL.userML != null)
                {
                    UserNameTextBox.Text = GlobalBLL.userML.UserName;
                    PasswordTextBox.Text = GlobalBLL.userML.Password;

                    if (!string.IsNullOrEmpty(GlobalBLL.userML.Image))
                    {
                        PathFileProfileTextBox.Text = string.Format("{0}\\{1}", System.IO.Path.GetFullPath(GlobalBLL.DirectoryFiles), GlobalBLL.userML.Image);

                        if (System.IO.File.Exists(PathFileProfileTextBox.Text))
                            ProfilePictureBox.BackgroundImage = new Bitmap(PathFileProfileTextBox.Text);
                        else
                            throw new Exception("No se encontró la imagen");
                    }
                }
                //else
                //{
                //    Alerts.cFAT100010 alr = new Alerts.cFAT100010("ERROR", "No se encontró la información del usuarios", MessageBoxIcon.Error);
                //    alr.ShowDialog();
                //}
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("LoadUser: {0}", ex.Message));
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
                        PathFileNameTextBox.Text = string.Format("{0}\\{1}", System.IO.Path.GetFullPath(GlobalBLL.DirectoryFiles), companyML.Image);

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

                LoadUser();


                if (!System.IO.Directory.Exists(GlobalBLL.DirectoryFiles)) System.IO.Directory.CreateDirectory(GlobalBLL.DirectoryFiles);
            }
            catch(Exception ex)
            {
                Alerts.cFAT100010 alr = new Alerts.cFAT100010("EROR", string.Format("cFMSE110010_Load: {0}", ex.Message), MessageBoxIcon.Error);
                alr.ShowDialog();
            }
        }

        private void SaveUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormValidateUser())
                {
                    BussinesLayer.UsersBLL usersBLL = new UsersBLL();

                    if (usersBLL.UserExist(UserNameTextBox.Text, GlobalBLL.userML.Id) <= 0)
                    {
                        string lastImage = GlobalBLL.userML.Image;
                        if (!string.IsNullOrEmpty(PathFileProfileTextBox.Text) && !System.IO.File.Exists(PathFileProfileTextBox.Text))
                            throw new Exception("La imagen seleccionada no existe");

                        if (employeeML != null)
                        {
                            employeeML.ControlNumber = KeyTextBox.Text;
                            employeeML.Name = NameTextBox.Text;
                            employeeML.LastName = LastNameTextBox.Text;
                            employeeBLL.Save(employeeML);
                        }

                        GlobalBLL.userML.UserName = PasswordTextBox.Text;
                        GlobalBLL.userML.Password = PasswordTextBox.Text;
                        GlobalBLL.userML.Image = System.IO.Path.GetFileName(PathFileProfileTextBox.Text);

                        if (usersBLL.Save(GlobalBLL.userML) > 0)
                        {

                            if (!string.IsNullOrEmpty(PathFileNameTextBox.Text))
                            {
                                if (!System.IO.Directory.Exists(GlobalBLL.DirectoryFiles)) System.IO.Directory.CreateDirectory(GlobalBLL.DirectoryFiles);

                                string lastPathFile = string.Format("{0}/{1}", GlobalBLL.DirectoryFiles, lastImage);
                                if (System.IO.Path.GetFullPath(lastPathFile) != PathFileNameTextBox.Text)
                                {
                                    System.IO.File.Delete(lastPathFile);
                                    System.IO.File.Copy(PathFileNameTextBox.Text, string.Format("{0}/{1}", GlobalBLL.DirectoryFiles, System.IO.Path.GetFileName(PathFileNameTextBox.Text)));
                                }
                            }

                            Alerts.cFAT100010 alr = new Alerts.cFAT100010("Información", "Guardado correctamente", MessageBoxIcon.Information);
                            alr.ShowDialog();
                        }
                    }
                    else
                    {
                        Alerts.cFAT100010 alr = new Alerts.cFAT100010("ERROR", "El nombre de usuario se encuentra en uso.", MessageBoxIcon.Error);
                        alr.ShowDialog();
                    }
                }

            }
            catch (Exception ex)
            {
                Alerts.cFAT100010 alr = new Alerts.cFAT100010("ERROR", string.Format("cFMSE110010_Load: {0}", ex.Message), MessageBoxIcon.Error);
                alr.ShowDialog();
            }
        }

        private void ClearUserButton_Click(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void SearchProfileButton_Click(object sender, EventArgs e)
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

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (ProfilePictureBox.BackgroundImage != null)
                            ProfilePictureBox.BackgroundImage.Dispose();
                        //LogoPictureBox.BackgroundImage = null;
                        //LogoPictureBox.Update();

                        ProfilePictureBox.BackgroundImage = new Bitmap(openFileDialog.FileName);
                        PathFileProfileTextBox.Text = openFileDialog.FileName;
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
    }
}
