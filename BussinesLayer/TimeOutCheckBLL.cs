using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Connection_BLL;
using System.Data;

namespace BussinesLayer
{
    public class TimeOutCheckBLL
    {
        public TimeOutCheckDAL TimeOutCheckDAL = new TimeOutCheckDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String ConnectionStrings;
        public String core = "TimeOutCheckBLL.TurnBLL";

        public TimeOutCheckBLL()
        {
            TimeOutCheckDAL.ConnectionString = conexion.ConnectionStrings();
            TimeOutCheckDAL.IdUserSession = GlobalBLL.userML.Id;
        }

        public DataTable TimeOutCheck(String Name)
        {
            try
            {
                return TimeOutCheckDAL.TimeOutCheck(Name);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("TimeOutCheck: {0}", ex.Message));
            }
        }

    }
}
