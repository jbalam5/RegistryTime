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

        public void LoadTurnId(int IdTurno)
        {
            try
            {
                TurnML Turn = TurnBLL.GetIdEntity(IdTurn);

                IdTurn = Convert.ToInt32(Turn.Id.ToString());
                textBoxTurno.Text = Turn.Name.ToString();
                textBoxDescripcion.Text = Turn.Description.ToString();
                dateTimeHoraEntrada.Text = Turn.TimeEntry.ToString();
                dateTimeIniciaEntrada.Text = Turn.StartEntry.ToString();
                dateTimeLimiteEntrada.Text = Turn.LimitEntry.ToString();
                dateTimeHoraSalida.Text = Turn.Departuretime.ToString();
                dateTimeLimiteSalida.Text = Turn.LimitDeparture.ToString();
                textBoxHorasJornada.Text = Turn.HoursJornada.ToString("HH:mm:ss");
            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("LoadTurnId: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cFRT140010_Load(object sender, EventArgs e)
        {
            if(IdTurn > 0)
                LoadTurnId(IdTurn);

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

        public void CalcHorasJornada(int hora24 = 0)
        {
            try
            {
                if(hora24 == 1)
                {
                    //MessageBox.Show("2");
                    double ho = dateTimeHoraSalida.Value.Subtract(dateTimeHoraEntrada.Value).TotalHours;
                    double timeS = ((24 + ho)*60)*60;
                    DateTime Hor = new DateTime(2000, 1, 1, 0, 0, 0);
                    textBoxHorasJornada.Text = Hor.AddSeconds(timeS).ToString("HH:mm:ss");
                        //DateTime.Parse("00:000:00").AddHours(timeS).ToString();
                }
                else
                {
                    var minutes = dateTimeHoraSalida.Value.Subtract(dateTimeHoraEntrada.Value);
                    textBoxHorasJornada.Text = minutes.ToString();
                }
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
                    TurnML Turn = new TurnML()
                    {
                        Name = textBoxTurno.Text,
                        Description = textBoxDescripcion.Text,
                        TimeEntry = dateTimeHoraEntrada.Value,
                        StartEntry = dateTimeIniciaEntrada.Value,
                        LimitEntry = dateTimeLimiteEntrada.Value,
                        Departuretime = dateTimeHoraSalida.Value,
                        LimitDeparture = dateTimeLimiteSalida.Value,
                        HoursJornada = Convert.ToDateTime(textBoxHorasJornada.Text)
                    };

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
                if(dateTimeHoraEntrada.Value > Convert.ToDateTime("12:00:00") && dateTimeHoraSalida.Value < Convert.ToDateTime("12:00:00"))
                    CalcHorasJornada(1);

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
            //if(dateTimeHoraEntrada.Value > dateTimeLimiteSalida.Value)
            //{
            //    dateTimeHoraSalida.Value = dateTimeIniciaEntrada.Value;
            //}
            //else
            //{
            //CalcHorasJornada();
            //}
            TimeSpan HEnt = TimeSpan.Parse(dateTimeHoraEntrada.Value.ToString("HH:mm:ss"));
            TimeSpan HSal = TimeSpan.Parse(dateTimeHoraSalida.Value.ToString("HH:mm:ss"));
            TimeSpan ti = TimeSpan.Parse("12:00:00");
            //if (dateTimeHoraEntrada.Value > Convert.ToDateTime("12:00:00") && dateTimeHoraSalida.Value < Convert.ToDateTime("12:00:00"))
            if(HEnt > ti && HSal < ti)
                CalcHorasJornada(1);
            else
                CalcHorasJornada();
        }
    }
}
