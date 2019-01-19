using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace BussinesLayer
{
    public class StatusBookBLL
    {
        public StatusBookDAL StatusBook = new StatusBookDAL();
        public Connection.ConnectionBLL conexion = new Connection.ConnectionBLL();
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
                return StatusBook.All(ConnectionStrings);

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

                return StatusBook.GetIdEntity(Id, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(StatusBookDAL StatusBook)
        {
            try
            {
                if (StatusBook.Id == 0)
                {
                    return StatusBook.Save(StatusBook, ConnectionStrings);
                }
                else
                {
                    return StatusBook.Update(StatusBook, ConnectionStrings);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public int Delete(StatusBookDAL StatusBook)
        {
            try
            {
                return StatusBook.Delete(StatusBook, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
