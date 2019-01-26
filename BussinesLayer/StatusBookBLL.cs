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
    public class StatusBookBLL
    {
        public StatusBookDAL StatusBookDAL = new StatusBookDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.StatusBookBLL";

        public StatusBookBLL()
        {
            ConnectionStrings = conexion.ConnectionStrings();
        }

        public DataTable All()
        {
            try
            {
                return StatusBookDAL.All(ConnectionStrings);

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

                return StatusBookDAL.GetIdEntity(Id, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(StatusBookML StatusBook)
        {
            try
            {
                if (StatusBook.Id == 0)
                {
                    return StatusBookDAL.Save(StatusBook, ConnectionStrings);
                }
                else
                {
                    return StatusBookDAL.Update(StatusBook, ConnectionStrings);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public int Delete(StatusBookML StatusBook)
        {
            try
            {
                return StatusBookDAL.Delete(StatusBook, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
