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

        public CompanyML GetEntity()
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
                        NumberUserEmploye = (row[CompanyML.DataBase.numberUserEmploye] != DBNull.Value) ? row[CompanyML.DataBase.numberUserEmploye].ToString() : string.Empty,

                    };

                    return company;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("GetEntity: {0}", ex.Message));
            }
        }

        public void InsertNumUser(int number)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                //String Query = String.Format("Update")

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("InsertNumUser: {0}", ex.Message));
            }

        }

        public DataTable GetIdEntity(int id)
        {
            try
            {

                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1 AND id={1}", TableName, id);
                ModelDAL ModelDAL = new ModelDAL();
                return ModelDAL.DataTableRecord(Query, ConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity : {1}", core, ex));
            }
        }

        public int Save(CompanyML company)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                return Convert.ToInt32(ModelDAL.InsertModel(company, TableName, IdUserSession, ConnectionString));
  
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.save : {1}", core, ex));
            }

        }

        public int Update(CompanyML Company)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                ModelDAL.UpdateModel(Company, TableName, IdUserSession, ConnectionString);
                return Company.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.update: {1}", core, ex));
            }
        }

        public int Delete(CompanyML Company)
        {
            try
            {
                ModelDAL ModelDAL = new ModelDAL();
                ModelDAL.DeleteModel(Company, TableName, IdUserSession, ConnectionString);
                return Company.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.delete: {1}", core, ex));
            }
        }
    }
}
