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
    public class DaysOfTurnDAL
    {
        public String core = "DataLayer.DaysOfTurnDAL";
        public String TableName = "daysOfTurn";
        public String ConnectionString = String.Empty;
        public int IdUserSession = 0;

        public DataTable All()
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

        public DataTable GetIdEntity(int id)
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

        public int Save(DaysOfTurnML DaysOfTurn)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.InsertModel(DaysOfTurn, TableName, IdUserSession);
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
                throw new Exception(String.Format("{0}.save : {1}", core, ex));
            }

        }

        public int Update(DaysOfTurnML DaysOfTurn)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.UpdateModel(DaysOfTurn, TableName, IdUserSession);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Response.ToString(), Conexion);
                cmd2.ExecuteNonQuery();

                return DaysOfTurn.Id;

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.update: {1}", core, ex));
            }
        }

        public void Delete(DaysOfTurnML DaysOfTurn)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.DeleteModel(DaysOfTurn, TableName, IdUserSession);
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
