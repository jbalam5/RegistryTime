using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLayer;
using ModelLayer;
using Alerts;
using System.Data.SqlClient;

namespace RegistryTime.Forms
{
    public partial class cFMEM110010 : Form
    {
        
        public int IdEmployee = 0;
        private String DirectoryFiles = "ImagenTMP/Employee";
        private String PathFileImage = String.Empty;
        private String PathFileImageOld = String.Empty;
        public int IdUser = 0;
        public int DaysWorks = 0;

        DepartamentBLL DepartamentBLL = new DepartamentBLL();
        RegularExpressionBLL RegularExpressionBLL = new RegularExpressionBLL();
        UsersBLL UsersBLL = new UsersBLL();
        DaysOfWorkEmployeeBLL DaysOfWorkEmployeeBLL = new DaysOfWorkEmployeeBLL();
        EmployeeBLL EmployeeBLL = new EmployeeBLL();
        TurnsOfEmployeeBLL TurnsOfEmployeeBLL = new TurnsOfEmployeeBLL();
        UsersML UsersML = new UsersML();
        DaysOfWorkEmployeeML DaysOfWorkEmployeeML = new DaysOfWorkEmployeeML();

        public cFMEM110010()
        {
            InitializeComponent();
        }

        public void LoadGetEmployee(int id)
        {
            try
            {

                EmployeeML EmployeeML = new EmployeeML();
                EmployeeML EmployeeEntiy;
                UsersML UserEntity;
                
                if(EmployeeBLL.GetIdEntity(id).Id > 0)
                {
                    EmployeeEntiy = EmployeeBLL.GetIdEntity(id);
                    if(radioButtonHombre.Text == EmployeeEntiy.Gender.ToString())
                    {
                        radioButtonHombre.Checked = true;
                    }
                    else
                    {
                        radioButtonMujer.Checked = true;
                    }

                    textBoxRfc.Text = EmployeeEntiy.RFC.ToString();
                    textBoxCurp.Text = EmployeeEntiy.Curp.ToString();
                    textBoxNombre.Text = EmployeeEntiy.Name.ToString();
                    textBoxApellidos.Text = EmployeeEntiy.LastName.ToString();
                    dateTimeFechaNacimiento.Text = Convert.ToDateTime(EmployeeEntiy.Birthdate).ToString();
                    textBoxNacionalidad.Text = EmployeeEntiy.Nationality.ToString();
                    textBoxCalle.Text = EmployeeEntiy.Address.ToString();
                    textBoxPais.Text = EmployeeEntiy.Country.ToString();
                    textBoxMunicipio.Text = EmployeeEntiy.Municipality.ToString();
                    textBoxEmail.Text = EmployeeEntiy.Email.ToString();
                    textBoxColonia.Text = EmployeeEntiy.Colony.ToString();
                    textBoxTelefono.Text = EmployeeEntiy.Telephone.ToString();
                    textBoxCodigoPostal.Text = EmployeeEntiy.PostalCode.ToString();
                    textBoxEstado.Text = EmployeeEntiy.StateCountry.ToString();
                    textBoxNumControl.Text = EmployeeEntiy.ControlNumber.ToString();
                    textBoxNumSeguro.Text = EmployeeEntiy.NumberSure.ToString();
                    textBoxSueldo.Text = EmployeeEntiy.Salary.ToString();
                    comboBoxTipoSeguro.SelectedValue = EmployeeEntiy.SureType.ToString();
                    comboBoxDepartamento.SelectedValue = EmployeeEntiy.IdDepartament.ToString();
                    comboBoxEscolaridad.SelectedValue = EmployeeEntiy.Scholarship.ToString();
                    comboBoxPuesto.SelectedValue = EmployeeEntiy.IdJob.ToString(); 
                    comboBoxEstadoCivil.SelectedValue = EmployeeEntiy.CivilStatus.ToString();
                }
                if ( !String.IsNullOrEmpty(UsersBLL.GetEntityById(id).UserName)){
                    UserEntity = UsersBLL.GetEntityById(id);
                    
                    textBoxUsuario.Text = UserEntity.UserName.ToString();
                    textBoxPassword.Text = UserEntity.Password.ToString();
                    comboBoxRol.SelectedValue = UserEntity.Rol.ToString();
                    PathFileNameTextBox.Text = UserEntity.Image.ToString();
                    IdUser = Convert.ToInt32( UserEntity.Id.ToString());
                    if (!string.IsNullOrEmpty(UserEntity.Image.ToString()))
                    {
                        String FilePath = string.Format("{0}\\{1}", System.IO.Path.GetFullPath(DirectoryFiles), UserEntity.Image.ToString());
                        PathFileImageOld = FilePath;
                        if (System.IO.File.Exists(FilePath))
                            pictureBoxImage.BackgroundImage = new Bitmap(FilePath);
                        else
                            throw new Exception("No se encontró la imagen");
                    }

                }
                if(DaysOfWorkEmployeeBLL.GetAllEntitys(id).Rows.Count > 0)
                {
                    int loop;
                    foreach (DataRow DaysWorkRow in DaysOfWorkEmployeeBLL.GetAllEntitys(id).Rows)
                    {
                        loop = 0;
                        foreach (object item in checkedListBoxDias.Items)
                        {
                            
                            if(DaysWorkRow[DaysOfWorkEmployeeML.DataBase.IdDays].ToString() == item.GetType().GetProperty("Value").GetValue(item, null).ToString())
                            {
                                checkedListBoxDias.SetItemChecked(loop, true);
                                break;
                            }

                            loop++;
                        }
                    }
                }


                if (TurnsOfEmployeeBLL.GetAllEntitys(id).Rows.Count > 0)
                {
                    int loopTurn;
                    foreach (DataRow TurnsOfEmployees in TurnsOfEmployeeBLL.GetAllEntitys(id).Rows)
                    {
                        loopTurn = 0;
                        foreach (object item in checkedListBoxTurns.Items)
                        {

                            if (TurnsOfEmployees[TurnsOfEmployeeML.DataBase.IdTurn].ToString() == item.GetType().GetProperty("Value").GetValue(item, null).ToString())
                            {
                                checkedListBoxTurns.SetItemChecked(loopTurn, true);
                                break;
                            }

                            loopTurn++;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonGuardar_Click: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cFRT140010_Load(object sender, EventArgs e)
        {
            LoadScholarship();
            LoadCivilStatus();
            LoadDepartaments();
            LoadJobs();
            LoadDays();
            LoadRol();
            LoadTurn();
            LoadTypeSure();
            if (IdEmployee > 0)
            {
                LoadGetEmployee(IdEmployee);
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            
            textBoxRfc.Text = String.Empty;
            textBoxCurp.Text = String.Empty;
            textBoxNombre.Text = String.Empty;
            textBoxApellidos.Text = String.Empty;
            dateTimeFechaNacimiento.Text = DateTime.Now.ToString();
            textBoxNacionalidad.Text = String.Empty;
            textBoxCalle.Text = String.Empty;
            textBoxPais.Text = String.Empty;
            textBoxMunicipio.Text = String.Empty;
            textBoxEmail.Text = String.Empty;
            textBoxColonia.Text = String.Empty;
            textBoxTelefono.Text = String.Empty;
            textBoxCodigoPostal.Text = String.Empty;
            textBoxEstado.Text = String.Empty;
            textBoxNumControl.Text = String.Empty;
            textBoxNumSeguro.Text = String.Empty;
            comboBoxDepartamento.SelectedIndex = 0;
            comboBoxPuesto.SelectedIndex = 0;
            comboBoxRol.SelectedIndex = 0;
            textBoxUsuario.Text = String.Empty;
            textBoxPassword.Text = String.Empty;
            comboBoxEstadoCivil.SelectedIndex = 0;
            comboBoxEscolaridad.SelectedIndex = 0;
            comboBoxTipoSeguro.SelectedIndex = 0;
            textBoxSueldo.Text = String.Empty;
            PathFileNameTextBox.Text = String.Empty;
        }

        public bool FormValidate()
        {
            try
            {
                bool Valid = true;

                if (string.IsNullOrEmpty(textBoxCurp.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingresar Curp");
                }
                else if (string.IsNullOrEmpty(textBoxNombre.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingresar el Nombre");
                }
                else if (string.IsNullOrEmpty(textBoxApellidos.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingresar el Apellidos");
                }
                else if (comboBoxEscolaridad.SelectedValue.ToString() == "")
                {
                    Valid = false;
                    throw new Exception("Seleccione una escolaridad");
                }
                
                else if (String.IsNullOrEmpty(textBoxCalle.Text)){
                    Valid = false;
                    throw new Exception("Debe ingresar el Calle");
                }
                else if (String.IsNullOrEmpty(textBoxTelefono.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingesar el Telefono");
                }
                else if (comboBoxEstadoCivil.SelectedValue.ToString() == "")
                {
                    Valid = false;
                    throw new Exception("Seleccione estado civil");
                }
                else if (int.Parse(comboBoxDepartamento.SelectedValue.ToString()) == 0)
                {
                    Valid = false;
                    throw new Exception("Debe ingresar Departamento");
                }
                else if (int.Parse(comboBoxPuesto.SelectedValue.ToString()) == 0)
                {
                    Valid = false;
                    throw new Exception("Seleccione un puesto");
                }
                else if (comboBoxTipoSeguro.SelectedValue.ToString() == "")
                {
                    Valid = false;
                    throw new Exception("Seleccione tipo de seguro");
                }
                else if (String.IsNullOrEmpty(textBoxUsuario.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingresar un Usuario");
                }
                else if (String.IsNullOrEmpty(textBoxPassword.Text)){
                    Valid = false;
                    throw new Exception("Debe ingresar un Password");
                }
                
                else if (String.IsNullOrEmpty(comboBoxRol.SelectedValue.ToString()))
                {
                    Valid = false;
                    throw new Exception("Debe ingresar rol");
                }
                else if (UsersBLL.UserExists(textBoxUsuario.Text) && IdUser == 0)
                {
                    Valid = false;
                    throw new Exception("El usuario ya existe");
                }
                else if (!RegularExpressionBLL.SingleNumber(textBoxCodigoPostal.Text))
                {
                    Valid = false;
                    throw new Exception("Ingrese Codigo Postal Valido");
                }
                else if (!RegularExpressionBLL.ValidEmal(textBoxEmail.Text))
                {
                    Valid = false;
                    throw new Exception("Ingrese Correo electronico Valido");
                }
                else if (!RegularExpressionBLL.ValidDecimal(textBoxSueldo.Text))
                {
                    Valid = false;
                    throw new Exception("Ingrese sueldo valido");
                }
                
                return Valid;
            }
            catch (Exception ex)
            {
                cFAT100010 alr = new Alerts.cFAT100010("ERROR", string.Format("{0}", ex), MessageBoxIcon.Error);
                alr.ShowDialog();
                return false;
            }

        }



        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormValidate())
                {

                UsersML User = new UsersML
                {
                    UserName = textBoxUsuario.Text,
                    Password = textBoxPassword.Text,
                    Image = System.IO.Path.GetFileName(PathFileNameTextBox.Text),
                    Rol = int.Parse(comboBoxRol.SelectedValue.ToString())

                };

                if(IdUser > 0)
                {
                    User.Id = IdUser;
                    User.IdUserUpdate = GlobalBLL.userML.Id;
                }
                
                UsersBLL UsersBALL = new UsersBLL();
                EmployeeML Employee = new EmployeeML
                {
                    RFC = textBoxRfc.Text,
                    Curp = textBoxCurp.Text,
                    Name = textBoxNombre.Text,
                    LastName = textBoxApellidos.Text,
                    Scholarship = comboBoxEscolaridad.SelectedValue.ToString(),
                    Birthdate = dateTimeFechaNacimiento.Value,
                    Nationality = textBoxNacionalidad.Text,
                    Address = textBoxCalle.Text,
                    Municipality = textBoxMunicipio.Text,
                    Country = textBoxPais.Text,
                    Email = textBoxEmail.Text,
                    Telephone = textBoxTelefono.Text,
                    CivilStatus = comboBoxEstadoCivil.SelectedValue.ToString(),
                    PostalCode = (String.IsNullOrEmpty(textBoxCodigoPostal.Text))?0: int.Parse(textBoxCodigoPostal.Text),
                    Colony = textBoxColonia.Text,
                    StateCountry = textBoxEstado.Text,
                    ControlNumber = textBoxNumControl.Text,
                    AdmissionDate = dateTimeFechaIngreso.Value,
                    IdDepartament = Int32.Parse(comboBoxDepartamento.SelectedValue.ToString()),
                    IdJob = Int32.Parse(comboBoxPuesto.SelectedValue.ToString()),
                    SureType = comboBoxTipoSeguro.SelectedValue.ToString(),
                    NumberSure = textBoxNumSeguro.Text,
                    Salary= Convert.ToDecimal( textBoxSueldo.Text),
                    IdUserInsert = GlobalBLL.userML.Id
                };

                if (radioButtonHombre.Checked)
                {
                    Employee.Gender = "Hombre";
                }
                else
                {
                    Employee.Gender = "Mujer";
                }
              
                if(IdEmployee > 0)
                {
                    Employee.Id = IdEmployee;
                }
                Employee.IdUser = UsersBALL.Save(User);
                EmployeeBLL EmployeeBLL = new EmployeeBLL();
                int IdNewEmployee = EmployeeBLL.Save(Employee);

                DaysOfWorkEmployeeBLL DaysOfWorkEmployeeBLL = new DaysOfWorkEmployeeBLL();
                DaysOfWorkEmployeeBLL.DeleteRegistrys(IdEmployee);
                foreach (object item in checkedListBoxDias.CheckedItems)
                {
                    DaysOfWorkEmployeeML DaysOfWorkEmployee = new DaysOfWorkEmployeeML()
                    {
                        IdDays = Int32.Parse(item.GetType().GetProperty("Value").GetValue(item, null).ToString()),
                        IdEmployee = IdNewEmployee,
                        IdUserInsert = GlobalBLL.userML.Id
                    };
                    DaysOfWorkEmployeeBLL.Save(DaysOfWorkEmployee);
                }

                TurnsOfEmployeeBLL TurnsOfEmployeeBLL = new TurnsOfEmployeeBLL();
                TurnsOfEmployeeBLL.DeleteRegistrys(IdEmployee);
                foreach (object item in checkedListBoxTurns.CheckedItems)
                {
                    TurnsOfEmployeeML TurnsOfEmployee = new TurnsOfEmployeeML()
                    {
                        IdTurn = Int32.Parse(item.GetType().GetProperty("Value").GetValue(item, null).ToString()),
                        IdEmployee = IdNewEmployee,
                        IdUserInsert = GlobalBLL.userML.Id
                    };
                    TurnsOfEmployeeBLL.Save(TurnsOfEmployee);
                }

                    if (!string.IsNullOrEmpty(PathFileNameTextBox.Text) && !string.IsNullOrEmpty(PathFileImage) && System.IO.Path.GetFileName(PathFileImageOld) != PathFileImage)
                {
                    if (!System.IO.Directory.Exists(DirectoryFiles)) System.IO.Directory.CreateDirectory(DirectoryFiles);

                    System.IO.File.Delete(string.Format("{0}/{1}", DirectoryFiles, PathFileNameTextBox.Text));
                    System.IO.File.Copy(PathFileImage, string.Format("{0}/{1}", DirectoryFiles, System.IO.Path.GetFileName(PathFileNameTextBox.Text)));
                }

                    cFMEM100010 FrmDataGrid = this.Owner as cFMEM100010;
                FrmDataGrid.LoadDataGridView();
                cFAT100010 Alert = new cFAT100010("Información", "Información Guardado con exito!!", MessageBoxIcon.Information);
                Alert.ShowDialog();
                Clear();
                this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonGuardar_Click: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cFMDE110010_Resize(object sender, EventArgs e)
        {
            tabControl1.Width = this.Width - 50;
            tabControl1.Height = this.Height - 180;
            checkedListBoxDias.Width = this.Width - 25;
            panel5.Width = this.Width - 50;
        }

        public void LoadScholarship()
        {
            try
            {

                comboBoxEscolaridad.DisplayMember = "Text";
                comboBoxEscolaridad.ValueMember = "Value";

                var items = new[] {
                    new { Text = "Seleccione un opción", Value = "" },
                    new { Text = "Primaria", Value = "primaria" },
                    new { Text = "Secundaria", Value = "secundaria" },
                    new { Text = "Preparatoria", Value = "preparatoria" },
                    new { Text = "Universidad", Value = "universidad" }
                };

                comboBoxEscolaridad.DataSource = items;

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadEscolaridad: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadTypeSure()
        {
            try
            {
                comboBoxTipoSeguro.DisplayMember = "Text";
                comboBoxTipoSeguro.ValueMember = "Value";

                var items = new[] {
                    new { Text = "Seleccione un opción", Value = "" },
                    new { Text = "IMSS", Value = "IMSS" },
                    new { Text = "IMSTE", Value = "IMSTE" }
                };

                comboBoxTipoSeguro.DataSource = items;

            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("LoadTypeSure: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            


        public void LoadCivilStatus()
        {
            try
            {

                comboBoxEstadoCivil.DisplayMember = "Text";
                comboBoxEstadoCivil.ValueMember = "Value";
                
                var items = new[] {
                    new { Text = "Seleccione un opción", Value = "" },
                    new { Text = "Soltero/a", Value = "Soltero" },
                    new { Text = "Casado/a", Value = "Casado" },
                    new { Text = "Divorciado/a", Value = "Divorciado" }
                };

                comboBoxEstadoCivil.DataSource = items;

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadEstadoCivil: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadDepartaments()
        {
            try
            {
                DepartamentBLL DepartamentBLL = new DepartamentBLL();
                DataTable Departamentos;
                Departamentos = DepartamentBLL.All("All");
                comboBoxDepartamento.DisplayMember = "Text";
                comboBoxDepartamento.ValueMember = "Value";

                List<Object> items = new List<object>();
                items.Add(new { Text = "Seleccione un opción", Value = "0" });
                foreach (DataRow Depatamento in Departamentos.Rows)
                {
                    items.Add(new { Text = Depatamento[DepartamentML.DataBase.Name].ToString(), Value = Depatamento[DepartamentML.DataBase.Id].ToString() });
                }
                comboBoxDepartamento.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadDepartaments: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadJobs()
        {
            try
            {
                JobBLL JobBLL = new JobBLL();
                DataTable Jobs;
                Jobs = JobBLL.All("All");
                comboBoxPuesto.DisplayMember = "Text";
                comboBoxPuesto.ValueMember = "Value";

                List<Object> items = new List<object>();
                items.Add(new { Text = "Seleccione un opción", Value = "0" });
                foreach (DataRow Job in Jobs.Rows)
                {
                    items.Add(new { Text = Job[JobML.DataBase.Name].ToString(), Value = Job[JobML.DataBase.Id].ToString() });
                }
                comboBoxPuesto.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadJobs: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadRol()
        {
            try
            {
                RoleBLL RoleBLL = new RoleBLL();
                DataTable Roles;
                Roles = RoleBLL.All();
                comboBoxRol.DisplayMember = "Text";
                comboBoxRol.ValueMember = "Value";

                List<Object> items = new List<object>();
                items.Add(new { Text = "Seleccione un opción", Value = "0" });
                foreach (DataRow Rol in Roles.Rows)
                {
                    items.Add(new { Text = Rol[RoleML.DataBase.Name].ToString(), Value = Rol[RoleML.DataBase.Id].ToString() });
                }
                comboBoxRol.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadJobs: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void LoadDays()
        {
            try
            {
                DaysBLL DaysBLL = new DaysBLL();
                DataTable Days;
                Days = DaysBLL.All();
                checkedListBoxDias.DisplayMember = "Text";
                checkedListBoxDias.ValueMember = "Value";
                foreach (DataRow Day in Days.Rows)
                {
                    checkedListBoxDias.Items.Add(new { Text = Day[DaysML.DataBase.Name].ToString(), Value = Day[DaysML.DataBase.Id].ToString() }, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadJobs: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadTurn()
        {
            try
            {
                TurnBLL TurnBLL = new TurnBLL();
                DataTable Turns;
                Turns = TurnBLL.All();
                checkedListBoxTurns.DisplayMember = "Text";
                checkedListBoxTurns.ValueMember = "Value";
                foreach (DataRow Turn in Turns.Rows)
                {
                    checkedListBoxTurns.Items.Add(new { Text = Turn[1].ToString(), Value = Turn[0].ToString() }, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadTurn: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonBuscar_Click(object sender, EventArgs e)
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
                        if (pictureBoxImage.BackgroundImage != null)
                            pictureBoxImage.BackgroundImage.Dispose();

                        pictureBoxImage.BackgroundImage = new Bitmap(openFileDialog.FileName);
                        PathFileNameTextBox.Text = openFileDialog.SafeFileName;
                        PathFileImage = openFileDialog.FileName;


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


