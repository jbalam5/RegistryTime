using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using System.Data;



namespace DataLayer
{
    public class MigrationHistoryDAL
    {
        public String core = "DataLayer.MigrationHistory";
        public String TableName = "dbo.MigrationHistory";
        //public String TablaStatusBook = "statusBook";
        public String ConnectionString = String.Empty;
        public int IdUserSession = 0;

        TurnDAL TurnDAL = new TurnDAL();

        public int Save(MigrationHistoryML MigrationHistory)
        {
            ModelDAL data = new ModelDAL();
            String Response = data.InsertModel(MigrationHistory, TableName, IdUserSession);
            SqlConnection Conexion = new SqlConnection
            {
                ConnectionString = ConnectionString
            };

            using (SqlCommand cmd2 = new SqlCommand(Response.ToString(), Conexion))
            {
                Conexion.Open();
                int newID = (Int32)cmd2.ExecuteScalar();

                if (Conexion.State == System.Data.ConnectionState.Open) Conexion.Close();
                return newID;
            }

        }

        public int Update(MigrationHistoryML MigrationHistory)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.UpdateModel(MigrationHistory, TableName, IdUserSession);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Response.ToString(), Conexion);
                cmd2.ExecuteNonQuery();
                return MigrationHistory.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.update: {1}", core, ex));
            }
        }

        public DateTime LastRecord()
        {
            try
            {
                DateTime Fecha;
                String Query = String.Format("SELECT  TOP 1 dateEnd FROM {0} WHERE _registry = 1 ORDER BY id DESC", TableName);
                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };

                using (SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion))
                {
                    Conexion.Open();                    
                    Fecha = (DateTime)cmd2.ExecuteScalar();

                    if (Conexion.State == System.Data.ConnectionState.Open) Conexion.Close();
                    return Fecha;                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.LastRecord: {1}", core, ex.Message));
            }
        }

        /// <summary>
        /// Verifica si registro es valido segun tiempo Checkin
        /// </summary>
        /// <param name="DateTimeRecord"></param>
        /// <param name="IdUser"></param>
        public Boolean ValidRecord(DateTime DateTimeRecord,TimeSpan TimeCheck, int IdUser)
        {
            try
            {
                Boolean Valid = true;
                //Validar si existe un valor anterior
                DataTable DTRecord = DataTableOldRecord(IdUser);
                DateTime DateTimeRecordOld;
                if (DTRecord.Rows.Count > 0)
                {
                    DateTimeRecordOld = Convert.ToDateTime(DTRecord.Rows[0]["dateTimeRecord"].ToString());
                    DateTimeRecordOld = DateTimeRecordOld.AddMilliseconds(TimeCheck.TotalMilliseconds);
                    DateTimeRecordOld = DateTimeRecordOld.AddSeconds(TimeCheck.TotalSeconds);
                    DateTimeRecordOld = DateTimeRecordOld.AddMinutes(TimeCheck.TotalMinutes);
                    DateTimeRecordOld = DateTimeRecordOld.AddHours(TimeCheck.TotalHours);

                    if(DateTimeRecordOld > DateTimeRecord)
                    {
                        Valid = false;
                    }
                }

                return Valid;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.LastRecord: {1}", core, ex.Message));
            }

        }

        public int getUserDialing(String idUser)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                StringBuilder Query = new StringBuilder();
                UsersDAL UsersDAL = new UsersDAL();
                UsersEmployeeDAL UsersEmployeeDAL = new UsersEmployeeDAL();
                
                Query.AppendLine("select ");
                Query.AppendFormat("{0} ", UsersEmployeeML.DataBase.idEmployee);
                Query.AppendLine("from ");
                Query.AppendFormat("{0} ", UsersDAL.TableName);
                Query.AppendFormat("left join {0} on ", UsersEmployeeDAL.TableName);
                Query.AppendFormat("{0}.{1} = {2}.{3} ", UsersDAL.TableName, UsersML.DataBase.Id, UsersEmployeeDAL.TableName, UsersEmployeeML.DataBase.idUser);
                Query.AppendLine("where ");
                Query.AppendFormat("{0}.{1} = {2}", UsersEmployeeDAL.TableName, UsersEmployeeML.DataBase.numControl, idUser);

                DataTable Response = ModelDAL.DataTableRecord(Query.ToString(), ConnectionString);
                if (Response.Rows.Count > 0)
                    return (int)Response.Rows[0][UsersEmployeeML.DataBase.idEmployee];
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.getUserDialing: {1}", core, ex.Message));
            }
        }

        public DataTable ListRecord(DateTime Start , DateTime End)
        {
            try
            {
                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1 AND dateTimeRecord BETWEEN '{1}' AND '{2}'", "HoursAssistance", Start.ToString("yyyy-MM-dd HH:mm:ss"), End.ToString("yyyy-MM-dd HH:mm:ss"));
                SqlConnection Connection = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Connection.Open();
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Connection);
                DataTable ListRecord = new DataTable();
                cmd.Fill(ListRecord);
                Connection.Close();
                return ListRecord;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.LastRecord: {1}", core, ex.Message));
            }
        }
        /// <summary>
        /// Verificar si existe una marcacion con los mismo parametros
        /// </summary>
        /// <param name="IdUser"></param>
        /// <param name="DateTimeRecord"></param>
        /// <returns></returns>
        public int IsExistRecord(int IdUser, DateTime DateTimeRecord)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                StringBuilder Query = new StringBuilder();
                Query.AppendLine("SELECT COUNT(*) FROM checkInHours WHERE ");
                Query.AppendLine("_registry = 1 ");
                Query.AppendFormat("AND idEmployee = {0} ", IdUser);
                Query.AppendFormat("AND dateTimeRecord = '{0}' ", DateTimeRecord.ToString("yyyy-MM-dd HH:mm:ss"));

                return ModelDAL.CountRecord(Query.ToString(), ConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.IsExistRecord: {1}", core, ex));
            }
        }

        public int NumRecordsUser(int IdUser)
        {
            try
            {
                String Query = String.Format("SELECT COUNT(*) FROM checkInHours WHERE _registry = 1 and idEmployee = {0}", IdUser);
                ModelDAL ModelDAL = new ModelDAL();
                return ModelDAL.CountRecord(Query.ToString(), ConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.NumRecordsUser: {1}", core, ex));
            }
        }


        /// <summary>
        /// Obtiene DateTimeRecord de la ultima Marcacion del empleado
        /// </summary>
        /// <param name="IdUser"></param>
        /// <returns></returns>
        public String RecordOld(int IdUser)
        {
            try
            {
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("SELECT TOP 1 dateTimeRecord FROM checkInHours WHERE idEmployee = {0} ORDER BY id DESC", IdUser);
                SqlConnection Connection = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                Connection.Open();
                SqlDataAdapter cmd = new SqlDataAdapter(Query.ToString(), Connection);
                DataTable DtTimeOutRecord = new DataTable();
                cmd.Fill(DtTimeOutRecord);
                Connection.Close();
                if (DtTimeOutRecord.Rows.Count > 0)
                {
                    return DtTimeOutRecord.Rows[0]["dateTimeRecord"].ToString();
                }
                else
                {
                    return String.Empty;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.RecordOld: {1}", core, ex.Message));
            }
        }

        /// <summary>
        /// Obtiene la ultima Marcacion del empleado
        /// </summary>
        /// <param name="IdUser"></param>
        /// <returns></returns>
        public DataTable DataTableOldRecord(int IdUser)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Query = String.Format("SELECT TOP 1 dateTimeRecord FROM checkInHours WHERE idEmployee = {0} ORDER BY id DESC", IdUser);
                return ModelDAL.DataTableRecord(Query.ToString(), ConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.DataTableOldRecord: {1}", core, ex.Message));
            }
        }


        //public void ValidRecord(DateTime DateTimeRecord, int IdUser) {
        //    try
        //    {
        //        DataTable TimeOutCheckDT = TimeOutCheck("checkin");
        //        //Validar si existe un valor anterior
        //        if(!String.IsNullOrEmpty(RecordOld(IdUser)))
        //        {

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}

        

        
    }
}
