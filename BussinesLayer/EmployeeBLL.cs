using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace BussinesLayer
{
    public class EmployeeBLL
    {
        public EmployeeDAL EmployeeDAL = new EmployeeDAL();
        public Connection.ConnectionBLL conexion = new Connection.ConnectionBLL();
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

        public DataTable GetIdEntity(int Id)
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

        public int Save(EmployeeDAL employee)
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

        public int Delete(EmployeeDAL employee)
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
