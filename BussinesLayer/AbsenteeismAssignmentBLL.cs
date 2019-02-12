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
    //class AbsenteeismAssignmentBLL
    //{
    //    public AbsenteeismAssignmentDAL AbsenteeismAssignmentDAL = new AbsenteeismAssignmentDAL();
    //    public ConnectionBLL conexion = new ConnectionBLL();
    //    public String ConnectionStrings;
    //    public String core = "BussinesLayer.AbsenteeismAssignmentBLL";

    //    public AbsenteeismAssignmentBLL()
    //    {
    //        ConnectionStrings = conexion.ConnectionStrings();
    //    }

    //    public DataTable All()
    //    {
    //        try
    //        {
    //            return AbsenteeismAssignmentDAL.All(ConnectionStrings);

    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(String.Format("{0}.All: {1}", core, ex));
    //        }
    //    }

    //    public DataTable GetIdEntity(int Id)
    //    {
    //        try
    //        {

    //            return AbsenteeismAssignmentDAL.GetIdEntity(Id, ConnectionStrings);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(String.Format("{0}.GetIdEntity: {1}", core, ex));
    //        }
    //    }

    //    public int Save(AbsenteeismAssignmentML absenteeism)
    //    {
    //        try
    //        {
    //            if (absenteeism.Id == 0)
    //            {
    //                return AbsenteeismAssignmentDAL.Save(absenteeism, ConnectionStrings);
    //            }
    //            else
    //            {
    //                return AbsenteeismAssignmentDAL.Update(absenteeism, ConnectionStrings);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(String.Format("{0}.Save: {1}", core, ex));
    //        }
    //    }

    //    public int Delete(AbsenteeismAssignmentML absenteeism)
    //    {
    //        try
    //        {
    //            return AbsenteeismAssignmentDAL.Delete(absenteeism, ConnectionStrings);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(String.Format("{0}.Delete: {1}", core, ex));
    //        }
    //    }
    //}
}
