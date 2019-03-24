using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ModelLayer;
using System.Data.SqlClient;

namespace DataLayer
{
    public class ReportsDAL
    {
        public String ConnectionString = String.Empty;

        public DataTable ReportAbsenteeism(int IdDepartamnet, int IdTurn, int IdEmployee)
        {
            try
            {
                StringBuilder Query = new StringBuilder();
                AbsenteeismAssignmentDAL AbsenteeismAssignmentDAL = new AbsenteeismAssignmentDAL();
                EmployeeDAL EmployeeDAL = new EmployeeDAL();
                AbsenteeismDAL AbsenteeismDAL = new AbsenteeismDAL();

                Query.AppendLine("SELECT ");
                Query.AppendFormat("AA.{0} AS NUMCONTROL, ", AbsenteeismAssignmentML.DataBase.controlNumber);
                Query.AppendFormat("EMP.{0} + ' ' + EMP.{1} EMPLEADO, ", EmployeeML.DataBase.Name, EmployeeML.DataBase.Lastname);
                Query.AppendFormat("DATEDIFF(day, convert(date, AA.{0}), DATEADD(dd, 1, convert(date, AA.{1}))) DIAS, ", AbsenteeismAssignmentML.DataBase.DateStar, AbsenteeismAssignmentML.DataBase.DateEnd);
                Query.AppendFormat("ABS.{0} AS CONCEPTO, ", AbsenteeismML.DataBase.Concept);
                Query.AppendFormat("CONCAT('del ', Convert(DATE, AA.{0}), ' al ', CONVERT(DATE, AA.{1})) AS FECHAS ", AbsenteeismAssignmentML.DataBase.DateStar, AbsenteeismAssignmentML.DataBase.DateEnd);
                Query.AppendFormat("FROM {0} AA ", AbsenteeismAssignmentDAL.TableName);
                Query.AppendFormat("LEFT OUTER JOIN {0} AS EMP ON EMP.id = AA.controlNumber ", EmployeeDAL.TableName);
                Query.AppendFormat("LEFT OUTER JOIN {0} AS ABS ON ABS.isKey = AA.KeyAbsenteeism ", AbsenteeismDAL.TableName);

                if(IdDepartamnet >0 || IdTurn > 0 || IdEmployee > 0)
                    Query.AppendLine(" WHERE ");

                if (IdDepartamnet > 0)
                {
                    Query.AppendFormat("EMP.{0} = {1}", EmployeeML.DataBase.IdDepartament, IdDepartamnet);
                }

                SqlConnection Connection = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Connection.Open();
                SqlDataAdapter cmd = new SqlDataAdapter(Query.ToString(), Connection);
                DataTable dtReportAbsenteeism = new DataTable();
                cmd.Fill(dtReportAbsenteeism);
                Connection.Close();
                if (dtReportAbsenteeism != null && dtReportAbsenteeism.Rows.Count > 0)
                {
                    return dtReportAbsenteeism;
                }
                return null;

            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("ReportAbsenteeism: {0}", ex.Message));
            }
        }
        public DataTable ReportExtras(DateTime DateStart, DateTime DateEnd)
        {
            try
            {
                StringBuilder Query = new StringBuilder();

                Query.AppendLine("SELECT ");
                Query.AppendFormat("Tab1.id, ");
                Query.AppendFormat("departament.name DEPARTAMENTO, ");
                Query.AppendFormat("employee.id CVE, ");
                Query.AppendFormat("employee.name EMPLEADO, ");
                Query.AppendFormat("turn TURNO, ");
                Query.AppendFormat("DateOnlyRecord FECHA, ");
                Query.AppendFormat("dateTimeRecord  AS ENTRADA, ");
                Query.AppendFormat("ISNULL(( SELECT ");
                Query.AppendFormat("dateTimeRecord ");
                Query.AppendFormat("FROM checkInHours ");
                Query.AppendFormat("WHERE ");
                Query.AppendFormat("dateOnlyRecord BETWEEN '{0}' and '{1}' ", DateStart.ToString("yyyy-MM-dd HH:mm:ss"), DateEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                Query.AppendFormat("AND idEmployee = Tab1.idEmployee ");
                Query.AppendFormat("AND turn = Tab1.turn ");
                Query.AppendFormat("AND typeCheck = 'SALIDA' ");
                Query.AppendFormat("), '00:00:00') as SALIDA " );
                Query.AppendFormat("INTO #TMPSALIDA ");
                Query.AppendFormat("FROM checkInHours AS Tab1 ");
                Query.AppendFormat("LEFT OUTER JOIN employee ON employee.id = Tab1.idEmployee ");
                Query.AppendFormat("LEFT OUTER JOIN departament ON departament.id = employee.idDepartament ");
                Query.AppendFormat("WHERE employee.id > 0 ");
                Query.AppendFormat("AND Tab1.typeCheck = 'ENTRADA' ");
                Query.AppendFormat("ORDER BY idDepartament, idEmployee ");
                Query.AppendFormat("SELECT * FROM #TMPSALIDA ");
                Query.AppendFormat("DROP TABLE #TMPSALIDA ");
                
                SqlConnection Connection = new SqlConnection()
                {
                    ConnectionString = ConnectionString
                };
                Connection.Open();
                SqlDataAdapter cmd = new SqlDataAdapter(Query.ToString(), Connection);
                DataTable dtReportHoursExtras = new DataTable();
                cmd.Fill(dtReportHoursExtras);
                Connection.Close();
                if (dtReportHoursExtras != null && dtReportHoursExtras.Rows.Count > 0)
                {
                    return dtReportHoursExtras;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("ReportExtras: {0}", ex.Message));
            }
        }
    }
}
