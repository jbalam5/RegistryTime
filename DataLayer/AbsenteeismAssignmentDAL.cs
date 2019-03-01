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
    public class AbsenteeismAssignmentDAL
    {
        public String core = "DataLayer.AbsenteeismAssignmentDAL";
        public String TableName = "AbsenteeismAssignment";

        public DataTable All(String ConnectionString)
        {
            try
            {
                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();

                String Query = String.Format("SELECT {0}.[id] ,{0}.[controlNumber] as NoControl,{0}.[KeyAbsenteeism] as ClaveAusentismo,{0}.[Description] as Descripcion,{0}.[Status] as Estado,{0}.[DateStar] as FechaInicio,{0}.[DateEnd] as FechaFinal FROM {0} where {0}._registry = 1", TableName);

                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtAbsenteeismAssignment = new DataTable();
                cmd.Fill(dtAbsenteeismAssignment);
                Conexion.Close();
                return dtAbsenteeismAssignment;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All : {1}", core, ex));
            }
        }

        public DataTable GetIdEntity(int id, string ConnectionString)
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
                DataTable dtAbsenteeismAssignment = new DataTable();
                cmd.Fill(dtAbsenteeismAssignment);
                Conexion.Close();
                return dtAbsenteeismAssignment;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity : {1}", core, ex));
            }
        }

        public int Save(AbsenteeismAssignmentML Absenteeismassignment, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("INSERT INTO {0}", TableName);
                Query.AppendLine("( controlNumber, KeyAbsenteeism, Description, Status, DateStar, DateEnd, _registry, idUserInsert, dateInsert)");
                Query.AppendLine(" VALUES(");
                Query.AppendFormat(" '{0}',", Absenteeismassignment.controlNumber);
                Query.AppendFormat(" '{0}',", Absenteeismassignment.KeyAbsenteeism);
                Query.AppendFormat(" '{0}',", Absenteeismassignment.Description);
                Query.AppendFormat(" '{0}',", Absenteeismassignment.Status);
                Query.AppendFormat(" '{0}',", Absenteeismassignment.DateStar.ToString("yyyy-MM-dd"));
                Query.AppendFormat(" '{0}',", Absenteeismassignment.DateEnd.ToString("yyyy-MM-dd"));
                Query.AppendLine(" 1,");
                Query.AppendFormat(" {0},", Absenteeismassignment.IdUserInsert);
                Query.AppendLine(" getDate() )");

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

        public int Update(AbsenteeismAssignmentML Absenteeismassignment, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ", TableName);
                Query.AppendLine(" SET ");
                Query.AppendFormat("controlNumber = '{0}', ", Absenteeismassignment.controlNumber);
                Query.AppendFormat("KeyAbsenteeism = '{0}', ", Absenteeismassignment.KeyAbsenteeism);
                Query.AppendFormat("Description = '{0}', ", Absenteeismassignment.Description);
                Query.AppendFormat("Status = '{0}', ", Absenteeismassignment.Status);
                Query.AppendFormat(" '{0}',", Absenteeismassignment.DateStar.ToString("yyyy-MM-dd"));
                Query.AppendFormat(" '{0}',", Absenteeismassignment.DateEnd.ToString("yyyy-MM-dd"));
                Query.AppendFormat("idUserUpdate = {0}, ", Absenteeismassignment.IdUserUpdate);
                Query.AppendLine("dateUpdate = GETDATE() ");
                Query.AppendFormat("WHERE id={0}", Absenteeismassignment.Id);

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

        public int Delete(AbsenteeismAssignmentML Absenteeismassignment, String ConnectionString)
            {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ", TableName);
                Query.AppendLine(" SET ");
                Query.AppendLine("_registry = 2, ");
                Query.AppendFormat("idUserDelete = {0}, ", Absenteeismassignment.IdUserDelete);
                Query.AppendLine("dateDelete = GETDATE() ");
                Query.AppendFormat("WHERE id={0}", Absenteeismassignment.Id);

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
