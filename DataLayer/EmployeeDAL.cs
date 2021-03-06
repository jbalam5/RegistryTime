﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ModelLayer;

namespace DataLayer
{
    public class EmployeeDAL
    {
        public String core = "DataLayer.EmployeeDAL";
        public String TableName = "employee";
        public int IdUserSession = 0;
        public String ConnectionString = String.Empty;



        public DataTable All(String tipo = "All" )
        {
            try
            {
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                String Query = String.Empty;
                if (tipo == "All"){
                    Query = String.Format("select * from {0} join {1} on {1}.id = {0}.idUser WHERE {0}._registry = 1", TableName, "users");
                }
                else{
                    Query = String.Format("select {0}.id AS ID, {0}.rfc AS RFC, {0}.curp AS CURP, {0}.name AS NOMBRE, {0}.lastname AS APELLIDOS,{0}.email AS CORREO, {1}.userName AS USUARIO from {0} join {1} on {1}.id = {0}.idUser WHERE {0}._registry = 1", TableName, "users");
                }
                
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

        public EmployeeML GetIdEntity(int id)
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
                DataTable dtEmployee = new DataTable();
                cmd.Fill(dtEmployee);
                Conexion.Close();
                if (dtEmployee != null && dtEmployee.Rows.Count > 0)
                {
                    return GetEntity(dtEmployee.Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity : {1}", core, ex));
            }
        }

        public EmployeeML GetEmploymentByIdUser(int id)
        {
            try
            {
                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1 AND {1} = {2}", TableName, EmployeeML.DataBase.IdUser, id);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtEmployee = new DataTable();
                cmd.Fill(dtEmployee);
                Conexion.Close();

                if (dtEmployee != null && dtEmployee.Rows.Count > 0)
                {
                    return GetEntity(dtEmployee.Rows[0]);

                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetEmploymentByIdUser : {1}", core, ex));
            }
        }

        public EmployeeML GetEntityByNoControl(int NoControl)
        {
            try
            {
                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1 AND idUser={1}", TableName, NoControl);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtEmplotment = new DataTable();
                cmd.Fill(dtEmplotment);
                Conexion.Close();

                if (dtEmplotment != null && dtEmplotment.Rows.Count > 0)
                {
                    return GetEntity(dtEmplotment.Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetEmploymentByIdUser : {1}", core, ex));
            }
        }

        public EmployeeML GetColumnsEmployee(int IdEmployee)
        {
            try
            {
                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1 AND id={1}", TableName, IdEmployee);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtEmplotment = new DataTable();
                cmd.Fill(dtEmplotment);
                Conexion.Close();

                if (dtEmplotment != null && dtEmplotment.Rows.Count > 0)
                {
                    return GetEntity(dtEmplotment.Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetColumnsEmployee : {1}", core, ex));
            }
        }

        public EmployeeML GetEntity(DataRow row)
        {
            try
            {
                if(row != null)
                {
                    EmployeeML EmployeeML = new EmployeeML()
                    {
                        Id = (row[EmployeeML.DataBase.Id] != DBNull.Value) ? Convert.ToInt32(row[EmployeeML.DataBase.Id]) : 0,
                        RFC = (row[EmployeeML.DataBase.Rfc] != DBNull.Value) ? row[EmployeeML.DataBase.Rfc].ToString() : string.Empty,
                        Curp = (row[EmployeeML.DataBase.Curp] != DBNull.Value) ? row[EmployeeML.DataBase.Curp].ToString() : string.Empty,
                        Name = (row[EmployeeML.DataBase.Name] != DBNull.Value) ? row[EmployeeML.DataBase.Name].ToString() : string.Empty,
                        LastName = (row[EmployeeML.DataBase.Lastname] != DBNull.Value) ? row[EmployeeML.DataBase.Lastname].ToString() : string.Empty,
                        Scholarship = (row[EmployeeML.DataBase.Scholarship] != DBNull.Value) ? row[EmployeeML.DataBase.Scholarship].ToString() : string.Empty,
                        Birthdate = (row[EmployeeML.DataBase.Birthdate] != DBNull.Value) ? Convert.ToDateTime(row[EmployeeML.DataBase.Birthdate]) : Convert.ToDateTime(row[EmployeeML.DataBase.Birthdate]),
                        Gender = (row[EmployeeML.DataBase.Gender] != DBNull.Value) ? row[EmployeeML.DataBase.Gender].ToString() : string.Empty,
                        Nationality = (row[EmployeeML.DataBase.Nationality] != DBNull.Value) ? row[EmployeeML.DataBase.Nationality].ToString() : string.Empty,
                        Address = (row[EmployeeML.DataBase.Address] != DBNull.Value) ? row[EmployeeML.DataBase.Address].ToString() : string.Empty,
                        Municipality = (row[EmployeeML.DataBase.Municipality] != DBNull.Value) ? row[EmployeeML.DataBase.Municipality].ToString() : string.Empty,
                        Country = (row[EmployeeML.DataBase.Country] != DBNull.Value) ? row[EmployeeML.DataBase.Country].ToString() : string.Empty,
                        Email = (row[EmployeeML.DataBase.Email] != DBNull.Value) ? row[EmployeeML.DataBase.Email].ToString() : string.Empty,
                        CivilStatus = (row[EmployeeML.DataBase.CivilStatus] != DBNull.Value) ? row[EmployeeML.DataBase.CivilStatus].ToString() : string.Empty,
                        Colony = (row[EmployeeML.DataBase.Colony] != DBNull.Value) ? row[EmployeeML.DataBase.Colony].ToString() : string.Empty,
                        StateCountry = (row[EmployeeML.DataBase.StateCountry] != DBNull.Value) ? row[EmployeeML.DataBase.StateCountry].ToString() : string.Empty,
                        PostalCode = (row[EmployeeML.DataBase.PostalCode] != DBNull.Value) ? int.Parse(row[EmployeeML.DataBase.PostalCode].ToString()) : 0,
                        SureType = (row[EmployeeML.DataBase.SureType] != DBNull.Value) ? row[EmployeeML.DataBase.SureType].ToString() : string.Empty,
                        IdJob = (row[EmployeeML.DataBase.IdJob] != DBNull.Value) ? int.Parse(row[EmployeeML.DataBase.IdJob].ToString()) : 0,
                        IdDepartament = (row[EmployeeML.DataBase.IdDepartament] != DBNull.Value) ? int.Parse(row[EmployeeML.DataBase.IdDepartament].ToString()) : 0,
                        IdUser = (row[EmployeeML.DataBase.IdUser] != DBNull.Value) ? int.Parse(row[EmployeeML.DataBase.IdUser].ToString()) : 0,
                        Telephone = (row[EmployeeML.DataBase.Telephone] != DBNull.Value) ? row[EmployeeML.DataBase.Telephone].ToString() : String.Empty,
                        Salary = (row[EmployeeML.DataBase.Salary] != DBNull.Value) ? decimal.Parse(row[EmployeeML.DataBase.Salary].ToString()) : 0,
                        HoursDay = (row[EmployeeML.DataBase.HoursDay] != DBNull.Value) ? Convert.ToDateTime(row[EmployeeML.DataBase.HoursDay].ToString()) : DateTime.Now,
                        NumberSure = (row[EmployeeML.DataBase.NumberSure] != DBNull.Value) ? row[EmployeeML.DataBase.NumberSure].ToString() : String.Empty,
                    };
                    return EmployeeML;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity : {1}", core, ex));
            }
        }

        public int Save(EmployeeML employee)
        {
            try
            {
                
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.InsertModel(employee, TableName, IdUserSession);
                
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

        public int Update(EmployeeML Employee)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.UpdateModel(Employee, TableName, IdUserSession);
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Response.ToString(), Conexion);
                cmd2.ExecuteNonQuery();
                Conexion.Close();
                return Employee.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.update: {1}", core, ex));
            }
        }

        public void Delete(EmployeeML Employee)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                String Response = ModelDAL.DeleteModel(Employee, TableName, IdUserSession);
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
    }
}
