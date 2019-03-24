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

        
        public void ValidRecord(DateTime DateTimeRecord, int IdUser)
        {
            try
            {
                DataTable TimeOutCheckDT = TurnDAL.TimeOutCheck("checkin");
                //Validar si existe un valor anterior
                if (!String.IsNullOrEmpty(TurnDAL.RecordOld(IdUser)))
                {

                }

            }
            catch (Exception ex)
            {

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

    }
}
