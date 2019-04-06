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
        ModelDAL  ModelDAL = new ModelDAL();


        public DataTable ReportAbsenteeism(DateTime DateStart, DateTime DateEnd, int IdDepartamnet = 0, int IdEmployee = 0)
        {
            try
            {
                StringBuilder Query = new StringBuilder();
                AbsenteeismAssignmentDAL AbsenteeismAssignmentDAL = new AbsenteeismAssignmentDAL();
                EmployeeDAL EmployeeDAL = new EmployeeDAL();
                DepartamentDAL DepartamentDAL = new DepartamentDAL();
                AbsenteeismDAL AbsenteeismDAL = new AbsenteeismDAL();

                Query.AppendLine("SELECT ");
                Query.AppendFormat("AA.{0} AS NUMCONTROL, ", AbsenteeismAssignmentML.DataBase.controlNumber);
                Query.AppendFormat("EMP.{0} + ' ' + EMP.{1} EMPLEADO, ", EmployeeML.DataBase.Name, EmployeeML.DataBase.Lastname);
                Query.AppendFormat("departament.{0} AS DEPARTAMENTO, ", DepartamentML.DataBase.Name);                
                Query.AppendFormat("ABS.{0} AS CONCEPTO, ", AbsenteeismML.DataBase.Concept);
                Query.AppendFormat("AA.{0} AS ESTADO, ", AbsenteeismAssignmentML.DataBase.Status);
                Query.AppendFormat("DATEDIFF(day, convert(date, AA.{0}), DATEADD(dd, 1, convert(date, AA.{1}))) TOTALDIAS, ", AbsenteeismAssignmentML.DataBase.DateStar, AbsenteeismAssignmentML.DataBase.DateEnd);
                Query.AppendFormat("CONCAT('del ', Convert(DATE, AA.{0}), ' al ', CONVERT(DATE, AA.{1})) AS FECHAS ", AbsenteeismAssignmentML.DataBase.DateStar, AbsenteeismAssignmentML.DataBase.DateEnd);
                Query.AppendFormat("FROM {0} AA ", AbsenteeismAssignmentDAL.TableName);
                Query.AppendFormat("LEFT OUTER JOIN {0} AS EMP ON EMP.id = AA.controlNumber AND EMP._Registry = 1 ", EmployeeDAL.TableName);
                Query.AppendFormat("LEFT OUTER JOIN {0} ON departament.id = EMP.idDepartament AND departament._Registry = 1 ", DepartamentDAL.TableName);
                Query.AppendFormat("LEFT OUTER JOIN {0} AS ABS ON ABS.isKey = AA.KeyAbsenteeism AND ABS._Registry = 1 ", AbsenteeismDAL.TableName);
                Query.AppendLine(" WHERE ");
                Query.AppendFormat("AA.dateInsert BETWEEN '{0}' and '{1}' ", DateStart.ToString("yyyy-MM-dd"), DateEnd.ToString("yyyy-MM-dd"));
                Query.AppendLine("AND AA._registry = 1 ");
                //Query.AppendLine("AND AA.Status = 'Aceptada' ");

                if (IdDepartamnet > 0)
                {
                    Query.AppendFormat(" AND EMP.{0} = {1}", EmployeeML.DataBase.IdDepartament, IdDepartamnet);
                }
                if (IdEmployee > 0)
                {
                    Query.AppendFormat(" AND EMP.{0} = {1}", EmployeeML.DataBase.Id, IdEmployee);
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
        public DataTable ReportExtras(DateTime DateStart, DateTime DateEnd, int IdTurn = 0, int IdDepartament = 0, int IdEmployee = 0)
        {
            try
            {
                StringBuilder Query = new StringBuilder();

                Query.AppendLine("SELECT ");
                //Query.AppendFormat("Tab1.id, ");
                Query.AppendFormat("employee.id CVE, ");
                Query.AppendFormat("employee.name EMPLEADO, ");
                Query.AppendFormat("departament.name DEPARTAMENTO, ");               
                Query.AppendFormat("turn TURNO, ");
                Query.AppendFormat("DateOnlyRecord FECHA, ");
                Query.AppendFormat("TURNO.timeEntry ENTRADA, ");
                Query.AppendFormat("ISNULL(dateTimeRecord, '00:00:00')  AS ENTRADA_MARCADA, ");
                Query.AppendFormat("TURNO.departuretime SALIDA, ");
                Query.AppendFormat("ISNULL(( SELECT ");
                Query.AppendFormat("dateTimeRecord ");
                Query.AppendFormat("FROM checkInHours ");
                Query.AppendFormat("WHERE ");
                Query.AppendFormat("dateOnlyRecord BETWEEN '{0}' and '{1}' ", DateStart.ToString("yyyy-MM-dd HH:mm:ss"), DateEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                Query.AppendFormat("AND checkInHours.idEmployee = Tab1.idEmployee ");
                Query.AppendFormat("AND ISNULL(checkInHours.idturn,0) = ISNULL(Tab1.idTurn,0) ");
                Query.AppendFormat("AND typeCheck = 'SALIDA' ");
                Query.AppendFormat("), '00:00:00') as SALIDA_MARCADA " );
                Query.AppendFormat("INTO #TMPSALIDA ");
                Query.AppendFormat("FROM checkInHours AS Tab1 ");
                Query.AppendFormat("LEFT OUTER JOIN employee ON employee.id = Tab1.idEmployee AND employee._Registry = 1 ");
                Query.AppendFormat("LEFT OUTER JOIN departament ON departament.id = employee.idDepartament AND departament._Registry = 1 ");
                Query.AppendFormat("LEFT OUTER JOIN turn TURNO ON TURNO.ID  = Tab1.idturn  AND TURNO._Registry = 1 ");
                Query.AppendFormat("LEFT OUTER JOIN turnsofemployee ON turnsofemployee.idEmployee = Tab1.idEmployee AND turnsofemployee.idTurn = Tab1.idturn ");
                Query.AppendFormat("WHERE Tab1._Registry = 1 ");
                Query.AppendFormat("AND Tab1.typeCheck = 'ENTRADA' ");
                if (IdTurn > 0)
                    Query.AppendFormat("AND Tab1.idTurn = {0} ", IdTurn);
                if (IdDepartament > 0)
                    Query.AppendFormat("AND departament.id = {0} ", IdDepartament);
                if (IdEmployee > 0)
                    Query.AppendFormat("AND employee.id= {0} ", IdEmployee);          
                Query.AppendFormat("ORDER BY employee.id ");
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

        public DataTable AdmissionDateEmployee(DateTime value1, DateTime value2)
        {
            try
            {
                StringBuilder Query = new StringBuilder();
                Query.AppendLine("SELECT ");
                Query.AppendLine("employee.id, ");
                Query.AppendLine("CONCAT(employee.name, ' ', employee.lastname) as Nombre, ");
                Query.AppendLine("departament.name as Departamento, ");
                Query.AppendLine("employee.birthdate as Cumpleanios,");
                Query.AppendLine("employee.admissionDate as FechaIngreso");
                Query.AppendFormat("FROM {0} ", "employee");
                Query.AppendLine("JOIN departament ON departament.id = employee.idDepartament ");
                Query.AppendLine(" WHERE ");
                Query.AppendFormat("employee._registry = {0} ", 1);
                Query.AppendFormat("and admissionDate BETWEEN '{0}' AND '{1}'", value1.ToString("yyyy-MM-dd"), value2.ToString("yyyy-MM-dd"));
                return ModelDAL.DataTableRecord(Query.ToString(), ConnectionString);
            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("AdmissionDateEmployee: {0}", ex.Message));
            }
        }
    }
}
