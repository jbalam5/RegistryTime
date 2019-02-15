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


namespace RegistryTime.Forms
{
    public partial class cFMEM110010 : Form
    {
        public int IdEmployee = 0;

        public int IdUser = 0;
        public int DaysWorks = 0;

        DepartamentBLL DepartamentBLL = new DepartamentBLL();
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
                EmployeeBLL EmployeeBLL = new EmployeeBLL();
                UsersBLL UsersBLL = new UsersBLL();
                DaysOfWorkEmployeeBLL DaysOfWorkEmployeeBLL = new DaysOfWorkEmployeeBLL();
                DataRow EmployeeRow;
                DataRow UserRow;
                
                if(EmployeeBLL.GetIdEntity(id).Rows.Count > 0)
                {
                    EmployeeRow = EmployeeBLL.GetIdEntity(id).Rows[0];
                    textBoxRfc.Text = EmployeeRow[EmployeeML.DataBase.Rfc].ToString();
                    textBoxCurp.Text = EmployeeRow[EmployeeML.DataBase.Curp].ToString();
                    textBoxNombre.Text = EmployeeRow[EmployeeML.DataBase.Name].ToString();
                    textBoxApellidos.Text = EmployeeRow[EmployeeML.DataBase.Lastname].ToString();
                    dateTimeFechaNacimiento.Text = Convert.ToDateTime(EmployeeRow[EmployeeML.DataBase.Birthdate]).ToString();
                    textBoxNacionalidad.Text = EmployeeRow[EmployeeML.DataBase.Nationality].ToString();
                    textBoxCalle.Text = EmployeeRow[EmployeeML.DataBase.Address].ToString();
                    textBoxPais.Text = EmployeeRow[EmployeeML.DataBase.Country].ToString();
                    textBoxMunicipio.Text = EmployeeRow[EmployeeML.DataBase.Municipality].ToString();
                    textBoxEmail.Text = EmployeeRow[EmployeeML.DataBase.Email].ToString();
                    textBoxColonia.Text = EmployeeRow[EmployeeML.DataBase.Colony].ToString();
                    textBoxTelefono.Text = EmployeeRow[EmployeeML.DataBase.Telephone].ToString();
                    textBoxCodigoPostal.Text = EmployeeRow[EmployeeML.DataBase.PostalCode].ToString();
                    textBoxEstado.Text = EmployeeRow[EmployeeML.DataBase.StateCountry].ToString();
                    textBoxNumControl.Text = EmployeeRow[EmployeeML.DataBase.ControlNumber].ToString();
                    textBoxNumSeguro.Text = EmployeeRow[EmployeeML.DataBase.NumberSure].ToString();
                    textBoxSueldo.Text = EmployeeRow[EmployeeML.DataBase.Salary].ToString();
                    comboBoxDepartamento.SelectedValue = EmployeeRow[EmployeeML.DataBase.IdDepartament].ToString();
                    comboBoxEscolaridad.SelectedValue = EmployeeRow[EmployeeML.DataBase.Scholarship].ToString();
                    comboBoxPuesto.SelectedValue = EmployeeRow[EmployeeML.DataBase.IdJob].ToString(); 
                    comboBoxEstadoCivil.SelectedValue = EmployeeRow[EmployeeML.DataBase.CivilStatus].ToString();
                }
                if ( UsersBLL.GetIdEntity(id).Rows.Count > 0){
                    UserRow = UsersBLL.GetIdEntity(id).Rows[0];
                    
                    textBoxUsuario.Text = UserRow[UsersML.DataBase.UserName].ToString();
                    textBoxPassword.Text =  UserRow[UsersML.DataBase.Password].ToString();
                    comboBoxRol.SelectedValue = UserRow[UsersML.DataBase.Rol].ToString();
                    IdUser = Convert.ToInt32( UserRow[UsersML.DataBase.Id].ToString());

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("buttonGuardar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            textBoxSueldo.Text = String.Empty;


        }

        public bool FormValidate()
        {
            try
            {
                bool Valid = true;

                if (string.IsNullOrEmpty(textBoxCurp.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingesar Curp");
                }
                else if (string.IsNullOrEmpty(textBoxNombre.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingesar el Nombre");
                }
                else if (string.IsNullOrEmpty(textBoxApellidos.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingesar el Apellidos");
                }
                else if (String.IsNullOrEmpty(textBoxCalle.Text)){
                    Valid = false;
                    throw new Exception("Debe ingesar el Calle");
                }
                else if (String.IsNullOrEmpty(textBoxTelefono.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingesar el Telefono");
                }
                else if (String.IsNullOrEmpty(comboBoxDepartamento.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingesar Departamento");
                }
                else if (String.IsNullOrEmpty(comboBoxPuesto.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingesar Puesto");
                }
                else if (String.IsNullOrEmpty(textBoxUsuario.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingesar un Usuario");
                }
                else if (String.IsNullOrEmpty(textBoxPassword.Text)){
                    Valid = false;
                    throw new Exception("Debe ingesar un Password");
                }
                
                else if (String.IsNullOrEmpty(comboBoxRol.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingesar rol");
                }
                
                return Valid;
            }
            catch (Exception ex)
            {
                cFAT100010 alr = new Alerts.cFAT100010("ERROR", string.Format("{0}", ex.Message), MessageBoxIcon.Error);
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
                    Rol = int.Parse(comboBoxRol.SelectedValue.ToString())
                };

                if(IdUser > 0)
                {
                    User.Id = IdUser;
                    User.IdUserUpdate = 1;
                }
                
                UsersBLL UsersBALL = new UsersBLL();
                EmployeeML Employee = new EmployeeML
                {
                    RFC = textBoxRfc.Text,
                    Curp = textBoxCurp.Text,
                    Name = textBoxNombre.Text,
                    LastName = textBoxApellidos.Text,
                    Scholarship = comboBoxEscolaridad.SelectedValue.ToString(),
                    Birthdate = dateTimeFechaNacimiento.Value.Date.ToShortDateString(),
                    Nationality = textBoxNacionalidad.Text,
                    Address = textBoxCalle.Text,
                    Municipality = textBoxMunicipio.Text,
                    Country = textBoxPais.Text,
                    Email = textBoxCalle.Text,
                    Telephone = textBoxTelefono.Text,
                    CivilStatus = comboBoxEstadoCivil.SelectedValue.ToString(),
                    PostalCode = Int32.Parse(textBoxCodigoPostal.Text),
                    Colony = textBoxColonia.Text,
                    StateCountry = textBoxEstado.Text,
                    ControlNumber = textBoxNumControl.Text,
                    AdmissionDate = dateTimeFechaIngreso.Value,
                    IdDepartament = Int32.Parse(comboBoxDepartamento.SelectedValue.ToString()),
                    IdJob = Int32.Parse(comboBoxPuesto.SelectedValue.ToString()),
                    SureType = textBoxNumSeguro.Text,
                    NumberSure = textBoxNumSeguro.Text,
                    Salary= Convert.ToDecimal( textBoxSueldo.Text),
                    IdUserInsert = 0
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
                        IdUserInsert = 1
                    };
                    DaysOfWorkEmployeeBLL.Save(DaysOfWorkEmployee);
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
                MessageBox.Show(String.Format("buttonGuardar_Click: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel5_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        public void LoadScholarship()
        {
            try
            {

                comboBoxEscolaridad.DisplayMember = "Text";
                comboBoxEscolaridad.ValueMember = "Value";

                var items = new[] {
                    new { Text = "Seleccione un opción", Value = "0" },
                    new { Text = "Primaria", Value = "primaria" },
                    new { Text = "Secundaria", Value = "secundaria" },
                    new { Text = "Preparatoria", Value = "preparatoria" },
                    new { Text = "Universidad", Value = "universidad" }
                };

                comboBoxEscolaridad.DataSource = items;

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadEscolaridad: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadTypeSure()
        {
            try
            {
                comboBoxTipoSeguro.DisplayMember = "Text";
                comboBoxTipoSeguro.ValueMember = "Value";

                var items = new[] {
                    new { Text = "Seleccione un opción", Value = "0" },
                    new { Text = "IMSS", Value = "IMSS" },
                    new { Text = "IMSTE", Value = "IMSTE" }
                };

                comboBoxTipoSeguro.DataSource = items;

            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("LoadTypeSure: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            


        public void LoadCivilStatus()
        {
            try
            {

                comboBoxEstadoCivil.DisplayMember = "Text";
                comboBoxEstadoCivil.ValueMember = "Value";
                
                var items = new[] {
                    new { Text = "Seleccione un opción", Value = "0" },
                    new { Text = "Soltero/a", Value = "Soltero" },
                    new { Text = "Casado/a", Value = "Casado" },
                    new { Text = "Divorciado/a", Value = "Divorciado" }
                };

                comboBoxEstadoCivil.DataSource = items;

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadEstadoCivil: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadDepartaments()
        {
            try
            {
                DepartamentBLL DepartamentBLL = new DepartamentBLL();
                DataTable Departamentos;
                Departamentos = DepartamentBLL.All();
                comboBoxDepartamento.DisplayMember = "Text";
                comboBoxDepartamento.ValueMember = "Value";

                List<Object> items = new List<object>();
                items.Add(new { Text = "Seleccione un opción", Value = "0" });
                foreach (DataRow Depatamento in Departamentos.Rows)
                {
                    items.Add(new { Text = Depatamento[1].ToString(), Value = Depatamento[0].ToString() });
                }



                comboBoxDepartamento.DataSource = items;

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadDepartaments: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadJobs()
        {
            try
            {
                JobBLL JobBLL = new JobBLL();
                DataTable Jobs;
                Jobs = JobBLL.All();
                comboBoxPuesto.DisplayMember = "Text";
                comboBoxPuesto.ValueMember = "Value";

                List<Object> items = new List<object>();
                items.Add(new { Text = "Seleccione un opción", Value = "0" });
                foreach (DataRow Job in Jobs.Rows)
                {
                    items.Add(new { Text = Job[1].ToString(), Value = Job[0].ToString() });
                }

                comboBoxPuesto.DataSource = items;

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadJobs: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    items.Add(new { Text = Rol[1].ToString(), Value = Rol[0].ToString() });
                }

                comboBoxRol.DataSource = items;

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadJobs: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    checkedListBoxDias.Items.Add(new { Text = Day[1].ToString(), Value = Day[0].ToString() }, false);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadJobs: {0}", ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

