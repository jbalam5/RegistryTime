using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using ModelLayer;
using Connection_BLL;
using System.Data;

namespace BussinesLayer
{
    public class ReportsBLL
    {
        ReportsDAL ReportsDAL = new ReportsDAL();
        ConnectionBLL Conection = new ConnectionBLL();

        public ReportsBLL()
        {
            ReportsDAL.ConnectionString = Conection.ConnectionStrings();
        }

        public DataTable ReportAbsenteeism(int IdDepartament, int IdTurn, int IdEmployee) 
        {
            try
            {
                return ReportsDAL.ReportAbsenteeism(IdDepartament, IdTurn, IdEmployee);
            }catch(Exception ex)
            {
                throw new Exception(String.Format("ReportAbsenteeim: {0}", ex.Message));
            }

        }

        public DataTable ReportExtrasHours(DateTime DateStart, DateTime DateEnd)
        {
            try
            {
                DataTable HoursExtras = ReportsDAL.ReportExtras(DateStart, DateEnd);
                TurnBLL TurnBLL = new TurnBLL();
                TimeSpan ExtraEntrada;
                TimeSpan ExtraSalida;
                TimeSpan RetardoEntrada;
                TimeSpan SalidaAntes;
                //return ReportsDAL.ReportExtras(DateStart, DateEnd);

                HoursExtras.Columns.Add("TiempoExtra", typeof(TimeSpan));
                HoursExtras.Columns.Add("Retardos", typeof(TimeSpan));
                
                foreach (DataRow Horas in HoursExtras.Rows)
                {
                    
                  
                    TimeSpan HoraEntrada = TimeSpan.Parse(Convert.ToDateTime(Horas["ENTRADA"].ToString()).ToString("HH:mm:ss"));
                    //TimeSpan HoraInicial = TimeSpan.Parse(Convert.ToDateTime(TurnMLEmployee.StartEntry.ToString()).ToString("HH:mm:ss"));
                    TimeSpan HoraSalida = TimeSpan.Parse(Convert.ToDateTime(Horas["SALIDA"].ToString()).ToString("HH:mm:ss"));
                    //TimeSpan LimiteSalida = TimeSpan.Parse(Convert.ToDateTime(TurnMLEmployee.LimitDeparture.ToString()).ToString("HH:mm:ss"));
                    //TimeSpan LimiteEntrada = TimeSpan.Parse(Convert.ToDateTime(TurnMLEmployee.LimitEntry.ToString()).ToString("HH:mm:ss"));
                    //TimeSpan Salida = TimeSpan.Parse(Convert.ToDateTime(TurnMLEmployee.Departuretime.ToString()).ToString("HH:mm:ss"));

                    ExtraEntrada = TimeSpan.Parse("00:00:00");
                    ExtraSalida = TimeSpan.Parse("00:00:00");
                    RetardoEntrada = TimeSpan.Parse("00:00:00");
                    SalidaAntes = TimeSpan.Parse("00:00:00");

                    if (Horas["TURNO"].ToString() != "HRS EXTRA")
                    {
                        TurnML TurnMLEmployee = TurnBLL.GetTurnForNaMe(Horas["TURNO"].ToString());
                        TimeSpan HoraInicial = TimeSpan.Parse(Convert.ToDateTime(TurnMLEmployee.StartEntry.ToString()).ToString("HH:mm:ss"));
                        TimeSpan LimiteSalida = TimeSpan.Parse(Convert.ToDateTime(TurnMLEmployee.LimitDeparture.ToString()).ToString("HH:mm:ss"));
                        TimeSpan LimiteEntrada = TimeSpan.Parse(Convert.ToDateTime(TurnMLEmployee.LimitEntry.ToString()).ToString("HH:mm:ss"));
                        TimeSpan Salida = TimeSpan.Parse(Convert.ToDateTime(TurnMLEmployee.Departuretime.ToString()).ToString("HH:mm:ss"));

                        if (HoraEntrada < HoraInicial)
                        {
                            ExtraEntrada = HoraInicial.Subtract(HoraEntrada);
                        }

                        if (HoraSalida > LimiteSalida)
                        {
                            ExtraSalida = HoraSalida.Subtract(LimiteSalida);
                        }

                        //RETARDOS
                        if (HoraEntrada > LimiteEntrada)
                        {
                            RetardoEntrada = HoraEntrada.Subtract(LimiteEntrada);
                        }
                        
                        if (HoraSalida < Salida && HoraSalida > HoraEntrada)
                        {
                            SalidaAntes = Salida.Subtract(HoraSalida);
                        }
                        else RetardoEntrada = TimeSpan.Parse("00:00:00");

                        Horas["TiempoExtra"] = SumToTime(ExtraEntrada, ExtraSalida);
                        Horas["Retardos"] = SumToTime(RetardoEntrada, SalidaAntes);
                    }
                    else
                    {
                        Horas["TiempoExtra"] = HoraSalida.Subtract(HoraEntrada);
                        Horas["Retardos"] = "00:00:00";
                    }
                }
                
                return HoursExtras;

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("ReportExtrasHours: {0}", ex.Message));
            }
        }

        public TimeSpan SumToTime(TimeSpan Dif1, TimeSpan Dif2)
        {
            try
            {
                return Dif1.Add(Dif2);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SumToTime: {0}", ex.Message));
            }
        }
    }
}
