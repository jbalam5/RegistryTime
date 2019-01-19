using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace BussinesLayer
{
    public class AbsenteeismBLL
    {
        public AbsenteeismDAL AbsenteeismDAL = new AbsenteeismDAL();
        public Connection.ConnectionBLL conexion = new Connection.ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.AbsenteeismBLL";

        public AbsenteeismBLL()
        {
            ConnectionStrings = conexion.ConnectionStrings();
        }

        public DataTable All()
        {
            try
            {
                return AbsenteeismDAL.All(ConnectionStrings);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All: {1}", core, ex));
            }
        }

        public DataTable GetIdEntity(int Id)
        {
            try
            {

                return AbsenteeismDAL.GetIdEntity(Id, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(AbsenteeismDAL absenteeism)
        {
            try
            {
                if (absenteeism.Id == 0)
                {
                    return AbsenteeismDAL.Save(absenteeism, ConnectionStrings);
                }
                else
                {
                    return AbsenteeismDAL.Update(absenteeism, ConnectionStrings);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public int Delete(AbsenteeismDAL absenteeism)
        {
            try
            {
                return AbsenteeismDAL.Delete(absenteeism, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
