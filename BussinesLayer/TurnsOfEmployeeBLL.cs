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
    public class TurnsOfEmployeeBLL
    {
        public TurnsOfEmployeeDAL TurnsOfEmployeeDAL = new TurnsOfEmployeeDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.TurnsOfEmployeeBLL";

        public TurnsOfEmployeeBLL()
        {
            ConnectionStrings = conexion.ConnectionStrings();
        }

        public DataTable All()
        {
            try
            {
                return TurnsOfEmployeeDAL.All(ConnectionStrings);

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

                return TurnsOfEmployeeDAL.GetIdEntity(Id, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(TurnsOfEmployeeML TurnsOfEmployee)
        {
            try
            {
                if (TurnsOfEmployee.Id == 0)
                {
                    return TurnsOfEmployeeDAL.Save(TurnsOfEmployee, ConnectionStrings);
                }
                else
                {
                    return TurnsOfEmployeeDAL.Update(TurnsOfEmployee, ConnectionStrings);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public int Delete(TurnsOfEmployeeML TurnsOfEmployee)
        {
            try
            {
                return TurnsOfEmployeeDAL.Delete(TurnsOfEmployee, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }

        public void DeleteRegistrys(int idEmployee)
        {
            TurnsOfEmployeeDAL.DeleteRegistrys(idEmployee, ConnectionStrings);
        }

        public DataTable GetAllEntitys(int id)
        {
            return TurnsOfEmployeeDAL.GetIdEntitys(id, ConnectionStrings);
        }
    }
}
