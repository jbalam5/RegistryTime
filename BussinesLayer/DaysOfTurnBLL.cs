using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;
using ModelLayer;

namespace BussinesLayer
{
    public class DaysOfTurnBLL
    {
        public DaysOfTurnDAL DaysOfTurnDAL = new DaysOfTurnDAL();
        public Connection.ConnectionBLL conexion = new Connection.ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.DaysOfTurnBLL";

        public DaysOfTurnBLL()
        {
            ConnectionStrings = conexion.ConnectionStrings();
        }

        public DataTable All()
        {
            try
            {
                return DaysOfTurnDAL.All(ConnectionStrings);

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

                return DaysOfTurnDAL.GetIdEntity(Id, ConnectionStrings);
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
                    return DaysOfTurnDAL.Save(daysOfTurn, ConnectionStrings);
                }
                else
                {
                    return DaysOfTurnDAL.Update(daysOfTurn, ConnectionStrings);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public int Delete(DaysOfTurnML daysOfTurn)
        {
            try
            {
                return DaysOfTurnDAL.Delete(daysOfTurn, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
