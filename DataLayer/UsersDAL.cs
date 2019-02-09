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
    public class UsersDAL
    {
        public String core = "DataLayer.UsersDAL";
        public String TableName = "users";

        public DataTable All(String ConnectionString)
        {
            try
            {
                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = ConnectionString;
                Conexion.Open();
                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1",TableName);
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

        public DataTable GetIdEntity(int id, String ConnectionString)
        {
            try
            {

                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1 AND id={1}", TableName, id);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };

                Conexion.Open();
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtDepartamentos = new DataTable();
                cmd.Fill(dtDepartamentos);
                Conexion.Close();
                return dtDepartamentos;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity : {1}", core, ex));
            }
        }


        public int Save(UsersML user, String ConnectionString)
        {
            try
            {
                 
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("INSERT INTO {0}", TableName);
                Query.AppendLine("( userName,password,rol,image,_registry,idUserInsert,dateInsert)");
                Query.AppendFormat(" VALUES('{0}','{1}',{2},'{3}',1,{4},GETDATE())",user.UserName,user.Password,user.Rol,user.Image, user.IdUserInsert);
                Query.AppendLine(" SELECT CAST(scope_identity() AS int)");
                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                
                using (SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion))
                {
                    Conexion.Open();
                    int  newID = (Int32)cmd2.ExecuteScalar();

                    if (Conexion.State == System.Data.ConnectionState.Open) Conexion.Close();
                    return newID;
                }
                
                    
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.save : {1}", core, ex));
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

        public int Update(UsersML user, String ConnectionString)
        {
            try
            {
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ",TableName);
                Query.AppendLine(" SET ");
                Query.AppendFormat("username = '{0}'", user.UserName);
                Query.AppendFormat("password = '{0}'", user.Password);
                Query.AppendFormat("rol = {0}", user.Rol);
                Query.AppendFormat("image = '{0}'", user.Image);
                Query.AppendFormat("idUserUpdate = {0}", user.IdUserUpdate);
                Query.AppendLine("dateUpdate = GETDATE()");
                Query.AppendFormat("WHERE id={0}", user.Id);
                
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };

                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion);
                cmd2.ExecuteNonQuery();
                return user.Id;


            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.update: {1}", core, ex));
            }
        }

        public int Delete(UsersML user, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ", TableName);
                Query.AppendLine(" SET ");
                Query.AppendLine("_registry = 2");
                Query.AppendFormat("idUserDelete = {0}", user.IdUserDelete);
                Query.AppendLine("dateDelete = GETDATE()");
                Query.AppendFormat("WHERE id={0}", user.Id);

                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = ConnectionString;
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
        
        public UsersML IsUser(UsersML user, String ConnectionString)
        {
            try
            {
                if (user != null)
                {
                    if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password))
                    {
                        String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1 AND userName='{1}' AND password='{2}'", TableName, user.UserName, user.Password);
                        SqlConnection Conexion = new SqlConnection();
                        Conexion.ConnectionString = ConnectionString;
                        Conexion.Open();
                        SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                        DataTable dtUser = new DataTable();
                        cmd.Fill(dtUser);
                        Conexion.Close();

                        if (dtUser != null && dtUser.Rows.Count > 0)
                        {
                            return getEntity(dtUser.Rows[0]);
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.delete: {1}", core, ex));
            }
        }

        private UsersML getEntity(DataRow row)
        {
            try
            {
                if(row != null)
                {
                    UsersML userML = new UsersML()
                    {
                        Id = (row["Id"] != DBNull.Value) ? int.Parse(row["Id"].ToString()) : 0,
                        UserName = (row["userName"] != DBNull.Value) ? row["userName"].ToString() : string.Empty,
                        Rol = (row["rol"] != DBNull.Value) ? row["rol"].ToString() : string.Empty
                    };

                    return userML;
                }
                return null;
            }catch(Exception ex)
            {
                throw new Exception(string.Format("getEntity: {0}", ex.Message));
            }
        }
    }
}
