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
    public class FestiveBLL
    {
        public FestiveDAL FestiveDAL = new FestiveDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.FestiveBLL";

        public FestiveBLL()
        {
            ConnectionStrings = conexion.ConnectionStrings();
        }

        public DataTable All()
        {
            try
            {
                return FestiveDAL.All(ConnectionStrings);

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

                return FestiveDAL.GetIdEntity(Id, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(FestiveML festive)
        {
            try
            {
                if (festive.Id == 0)
                {
                    return FestiveDAL.Save(festive, ConnectionStrings);
                }
                else
                {
                    return FestiveDAL.Update(festive, ConnectionStrings);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public int Delete(FestiveML festive)
        {
            try
            {
                return FestiveDAL.Delete(festive, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
