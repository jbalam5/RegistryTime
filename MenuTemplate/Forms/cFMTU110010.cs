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
    public partial class cFMTU110010 : Form
    {
        public int IdTurn = 0;
        TurnBLL TurnBLL = new TurnBLL();

        public cFMTU110010()
        {
            InitializeComponent();
        }

        private void cFRT140010_Load(object sender, EventArgs e)
        {
            //dateTimeLimiteEntrada.Format = DateTimePickerFormat.Time;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            textBoxTurno.Text = String.Empty;
            textBoxDescripcion.Text = String.Empty;
            textBoxHorasJornada.Text = "0";
            dateTimeHoraEntrada.CustomFormat = "HH:mm:ss";
            dateTimeHoraEntrada.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dateTimeIniciaEntrada.CustomFormat = "HH:mm:ss";
            dateTimeIniciaEntrada.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dateTimeLimiteEntrada.CustomFormat = "HH:mm:ss";
            dateTimeLimiteEntrada.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dateTimeHoraSalida.CustomFormat = "HH:mm:ss";
            dateTimeHoraSalida.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dateTimeLimiteSalida.CustomFormat = "HH:mm:ss";
            dateTimeLimiteSalida.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        }

        public void CalcHorasJornada()
        {
            try
            {
                var minutes = dateTimeHoraSalida.Value.Subtract(dateTimeHoraEntrada.Value);
                textBoxHorasJornada.Text = minutes.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("CalcHorasJornada: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool FormValidate()
        {
            try
            {
                bool Valid = true;

                if (string.IsNullOrEmpty(textBoxTurno.Text))
                {
                    Valid = false;
                    throw new Exception("Ingrese Nombre");
                }
                return Valid;
            }
            catch (Exception ex)
            {
                cFAT100010 alr = new Alerts.cFAT100010("EROR", string.Format("{0}", ex.Message), MessageBoxIcon.Error);
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
                    TurnML Turn = new TurnML();
                    
                    Turn.Name = textBoxTurno.Text;
                    Turn.Description = textBoxDescripcion.Text;
                    Turn.TimeEntry = dateTimeHoraEntrada.Value;
                    Turn.StartEntry = dateTimeIniciaEntrada.Value;
                    Turn.LimitEntry = dateTimeLimiteEntrada.Value;
                    Turn.Departuretime = dateTimeHoraSalida.Value;
                    Turn.LimitDeparture = dateTimeLimiteSalida.Value;
                    Turn.HoursJornada = Convert.ToDateTime(textBoxHorasJornada.Text);

                    if (IdTurn > 0)
                    {
                        Turn.Id = IdTurn;
                    }
                    
                    TurnBLL.Save(Turn);

                    cFMTU100010 FrmDataGrid = this.Owner as cFMTU100010;
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

        private void cFMTU110010_Resize(object sender, EventArgs e)
        {
            tabControl1.Width = this.Width - 50;
            tabControl1.Height = this.Height - 180;
        }

        private void dateTimeHoraEntrada_ValueChanged(object sender, EventArgs e)
        {
            dateTimeIniciaEntrada.Value = dateTimeHoraEntrada.Value;
            dateTimeLimiteEntrada.Value = dateTimeHoraEntrada.Value;
            
            if(dateTimeHoraSalida.Value > dateTimeHoraEntrada.Value)
            {
                CalcHorasJornada();
            }
            else
            {
                dateTimeHoraSalida.Value = dateTimeHoraEntrada.Value;
            }


        }

        private void dateTimeHoraSalida_ValueChanged(object sender, EventArgs e)
        {       
            dateTimeLimiteSalida.Value = dateTimeHoraSalida.Value;
            if(dateTimeHoraEntrada.Value > dateTimeLimiteSalida.Value)
            {
                dateTimeHoraSalida.Value = dateTimeIniciaEntrada.Value;
            }
            else
            {
                CalcHorasJornada();
            }
        }
    }
}
