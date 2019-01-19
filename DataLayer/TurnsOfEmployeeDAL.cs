using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class TurnsOfEmployeeDAL
    {
        public String core = "DataLayer.TurnDAL";
        public String TableName = "turnOfOfEmployye";

        public int Id { get; set; }
        public String IdTurn { get; set; }
        public String IdEmployee { get; set; }
        public string Observation { get; set; }
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
                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
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
                SqlConnection Conexion = new SqlConnection
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

        public int Save(TurnsOfEmployeeDAL turnsOfEmployee, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("INSERT INTO {0}", TableName);
                Query.AppendLine("( idTurn,idEmployee,observation,_registry,idUserInsert,dateInsert)");
                Query.AppendFormat(" VALUES({0},{1},{2},1,{2},())", turnsOfEmployee.IdTurn, turnsOfEmployee.IdEmployee, turnsOfEmployee.IdUserInsert);
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

        public int Update(TurnsOfEmployeeDAL turnsOfEmployee ,String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ", TableName);
                Query.AppendLine(" SET ");
                Query.AppendFormat("idTurn = {0}", turnsOfEmployee.IdTurn);
                Query.AppendFormat("IdEmployee = {0}", turnsOfEmployee.Id);
                Query.AppendFormat("observation = {0}", turnsOfEmployee.Observation);
                Query.AppendLine("dateUpdate = GETDATE()");
                Query.AppendFormat("WHERE id={0}", turnsOfEmployee.Id);

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

        public int Delete(TurnsOfEmployeeDAL turnsOfEmployee, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ", TableName);
                Query.AppendLine(" SET ");
                Query.AppendLine("_registry = 2");
                Query.AppendFormat("idUserDelete = {0}", turnsOfEmployee.IdUserDelete);
                Query.AppendLine("dateDelete = GETDATE()");
                Query.AppendFormat("WHERE id={0}", turnsOfEmployee.Id);

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
