using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Data;
namespace BussinesLayer
{
    public class UsersBLL
    {
        public UsersDAL usersDAL = new UsersDAL();
        public Connection.ConnectionBLL conexion = new Connection.ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.UsersBLL";

        public UsersBLL()
        {
            ConnectionStrings = conexion.ConnectionStrings();
        }

        public DataTable All()
        {
            try
            {
                return  usersDAL.All(ConnectionStrings);
                
            }catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.All: {1}", core, ex));
            }
        }

        public DataTable GetIdEntity(int Id)
        {
            try
            {
                
                return usersDAL.GetIdEntity(Id,ConnectionStrings);
            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public  int Save(UsersDAL users)
        {
            try
            {
                if (users.Id == 0)
                {
                    return usersDAL.Save(users, ConnectionStrings);
                }
                else
                {
                    return usersDAL.Update(users, ConnectionStrings);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public int Delete(UsersDAL users)
        {
            try
            {
                return usersDAL.Delete(users, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
