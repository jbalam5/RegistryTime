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

        public DataTable ReportAbsenteeism(DateTime DateStart, DateTime DateEnd, int IdDepartament = 0, int IdEmployee = 0) 
        {
            try
            {
                //DataTable Ausentismos = ReportsDAL.ReportAbsenteeism(DateStart, DateEnd, IdDepartament, IdEmployee);

                return ReportsDAL.ReportAbsenteeism(DateStart, DateEnd, IdDepartament, IdEmployee);
            }catch(Exception ex)
            {
                throw new Exception(String.Format("ReportAbsenteeim: {0}", ex.Message));
            }
        }

        public DataTable ReportExtrasHours(DateTime DateStart, DateTime DateEnd, int IdTurn = 0, int IdDepartament = 0, int IdEmployee = 0)
        {
            try
            {
                DataTable HoursExtras = ReportsDAL.ReportExtras(DateStart, DateEnd, IdTurn, IdDepartament, IdEmployee);
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
                    TimeSpan HoraSalida = TimeSpan.Parse(Convert.ToDateTime(Horas["SALIDA"].ToString()).ToString("HH:mm:ss"));

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

        public DataTable DateReportsStartEntry(DateTime DateIn, DateTime DateEnd, String Turn, String Departament)
        {
            try
            {
                DataTable Response = ReportsDAL.AdmissionDateEmployee(DateIn, DateEnd);

                if (String.IsNullOrEmpty(Turn) && String.IsNullOrEmpty(Departament))
                    return Response;

                if (!String.IsNullOrEmpty(Turn))
                    Response.Select(String.Format("Departamento = '{0}'", Turn));

                if (!String.IsNullOrEmpty(Departament))
                    Response.Select(String.Format("Departamento = '{0}'", Departament));

                return Response;
            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("ReportHoursJob: {0}", ex.Message));
            }
        }

        public DataTable ReportHoursJob(DateTime DateStart, DateTime DateEnd, int IdTurn = 0, int IdDepartament = 0, int IdEmployee = 0)
        {
            try
            {
                DataTable HoursExtras = ReportsDAL.ReportExtras(DateStart, DateEnd, IdTurn, IdDepartament, IdEmployee);
                TurnBLL TurnBLL = new TurnBLL();
                EmployeeBLL EmployeeBLL = new EmployeeBLL();
                TimeSpan ExtraEntrada;
                TimeSpan ExtraSalida;
                TimeSpan RetardoEntrada;
                TimeSpan SalidaAntes;
                TimeSpan HrsJornadas;
                TimeSpan HrsExtras;
                TimeSpan TotalHrsDia;
                String TotalHrs;

                HoursExtras.Columns.Add("HORASJORNADA", typeof(TimeSpan));
                HoursExtras.Columns.Add("HORASEXTRAS", typeof(TimeSpan));
                HoursExtras.Columns.Add("TOTAL_HRS", typeof(TimeSpan));
                HoursExtras.Columns.Add("SUELDO_TOTAL", typeof(Decimal));

                foreach (DataRow Horas in HoursExtras.Rows)
                {


                    TimeSpan HoraEntrada = TimeSpan.Parse(Convert.ToDateTime(Horas["ENTRADA"].ToString()).ToString("HH:mm:ss"));
                    TimeSpan HoraSalida = TimeSpan.Parse(Convert.ToDateTime(Horas["SALIDA"].ToString()).ToString("HH:mm:ss"));
                    //int IdEmployee = Int32.Parse(Horas["CVE"].ToString());

                    ExtraEntrada = TimeSpan.Parse("00:00:00");
                    ExtraSalida = TimeSpan.Parse("00:00:00");
                    RetardoEntrada = TimeSpan.Parse("00:00:00");
                    SalidaAntes = TimeSpan.Parse("00:00:00");

                    EmployeeML SalaryEmployeeML = EmployeeBLL.GetColumnsEmployee(Int32.Parse(Horas["CVE"].ToString()));
                    
                    Decimal Salario = Decimal.Parse(SalaryEmployeeML.Salary.ToString());
                    Decimal horasxDias = Decimal.Parse(SalaryEmployeeML.HoursOfDay.ToString());

                    if (Horas["TURNO"].ToString() != "HRS EXTRA")
                    {
                        TurnML TurnMLEmployee = TurnBLL.GetTurnForNaMe(Horas["TURNO"].ToString());                      

                        TimeSpan HoraInicial = TimeSpan.Parse(Convert.ToDateTime(TurnMLEmployee.StartEntry.ToString()).ToString("HH:mm:ss"));
                        TimeSpan LimiteSalida = TimeSpan.Parse(Convert.ToDateTime(TurnMLEmployee.LimitDeparture.ToString()).ToString("HH:mm:ss"));
                        TimeSpan LimiteEntrada = TimeSpan.Parse(Convert.ToDateTime(TurnMLEmployee.LimitEntry.ToString()).ToString("HH:mm:ss"));
                        TimeSpan Salida = TimeSpan.Parse(Convert.ToDateTime(TurnMLEmployee.Departuretime.ToString()).ToString("HH:mm:ss"));
                        TimeSpan HorasJornada = TimeSpan.Parse(Convert.ToDateTime(TurnMLEmployee.HoursJornada.ToString()).ToString("HH:mm:ss"));
                        
                        //HORAS EXTRAS
                        if (HoraEntrada < HoraInicial)
                        {
                            ExtraEntrada = HoraInicial.Subtract(HoraEntrada);
                        }

                        if (HoraSalida > LimiteSalida)
                        {
                            ExtraSalida = HoraSalida.Subtract(LimiteSalida);
                        }                      

                        //HORAS JORNADA NORMAL
                        if (HoraEntrada != TimeSpan.Parse("00:00:00") && HoraSalida != TimeSpan.Parse("00:00:00"))
                        {
                            Horas["HORASJORNADA"] = HorasJornada;
                            HrsJornadas = HorasJornada;
                        }
                        else
                        {
                            Horas["HORASJORNADA"] = TimeSpan.Parse("00:00:00");
                            HrsJornadas = TimeSpan.Parse("00:00:00");
                        }
                        Horas["HORASEXTRAS"] = SumToTime(ExtraEntrada, ExtraSalida); 
                        HrsExtras = SumToTime(ExtraEntrada, ExtraSalida);
                    }
                    else
                    {
                        Horas["HORASJORNADA"] = TimeSpan.Parse("00:00:00");
                        Horas["HORASEXTRAS"] = HoraSalida.Subtract(HoraEntrada);
                        HrsJornadas = TimeSpan.Parse("00:00:00");
                        HrsExtras = HoraSalida.Subtract(HoraEntrada); ;
                    }
                                     
                    Horas["TOTAL_HRS"] = SumToTime(HrsJornadas, HrsExtras);
                    TotalHrsDia = SumToTime(HrsJornadas, HrsExtras);
                    TotalHrs = Convert.ToDecimal(Convert.ToDecimal(TotalHrsDia.Hours) + (Convert.ToDecimal(TotalHrsDia.Minutes))).ToString("#.00");

                    Horas["SUELDO_TOTAL"] = (Salario/15/horasxDias) * Convert.ToDecimal(TotalHrs);
                }

                return HoursExtras;

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("ReportHoursJob: {0}", ex.Message));
            }
        }

        public DataTable ReportUsers()
        {
            try
            {           
                return ReportsDAL.ReportUsers();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("ReportUsers: {0}", ex.Message));
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
