using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataLayer;
using Connection_BLL;
using System.Data;
using BiometricCore;

namespace BussinesLayer
{
    public class ZKTecoHourAssistanceBLL
    {
        public ZKTecoHourAssistanceDAL zkTecoHourAssistanceDAL = new ZKTecoHourAssistanceDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.ZKTecoHourAssistanceBLL";

        public ZKTecoHourAssistanceBLL()
        {
            ConnectionStrings = conexion.ConnectionStrings();
            zkTecoHourAssistanceDAL.idUser = GlobalBLL.userML.Id;
        }

        public DataTable All()
        {
            try
            {
                return zkTecoHourAssistanceDAL.All(ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All: {1}", core, ex));
            }
        }

        public int save(ZKTecoHourAssistanceML hourAssistanceML)
        {
            try
            {
                if (hourAssistanceML.Id> 0)
                    return zkTecoHourAssistanceDAL.Update(hourAssistanceML, ConnectionStrings);
                else
                    return zkTecoHourAssistanceDAL.Insert(hourAssistanceML, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        /// <summary>
        /// Función que lee todos los Logs de Registros del Lector y los Migra a la Base de Datos
        /// </summary>
        /// <returns>Total de Registros migrados</returns>
        public List<string> MigrateHoursToBD()
        {
            try
            {
                ZKTecoDeviceBLL zKTecoDeviceBLL = new ZKTecoDeviceBLL();

                if (zKTecoDeviceBLL.connect())
                {
                    ICollection<HoursAssistanceInfo> hoursAssistances = zKTecoDeviceBLL.GetLogData();

                    int count = 0;
                    string firstDate = string.Empty;
                    string lastDate = string.Empty;
                    List<string> dateMigrate = new List<string>();

                    if (hoursAssistances != null && hoursAssistances.Count > 0)
                    {
                        foreach (HoursAssistanceInfo ihoursAssistance in hoursAssistances)
                        {
                            if (count == 0)
                                firstDate = DateTime.Parse(ihoursAssistance.DateTimeRecord).ToString("yyyy-MM-dd HH:mm:ss");

                            lastDate = DateTime.Parse(ihoursAssistance.DateTimeRecord).ToString("yyyy-MM-dd HH:mm:ss");
                            ZKTecoHourAssistanceML zKTecoHourAssistanceML = new ZKTecoHourAssistanceML()
                            {
                                MachineNumber = ihoursAssistance.MachineNumber,
                                IdUser = ihoursAssistance.IndRegID,
                                VerifyState = ihoursAssistance.VerifyState,
                                VerifyType = ihoursAssistance.VerifyType,
                                WorkCode = ihoursAssistance.WorkCode,
                                DateTimeRecord = lastDate
                            };

                            zkTecoHourAssistanceDAL.Insert(zKTecoHourAssistanceML, ConnectionStrings);
                            count++;
                            Console.WriteLine("Registro {0}", count);
                        }

                        dateMigrate.Add(firstDate);
                        dateMigrate.Add(lastDate);
                        //MigrationHistoryBLL migrationHistoryBLL = new MigrationHistoryBLL();
                        //MigrationHistoryML migrationHistoryML = new MigrationHistoryML()
                        //{
                        //    DateStart = DateTime.Parse(firstDate),
                        //    DateEnd = DateTime.Parse(lastDate)
                        //};

                        //migrationHistoryBLL.Save(migrationHistoryML);
                    }

                    if (count > 0)
                        return dateMigrate;

                    return null;
                }
                else
                {
                    throw new Exception("Error al conectar con el lector");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("MigrateHoursToBD: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Función que lee los Logs de Registros del Lector por rango de fecha y los Migra a la Base de Datos
        /// </summary>
        /// <param name="startDate">Fecha de Inicio</param>
        /// <param name="endDate">Fecha Fin</param>
        /// <returns>Total de registros migrados</returns>
        public int MigrateHoursToBD(string startDate, string endDate)
        {
            try
            {
                if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate)) throw new Exception("MigrateHoursToBD: No se encontró la Fecha Inicio/Fecha Fin");

                string _startDate = DateTime.Parse(startDate).ToString("yyyy-MM-dd hh:mm:ss");
                string _endDate = DateTime.Parse(endDate).ToString("yyyy-MM-dd hh:mm:ss");

                ZKTecoDeviceBLL zKTecoDeviceBLL = new ZKTecoDeviceBLL();

                if (zKTecoDeviceBLL.connect())
                {
                    ICollection<HoursAssistanceInfo> hoursAssistances = zKTecoDeviceBLL.GetLogData(_startDate, _endDate);

                    int count = 0;

                    if (hoursAssistances != null && hoursAssistances.Count > 0)
                    {
                        foreach (HoursAssistanceInfo ihoursAssistance in hoursAssistances)
                        {
                            ZKTecoHourAssistanceML zKTecoHourAssistanceML = new ZKTecoHourAssistanceML()
                            {
                                MachineNumber = ihoursAssistance.MachineNumber,
                                IdUser = ihoursAssistance.IndRegID,
                                VerifyState = ihoursAssistance.VerifyState,
                                VerifyType = ihoursAssistance.VerifyType,
                                WorkCode = ihoursAssistance.WorkCode,
                                DateTimeRecord = DateTime.Parse(ihoursAssistance.DateTimeRecord).ToString("yyyy-MM-dd HH:mm:ss")
                            };

                            zkTecoHourAssistanceDAL.Insert(zKTecoHourAssistanceML, ConnectionStrings);

                            count++;
                            Console.WriteLine("Registro {0}", count);
                        }

                        //MigrationHistoryBLL migrationHistoryBLL = new MigrationHistoryBLL();
                        //MigrationHistoryML migrationHistoryML = new MigrationHistoryML()
                        //{
                        //    DateStart = startDate,
                        //    DateEnd = endDate
                        //};

                        //migrationHistoryBLL.Save(migrationHistoryML);
                    }

                    return count;
                }
                else
                {
                    throw new Exception("Error al conectar con el lector");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("MigrateHoursToBD: {0}", ex.Message));
            }
        }
    }
}
