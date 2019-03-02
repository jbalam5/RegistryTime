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

        public DepartamentML GetDepartament(DataRow row)
        {
            try
            {
                if (row != null)
                {
                    DepartamentML Departament = new DepartamentML()
                    {
                        Id = (row[DepartamentML.DataBase.Id] != DBNull.Value) ? int.Parse(row[DepartamentML.DataBase.Id].ToString()) : 0,
                        Name = (row[DepartamentML.DataBase.Name] != DBNull.Value) ? row[DepartamentML.DataBase.Name].ToString() : string.Empty,
                        Manager = (row[DepartamentML.DataBase.Manager] != DBNull.Value) ? row[DepartamentML.DataBase.Manager].ToString() : string.Empty,
                        Description = (row[DepartamentML.DataBase.Description] != DBNull.Value) ? row[DepartamentML.DataBase.Description].ToString() : string.Empty
                    };

                    return Departament;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.GetDepartament : {1}", core, ex));
            }
        }

        public DepartamentML GetIdEntity(int id)
        {
            try
            {
                
                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1 AND id={1}", TableName,id);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtDepartamentos = new DataTable();
                cmd.Fill(dtDepartamentos);
                Conexion.Close();
                return GetDepartament(dtDepartamentos.Rows[0]);
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

        public void Delete(DepartamentML Departament)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.DeleteModel(Departament, TableName, IdUserSession);
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
