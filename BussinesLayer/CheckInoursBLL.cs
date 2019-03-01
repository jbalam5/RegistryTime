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
    public class CheckInoursBLL
    {
        public CheckInHoursDAL CheckInHoursDAL = new CheckInHoursDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        
        public String core = "BussinesLayer.CheckInoursBLL";

        public CheckInoursBLL()
        {
            CheckInHoursDAL.ConnectionString = conexion.ConnectionStrings();
            CheckInHoursDAL.IdUserSession = GlobalBLL.userML.Id;
        }

        public DataTable All()
        {
            try
            {
                return CheckInHoursDAL.All();

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

                return CheckInHoursDAL.GetIdEntity(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(CheckInHoursML CheckInHours)
        {
            try
            {
                if (CheckInHours.Id == 0)
                {
                    return CheckInHoursDAL.Save(CheckInHours);
                }
                else
                {
                    return CheckInHoursDAL.Update(CheckInHours);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public void Delete(CheckInHoursML CheckInHours)
        {
            try
            {
                CheckInHoursDAL.Delete(CheckInHours);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }

        public DataTable Migrate(DateTime Inicio, DateTime Fin)
        {
            try
            {
                return CheckInHoursDAL.Migrate(Inicio,Fin);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
