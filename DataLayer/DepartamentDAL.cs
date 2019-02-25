using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ModelLayer;
using System.Reflection;

namespace DataLayer
{
    public class DepartamentDAL
    {
        public String core = "DataLayer.DepartamentDAL";
        public String TableName = "departament";
        public String TablaStatusBook = "statusBook";
        public String ConnectionString = String.Empty;
        public int IdUserSession = 0;
        

        public DataTable All()
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
         public DataTable AllTable()
        {
            try
            {
                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = ConnectionString;
                Conexion.Open();
                String Query = String.Format("SELECT * FROM {0} where {0}._registry = 1", TableName);
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

        public int Save(DepartamentML Departament)
        {
            ModelDAL data = new ModelDAL();
            String Response = data.InsertModel(Departament, TableName,IdUserSession);
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

        public int Update(DepartamentML Departament)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.UpdateModel(Departament, TableName, IdUserSession);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Response.ToString(), Conexion);
                cmd2.ExecuteNonQuery();
                return Departament.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.update: {1}", core, ex));
            }
        }

        public int Delete(DepartamentML departament)
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

    public class CPropiedadValor
    {
        public string Propiedad { get; set; }
        public string Valor { get; set; }
    }
}
