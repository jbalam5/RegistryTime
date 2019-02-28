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
    public class DaysOfTurnBLL
    {
        public DaysOfTurnDAL DaysOfTurnDAL = new DaysOfTurnDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.DaysOfTurnBLL";


        public DaysOfTurnBLL()
        {
            ConnectionStrings = conexion.ConnectionStrings();
            DaysOfTurnDAL.ConnectionString = conexion.ConnectionStrings();
            DaysOfTurnDAL.IdUserSession = GlobalBLL.userML.Id;
        }

        public DataTable All()
        {
            try
            {
                return DaysOfTurnDAL.All();

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

                return DaysOfTurnDAL.GetIdEntity(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(DaysOfTurnML daysOfTurn)
        {
            try
            {
                if (daysOfTurn.Id == 0)
                {
                    return DaysOfTurnDAL.Save(daysOfTurn);
                }
                else
                {
                    return DaysOfTurnDAL.Update(daysOfTurn);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public void Delete(DaysOfTurnML daysOfTurn)
        {
            try
            {
                DaysOfTurnDAL.Delete(daysOfTurn);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }

        public void DeleteRegistrys(int idEmployee)
        {
            throw new NotImplementedException();
        }
    }
}
