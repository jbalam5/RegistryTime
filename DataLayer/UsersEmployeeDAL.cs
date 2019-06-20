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
    public class UsersEmployeeDAL
    {
        public String TableName = "usersEmployee";
        private String core = "DataLayer.PermissionDAL";
        public String ConnectionString = String.Empty;
        public int IdUserSession = 0;

        public UsersEmployeeML GetEntityByIdUser(int id)
        {
            try
            {
                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1 AND idUser={1}", TableName, id);
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
                    return getEntityObject(dtUsers.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.getEntityObject : {1}", core, ex));
            }
        }

        public UsersEmployeeML getEntityObject(DataRow drUserEmployee)
        {
            try
            {
                UsersEmployeeML usersEmployee = new UsersEmployeeML()
                {
                    Id = (drUserEmployee[UsersEmployeeML.DataBase.Id] != DBNull.Value) ? int.Parse(drUserEmployee[UsersEmployeeML.DataBase.Id].ToString()) : 0,
                    IdEmployee = (drUserEmployee[UsersEmployeeML.DataBase.IdEmployee] != DBNull.Value) ? int.Parse(drUserEmployee[UsersEmployeeML.DataBase.IdEmployee].ToString()) : 0,
                    IdUser = (drUserEmployee[UsersEmployeeML.DataBase.IdUser] != DBNull.Value) ? int.Parse(drUserEmployee[UsersEmployeeML.DataBase.IdUser].ToString()) : 0
                };

                return usersEmployee;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.getEntityObject : {1}", core, ex));
            }
        }

        public int Insert(UsersEmployeeML usersEmployee)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.InsertModel(usersEmployee, TableName, IdUserSession);
                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Response.ToString(), Conexion);
                return cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Insert : {1}", core, ex));
            }
        }

        public int Update(UsersEmployeeML usersEmployee)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.UpdateModel(usersEmployee, TableName, IdUserSession);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Response.ToString(), Conexion);
                cmd2.ExecuteNonQuery();
                Conexion.Close();

                return usersEmployee.Id;

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.update: {1}", core, ex));
            }
        }

        public void Delete(UsersEmployeeML usersEmployee)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.DeleteModel(usersEmployee, TableName, IdUserSession);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Response.ToString(), Conexion);
                cmd2.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.delete: {1}", core, ex));
            }
        }

        public Boolean UserExists(int idUser)
        {
            try
            {
                if (idUser > 0)
                {
                    StringBuilder Query = new StringBuilder();
                    Query.AppendFormat("select * from {0} where idUser = {1}", TableName, idUser);
                    SqlConnection Conexion = new SqlConnection()
                    {
                        ConnectionString = ConnectionString
                    };
                    Conexion.Open();
                    SqlDataAdapter cmd = new SqlDataAdapter(Query.ToString(), Conexion);
                    DataTable dtUsers = new DataTable();
                    cmd.Fill(dtUsers);
                    Conexion.Close();
                    if (dtUsers.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
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
    }
}
