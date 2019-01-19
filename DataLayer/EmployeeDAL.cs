using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class EmployeeDAL
    {
        public String core = "DataLayer.EmployeeDAL";
        public String TableName = "employee";

        public int Id { get; set; }
        public String RFC { get; set; }
        public String Curp { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Scholarship { get; set; }
        public String IdJob { get; set; }
        public String IdDepartament { get; set; }
        public String IdUser { get; set; }
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


        public int Save(EmployeeDAL employee, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("INSERT INTO {0}", TableName);
                Query.AppendLine("( rfc,curp,name,lastname,scholarship,idJob,idDepartament,idUser,_registry,idUserInsert,dateInsert)");
                Query.AppendFormat(" VALUES({0},{1},{2},{3},{4},{5},{6},{7},1,{9},GETDATE())", employee.RFC, employee.Curp, employee.Name, employee.LastName,employee.Scholarship, employee.IdJob, employee.IdDepartament, employee.IdUser,employee.IdUserDelete);
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

        public int Update(EmployeeDAL employee, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ", TableName);
                Query.AppendLine(" SET ");
                Query.AppendFormat("rfc = {0}", employee.RFC);
                Query.AppendFormat("curp = {0}", employee.Curp);
                Query.AppendFormat("name = {0}", employee.Name);
                Query.AppendFormat("lastname = {0}", employee.LastName);
                Query.AppendFormat("scholarship = {0}", employee.Scholarship);
                Query.AppendFormat("idJob = {0}", employee.IdJob);
                Query.AppendFormat("idDepartament = {0}", employee.IdDepartament);
                Query.AppendFormat("idUser = {0}", employee.IdUser);
                Query.AppendFormat("idUserUpdate = {0}", employee.IdUserUpdate);
                Query.AppendLine("dateUpdate = GETDATE()");
                Query.AppendFormat("WHERE id={0}", employee.Id);

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

        public int Delete(EmployeeDAL employee, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ", TableName);
                Query.AppendLine(" SET ");
                Query.AppendLine("_registry = 2");
                Query.AppendFormat("idUserDelete = {0}", employee.IdUserDelete);
                Query.AppendLine("dateDelete = GETDATE()");
                Query.AppendFormat("WHERE id={0}", employee.Id);

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
