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
    public class AbsenteeismBLL
    {
        public AbsenteeismDAL AbsenteeismDAL = new AbsenteeismDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.AbsenteeismBLL";

        public AbsenteeismBLL()
        {
            ConnectionStrings = conexion.ConnectionStrings();
        }

        public DataTable All()
        {
            try
            {
                return AbsenteeismDAL.All(ConnectionStrings);

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

                return AbsenteeismDAL.GetIdEntity(Id, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(AbsenteeismML absenteeism)
        {
            try
            {
                if (absenteeism.Id == 0)
                {
                    return AbsenteeismDAL.Save(absenteeism, ConnectionStrings);
                }
                else
                {
                    return AbsenteeismDAL.Update(absenteeism, ConnectionStrings);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public int Delete(AbsenteeismML absenteeism)
        {
            try
            {
                return AbsenteeismDAL.Delete(absenteeism, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
