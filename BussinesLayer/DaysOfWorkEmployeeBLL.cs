using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Connection_BLL;
using DataLayer;
using ModelLayer;

namespace BussinesLayer
{
    public class DaysOfWorkEmployeeBLL
    {
        DaysOfWorkEmployeeDAL DaysOfWorkEmployeeDAL = new DaysOfWorkEmployeeDAL();
        public String ConnectionStrings;
        public ConnectionBLL conexion = new ConnectionBLL();
        public String core = "BussinesLayer.DaysOfWorkEmployeeBLL";

        public DaysOfWorkEmployeeBLL()
        {
            ConnectionStrings = conexion.ConnectionStrings();
            DaysOfWorkEmployeeDAL.ConnectionString = conexion.ConnectionStrings();
            DaysOfWorkEmployeeDAL.IdUserSession = GlobalBLL.userML.Id;            

        }

        public DataTable All()
        {
            try
            {
                return DaysOfWorkEmployeeDAL.All();

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

                return DaysOfWorkEmployeeDAL.GetIdEntity(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public DataTable GetAllEntitys(int Id)
        {
            try
            {

                return DaysOfWorkEmployeeDAL.GetAllEntitys(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(DaysOfWorkEmployeeML DaysOfWorkEmployee)
        {
            try
            {
                if (DaysOfWorkEmployee.Id == 0)
                {
                    return DaysOfWorkEmployeeDAL.Save(DaysOfWorkEmployee);
                }
                else
                {
                    return DaysOfWorkEmployeeDAL.Update(DaysOfWorkEmployee);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public void Delete(DaysOfWorkEmployeeML DaysOfWorkEmployee)
        {
            try
            {
                DaysOfWorkEmployeeDAL.Delete(DaysOfWorkEmployee);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }

        public void DeleteRegistrys(int IdEmployee)
        {
            try
            {
                DaysOfWorkEmployeeDAL.DeleteRegistrys(IdEmployee);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.DeleteRegistrys: {1}", core, ex));
            }
        }
    }
}
