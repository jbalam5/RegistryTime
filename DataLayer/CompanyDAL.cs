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
    public class CompanyDAL
    {
        public String core = "DataLayer.CompanyDAL";
        public String TableName = "company";

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

        public CompanyML GetEntity(String ConnectionString)
        {
            try
            {
                SqlConnection Conexion = new SqlConnection
                {
                    ConnectionString = ConnectionString
                };
                Conexion.Open();
                String Query = String.Format("SELECT TOP 1 * FROM {0} WHERE _registry = 1 Order By id desc", TableName);
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtCompany = new DataTable();
                cmd.Fill(dtCompany);
                Conexion.Close();

                if(dtCompany != null && dtCompany.Rows.Count > 0)
                {
                    return GetEntity(dtCompany.Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All : {1}", core, ex));
            }

        }

        public CompanyML GetEntity(DataRow row)
        {
            try
            {
                if (row != null)
                {
                    CompanyML company = new CompanyML()
                    {
                        Id = (row[CompanyML.DataBase.id] != DBNull.Value) ? int.Parse(row[CompanyML.DataBase.id].ToString()) : 0,
                        Rfc = (row[CompanyML.DataBase.rfc] != DBNull.Value) ? row[CompanyML.DataBase.rfc].ToString() : string.Empty,
                        BusinessName = (row[CompanyML.DataBase.businessName] != DBNull.Value) ? row[CompanyML.DataBase.businessName].ToString() : string.Empty,
                        Street = (row[CompanyML.DataBase.street] != DBNull.Value) ? row[CompanyML.DataBase.street].ToString() : string.Empty,
                        Municipality = (row[CompanyML.DataBase.municipality] != DBNull.Value) ? row[CompanyML.DataBase.municipality].ToString() : string.Empty,
                        State = (row[CompanyML.DataBase.state] != DBNull.Value) ? row[CompanyML.DataBase.state].ToString() : string.Empty,
                        Country = (row[CompanyML.DataBase.country] != DBNull.Value) ? row[CompanyML.DataBase.country].ToString() : string.Empty,
                        Email = (row[CompanyML.DataBase.email] != DBNull.Value) ? row[CompanyML.DataBase.email].ToString() : string.Empty,
                        PostalCode = (row[CompanyML.DataBase.poltalCode] != DBNull.Value) ? row[CompanyML.DataBase.poltalCode].ToString() : string.Empty,
                        Telephone = (row[CompanyML.DataBase.telephone] != DBNull.Value) ? row[CompanyML.DataBase.telephone].ToString() : string.Empty,
                        Image = (row[CompanyML.DataBase.image] != DBNull.Value) ? row[CompanyML.DataBase.image].ToString() : string.Empty,
                        _regitry = (row[CompanyML.DataBase._registry] != DBNull.Value) ? int.Parse(row[CompanyML.DataBase._registry].ToString()) : 0,
                        IdUserInsert = (row[CompanyML.DataBase.idUserInsert] != DBNull.Value) ? int.Parse(row[CompanyML.DataBase.idUserInsert].ToString()) : 0
                    };

                    return company;
                }
                return null;
            }catch(Exception ex)
            {
                throw new Exception(string.Format("GetEntity: {0}", ex.Message));
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

        public int Save(CompanyML company, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("INSERT INTO {0}", TableName);
                Query.AppendLine("( rfc,businessName,street,municipality,state,country,email,postalCode,telephone,image,_registry,idUserInsert,dateInsert)");
                Query.AppendFormat(" VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',1,{10},GETDATE())",company.Rfc, company.BusinessName, company.Street, company.Municipality, company.State, company.Country, company.Email, company.PostalCode, company.Telephone, company.Image ,company.IdUserInsert);
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

        public int Update(CompanyML company, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ", TableName);
                Query.AppendLine(" SET ");
                Query.AppendFormat("rfc = '{0}', ", company.Rfc);
                Query.AppendFormat("businessName = '{0}', ", company.BusinessName);
                Query.AppendFormat("street = '{0}', ", company.Street);
                Query.AppendFormat("municipality = '{0}', ", company.Municipality);
                Query.AppendFormat("state = '{0}', ", company.State);
                Query.AppendFormat("country = '{0}', ", company.Country);
                Query.AppendFormat("email = '{0}', ", company.Email);
                Query.AppendFormat("postalCode = '{0}', ", company.PostalCode);
                Query.AppendFormat("telephone = '{0}', ", company.Telephone);
                Query.AppendFormat("image = '{0}', ", company.Image);
                Query.AppendFormat("idUserUpdate = {0}, ", company.IdUserUpdate);
                Query.AppendLine("dateUpdate = GETDATE() ");
                Query.AppendFormat("WHERE id={0}", company.Id);

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

        public int Delete(CompanyML company, String ConnectionString)
        {
            try
            {
                int id = 0;
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} ", TableName);
                Query.AppendLine(" SET ");
                Query.AppendLine("_registry = 2");
                Query.AppendFormat("idUserDelete = {0}", company.IdUserDelete);
                Query.AppendLine("dateDelete = GETDATE()");
                Query.AppendFormat("WHERE id={0}", company.Id);

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
