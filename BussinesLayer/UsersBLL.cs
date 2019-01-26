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
    public class UsersBLL
    {
        public UsersDAL usersDAL = new UsersDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
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

        public  int Save(UsersML users)
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

        public int Delete(UsersML users)
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
