using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection_BLL;
using DataLayer;
using ModelLayer;

namespace BussinesLayer
{
    public class MigrationHistoryBLL
    {
        public MigrationHistoryDAL MigrationHistoryDAL = new MigrationHistoryDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String core = "BussinesLayer.EmployeeBLL";

        public MigrationHistoryBLL()
        {

            MigrationHistoryDAL.IdUserSession = GlobalBLL.userML.Id;
            MigrationHistoryDAL.ConnectionString = conexion.ConnectionStrings();
        }

        public int Save(MigrationHistoryML MigrationHistory)
        {
            try
            {
                if (MigrationHistory.Id == 0)
                {
                    return MigrationHistoryDAL.Save(MigrationHistory);
                }
                else
                {
                    return MigrationHistoryDAL.Update(MigrationHistory);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public DateTime LastRecord()
        {
            try
            {
                return MigrationHistoryDAL.LastRecord();                
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.lastRecord: {1}", core, ex.Message));
            }
        }

    }
}
