using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace BussinesLayer
{
    public class CompanyBLL
    {
        public CompanyDAL CompanyDAL = new CompanyDAL();
        public Connection.ConnectionBLL conexion = new Connection.ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.CompanyBLL";

        public CompanyBLL()
        {
            ConnectionStrings = conexion.ConnectionStrings();
        }

        public DataTable All()
        {
            try
            {
                return CompanyDAL.All(ConnectionStrings);

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

                return CompanyDAL.GetIdEntity(Id, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(CompanyDAL Company)
        {
            try
            {
                if (Company.Id == 0)
                {
                    return CompanyDAL.Save(Company, ConnectionStrings);
                }
                else
                {
                    return CompanyDAL.Update(Company, ConnectionStrings);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public int Delete(CompanyDAL Company)
        {
            try
            {
                return CompanyDAL.Delete(Company, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
