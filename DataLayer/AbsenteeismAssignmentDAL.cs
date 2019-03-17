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
        public int IdUserSession = 0;
        public String ConnectionString = String.Empty;

        public DataTable All()
        {
            try
            {
                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();

                String Query = String.Format("SELECT {0}.[id],{0}.[KeyAbsenteeism] as ClaveAusentismo,{0}.[Description] as Descripcion,{0}.[Status] as Estado,{0}.[DateStar] as FechaInicio,{0}.[DateEnd] as FechaFinal FROM {0} where {0}._registry = 1", TableName);

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

        public int Save(AbsenteeismAssignmentML Absenteeismassignment)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.InsertModel(Absenteeismassignment, TableName, IdUserSession);

                SqlConnection Conexion = new SqlConnection()
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
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.save : {1}", core, ex));
            }
        }

        public int Update(AbsenteeismAssignmentML Absenteeismassignment)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.UpdateModel(Absenteeismassignment, TableName, IdUserSession);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Response.ToString(), Conexion);
                cmd2.ExecuteNonQuery();
                return Absenteeismassignment.Id;

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.update: {1}", core, ex));
            }
        }

        public void Delete(AbsenteeismAssignmentML Absenteeismassignment)
        {
            try
            {
             
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.DeleteModel(Absenteeismassignment, TableName, IdUserSession);
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

        public AbsenteeismAssignmentML GetEntityId(int id)
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
                return GetEntityId(dtAbsenteeismAssignment.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity : {1}", core, ex));
            }
        }

        public AbsenteeismAssignmentML GetEntityId(DataRow row)
        {
            try
            {
                if (row != null)
                {
                    AbsenteeismAssignmentML AbsenteeismAssignmentML = new AbsenteeismAssignmentML()
                    {
                        Id = (row[AbsenteeismAssignmentML.DataBase.Id] != DBNull.Value) ? Convert.ToInt32(row[AbsenteeismAssignmentML.DataBase.Id]) : 0,
                        ControlNumber = (row[AbsenteeismAssignmentML.DataBase.controlNumber] != DBNull.Value) ? row[AbsenteeismAssignmentML.DataBase.controlNumber].ToString() : string.Empty,
                        KeyAbsenteeism = (row[AbsenteeismAssignmentML.DataBase.KeyAbsenteeism] != DBNull.Value) ? row[AbsenteeismAssignmentML.DataBase.KeyAbsenteeism].ToString() : string.Empty,
                        Description = (row[AbsenteeismAssignmentML.DataBase.Description] != DBNull.Value) ? row[AbsenteeismAssignmentML.DataBase.Description].ToString() : string.Empty,
                        Status = (row[AbsenteeismAssignmentML.DataBase.Status] != DBNull.Value) ? row[AbsenteeismAssignmentML.DataBase.Status].ToString() : string.Empty,
                        DateStar = (row[AbsenteeismAssignmentML.DataBase.DateStar] != DBNull.Value) ? Convert.ToDateTime(row[AbsenteeismAssignmentML.DataBase.DateStar]) : Convert.ToDateTime(row[AbsenteeismAssignmentML.DataBase.DateStar]),
                        DateEnd = (row[AbsenteeismAssignmentML.DataBase.DateEnd] != DBNull.Value) ? Convert.ToDateTime(row[AbsenteeismAssignmentML.DataBase.DateEnd]) : Convert.ToDateTime(row[AbsenteeismAssignmentML.DataBase.DateEnd]),
                    };
                    return AbsenteeismAssignmentML;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity : {1}", ex.Message));
            }
        }
    }
}
