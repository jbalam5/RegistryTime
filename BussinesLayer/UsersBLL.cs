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

        public UsersML GetEntityById(int Id)
        {
            try
            {
                UsersML UsersML = usersDAL.GetEntityById(Id, ConnectionStrings);
                UsersML.Password = conexion.DesEncriptar(UsersML.Password);
                return UsersML;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int UserExist(string UserName, int id)
        {
            try
            {
                return usersDAL.UserExist(UserName, id, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.UserExist: {1}", core, ex));
            }
        }

        public  int Save(UsersML users)
        {
            try
            {
                users.Password = conexion.Encriptar(users.Password);
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

        public UsersML IsUser(UsersML user)
        {
            try
            {
                user.Password = conexion.Encriptar(user.Password);
                return usersDAL.IsUser(user, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.IsUser: {1}", core, ex));
            }
        }

        public Boolean UserExists(String Username)
        {
            try
            {
                return usersDAL.UserExists(Username, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.UserExists: {1}", core, ex));
            }
        }

    }
}
