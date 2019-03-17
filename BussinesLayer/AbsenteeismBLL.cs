using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;
using ModelLayer;
using Connection_BLL;

namespace BussinesLayer
{
    public class AbsenteeismBLL
    {
        public AbsenteeismDAL AbsenteeismDAL = new AbsenteeismDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.AbsenteeismBLL";

        public AbsenteeismBLL()
        {
            AbsenteeismDAL.IdUserSession = GlobalBLL.userML.Id;
            AbsenteeismDAL.ConnectionString = conexion.ConnectionStrings();
        }

        public DataTable All()
        {
            try
            {
                return AbsenteeismDAL.All();

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All: {1}", core, ex));
            }
        }

        public DataTable AllTable()
        {
            try
            {
                return AbsenteeismDAL.AllTable();
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

                return AbsenteeismDAL.GetIdEntity(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(AbsenteeismML absenteeism)
        {
            try
            {
                if (absenteeism.Id == 0)
                {
                    return AbsenteeismDAL.Save(absenteeism);
                }
                else
                {
                    return AbsenteeismDAL.Update(absenteeism);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public void Delete(AbsenteeismML absenteeism)
        {
            try
            {
                AbsenteeismDAL.Delete(absenteeism);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
