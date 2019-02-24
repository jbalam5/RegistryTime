using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiometricCore;
using ModelLayer;

namespace DataLayer
{
    public class ZKTecoHourAssistanceDAL
    {
        public String core = "DataLayer.ZKTecoHourAssistanceDAL";
        public String TableName = "HoursAssistance";

        public DataTable All(String ConnectionString)
        {
            try
            {
                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = ConnectionString;
                Conexion.Open();
                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1", TableName);
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtReader = new DataTable();
                cmd.Fill(dtReader);
                Conexion.Close();
                return dtReader;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All : {1}", core, ex));
            }

        }
        
        public int Insert(ZKTecoHourAssistanceML hoursAssistanceML, String ConnectionString)
        {
            try
            {
                if (hoursAssistanceML != null)
                {

                    StringBuilder Query = new StringBuilder();
                    Query.AppendFormat("INSERT INTO {0} (", TableName);
                    Query.AppendFormat(" {0}, ", ZKTecoHourAssistanceML.DataBase.machineNumber);
                    Query.AppendFormat(" {0}, ", ZKTecoHourAssistanceML.DataBase.idUser);
                    Query.AppendFormat(" {0}, ", ZKTecoHourAssistanceML.DataBase.verifyType);
                    Query.AppendFormat(" {0}, ", ZKTecoHourAssistanceML.DataBase.verifyState);
                    Query.AppendFormat(" {0}, ", ZKTecoHourAssistanceML.DataBase.workCode);
                    Query.AppendFormat(" {0}, ", ZKTecoHourAssistanceML.DataBase.dateTimeRecord);
                    Query.AppendFormat(" {0}, ", ZKTecoHourAssistanceML.DataBase.dateOnlyRecord);
                    Query.AppendFormat(" {0}, ", ZKTecoHourAssistanceML.DataBase.timeOnlyRecord);
                    Query.AppendLine(" _registry, idUserInsert, dateInsert");
                    Query.AppendLine(") VALUES( ");
                    Query.AppendFormat(" {0}, ", hoursAssistanceML.MachineNumber);
                    Query.AppendFormat(" {0}, ", hoursAssistanceML.IdUser);
                    Query.AppendFormat(" {0}, ", hoursAssistanceML.VerifyType);
                    Query.AppendFormat(" {0}, ", hoursAssistanceML.VerifyState);
                    Query.AppendFormat(" {0}, ", hoursAssistanceML.WorkCode);
                    Query.AppendFormat(" Format(convert(DateTime, '{0}'), 'yyyy-MM-dd HH:mm:ss'), ", hoursAssistanceML.DateTimeRecord);
                    Query.AppendFormat(" Format(convert(Date, '{0}'), 'yyyy-MM-dd'), ", hoursAssistanceML.DateTimeRecord);
                    Query.AppendFormat(" convert(Time, '{0}'), ", hoursAssistanceML.DateTimeRecord);
                    Query.AppendLine(" 1, ");
                    Query.AppendFormat(" {0}, ", 1);
                    Query.AppendLine(" GETDATE()) ");
                    Query.AppendLine(" SELECT CAST(scope_identity() AS int)");
                    SqlConnection Conexion = new SqlConnection
                    {
                        ConnectionString = ConnectionString
                    };

                    using (SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion))
                    {
                        Conexion.Open();
                        int newID = (Int32)cmd2.ExecuteScalar();

                        if (Conexion.State == System.Data.ConnectionState.Open) Conexion.Close();
                        return newID;
                    }

                }

                return 0;

            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.Insert : {1}", core, ex));
            }
        }

        public int Update(ZKTecoHourAssistanceML hoursAssistanceML, String ConnectionString)
        {
            try
            {
                if (hoursAssistanceML != null)
                {

                    StringBuilder Query = new StringBuilder();
                    Query.AppendFormat("UPDATE {0} SET ", TableName);
                    Query.AppendFormat(" {0} = {1}, ", ZKTecoHourAssistanceML.DataBase.machineNumber, hoursAssistanceML.MachineNumber);
                    Query.AppendFormat(" {0} = {1}, ", ZKTecoHourAssistanceML.DataBase.idUser, hoursAssistanceML.IdUser);
                    Query.AppendFormat(" {0} = {1}, ", ZKTecoHourAssistanceML.DataBase.verifyType, hoursAssistanceML.VerifyType);
                    Query.AppendFormat(" {0} = {1}, ", ZKTecoHourAssistanceML.DataBase.verifyState, hoursAssistanceML.VerifyState);
                    Query.AppendFormat(" {0} = {1}, ", ZKTecoHourAssistanceML.DataBase.workCode, hoursAssistanceML.WorkCode);
                    Query.AppendFormat(" {0} = Format(convert(DateTime, '{1}'), 'yyyy-MM-dd HH:mm:ss'), ", ZKTecoHourAssistanceML.DataBase.dateTimeRecord, hoursAssistanceML.DateTimeRecord);
                    Query.AppendFormat(" {0} = Format(convert(Date, '{1}'), yyyy-MM-dd), ", ZKTecoHourAssistanceML.DataBase.dateOnlyRecord, hoursAssistanceML.DateTimeRecord);
                    Query.AppendFormat(" {0} = convert(Time, '{1}'), ", ZKTecoHourAssistanceML.DataBase.timeOnlyRecord, hoursAssistanceML.DateTimeRecord);
                    Query.AppendFormat(" idUserUpdate = {0}, ", 1);
                    Query.AppendLine(" dateUpdate = GETDATE() ");
                    Query.AppendFormat(" WHERE id = {0}' ", hoursAssistanceML.Id);

                    SqlConnection Conexion = new SqlConnection()
                    {
                        ConnectionString = ConnectionString
                    };

                    Conexion.Open();
                    SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion);
                    cmd2.ExecuteNonQuery();
                    return hoursAssistanceML.Id;

                }

                return 0;

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Insert : {1}", core, ex));
            }
        }
    }
}
