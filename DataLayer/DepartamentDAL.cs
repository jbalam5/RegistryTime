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
    public class DepartamentDAL
    {
        public String core = "DataLayer.DepartamentDAL";
        public String TableName = "departament";
        public String TablaStatusBook = "statusBook";

        public DataTable All(String ConnectionString)
        {
            try
            {
                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = ConnectionString;
                Conexion.Open();
                //String Query = String.Format("SELECT {0}.[id] ,{0}.[name] as Nombre,{0}.[manager] as Encargado,{0}.[description] as Descripcion,{1}.Name as Estado FROM {0} left outer join {1} on {1}.id = {0}._registry where {0}._registry = 1", TableName, TablaStatusBook);
                String Query = String.Format("SELECT {0}.[id] ,{0}.[name] as Nombre,{0}.[manager] as Encargado,{0}.[description] as Descripcion FROM {0} where {0}._registry = 1", TableName);
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

        public DataTable GetIdEntity(int id ,String ConnectionString)
        {
            try
            {
                
                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1 AND id={1}", TableName,id);
                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = ConnectionString;
                Conexion.Open();
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtDepartamentos = new DataTable();
                cmd.Fill(dtDepartamentos);
                Conexion.Close();
                return dtDepartamentos;
            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity : {1}", core, ex));
            }
        }

        public int LastId(String ConnectionString)
        {
            try
            {
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT LAST_INSERT_ID() as lastid", Conexion);
                int idInsert = (int)cmd2.ExecuteScalar();
                Conexion.Close();
                return idInsert;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.LastId : {1}", core, ex));
            }
        }

        public int Save(DepartamentML Departament, String ConnectionString)
        {
            try
            {
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("INSERT INTO {0}", TableName);
                Query.AppendLine("( name,manager,description,_registry,idUserInsert,dateInsert)");
                Query.AppendLine(" VALUES( ");
                Query.AppendFormat(" '{0}', ", Departament.Name);
                Query.AppendFormat(" '{0}', ", Departament.Manager);
                Query.AppendFormat(" '{0}', ", Departament.Description);
                Query.AppendLine(" 1, ");
                Query.AppendFormat(" {0}, ", Departament.IdUserInsert);
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
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.save : {1}", core, ex));
            }

        }

        public int Update(DepartamentML departament, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ", TableName);
                Query.AppendLine(" SET ");
                Query.AppendFormat(" name = '{0}',", departament.Name);
                Query.AppendFormat(" manager = '{0}',", departament.Manager);
                Query.AppendFormat(" description = '{0}',", departament.Description);
                Query.AppendFormat(" idUserUpdate = {0},", departament.IdUserUpdate);
                Query.AppendLine(" dateUpdate = GETDATE()");
                Query.AppendFormat(" WHERE id={0}", departament.Id);

                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = ConnectionString;
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

        public int Delete(DepartamentML departament, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ", TableName);
                Query.AppendLine(" SET ");
                Query.AppendLine(" _registry = 2,");
                Query.AppendFormat(" idUserDelete = {0}, ", departament.IdUserDelete);
                Query.AppendLine(" dateDelete = GETDATE()");
                Query.AppendFormat("WHERE id={0}", departament.Id);

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
