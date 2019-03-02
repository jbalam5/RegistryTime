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
    public class TurnBLL
    {
        public TurnDAL TurnDAL = new TurnDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.TurnBLL";

        public TurnBLL()
        {
            TurnDAL.ConnectionString = conexion.ConnectionStrings();
            TurnDAL.IdUserSession = GlobalBLL.userML.Id;
        }

        public DataTable All()
        {
            try
            {
                return TurnDAL.All();

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All: {1}", core, ex));
            }
        }

        public TurnML GetIdEntity(int Id)
        {
            try
            {

                return TurnDAL.GetIdEntity(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(TurnML Turn )
        {
            try
            {
                if (Turn.Id == 0)
                {
                    return TurnDAL.Save(Turn);
                }
                else
                {
                    return TurnDAL.Update(Turn);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public void Delete(TurnML turn)
        {
            try
            {
                TurnDAL.Delete(turn);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
