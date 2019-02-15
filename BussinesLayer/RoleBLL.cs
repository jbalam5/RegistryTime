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
            ConnectionStrings = conexion.ConnectionStrings();
        }

        public DataTable All()
        {
            try
            {
                return RoleDAL.All(ConnectionStrings);

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

                return RoleDAL.GetIdEntity(Id, ConnectionStrings);
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
                    return RoleDAL.Save(Role, ConnectionStrings);
                }
                else
                {
                    return RoleDAL.Update(Role, ConnectionStrings);
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
                return RoleDAL.Delete(Role, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
