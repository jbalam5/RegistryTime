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
        public String ConnectionString = String.Empty;
        public int IdUserSession = 0;

        public DataTable All()
        {
            try
            {
                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = ConnectionString;
                Conexion.Open();
                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1",TableName);
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtUsers = new DataTable();
                cmd.Fill(dtUsers);
                Conexion.Close();
                return dtUsers;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All : {1}", core, ex));
            }

        }

        public int UserExist(string UserName, int id)
        {
            try
            {
                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1 AND userName='{1}' AND id != {2}", TableName, UserName, id);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };

                Conexion.Open();
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtDepartamentos = new DataTable();
                cmd.Fill(dtDepartamentos);
                Conexion.Close();

                if (dtDepartamentos != null)
                {
                    return dtDepartamentos.Rows.Count;
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All : {1}", core, ex));
            }
        }

        public UsersML GetEntityById(int id)
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
                DataTable dtUsers = new DataTable();
                cmd.Fill(dtUsers);
                Conexion.Close();

                if (dtUsers != null && dtUsers.Rows.Count > 0)
                {
                    return getEntity(dtUsers.Rows[0]);
                }

                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetEntityById : {1}", core, ex));
            }
        }

        
        public int Save(UsersML User)
        {
            try
            {

                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.InsertModel(User, TableName, IdUserSession);

                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                
                using (SqlCommand cmd2 = new SqlCommand(Response.ToString(), Conexion))
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

        public int Update(UsersML User)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.UpdateModel(User, TableName, IdUserSession);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Response.ToString(), Conexion);
                cmd2.ExecuteNonQuery();

                return User.Id;

            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.update: {1}", core, ex));
            }
        }

        public int Delete(UsersML user)
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

        public Boolean UserExists(String Username)
        {
            try
            {
                if (!String.IsNullOrEmpty(Username))
                {
                    StringBuilder Query = new StringBuilder();
                    Query.AppendFormat("select * from {0} where userName = upper('{1}')", TableName, Username);
                    SqlConnection Conexion = new SqlConnection()
                    {
                        ConnectionString = ConnectionString
                    };
                    Conexion.Open();
                    SqlDataAdapter cmd = new SqlDataAdapter(Query.ToString(), Conexion);
                    DataTable dtUsers = new DataTable();
                    cmd.Fill(dtUsers);
                    Conexion.Close();
                    if(dtUsers.Rows.Count > 0)
                    {
                        return true;
                    }
                    else{
                        return false;
                    }

                }
                else
                {
                    throw new Exception("Variable Nombre Vacia!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.UserExists: {1}", core, ex));
            }
        }


        
        public UsersML IsUser(UsersML user)
        {
            try
            {
                if (user != null)
                {
                    if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password))
                    {
                        
                        String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1 AND userName='{1}' AND password='{2}'", TableName, user.UserName, user.Password);
                        SqlConnection Conexion = new SqlConnection
                        {
                            ConnectionString = ConnectionString
                        };
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
                        Id = (row[UsersML.DataBase.Id] != DBNull.Value) ? int.Parse(row[UsersML.DataBase.Id].ToString()) : 0,
                        UserName = (row[UsersML.DataBase.UserName] != DBNull.Value) ? row[UsersML.DataBase.UserName].ToString() : string.Empty,
                        Password = (row[UsersML.DataBase.Password] != DBNull.Value) ? row[UsersML.DataBase.Password].ToString() : string.Empty,
                        Rol = (row[UsersML.DataBase.Rol] != DBNull.Value) ? int.Parse(row[UsersML.DataBase.Rol].ToString()) : 0,
                        Image = (row[UsersML.DataBase.Image] != DBNull.Value) ? row[UsersML.DataBase.Image].ToString() : string.Empty,
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

