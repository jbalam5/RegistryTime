using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ModelLayer;
using Connection_BLL;
using DataLayer;

namespace BussinesLayer
{
    public class ReaderConnectionBLL
    {
        public ReaderConnectionDAL readerConnectionDAL = new ReaderConnectionDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.ReaderConnectionBLL";

        public ReaderConnectionBLL()
        {
            ConnectionStrings = conexion.ConnectionStrings();
            readerConnectionDAL.idUser = GlobalBLL.userML.Id;
        }

        public DataTable All()
        {
            try
            {
                return readerConnectionDAL.All(ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All: {1}", core, ex));
            }
        }

        public ReaderConnectionML GetConnectionById(int id)
        {
            try
            {
                return readerConnectionDAL.GetConnectionById(id, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetConnectionById: {1}", core, ex));
            }
        }

        public ReaderConnectionML GetActiveConnection()
        {
            try
            {
                return readerConnectionDAL.GetActiveConnection(ConnectionStrings);
            }catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.GetActiveConnection: {1}", core, ex));
            }
        }

        public int save(ReaderConnectionML readerConnectionML)
        {
            try
            {
                if (readerConnectionML.id > 0)
                    return readerConnectionDAL.Update(readerConnectionML, ConnectionStrings);
                else
                    return readerConnectionDAL.Insert(readerConnectionML, ConnectionStrings);
            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public int Delete(int Id)
        {
            try
            {
                return readerConnectionDAL.Delete(Id, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
