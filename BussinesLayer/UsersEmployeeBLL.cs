using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataLayer;
using Connection_BLL;

namespace BussinesLayer
{
    public class UsersEmployeeBLL
    {
        public UsersEmployeeDAL usersEmployeeDAL = new UsersEmployeeDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String core = "BussinesLayer.UsersEmployee";

        public UsersEmployeeBLL()
        {
            usersEmployeeDAL.ConnectionString = conexion.ConnectionStrings();
            usersEmployeeDAL.IdUserSession = (GlobalBLL.userML != null) ? GlobalBLL.userML.Id : 0;
        }

        public UsersEmployeeML GetEntityByIdUser(int Id)
        {
            try
            {
                return usersEmployeeDAL.GetEntityByIdUser(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(UsersEmployeeML usersEmployeeML)
        {
            try
            {
                return (usersEmployeeML.Id > 0) ? usersEmployeeDAL.Update(usersEmployeeML) : usersEmployeeDAL.Insert(usersEmployeeML);       
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public void delete(int Id)
        {
            try
            {
                UsersEmployeeML usersEmployee = new UsersEmployeeML()
                {
                    Id = Id
                };

                usersEmployeeDAL.Delete(usersEmployee);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public Boolean UserExists(int idUser)
        {
            try
            {
                return usersEmployeeDAL.UserExists(idUser);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }
    }
}
