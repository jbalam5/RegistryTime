using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class UsersDAL
    {
        public String core = "DataLayer.UsersDAL";
        public String TableName = "users";

        public int Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Rol { get; set; }
        public String Image { get; set; }
        public int _regitry { get; set; }
        public int IdUserInsert { get; set; }
        public DateTime DateInsert { get; set; }
        public int IdUserUpdate { get; set; }
        public DateTime DateUpdate { get; set; }
        public int IdUserDelete { get; set; }
        public DateTime DateDelete { get; set; }


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
                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = ConnectionString;
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


        public int Save(UsersDAL user, String ConnectionString)
        {
            try
            {
                int id = 0;               
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("INSERT INTO {0}", TableName);
                Query.AppendLine("( userName,password,rol,image,_registry,idUserInsert,dateInsert)");
                Query.AppendFormat(" VALUES({0},{1},{2},{3},1,{4},GETDATE())",user.UserName,user.Password,user.Rol,user.Image, user.IdUserInsert);
                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = ConnectionString;
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

        public int Update(UsersDAL user, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ",TableName);
                Query.AppendLine(" SET ");
                Query.AppendFormat("username = {0}", user.UserName);
                Query.AppendFormat("password = {0}", user.Password);
                Query.AppendFormat("rol = {0}", user.Rol);
                Query.AppendFormat("image = {0}", user.Image);
                Query.AppendFormat("idUserUpdate = {0}", user.IdUserUpdate);
                Query.AppendLine("dateUpdate = GETDATE()");
                Query.AppendFormat("WHERE id={0}", user.Id);
                
                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = ConnectionString;
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion);
                id = cmd2.ExecuteNonQuery();
                return id;


            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.update: {1}", core, ex));
            }
        }

        public int Delete(UsersDAL user, String ConnectionString)
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
    }
}
