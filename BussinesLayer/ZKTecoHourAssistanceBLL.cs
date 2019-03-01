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

        public int MigrateHoursToBD()
        {
            try
            {
                ZKTecoDeviceBLL zKTecoDeviceBLL = new ZKTecoDeviceBLL();

                if (zKTecoDeviceBLL.connect())
                {
                    ICollection<HoursAssistanceInfo> hoursAssistances = zKTecoDeviceBLL.GetLogData();

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
