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
    public partial class cFMAA110010 : Form
    {
        public int IdAbsenteeismAssignment = 0;

        public int IdOject = 0;
        public int idObject = 0;

        AbsenteeismAssignmentBLL AbsenteeismAssignmentBLL = new AbsenteeismAssignmentBLL();
        EmployeeBLL EmployeeBLL = new EmployeeBLL();

        public cFMAA110010()
        {
            InitializeComponent();
        }

        public void LoadObject()
        {
            try
            {
                EmployeeBLL EmployeeBLL = new EmployeeBLL();
                EmployeeML Employee = EmployeeBLL.GetIdEntity(idObject);
                textBoxNumControl.Text = Employee.Id.ToString();
                textBoxNombre.Text = Employee.Name.ToString();
                textBoxApellidoM.Text = Employee.LastName.ToString();

                DepartamentBLL DepartamentBLL = new DepartamentBLL();
                DepartamentML Departament = DepartamentBLL.GetIdEntity(Employee.IdDepartament);
                textBoxDepartamento.Text = Departament.Name.ToString();

                JobBLL JobBLL = new JobBLL();
                JobML Job = JobBLL.GetIdEntity(Employee.IdJob);
                textBoxPuesto.Text = Job.Name;


                
            }catch(Exception ex)
            {

            }
        }

        private void cFRT140010_Load(object sender, EventArgs e)
        {
            LoadAbsenteissm();
            LoadStatus();

            if(IdOject > 0)
            {
                cargardata(IdOject);
            }
        }

        public void cargardata(int IdOject)
        {
            ModelLayer.EmployeeML HelpEmployee = EmployeeBLL.GetIdEntity(IdOject);
            textBoxNumControl.Text = HelpEmployee.Id.ToString();

            if (idObject > 0)
                LoadObject();

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            textBoxNumControl.Text = String.Empty;
            textBoxNombre.Text = String.Empty;
            textBoxApellidoP.Text = String.Empty;
            textBoxDepartamento.Text = String.Empty;
            textBoxPuesto.Text = String.Empty;

            comboBoxAusentismo.SelectedIndex = 0;
            comboBoxEstadoAsig.SelectedIndex = 0;
            textBoxDescripcion.Text = String.Empty;
            dateTimeFechaInicio.Text = String.Empty;
            dateTimeFechaFin.Text = String.Empty;      
        }

        public bool FormValidate()
        {
            try
            {
                bool Valid = true;

                if (string.IsNullOrEmpty(textBoxNumControl.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingresar un Numero de Control");
                }
                else if (string.IsNullOrEmpty(textBoxNombre.Text))
                {
                    Valid = false;
                    throw new Exception("Debe ingresar un Número de control válido");
                }
                else if (int.Parse(comboBoxAusentismo.SelectedValue.ToString()) == 0)
                {
                    Valid = false;
                    throw new Exception("Debe ingresar el Concepto de Ausentismo");
                }
                else if (comboBoxEstadoAsig.SelectedValue.ToString() == "")
                {
                    Valid = false;
                    throw new Exception("Seleccione un estatus del ausentismo");
                }
                else if (dateTimeFechaInicio.Value > dateTimeFechaFin.Value) 
                {
                    Valid = false;
                    throw new Exception("La Fecha de inicio no debe ser menor a la fecha fin");
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
                    AbsenteeismAssignmentML AsigAusentismo = new AbsenteeismAssignmentML();

                    AsigAusentismo.controlNumber = textBoxNumControl.Text;
                    AsigAusentismo.KeyAbsenteeism = comboBoxAusentismo.Text;
                    AsigAusentismo.Status = comboBoxEstadoAsig.Text;
                    AsigAusentismo.DateStar = dateTimeFechaInicio.Value;
                    AsigAusentismo.DateEnd = dateTimeFechaFin.Value;
                    AsigAusentismo.Description = textBoxDescripcion.Text;
                    
                    if (IdAbsenteeismAssignment > 0)
                    {
                        AsigAusentismo.Id = IdAbsenteeismAssignment;
                    }

                    AbsenteeismAssignmentBLL.Save(AsigAusentismo);

                    cFMAA100010 FrmDataGrid = this.Owner as cFMAA100010;
                    FrmDataGrid.LoadDataGridView();

                    cFAT100010 Alert = new cFAT100010("Información", "Información Guardado con éxito!!", MessageBoxIcon.Information);
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

        private void cFMAA110010_Resize(object sender, EventArgs e)
        {
            //textBoxPuesto.Width = this.Width - 200;
            //textBoxDescripcion.Width = this.Width - 200;
            
        }

        private void textBoxNumControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                RegistryTime.Help.cFHAA100010 frm = new Help.cFHAA100010();
                AddOwnedForm(frm);
                frm.ShowDialog();
            }
        }

        public void LoadAbsenteissm()
        {
            try
            {
                AbsenteeismBLL AbsenteeismBLL = new AbsenteeismBLL();
                DataTable Conceptos;
                Conceptos = AbsenteeismBLL.All();
                comboBoxAusentismo.DisplayMember = "Text";
                comboBoxAusentismo.ValueMember = "Value";

                List<Object> items = new List<object>();
                items.Add(new { Text = "Seleccione una opción", Value = "0" });
                foreach (DataRow Concepto in Conceptos.Rows)
                {
                    items.Add(new { Text = Concepto[1].ToString(), Value = Concepto[0].ToString() });
                }
                comboBoxAusentismo.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadAbsenteissm: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadStatus()
        {
            try
            {

                comboBoxEstadoAsig.DisplayMember = "Text";
                comboBoxEstadoAsig.ValueMember = "Value";

                var items = new[] {
                    new { Text = "Seleccione una opción", Value = "" },
                    new { Text = "Aceptada", Value = "aceptada" },
                    new { Text = "Rechazada", Value = "rechazada" }
                };

                comboBoxEstadoAsig.DataSource = items;

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("LoadStatus: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
