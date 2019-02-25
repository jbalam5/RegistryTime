﻿using System;
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
            
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBoxTurno.Text))
                {
                    TurnML Turn = new TurnML();
                    int HoursJornada = Convert.ToInt32(textBoxHorasJornada.Text);

                    Turn.Name = textBoxTurno.Text;
                    Turn.Description = textBoxDescripcion.Text;
                    Turn.TimeEntry = dateTimeHoraEntrada.Value;
                    Turn.StartEntry = dateTimeIniciaEntrada.Value;
                    Turn.LimitEntry = dateTimeLimiteEntrada.Value;
                    Turn.Departuretime = dateTimeHoraSalida.Value;
                    Turn.LimitDeparture = dateTimeLimiteSalida.Value;
                    Turn.HoursJornada = HoursJornada;

                    if (IdTurn > 0)
                    {
                        Turn.Id = IdTurn;
                        Turn.IdUserUpdate = GlobalBLL.userML.Id; ;
                    }
                    else
                    {
                        Turn.IdUserInsert = GlobalBLL.userML.Id;
                    }
                    TurnBLL.Save(Turn);

                    cFMTU100010 FrmDataGrid = this.Owner as cFMTU100010;
                    FrmDataGrid.LoadDataGridView();

                    MessageBox.Show("Guardado con Éxito");
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
        }

        private void dateTimeHoraSalida_ValueChanged(object sender, EventArgs e)
        {       
            dateTimeLimiteSalida.Value = dateTimeHoraSalida.Value;
        }
    }
}
