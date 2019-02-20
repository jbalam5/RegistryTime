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
    public class TurnsOfEmployeeDAL
    {
        public String core = "DataLayer.TurnsOfEmployeeDAL";
        public String TableName = "turnsOfEmployee";


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
                DataTable dtTurnOfOfEmployye = new DataTable();
                cmd.Fill(dtTurnOfOfEmployye);
                Conexion.Close();
                return dtTurnOfOfEmployye;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All : {1}", core, ex.Message));
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
                DataTable dtTurnOfOfEmployye = new DataTable();
                cmd.Fill(dtTurnOfOfEmployye);
                Conexion.Close();
                return dtTurnOfOfEmployye;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity : {1}", core, ex.Message));
            }
        }

        public int Save(TurnsOfEmployeeML turnsOfEmployee, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("INSERT INTO {0}", TableName);
                Query.AppendLine("( idTurn,idEmployee,_registry,idUserInsert,dateInsert)");
                Query.AppendFormat(" VALUES({0},{1},1,{2},getdate())", turnsOfEmployee.IdTurn, turnsOfEmployee.IdEmployee, turnsOfEmployee.IdUserInsert);
                Query.AppendLine(" SELECT CAST(scope_identity() AS int)");
                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion);
                id = (Int32)cmd2.ExecuteScalar();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.save : {1}", core, ex.Message));
            }

        }

        public DataTable GetIdEntitys(int id, String ConnectionString)
        {
            try
            {
                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1 AND idEmployee={1}", TableName, id);
                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtTurnOfOfEmployye = new DataTable();
                cmd.Fill(dtTurnOfOfEmployye);
                Conexion.Close();
                return dtTurnOfOfEmployye;
            }
            catch(Exception ex){
                throw new Exception(String.Format("{0}.save : {1}", core, ex.Message));
            }

        }

        public void DeleteRegistrys(int idEmployee,String ConnectionString)
        {
            try
            {
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("Delete from {0}", TableName);
                Query.AppendFormat(" WHERE idEmployee={0}", idEmployee);

                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion);
                cmd2.ExecuteNonQuery();
            }catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.save : {1}", core, ex.Message));
            }
        }

        public int Update(TurnsOfEmployeeML turnsOfEmployee ,String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ", TableName);
                Query.AppendLine(" SET ");
                Query.AppendFormat("idTurn = {0}", turnsOfEmployee.IdTurn);
                Query.AppendFormat("IdEmployee = {0}", turnsOfEmployee.Id);
                Query.AppendFormat("observation = '{0}'", turnsOfEmployee.Observation);
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
                throw new Exception(String.Format("{0}.update: {1}", core, ex.Message));
            }
        }

        public int Delete(TurnsOfEmployeeML turnsOfEmployee, String ConnectionString)
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
                throw new Exception(String.Format("{0}.delete: {1}", core, ex.Message));
            }
        }

    }
}
