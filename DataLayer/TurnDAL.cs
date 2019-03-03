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
    public class TurnDAL
    {
        public String core = "DataLayer.TurnDAL";
        public String TableName = "turn";
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
                //String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1", TableName);
                String Query = String.Format("SELECT {0}.[id] ,{0}.[name] as Turno,{0}.[Description] as Descripcion,{0}.[TimeEntry] as HoraEntrada,{0}.[StartEntry] as IniciaEntrada,{0}.[LimitEntry] as LimiteEntrada,{0}.[Departuretime] as HoraSalida,{0}.[LimitDeparture] as LimiteSalida, {0}.[HoursJornada] as HorasJornada  FROM {0} where {0}._registry = 1", TableName);

                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtTurnos = new DataTable();
                cmd.Fill(dtTurnos);
                Conexion.Close();
                return dtTurnos;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All : {1}", core, ex));
            }

        }

        public TurnML GetEntity(DataRow row)
        {
            try
            {
                if (row != null)
                {
                    TurnML TurnML = new TurnML()
                    {
                        Id = (row[TurnML.DataBase.Id] != DBNull.Value) ? int.Parse(row[TurnML.DataBase.Id].ToString()) : 0,
                        Name = (row[TurnML.DataBase.Name] != DBNull.Value) ? row[TurnML.DataBase.Name].ToString() : string.Empty,
                        Description = (row[TurnML.DataBase.Description] != DBNull.Value) ? row[TurnML.DataBase.Description].ToString() : string.Empty,
                        TimeEntry = (row[TurnML.DataBase.TimeEntry] != DBNull.Value) ? Convert.ToDateTime( row[TurnML.DataBase.TimeEntry].ToString()):DateTime.Now,
                        StartEntry = (row[TurnML.DataBase.StartEntry] != DBNull.Value) ? Convert.ToDateTime(row[TurnML.DataBase.StartEntry].ToString()) : DateTime.Now,
                        LimitEntry = (row[TurnML.DataBase.LimitEntry] != DBNull.Value) ? Convert.ToDateTime(row[TurnML.DataBase.LimitEntry].ToString()) : DateTime.Now,
                        Departuretime = (row[TurnML.DataBase.Departuretime] != DBNull.Value) ? Convert.ToDateTime(row[TurnML.DataBase.Departuretime].ToString()) : DateTime.Now,
                        LimitDeparture = (row[TurnML.DataBase.LimitDeparture] != DBNull.Value) ? Convert.ToDateTime(row[TurnML.DataBase.LimitDeparture].ToString()) : DateTime.Now,
                        HoursJornada = (row[TurnML.DataBase.HoursJornada] != DBNull.Value) ? Convert.ToDateTime(row[TurnML.DataBase.HoursJornada].ToString()) : DateTime.Now,

                    };

                    return TurnML;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.GetEntity : {1}", core, ex));
            }
        }

        public TurnML GetIdEntity(int id)
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
                DataTable dtTurnos = new DataTable();
                cmd.Fill(dtTurnos);
                Conexion.Close();
                return GetEntity(dtTurnos.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity : {1}", core, ex));
            }
        }

        public int Save(TurnML Turn)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.InsertModel(Turn, TableName, IdUserSession);
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

        public int Update(TurnML Turn)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.UpdateModel(Turn, TableName, IdUserSession);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Response.ToString(), Conexion);
                cmd2.ExecuteNonQuery();
                return Turn.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.update: {1}", core, ex));
            }
        }

        public void Delete(TurnML Turn)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.DeleteModel(Turn, TableName, IdUserSession);
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
                throw new Exception(String.Format("{0}.delete: {1}", core, ex));
            }
        }
    }
}
