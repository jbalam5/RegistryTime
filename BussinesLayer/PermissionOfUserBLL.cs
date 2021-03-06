﻿using System;
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
    public class PermissionOfUserBLL
    {
        public PermissionsOfUserDAL PermissionsOfUserDAL = new PermissionsOfUserDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.PermissionOfUserBLL";

        public PermissionOfUserBLL()
        {
            ConnectionStrings = conexion.ConnectionStrings();
        }

        public DataTable All()
        {
            try
            {
                return PermissionsOfUserDAL.All(ConnectionStrings);

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

                return PermissionsOfUserDAL.GetIdEntity(Id, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(PermissionsOfUserML PermissionsOfUser)
        {
            try
            {
                if (PermissionsOfUser.Id == 0)
                {
                    return PermissionsOfUserDAL.Save(PermissionsOfUser, ConnectionStrings);
                }
                else
                {
                    return PermissionsOfUserDAL.Update(PermissionsOfUser, ConnectionStrings);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public int Delete(PermissionsOfUserML PermissionsOfUser)
        {
            try
            {
                return PermissionsOfUserDAL.Delete(PermissionsOfUser, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
