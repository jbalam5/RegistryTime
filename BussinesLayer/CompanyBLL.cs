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
    public class CompanyBLL
    {
        public CompanyDAL CompanyDAL = new CompanyDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.CompanyBLL";

        public CompanyBLL()
        {
            CompanyDAL.IdUserSession = GlobalBLL.userML.Id;
            CompanyDAL.ConnectionString = conexion.ConnectionStrings();
        }

      
        public DataTable All()
        {
            try
            {
                return CompanyDAL.All();

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All: {1}", core, ex));
            }
        }

        public CompanyML GetEntity()
        {
            try
            {
                return CompanyDAL.GetEntity();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetEntity: {1}", core, ex));
            }
        }

        public DataTable GetIdEntity(int Id)
        {
            try
            {
                return CompanyDAL.GetIdEntity(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(CompanyML Company)
        {
            try
            {
                if (Company.Id == 0)
                {
                    return CompanyDAL.Save(Company);
                }
                else
                {
                    return CompanyDAL.Update(Company);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public int Delete(CompanyML Company)
        {
            try
            {
                return CompanyDAL.Delete(Company);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }

        //public void InsertNumUser(int Number)
        //{
        //    try
        //    {
        //        CompanyDAL.InsertNumUser(Number);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(String.Format("{0}.InsertNumUser: {1}", core, ex.Message));
        //    }
        //}
    }
}
