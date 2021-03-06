﻿using System;
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

        public string LastRecord()
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
                TimeOutCheckBLL TimeOutCheckBLL = new TimeOutCheckBLL();
                TurnBLL TurnBLL = new TurnBLL();
                DataTable TimeOutCheckDT = TimeOutCheckBLL.TimeOutCheck("checkin");
                DataTable TimeOutCheckMax = TimeOutCheckBLL.TimeOutCheck("maxihours");
                //String TotalAddHours;  //= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0,0, 0);
                TimeSpan TotalAddHours;
                TimeSpan MaxAddHours;
                int idGetUser = 0;
              
                if (TimeOutCheckMax.Rows.Count >0)
                {
                    MaxAddHours = TimeSpan.Parse(TimeOutCheckMax.Rows[0]["timeCheck"].ToString());
                }
                else
                {
                    MaxAddHours = TimeSpan.Parse("00:00:00");
                }
                //bool SinHoras = false;
                if (TimeOutCheckDT.Rows.Count > 0)
                {
                    //TotalAddHours = TimeOutCheckDT.Rows[0]["timeCheck"].ToString();
                    TotalAddHours = TimeSpan.Parse( TimeOutCheckDT.Rows[0]["timeCheck"].ToString());
                    //SinHoras = true;
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
                        idGetUser = MigrationHistoryDAL.getUserDialing(Record["idUser"].ToString());
                        //Verificar si es MARCACION VALIDA
                        if (MigrationHistoryDAL.ValidRecord(Convert.ToDateTime(Record["dateTimeRecord"].ToString()), TotalAddHours, idGetUser) && idGetUser != 0)
                        {
                            //VERIFICAR SI NO EXISTE UNA MARCACION CON LOS MISMO PARAMETROS
                            if (MigrationHistoryDAL.IsExistRecord(idGetUser, Convert.ToDateTime(Record["dateTimeRecord"].ToString())) == 0)
                            {
                                TurnML TurnUser = TurnBLL.GetTurnUser(Convert.ToDateTime(Record["dateTimeRecord"].ToString()), idGetUser);
                                String RecordData = MigrationHistoryDAL.RecordOld(idGetUser);
                                if (!String.IsNullOrEmpty(RecordData))
                                {
                                    DateTime RecordOldTime = Convert.ToDateTime(RecordData.ToString());

                                    CheckInHours.IdEmployee = idGetUser;
                                    CheckInHours.MachineNumber = 1;
                                    CheckInHours.DateTimeRecord = Convert.ToDateTime(Record["dateTimeRecord"].ToString());
                                    CheckInHours.DateOnlyRecord = Convert.ToDateTime(Record["dateOnlyRecord"].ToString());
                                    CheckInHours.TimeOnlyRecord = TimeSpan.Parse(Record["timeOnlyRecord"].ToString());
                                    CheckInHours.IdTurn = (TurnUser != null) ? TurnUser.Id : 0;
                                    TimeSpan TotalDiffHours = TotalDiffTime(RecordOldTime, Convert.ToDateTime(Record["dateTimeRecord"].ToString()));
                                    if (MaxAddHours > TotalDiffHours)
                                    {
                                        int Resul = MigrationHistoryDAL.NumRecordsUser(idGetUser) % 2;
                                        CheckInHours.TypeCheck = ( Resul == 0 )?"ENTRADA":"SALIDA";
                                    }
                                    else
                                    {
                                        CheckInHours.TypeCheck = "ENTRADA";
                                    }
                                }
                                else
                                {
                                    if (TurnUser != null)
                                    {
                                        CheckInHours.IdEmployee = idGetUser;
                                        CheckInHours.MachineNumber = 1;
                                        CheckInHours.DateTimeRecord = Convert.ToDateTime(Record["dateTimeRecord"].ToString());
                                        CheckInHours.DateOnlyRecord = Convert.ToDateTime(Record["dateOnlyRecord"].ToString());
                                        CheckInHours.TimeOnlyRecord = TimeSpan.Parse(Record["timeOnlyRecord"].ToString());
                                        CheckInHours.IdTurn = TurnUser.Id;
                                        CheckInHours.TypeCheck = "ENTRADA";
                                    }
                                    else
                                    {
                                        CheckInHours.IdEmployee = idGetUser;
                                        CheckInHours.MachineNumber = 1;
                                        CheckInHours.DateTimeRecord = Convert.ToDateTime(Record["dateTimeRecord"].ToString());
                                        CheckInHours.DateOnlyRecord = Convert.ToDateTime(Record["dateOnlyRecord"].ToString());
                                        CheckInHours.TimeOnlyRecord = TimeSpan.Parse(Record["timeOnlyRecord"].ToString());
                                        CheckInHours.IdTurn = 0;
                                        CheckInHours.TypeCheck = "ENTRADA";
                                    }
                                }
                                CheckInHoursBLL CheckInHoursBLL = new CheckInHoursBLL();
                                CheckInHoursBLL.Save(CheckInHours);
                            }
                        }       

                    }

                }
                //return ListRecord;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.ListRecord: {1}", core, ex));
            }
        }
        /// <summary>
        /// Total diferencia en minutos
        /// </summary>
        /// <param name="DatetimeRecordOld"></param>
        /// <param name="DateTimeRecord"></param>
        public TimeSpan TotalDiffTime(DateTime DatetimeRecordOld, DateTime DateTimeRecord)
        {
            try
            {
                TimeSpan TimeDiff = DateTimeRecord - DatetimeRecordOld;
                return TimeDiff;
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
                TMP = TMP.AddMilliseconds(TimeOutChec.TotalMilliseconds);
                TMP = TMP.AddSeconds(TimeOutChec.TotalSeconds);
                TMP = TMP.AddMinutes(TimeOutChec.TotalMinutes);
                TMP = TMP.AddHours(TimeOutChec.TotalHours);
                TimeSpan S = TimeSpan.Parse("45:00:00");
                
                return TMP;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.AddHoursTo: {1}", core, ex.Message));
            }
        }

        /// <summary>
        /// Optener la ultima marcacion del empleado
        /// </summary>
        /// <param name="IdUser"></param>
        /// <returns></returns>
        public String RecordOld(int IdUser)
        {
            try
            {
                return MigrationHistoryDAL.RecordOld(IdUser);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.TimeOutCheck: {1}", core, ex));
            }
        }

        public bool VerifyTypeMigrate(int type)
        {
            try
            {
                return MigrationHistoryDAL.VerifyTypeMigrate(type);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.VerifyTypeMigrate: {1}", core, ex.Message));
            }
        }
    }
}
