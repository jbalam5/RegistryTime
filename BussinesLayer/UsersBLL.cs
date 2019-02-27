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
        public UsersDAL UsersDAL = new UsersDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String core = "BussinesLayer.UsersBLL";

        public UsersBLL()
        {            
            UsersDAL.ConnectionString = conexion.ConnectionStrings();
            UsersDAL.IdUserSession = (GlobalBLL.userML != null) ? GlobalBLL.userML.Id : 0;
        }

        public DataTable All()
        {
            try
            {
                return  UsersDAL.All();
                
            }catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.All: {1}", core, ex));
            }
        }

        public UsersML GetEntityById(int Id)
        {
            try
            {
                UsersML UsersML = UsersDAL.GetEntityById(Id);
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
                return UsersDAL.UserExist(UserName, id);
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
                    return UsersDAL.Save(users);
                }
                else
                {   
                    return UsersDAL.Update(users);
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
                return UsersDAL.Delete(users);
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
                //UsersDAL.IdUserSession = UsersDAL.IsUser(user).Id;
                return UsersDAL.IsUser(user);
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
                return UsersDAL.UserExists(Username);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.UserExists: {1}", core, ex));
            }
        }

    }
}
