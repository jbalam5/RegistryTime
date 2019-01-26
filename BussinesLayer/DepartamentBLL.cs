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
    public class DepartamentBLL
    {
        public DepartamentDAL DepartamentDAL = new DepartamentDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.StatusBookBLL";

        public DepartamentBLL()
        {
            ConnectionStrings = conexion.ConnectionStrings();
        }

        public DataTable All()
        {
            try
            {
                return DepartamentDAL.All(ConnectionStrings);

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

                return DepartamentDAL.GetIdEntity(Id, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(DepartamentML departament)
        {
            try
            {
                if (departament.Id == 0)
                {
                    return DepartamentDAL.Save(departament, ConnectionStrings);
                }
                else
                {
                    return DepartamentDAL.Update(departament, ConnectionStrings);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public int Delete(DepartamentML departament)
        {
            try
            {
                return DepartamentDAL.Delete(departament, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
