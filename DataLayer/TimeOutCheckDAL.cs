using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class TimeOutCheckDAL
    {
        ModelDAL ModelDAL = new ModelDAL();
        public String ConnectionString = String.Empty;
        public int IdUserSession = 0;

        public DataTable TimeOutCheck(String Name)
        {
            try
            {
                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("SELECT * FROM timeOutCheck WHERE _registry = 1 AND name = '{0}'", Name);
                return ModelDAL.DataTableRecord(Query.ToString(), ConnectionString);                
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("TimeOutCheck: {0}",ex.Message));
            }
        }

    }
}
