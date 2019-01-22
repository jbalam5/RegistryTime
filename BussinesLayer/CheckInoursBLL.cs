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
    public class CheckInoursBLL
    {
        public CheckInHoursDAL CheckInHoursDAL = new CheckInHoursDAL();
        public Connection.ConnectionBLL conexion = new Connection.ConnectionBLL();
        public String ConnectionStrings;
        public String core = "BussinesLayer.CheckInoursBLL";

        public CheckInoursBLL()
        {
            ConnectionStrings = conexion.ConnectionStrings();
        }

        public DataTable All()
        {
            try
            {
                return CheckInHoursDAL.All(ConnectionStrings);

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

                return CheckInHoursDAL.GetIdEntity(Id, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
            }
        }

        public int Save(CheckInHoursML CheckInHours)
        {
            try
            {
                if (CheckInHours.Id == 0)
                {
                    return CheckInHoursDAL.Save(CheckInHours, ConnectionStrings);
                }
                else
                {
                    return CheckInHoursDAL.Update(CheckInHours, ConnectionStrings);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex));
            }
        }

        public int Delete(CheckInHoursML CheckInHours)
        {
            try
            {
                return CheckInHoursDAL.Delete(CheckInHours, ConnectionStrings);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
            }
        }
    }
}
