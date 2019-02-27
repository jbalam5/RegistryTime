using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace DataLayer
{
    public class ReaderConnectionDAL
    {
        #region "PROPERTIES"
        public int idUser { get; set; }
        #endregion

        #region "VARIABLES GLOBALES"
        private String core = "DataLayer.ReaderConnectionDAL";
        private String TableName = "ReaderConnection";
        #endregion

        public DataTable All(String ConnectionString)
        {
            try
            {
                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = ConnectionString;
                Conexion.Open();
                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1", TableName);
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtReader = new DataTable();
                cmd.Fill(dtReader);
                Conexion.Close();
                return dtReader;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All : {1}", core, ex));
            }

        }
        
        public ReaderConnectionML GetActiveConnection(String ConnectionString)
        {
            try
            {
                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = ConnectionString;
                Conexion.Open();
                String Query = String.Format("SELECT TOP 1 * FROM {0} WHERE _registry = 1 AND isDefault = convert(Bit, 'True')", TableName);
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtReader = new DataTable();
                cmd.Fill(dtReader);
                Conexion.Close();
                
                if(dtReader != null && dtReader.Rows.Count > 0)
                {
                    return GetEntity(dtReader.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetActiveConnection : {1}", core, ex));
            }
        }

        public ReaderConnectionML GetConnectionById(int Id, String ConnectionString)
        {
            try
            {
                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = ConnectionString;
                Conexion.Open();
                String Query = String.Format("SELECT * FROM {0} WHERE _registry = 1 AND id = {1}", TableName, Id);
                SqlDataAdapter cmd = new SqlDataAdapter(Query, Conexion);
                DataTable dtReader = new DataTable();
                cmd.Fill(dtReader);
                Conexion.Close();

                if (dtReader != null && dtReader.Rows.Count > 0)
                {
                    return GetEntity(dtReader.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetConnectionById : {1}", core, ex));
            }
        }

        public ReaderConnectionML GetEntity(DataRow row)
        {
            try
            {
                if(row != null)
                {
                    ReaderConnectionML readerConnectionML = new ReaderConnectionML()
                    {
                        ip = (row[ReaderConnectionML.DataBase.ip] != DBNull.Value) ? row[ReaderConnectionML.DataBase.ip].ToString() : string.Empty,
                        port = (row[ReaderConnectionML.DataBase.port] != DBNull.Value) ? row[ReaderConnectionML.DataBase.port].ToString() : string.Empty,
                        name = (row[ReaderConnectionML.DataBase.name] != DBNull.Value) ? row[ReaderConnectionML.DataBase.name].ToString() : string.Empty,
                        isDefault = (row[ReaderConnectionML.DataBase.isDefault] != DBNull.Value) ? Convert.ToBoolean(row[ReaderConnectionML.DataBase.isDefault].ToString()) : false,
                    };

                    return readerConnectionML;
                }

                return null;
            }catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.ReaderConnectionML : {1}", core, ex));
            }
        }

        public int Insert(ReaderConnectionML readerConnectionML, string ConnectionString)
        {
            try
            {
                if (readerConnectionML != null)
                {
                    if (readerConnectionML.isDefault)
                    {
                        StringBuilder QueryUpdate = new StringBuilder();
                        QueryUpdate.AppendFormat("UPDATE {0} SET ", TableName);
                        QueryUpdate.AppendFormat("{0} = Convert(Bit, 'false')", ReaderConnectionML.DataBase.isDefault);

                        SqlConnection ConexionUpdate = new SqlConnection
                        {
                            ConnectionString = ConnectionString
                        };

                        using (SqlCommand cmd2 = new SqlCommand(QueryUpdate.ToString(), ConexionUpdate))
                        {
                            ConexionUpdate.Open();
                            cmd2.ExecuteScalar();
                            if (ConexionUpdate.State == System.Data.ConnectionState.Open) ConexionUpdate.Close();
                        }
                    }

                    StringBuilder Query = new StringBuilder();
                    Query.AppendFormat("INSERT INTO {0}", TableName);
                    Query.AppendFormat("({0}, {1}, {2}, {3}, {4}, _registry, idUserInsert, dateInsert)", ReaderConnectionML.DataBase.name, ReaderConnectionML.DataBase.ip, ReaderConnectionML.DataBase.port, ReaderConnectionML.DataBase.isDefault, ReaderConnectionML.DataBase.idReader);
                    Query.AppendLine(" VALUES( ");
                    Query.AppendFormat(" '{0}', ", readerConnectionML.name);
                    Query.AppendFormat(" '{0}', ", readerConnectionML.ip);
                    Query.AppendFormat(" '{0}', ", readerConnectionML.port);
                    Query.AppendFormat(" convert(bit, '{0}'), ", readerConnectionML.isDefault);
                    Query.AppendFormat(" {0}, ", readerConnectionML.idReader);
                    Query.AppendLine(" 1, ");
                    Query.AppendFormat(" {0}, ", idUser);
                    Query.AppendLine(" GETDATE()) ");
                    Query.AppendLine(" SELECT CAST(scope_identity() AS int)");
                    SqlConnection Conexion = new SqlConnection
                    {
                        ConnectionString = ConnectionString
                    };

                    using (SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion))
                    {
                        Conexion.Open();
                        int newID = (Int32)cmd2.ExecuteScalar();

                        if (Conexion.State == System.Data.ConnectionState.Open) Conexion.Close();
                        return newID;
                    }

                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Insert : {1}", core, ex));
            }
        }

        public int Update(ReaderConnectionML readerConnectionML, string ConnectionString)
        {
            try
            {
                if (readerConnectionML != null)
                {
                    if (readerConnectionML.isDefault)
                    {
                        StringBuilder QueryUpdate = new StringBuilder();
                        QueryUpdate.AppendFormat("UPDATE {0} SET ", TableName);
                        QueryUpdate.AppendFormat("{0} = Convert(Bit, 'false')", ReaderConnectionML.DataBase.isDefault);

                        SqlConnection ConexionUpdate = new SqlConnection
                        {
                            ConnectionString = ConnectionString
                        };

                        using (SqlCommand cmd2Update = new SqlCommand(QueryUpdate.ToString(), ConexionUpdate))
                        {
                            ConexionUpdate.Open();
                            cmd2Update.ExecuteScalar();
                            if (ConexionUpdate.State == System.Data.ConnectionState.Open) ConexionUpdate.Close();
                        }
                    }


                    StringBuilder Query = new StringBuilder();
                    Query.AppendFormat("UPDATE {0} SET ", TableName);
                    Query.AppendFormat("{0} = '{1}', ", ReaderConnectionML.DataBase.name, readerConnectionML.name);
                    Query.AppendFormat("{0} = '{1}', ", ReaderConnectionML.DataBase.ip, readerConnectionML.ip);
                    Query.AppendFormat("{0} = '{1}', ", ReaderConnectionML.DataBase.port, readerConnectionML.port);
                    Query.AppendFormat("{0} =  convert(bit, '{1}'), ", ReaderConnectionML.DataBase.isDefault, readerConnectionML.isDefault);
                    Query.AppendFormat("{0} = {1}, ", ReaderConnectionML.DataBase.idReader, readerConnectionML.idReader);
                    Query.AppendFormat("idUserUpdate = {0}, ", idUser);
                    Query.AppendLine("dateUpdate = GETDATE() ");
                    Query.AppendFormat("WHERE id = {0}", readerConnectionML.id);

                    SqlConnection Conexion = new SqlConnection()
                    {
                        ConnectionString = ConnectionString
                    };

                    Conexion.Open();
                    SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion);
                    cmd2.ExecuteNonQuery();
                    return readerConnectionML.id;
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Update : {1}", core, ex));
            }
        }


        public int Delete(int id, string ConnectionString)
        {
            try
            {
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} SET ", TableName);
                Query.AppendLine("_registry = 0, ");
                Query.AppendFormat("idUserDelete = {0}, ", idUser);
                Query.AppendLine("dateDelete = GETDATE() ");
                Query.AppendFormat("WHERE id = {0}", id);

                SqlConnection Conexion = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };

                Conexion.Open();
                SqlCommand cmd2 = new SqlCommand(Query.ToString(), Conexion);
                cmd2.ExecuteNonQuery();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete : {1}", core, ex));
            }
        }
    }
}
