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
    public class JobBLL
    {
        public JobDAL JobDAL = new JobDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.StatusBookBLL";

        public JobBLL()
        {
            JobDAL.ConnectionString = conexion.ConnectionStrings();
            JobDAL.IdUserSession = GlobalBLL.userML.Id;
        }

        public DataTable All(String Table = "Default")
        {
            try
            {
                if(Table == "All")
                    return JobDAL.AllTable();
                else
                    return JobDAL.All();

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All: {1}", core, ex));
            }
        }

        public JobML GetIdEntity(int Id)
        {
            try
            {
                return JobDAL.GetIdEntity(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(JobML Job)
        {
            try
            {
                if (Job.Id == 0)
                {
                    return JobDAL.Save(Job);
                }
                else
                {
                    return JobDAL.Update(Job);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public void Delete(JobML Job)
        {
            try
            {
                JobDAL.Delete(Job);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
