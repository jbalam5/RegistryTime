using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ModelLayer;

namespace DataLayer
{
    public class CheckInHoursDAL
    {
        public String core = "DataLayer.CheckInHoursDAL";
        public String TableName = "checkInHours";
        public String ConnectionString = String.Empty;
        public int IdUserSession = 0;

        public DataTable All()
        {
            try
            {
                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1", TableName);
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtDepartamentos = new DataTable();
                cmd.Fill(dtDepartamentos);
                Conexion.Close();
                return dtDepartamentos;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All : {1}", core, ex));
            }

        }

        public DataTable GetIdEntity(int id)
        {
            try
            {

                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1 AND id={1}", TableName, id);
                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtCheckIn = new DataTable();
                cmd.Fill(dtCheckIn);
                Conexion.Close();
                return dtCheckIn;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity : {1}", core, ex));
            }
        }

        //public CheckInHoursML GetEntityByNoControl(int Id, string ConnectionString)
        //{
        //    try
        //    {
        //        String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1 AND id={1}", TableName, id);
        //        SqlConnection Conexion = new SqlConnection
        //        {
        //            ConnectionString = ConnectionString
        //        };
        //        Conexion.Open();
        //        SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
        //        DataTable dtDepartamentos = new DataTable();
        //        cmd.Fill(dtDepartamentos);
        //        Conexion.Close();
        //        return dtDepartamentos;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw new Exception(String.Format("{0}.GetEntityByNoControl : {1}", core, ex));
        //    }

        //}

        public int Save(CheckInHoursML CheckInHours)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.InsertModel(CheckInHours, TableName, IdUserSession);

                SqlConnection Conexion = new SqlConnection()
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
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.save : {1}", core, ex));
            }

        }

        public int Update(CheckInHoursML CheckInHours)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.UpdateModel(CheckInHours, TableName, IdUserSession);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Response.ToString(), Conexion);
                cmd2.ExecuteNonQuery();
                return CheckInHours.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.update: {1}", core, ex));
            }
        }

        public void Delete(CheckInHoursML CheckInHours)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.DeleteModel(CheckInHours, TableName, IdUserSession);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Response.ToString(), Conexion);
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.delete: {1}", core, ex.Message));
            }
        }

        public void MigrateFunction(DateTime Start , DateTime End, int dividendo)
        {
            try
            {
                //String Query = String.Format("select * from {0} where _registry=1 and dateOnlyRecord between '{1}' and '{2}'", "HoursAssistance",Inicio.ToString("yyyy-MM-dd"), Fin.ToString("yyyy-MM-dd"))select * from {0} where _registry=1 and dateOnlyRecord between '{1}' and '{2}'", "HoursAssistance",Inicio.ToString("yyyy-MM-dd"), Fin.ToString("yyyy-MM-dd"));
                DateTime StartTMP = Start;
                DateTime StartTMP2 = Start;
                DateTime EndTMP = End;
                
                TimeSpan TotalDays = EndTMP.AddDays(1) - StartTMP;
                int ToDays = Convert.ToInt32(TotalDays.TotalDays);
                if (ToDays > dividendo)
                {
                    int Part = ToDays / dividendo;
                    for (int i =0; i < dividendo; i++)
                    {
                        Migrate(StartTMP, StartTMP2.AddDays(Part));
                        StartTMP = StartTMP2;
                    }
                    Migrate(StartTMP, End);

                }
                //return Response;

            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.Migrate: {1}", core, ex.Message));
            }
        }

        public void Migrate(DateTime Start, DateTime End)
        {
            try
            {
                String Query = "dbo.sp_migrar_check";
                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.CommandTimeout = 0;
                cmd.SelectCommand.Parameters.Add("@date1", SqlDbType.DateTime).Value = Start;
                cmd.SelectCommand.Parameters.Add("@date2", SqlDbType.DateTime).Value = End;
                DataTable Response = new DataTable();
                cmd.Fill(Response);
                Conexion.Close();
            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.Migrate: {1}", core, ex.Message));
            }
        }

        public DataTable GetDateReports(DateTime FechaInicio, DateTime FechaFin)
        { 
            try
            {
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("SELECT * FROM {0} ", TableName);
                Query.AppendLine("WHERE _registry = 1 ");
                Query.AppendFormat("AND Date BETWEEN {0} AND {1} ", FechaInicio.ToString("yyyy-MM-dd"), FechaFin.ToString("yyyy-MM-dd"));
                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlDataAdapter cmd = new SqlDataAdapter(Query.ToString(), Conexion);
                DataTable Response = new DataTable();
                cmd.Fill(Response);
                Conexion.Close();

                return Response;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Migrate: {1}", core, ex.Message));
            }
        }
        public String TypeCheck(DateTime Date)
        {
            try
            {
                String Query = String.Format("");
                return "ho";

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Migrate: {1}", core, ex.Message));
            }
        }

        public Boolean ExistCheck(CheckInHoursML checkInHours)
        {
            try
            {
                String Query = String.Format("select count(*) as count from {0} where _registry=1 and {1}='{2}' and {3}='{4}' and {5}='{6}'",TableName,CheckInHoursML.Database.DateTimeRecord,checkInHours.DateTimeRecord.ToString("yyyy-MM-dd hh:mm:ss"), CheckInHoursML.Database.TypeCheck, checkInHours.TypeCheck, CheckInHoursML.Database.idEmployee, checkInHours.IdEmployee);
                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                using (SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion))
                {
                    Conexion.Open();
                    int newID = (Int32)cmd2.ExecuteScalar();
                    
                    if (newID == 0)
                        return false;
                    else
                        return true;                    
                }

            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.ExistCheck: {1}", core, ex.Message));
            }
        }


    }
}
