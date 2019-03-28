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
    public class CheckInHoursBLL
    {
        public CheckInHoursDAL CheckInHoursDAL = new CheckInHoursDAL();
        public ConnectionBLL conexion = new ConnectionBLL();
        
        public String core = "BussinesLayer.CheckInhHoursBLL";

        public CheckInHoursBLL()
        {
            CheckInHoursDAL.ConnectionString = conexion.ConnectionStrings();
            CheckInHoursDAL.IdUserSession = GlobalBLL.userML.Id;
        }

        public DataTable All()
        {
            try
            {
                return CheckInHoursDAL.All();

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.All: {1}", core, ex.Message));
            }
        }

        public DataTable GetIdEntity(int Id)
        {
            try
            {

                return CheckInHoursDAL.GetIdEntity(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex.Message));
            }
        }

        public int Save(CheckInHoursML CheckInHours)
        {
            try
            {
                if (CheckInHours.Id == 0)
                {
                    return CheckInHoursDAL.Save(CheckInHours);
                }
                else
                {
                    return CheckInHoursDAL.Update(CheckInHours);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Save: {1}", core, ex.Message));
            }
        }

        public void Delete(CheckInHoursML CheckInHours)
        {
            try
            {
                CheckInHoursDAL.Delete(CheckInHours);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Delete: {1}", core, ex.Message));
            }
        }

        public DataTable DateReports(DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                return CheckInHoursDAL.GetDateReports(FechaInicio, FechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.DateReports: {1}", core, ex.Message));
            }
        }

        public void Migrate(DateTime Inicio, DateTime Fin, int dividendo)
        {
            try
            {
                 CheckInHoursDAL.MigrateFunction(Inicio,Fin, dividendo);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Migrate: {1}", core, ex.Message));
            }
        }

        public void Migrate2(int dividendo)
        {
            try
            {
                MigrationHistoryBLL MigrationHistoryBLL = new MigrationHistoryBLL();
                DateTime Start = MigrationHistoryBLL.LastRecord();
                //CheckInHoursDAL.MigrateFunction(Start, DateTime.Now, dividendo);
                MigrationHistoryBLL.ListRecord(Start, DateTime.Now);

                MigrationHistoryML MigrationHistory = new MigrationHistoryML();
                MigrationHistory.DateStart = Start;
                MigrationHistory.DateEnd = DateTime.Now;
                MigrationHistoryBLL.Save(MigrationHistory);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.Migrate2: {1}", core, ex.Message));
            }
        }
    }
}
