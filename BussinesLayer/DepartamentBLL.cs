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
            DepartamentDAL.IdUserSession = GlobalBLL.userML.Id;
            DepartamentDAL.ConnectionString = conexion.ConnectionStrings();
        }

        public DataTable All(String Table = "Defaul")
        {
            try
            {
                if(Table == "All")
                    return DepartamentDAL.AllTable();
                else
                    return DepartamentDAL.AllTable();

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

                return DepartamentDAL.GetIdEntity(Id);
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
                    return DepartamentDAL.Save(departament);
                }
                else
                {
                    return DepartamentDAL.Update(departament);
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
                return DepartamentDAL.Delete(departament);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
