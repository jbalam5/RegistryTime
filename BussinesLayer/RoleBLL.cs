using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Data;
using ModelLayer;
using Connection_BLL;

namespace BussinesLayer
{
    public class RoleBLL
    {
        public RoleDAL RoleDAL = new RoleDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.StatusBookBLL";

        public RoleBLL()
        {
            RoleDAL.ConnectionString = conexion.ConnectionStrings();
            RoleDAL.IdUserSession = (GlobalBLL.userML != null) ? GlobalBLL.userML.Id : 0;
        }

        public DataTable All()
        {
            try
            {
                return RoleDAL.All();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All: {1}", core, ex));
            }
        }

        public RoleML GetIdEntity(int Id)
        {
            try
            {
                return RoleDAL.GetIdEntity(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(RoleML Role)
        {
            try
            {
                if (Role.Id == 0)
                {
                    return RoleDAL.Save(Role);
                }
                else
                {
                    return RoleDAL.Update(Role);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public int Delete(RoleML Role)
        {
            try
            {
                return RoleDAL.Delete(Role);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
