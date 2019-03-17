using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using ModelLayer;
using Connection_BLL;
using System.Data;

namespace BussinesLayer
{
    public class ReportsBLL
    {
        ReportsDAL ReportsDAL = new ReportsDAL();
        ConnectionBLL Conection = new ConnectionBLL();

        public ReportsBLL()
        {
            ReportsDAL.ConnectionString = Conection.ConnectionStrings();
        }

        public DataTable ReportAbsenteeism(int IdDepartament, int IdTurn, int IdEmployee) 
        {
            try
            {
                return ReportsDAL.ReportAbsenteeism(IdDepartament, IdTurn, IdEmployee);
            }catch(Exception ex)
            {
                throw new Exception(String.Format("ReportAbsenteeim: {0}", ex.Message));
            }

        }

    }
}
