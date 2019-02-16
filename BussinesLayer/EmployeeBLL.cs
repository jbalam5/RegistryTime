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
    public class EmployeeBLL
    {
        public EmployeeDAL EmployeeDAL = new EmployeeDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.EmployeeBLL";

        public EmployeeBLL()
        {
            ConnectionStrings = conexion.ConnectionStrings();
        }

        public DataTable All()
        {
            try
            {
                return EmployeeDAL.All(ConnectionStrings);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All: {1}", core, ex));
            }
        }

        public EmployeeML GetIdEntity(int Id)
        {
            try
            {

                return EmployeeDAL.GetIdEntity(Id, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public EmployeeML GetEmploymentByIdUser(int Id)
        {
            try
            {

                return EmployeeDAL.GetEmploymentByIdUser(Id, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetEmploymentByIdUser: {1}", core, ex));
            }
        }

        public int Save(EmployeeML employee)
        {
            try
            {
                if (employee.Id == 0)
                {
                    return EmployeeDAL.Save(employee, ConnectionStrings);
                }
                else
                {
                    return EmployeeDAL.Update(employee, ConnectionStrings);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public int Delete(EmployeeML employee)
        {
            try
            {
                return EmployeeDAL.Delete(employee, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
