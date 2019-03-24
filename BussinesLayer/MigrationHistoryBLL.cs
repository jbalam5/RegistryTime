using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection_BLL;
using DataLayer;
using ModelLayer;
using System.Data;

namespace BussinesLayer
{
    public class MigrationHistoryBLL
    {
        public MigrationHistoryDAL MigrationHistoryDAL = new MigrationHistoryDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String core = "BussinesLayer.MigrationHistoryBLL";

        public MigrationHistoryBLL()
        {

            MigrationHistoryDAL.IdUserSession = GlobalBLL.userML.Id;
            MigrationHistoryDAL.ConnectionString = conexion.ConnectionStrings();
        }

        public int Save(MigrationHistoryML MigrationHistory)
        {
            try
            {
                if (MigrationHistory.Id == 0)
                {
                    return MigrationHistoryDAL.Save(MigrationHistory);
                }
                else
                {
                    return MigrationHistoryDAL.Update(MigrationHistory);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public DateTime LastRecord()
        {
            try
            {
                return MigrationHistoryDAL.LastRecord();                
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.lastRecord: {1}", core, ex.Message));
            }
        }

        public void MIGRATEHOURS(DateTime Start , DateTime End)
        {
            try
            {
                DataTable ListCheck = MigrationHistoryDAL.ListRecord(Start, End);
            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.MIGRATEHOURS: {1}", core, ex.Message));
            }
        }


        //--------------- NUEVA MIGRACION
        public void ListRecord(DateTime Start, DateTime End)
        {
            try
            {
                DataTable ListRecord = MigrationHistoryDAL.ListRecord(Start, End);
                TurnBLL TurnBLL = new TurnBLL();
                DataTable TimeOutCheckDT = TurnBLL.TimeOutCheck("checkin");
                //String TotalAddHours;  //= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0,0, 0);
                TimeSpan TotalAddHours;
                bool SinHoras = false;
                if (TimeOutCheckDT.Rows.Count > 0)
                {
                    //TotalAddHours = TimeOutCheckDT.Rows[0]["timeCheck"].ToString();
                    TotalAddHours = TimeSpan.Parse( TimeOutCheckDT.Rows[0]["timeCheck"].ToString());
                    SinHoras = true;
                }
                else
                {
                    TotalAddHours = TimeSpan.Parse("00:00:00");
                }
                if (ListRecord.Rows.Count > 0)
                {
                    String NameTurn = String.Empty;
                    CheckInHoursML CheckInHours = new CheckInHoursML();
                    foreach (DataRow Record in ListRecord.Rows)
                    {
                        String RecordData = TurnBLL.RecordOld(Convert.ToInt32(Record["idUser"].ToString()));
                        if (!String.IsNullOrEmpty(RecordData))
                        {

                            DateTime RecordOldTime = Convert.ToDateTime(RecordData.ToString());
                            if (SinHoras == true)
                            {
                                if (AddHoursTo(RecordOldTime, TotalAddHours) < Convert.ToDateTime(Record["dateTimeRecord"].ToString()))
                                {
                                        CheckInHours.IdEmployee = Convert.ToInt32(Record["idUser"].ToString());
                                        CheckInHours.MachineNumber = 1;
                                        CheckInHours.DateTimeRecord = Convert.ToDateTime(Record["dateTimeRecord"].ToString());
                                        CheckInHours.DateOnlyRecord = Convert.ToDateTime(Record["dateOnlyRecord"].ToString());
                                        CheckInHours.TimeOnlyRecord = TimeSpan.Parse(Record["dateTimeRecord"].ToString());
                                        CheckInHours.Turn = "HRS EXTRA";
                                        CheckInHours.TypeCheck = "ENTRADA";                                    
                                }
                               
                            }

                        }
                        else
                        {

                            //VERIFICAR TURNO
                            TurnML TurnUser = TurnBLL.GetTurnUser(Convert.ToDateTime(Record["dateTimeRecord"].ToString()), Convert.ToInt32(Record["idUser"].ToString()));
                            if(TurnUser != null)
                            {
                                CheckInHours.IdEmployee = Convert.ToInt32(Record["idUser"].ToString());
                                CheckInHours.MachineNumber = 1;
                                CheckInHours.DateTimeRecord = Convert.ToDateTime(Record["dateTimeRecord"].ToString());
                                CheckInHours.DateOnlyRecord = Convert.ToDateTime(Record["dateOnlyRecord"].ToString());
                                CheckInHours.TimeOnlyRecord = TimeSpan.Parse(Record["dateTimeRecord"].ToString());
                                CheckInHours.Turn = TurnUser.Name;
                                CheckInHours.TypeCheck = "ENTRADA";
                            }
                            else
                            {

                                CheckInHours.IdEmployee = Convert.ToInt32(Record["idUser"].ToString());
                                CheckInHours.MachineNumber = 1;
                                CheckInHours.DateTimeRecord = Convert.ToDateTime(Record["dateTimeRecord"].ToString());
                                CheckInHours.DateOnlyRecord = Convert.ToDateTime(Record["dateOnlyRecord"].ToString());
                                CheckInHours.TimeOnlyRecord = TimeSpan.Parse(Record["timeOnlyRecord"].ToString());
                                CheckInHours.Turn = "HRS EXTRA";
                                CheckInHours.TypeCheck = "ENTRADA";
                               
                            }
                            //nuevo registro del usuario
                        }
                        CheckInHoursBLL CheckInHoursBLL = new CheckInHoursBLL();
                        CheckInHoursBLL.Save(CheckInHours);
                    }

                }
                //return ListRecord;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.ListRecord: {1}", core, ex));
            }
        }

        public DateTime AddHoursTo(DateTime RecordOld, TimeSpan TimeOutChec)
        {
            try
            {
                DateTime TMP = RecordOld;
                TMP.AddMilliseconds(TimeOutChec.TotalMilliseconds);
                TMP.AddSeconds(TimeOutChec.TotalSeconds);
                TMP.AddMinutes(TimeOutChec.TotalMinutes);
                TMP.AddHours(TimeOutChec.TotalHours);

                return TMP;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.AddHoursTo: {1}", core, ex.Message));
            }
        }

        //public void FormatDateTime(DateTime DateTim)
        //{
        //    try
        //    {
                
        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //}




    }
}
