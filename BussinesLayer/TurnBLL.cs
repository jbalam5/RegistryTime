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

        public DataTable All(String Type = "All")
        {
            try
            {
                return TurnDAL.All(Type);

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

   
     
        /// <summary>
        /// Obtiene numero de registros del empleado
        /// </summary>
        /// <param name="IdUser"></param>
        public void CountRecorsdOld(int IdUser)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.TimeOutCheck: {1}", core, ex));
            }
        }

        public TurnML GetTurnUser(DateTime Record, int IdUser)
        {
            try
            {
                return TurnDAL.GetTurnUser(Record, IdUser);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetTurnUser: {1}", core, ex));
            }
        }

        public TurnML GetTurnForNaMe(String NameTurn)
        {
            try
            {
                return TurnDAL.GetTurnForNaMe(NameTurn);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetTurnForNaMe: {1}", core, ex));
            }
        }
    }
}
