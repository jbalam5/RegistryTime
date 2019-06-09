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
            EmployeeDAL.IdUserSession = GlobalBLL.userML.Id;
            EmployeeDAL.ConnectionString = conexion.ConnectionStrings();
        }

        public DataTable All(string Tipo)
        {
            try
            {
                return EmployeeDAL.All( Tipo);

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

                return EmployeeDAL.GetIdEntity(Id);
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

                return EmployeeDAL.GetEmploymentByIdUser(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetEmploymentByIdUser: {1}", core, ex));
            }
        }

        public EmployeeML GetEntityByNoControl(int NoControl)
        {
            try
            {

                return EmployeeDAL.GetEntityByNoControl(NoControl);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetEntityByNoControl: {1}", core, ex));
            }
        }

        public EmployeeML GetColumnsEmployee(int IdEmployee)
        {
            try
            {
                return EmployeeDAL.GetColumnsEmployee(IdEmployee);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetSalary: {1}", core, ex));
            }
        }

        public int Save(EmployeeML employee)
        {
            try
            {
                if (employee.Id == 0)
                {
                    return EmployeeDAL.Save(employee);
                }
                else
                {
                    return EmployeeDAL.Update(employee);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public void Delete(EmployeeML employee)
        {
            try
            {
                EmployeeDAL.Delete(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }

    }
}
