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

        public DataTable All(String ConnectionString)
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

        public DataTable GetIdEntity(int id, String ConnectionString)
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
                return dtTurnos;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity : {1}", core, ex));
            }
        }

        public int Save(TurnML Turn, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("INSERT INTO {0}", TableName);
                Query.AppendLine("( name, Description, TimeEntry, StartEntry, LimitEntry, Departuretime, LimitDeparture, HoursJornada, _registry, idUserInsert, dateInsert)");
                Query.AppendLine(" VALUES(");
                Query.AppendFormat(" '{0}',", Turn.Name);
                Query.AppendFormat(" '{0}',", Turn.Description);
                Query.AppendFormat(" '{0}',", Turn.TimeEntry.ToString("HH:mm:ss"));
                Query.AppendFormat(" '{0}',", Turn.StartEntry.ToString("hh:mm:ss"));
                Query.AppendFormat(" '{0}',", Turn.LimitEntry.ToString("hh:mm:ss"));
                Query.AppendFormat(" '{0}',", Turn.Departuretime.ToString("hh:mm:ss"));
                Query.AppendFormat(" '{0}',", Turn.LimitDeparture.ToString("hh:mm:ss"));
                Query.AppendFormat(" {0},", Turn.HoursJornada);
                Query.AppendLine(" 1,");
                Query.AppendFormat(" {0},", Turn.IdUserInsert );
                Query.AppendLine(" getDate() )");
               
                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion);
                id = cmd2.ExecuteNonQuery();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.save : {1}", core, ex));
            }

        }

        public int Update(TurnML turn, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ", TableName);
                Query.AppendLine(" SET ");
                Query.AppendFormat("name = '{0}', ", turn.Name);
                Query.AppendFormat("description = '{0}', ", turn.Description);
                Query.AppendFormat("timeentry = '{0}', ", turn.TimeEntry);
                Query.AppendFormat("startentry = '{0}', ", turn.StartEntry);
                Query.AppendFormat("limitentry = '{0}', ", turn.LimitEntry);
                Query.AppendFormat("departuretime = '{0}', ", turn.Departuretime);
                Query.AppendFormat("limitdeparture = '{0}', ", turn.LimitDeparture);
                Query.AppendFormat("hoursjornada = {0}, ", turn.HoursJornada);
                Query.AppendFormat("idUserUpdate = {0}, ", turn.IdUserUpdate);
                Query.AppendLine("dateUpdate = GETDATE() ");
                Query.AppendFormat("WHERE id={0}", turn.Id);

                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion);
                id = cmd2.ExecuteNonQuery();
                return id;


            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.update: {1}", core, ex));
            }
        }

        public int Delete(TurnML turn, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ", TableName);
                Query.AppendLine(" SET ");
                Query.AppendLine("_registry = 2, ");
                Query.AppendFormat("idUserDelete = {0}, ", turn.IdUserDelete);
                Query.AppendLine("dateDelete = GETDATE() ");
                Query.AppendFormat("WHERE id={0}", turn.Id);

                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion);
                id = cmd2.ExecuteNonQuery();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.delete: {1}", core, ex));
            }
        }
    }
}
