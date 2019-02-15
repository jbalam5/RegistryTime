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
    public class EmployeeDAL
    {
        public String core = "DataLayer.EmployeeDAL";
        public String TableName = "employee";

       
        public DataTable All(String ConnectionString)
        {
            try
            {
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                String Query = String.Format("select {0}.id, {0}.rfc, {0}.curp, {0}.name, {0}.lastname,{0}.email, {1}.userName from {0} join {1} on {1}.id = {0}.idUser WHERE {0}._registry = 1", TableName, "users");
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
                SqlConnection Conexion = new SqlConnection()
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

        public EmployeeML GetEmploymentByIdUser(int id, String ConnectionString)
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
                DataTable dtDepartamentos = new DataTable();
                cmd.Fill(dtDepartamentos);
                Conexion.Close();

                if (dtDepartamentos != null && dtDepartamentos.Rows.Count > 0)
                {
                    return GetEntity(dtDepartamentos.Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetEmploymentByIdUser : {1}", core, ex));
            }
        }

        public EmployeeML GetEntity(DataRow row)
        {
            try
            {
                if(row != null)
                {
                    EmployeeML employmentML = new EmployeeML()
                    {
                        RFC = (row[EmployeeML.DataBase.Rfc] != DBNull.Value) ? row[EmployeeML.DataBase.Rfc].ToString() : string.Empty,
                        Curp = (row[EmployeeML.DataBase.Curp] != DBNull.Value) ? row[EmployeeML.DataBase.Curp].ToString() : string.Empty,
                        Name = (row[EmployeeML.DataBase.Name] != DBNull.Value) ? row[EmployeeML.DataBase.Name].ToString() : string.Empty,
                        LastName = (row[EmployeeML.DataBase.Lastname] != DBNull.Value) ? row[EmployeeML.DataBase.Lastname].ToString() : string.Empty,
                        Scholarship = (row[EmployeeML.DataBase.Scholarship] != DBNull.Value) ? row[EmployeeML.DataBase.Scholarship].ToString() : string.Empty,
                        Birthdate = (row[EmployeeML.DataBase.Birthdate] != DBNull.Value) ? row[EmployeeML.DataBase.Birthdate].ToString() : string.Empty,
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
                        ControlNumber = (row[EmployeeML.DataBase.ControlNumber] != DBNull.Value) ? row[EmployeeML.DataBase.ControlNumber].ToString() : string.Empty,
                        SureType = (row[EmployeeML.DataBase.SureType] != DBNull.Value) ? row[EmployeeML.DataBase.SureType].ToString() : string.Empty,
                        IdJob = (row[EmployeeML.DataBase.IdJob] != DBNull.Value) ? int.Parse(row[EmployeeML.DataBase.IdJob].ToString()) : 0,
                        IdDepartament = (row[EmployeeML.DataBase.IdDepartament] != DBNull.Value) ? int.Parse(row[EmployeeML.DataBase.IdDepartament].ToString()) : 0,
                        IdUser = (row[EmployeeML.DataBase.IdUser] != DBNull.Value) ? int.Parse(row[EmployeeML.DataBase.IdUser].ToString()) : 0,
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity : {1}", core, ex));
            }
        }

        public int Save(EmployeeML employee, String ConnectionString)
        {
            try
            {
                
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("INSERT INTO {0}", TableName);
                Query.AppendLine("( rfc,curp,name,lastname,scholarship,birthdate,gender,nationality,address,municipality,country," +
                    "email,telephone,civilStatus,postalCode,colony,stateCountry,controlNumber,sureType,numberSure,salary,idJob,idDepartament,idUser,_registry,idUserInsert,dateInsert)");
                Query.AppendLine("VALUES(");
                Query.AppendFormat(" '{0}',", employee.RFC);
                Query.AppendFormat(" '{0}',", employee.Curp);
                Query.AppendFormat(" '{0}',", employee.Name);
                Query.AppendFormat(" '{0}',", employee.LastName);
                Query.AppendFormat(" '{0}',", employee.Scholarship);
                Query.AppendFormat(" '{0}',", employee.Birthdate);
                Query.AppendFormat(" '{0}',", employee.Gender);
                Query.AppendFormat(" '{0}',", employee.Nationality);
                Query.AppendFormat(" '{0}',", employee.Address);
                Query.AppendFormat(" '{0}',", employee.Municipality);
                Query.AppendFormat(" '{0}',", employee.Country);
                Query.AppendFormat(" '{0}',", employee.Email);
                Query.AppendFormat(" '{0}',", employee.Telephone);
                Query.AppendFormat(" '{0}',", employee.CivilStatus);
                Query.AppendFormat(" {0},", employee.PostalCode);
                Query.AppendFormat(" '{0}',", employee.Colony);
                Query.AppendFormat(" '{0}',", employee.StateCountry);
                Query.AppendFormat(" '{0}',", employee.ControlNumber);
                Query.AppendFormat(" '{0}',", employee.SureType);
                Query.AppendFormat(" '{0}',", employee.NumberSure);
                Query.AppendFormat(" {0},", employee.Salary);
                Query.AppendFormat(" {0},", employee.IdJob);
                Query.AppendFormat(" {0},", employee.IdDepartament);
                Query.AppendFormat(" {0},", employee.IdUser);
                Query.AppendLine(" 1,");
                Query.AppendFormat(" {0},", employee.IdUserInsert);
                Query.AppendLine(" GETDATE()");
                Query.AppendLine(")");
                Query.AppendLine(" SELECT CAST(scope_identity() AS int)");
                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                //Conexion.Open();
                //SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion);

                using (SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion))
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

        public int Update(EmployeeML employee, String ConnectionString)
        {
            try
            {
                
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ", TableName);
                Query.AppendLine(" SET ");
                Query.AppendFormat(" rfc = {0}", employee.RFC);
                Query.AppendFormat(" curp = {0}", employee.Curp);
                Query.AppendFormat(" name = {0}", employee.Name);
                Query.AppendFormat(" lastname = {0}", employee.LastName);
                Query.AppendFormat(" scholarship = {0}", employee.Scholarship);
                Query.AppendFormat(" birthdate='{0}',", employee.Birthdate);
                Query.AppendFormat(" gender= '{0}',", employee.Gender);
                Query.AppendFormat(" nationality = '{0}',", employee.Nationality);
                Query.AppendFormat(" address='{0}',", employee.Address);
                Query.AppendFormat(" municipality = '{0}',", employee.Municipality);
                Query.AppendFormat(" country = '{0}',", employee.Country);
                Query.AppendFormat(" email = '{0}',", employee.Email);
                Query.AppendFormat(" telephone = '{0}',", employee.Telephone);
                Query.AppendFormat(" civilStatus = '{0}',", employee.CivilStatus);
                Query.AppendFormat(" postalCode = {0},", employee.PostalCode);
                Query.AppendFormat(" colony= '{0}',", employee.Colony);
                Query.AppendFormat(" stateCountry = '{0}',", employee.StateCountry);
                Query.AppendFormat(" controlNumber = '{0}',", employee.ControlNumber);
                Query.AppendFormat(" sureType = '{0}',", employee.SureType);
                Query.AppendFormat(" numberSure = '{0}',", employee.NumberSure);
                Query.AppendFormat(" salary = {0},", employee.Salary);
                Query.AppendFormat(" idJob = {0}", employee.IdJob);
                Query.AppendFormat(" idDepartament = {0}", employee.IdDepartament);


                Query.AppendFormat(" idUser = {0}", employee.IdUser);
                Query.AppendFormat(" idUserUpdate = {0}", employee.IdUserUpdate);

                Query.AppendLine("dateUpdate = GETDATE()");
                Query.AppendFormat("WHERE id={0}", employee.Id);

                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion);
                cmd2.ExecuteNonQuery();
                return employee.Id;


            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.update: {1}", core, ex));
            }
        }

        public int Delete(EmployeeML employee, String ConnectionString)
        {
            try
            {
                
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ", TableName);
                Query.AppendLine(" SET ");
                Query.AppendLine("_registry = 2,");
                Query.AppendFormat(" idUserDelete = {0},", employee.IdUserDelete);
                Query.AppendLine(" dateDelete = GETDATE()");
                Query.AppendFormat(" WHERE id={0}", employee.Id);

                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion);
                return cmd2.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.delete: {1}", core, ex));
            }
        }
    }
}
