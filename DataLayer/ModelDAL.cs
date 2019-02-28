using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ModelDAL
    {

        
        public String InsertModel(Object ObjectModel, String TableName, int IdUserSession)
        {
            StringBuilder Query = new StringBuilder();
            Query.AppendFormat("INSERT INTO {0}", TableName);
            int contProperty = 0;
            String Fields = String.Empty;
            String FieldsValue = String.Empty;
            foreach (PropertyInfo PropertyModel in ObjectModel.GetType().GetProperties())
            {
                if (PropertyModel.Name != "Id")
                {
                    if (contProperty > 0)
                    {
                        Fields += ",";
                        FieldsValue += ",";
                    }
                    Fields += PropertyModel.Name;
                    if (PropertyModel.PropertyType == typeof(int))
                    {
                        if (!String.IsNullOrEmpty(PropertyModel.GetValue(ObjectModel).ToString()))
                            FieldsValue += PropertyModel.GetValue(ObjectModel).ToString();
                         else
                            FieldsValue += "NULL";
                    }
                    else if (PropertyModel.PropertyType == typeof(DateTime))
                    {
                        if (!String.IsNullOrEmpty(PropertyModel.GetValue(ObjectModel).ToString()))
                        {
                            DateTime date = Convert.ToDateTime(PropertyModel.GetValue(ObjectModel).ToString());
                            FieldsValue += String.Format("'{0}'", date.ToString("yyyy-MM-dd hh:mm:ss"));
                        }
                        else
                        {
                            FieldsValue += "NULL";
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(PropertyModel.GetValue(ObjectModel).ToString()))
                            FieldsValue += String.Format("'{0}'", PropertyModel.GetValue(ObjectModel).ToString()); 
                        else
                            FieldsValue += "NULL";
                    }
                    contProperty++;
                }
            }

            String[] Response = ControlFields("INSERT", IdUserSession);
            Response[0] += String.Format(",{0}", Fields.ToString());
            Response[1] += String.Format(",{0}", FieldsValue.ToString());
            Query.AppendFormat("( {0} )", Response[0].ToString());
            Query.AppendFormat("VALUES( {0} )", Response[1].ToString());
            Query.AppendLine(" SELECT CAST(scope_identity() AS int)");
            return Query.ToString();
            
        }

        public String UpdateModel(Object ObjectModel, String TableName, int IdUserSession)
        {
            StringBuilder Query = new StringBuilder();
            String Fields = String.Empty;
            String FieldsValue = String.Empty;
            Query.AppendFormat("UPDATE {0} SET", TableName);
            String IdEdit = String.Empty;
            
            foreach (PropertyInfo PropertyModel in ObjectModel.GetType().GetProperties())
            {
                if (PropertyModel.Name == "Id")
                {
                    IdEdit = PropertyModel.GetValue(ObjectModel).ToString();
                }
                if (PropertyModel.PropertyType == typeof(int))
                {
                    if (PropertyModel.Name != "Id")
                    {
                        Query.AppendFormat(" {0} = {1},", PropertyModel.Name.ToString(), PropertyModel.GetValue(ObjectModel).ToString());
                    }
                }
                else if (PropertyModel.PropertyType == typeof(DateTime))
                {
                    DateTime date = Convert.ToDateTime(PropertyModel.GetValue(ObjectModel).ToString());
                    Query.AppendFormat(" {0}='{1}',", PropertyModel.Name.ToString(), date.ToString("yyyy-MM-dd hh:mm:ss"));
                }
                else
                {
                    Query.AppendFormat(" {0}='{1}' ,", PropertyModel.Name.ToString(), PropertyModel.GetValue(ObjectModel).ToString());
                }
            }
            String[] Response = ControlFields("UPDATE", IdUserSession);
            Query.AppendLine(Response[1]);
            Query.AppendFormat(" WHERE id = {0} ", IdEdit);            
            return Query.ToString();
        }

        public String DeleteModel(Object ObjectModel, String TableName, int IdUserSession)
        {
            try
            {

                StringBuilder Query = new StringBuilder();
                Query.AppendFormat("UPDATE {0} SET ", TableName);
                String IdEdit = String.Empty;
                foreach (PropertyInfo PropertyModel in ObjectModel.GetType().GetProperties())
                {
                    if (PropertyModel.Name == "Id")
                    {
                        IdEdit = PropertyModel.GetValue(ObjectModel).ToString();
                    }
                }
                    String[] Response = ControlFields("DELETE", IdUserSession);
                Query.AppendLine(Response[1]);
                Query.AppendFormat(" WHERE id={0}", IdEdit);

                return Query.ToString();
            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("DeleteModel: {0}", ex.Message));
            }
        }

        public String[] ControlFields(String TypeModel, int IdUserSession)
        {
            try
            {
                Object ObjectModel = new ModelLayer.ControlField();
                String Fields = String.Empty;
                String FieldsValue = String.Empty;
                
                foreach (PropertyInfo PropertyModel in ObjectModel.GetType().GetProperties())
                {
                    if (TypeModel == "INSERT")
                    {
                        if (PropertyModel.Name == "IdUserInsert")
                        {
                            Fields += "_registry";
                            Fields += ",";
                            FieldsValue += 1;
                            FieldsValue += ",";
                            Fields += PropertyModel.Name;
                            Fields += ",";
                            FieldsValue += IdUserSession;

                        }
                        if (PropertyModel.Name == "DateInsert")
                        {
                            FieldsValue += ",";
                            Fields += PropertyModel.Name;
                            FieldsValue += String.Format("'{0}'", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                        }
                    }
                    else if (TypeModel == "UPDATE")
                    {
                        if (PropertyModel.Name == "IdUserUpdate")
                        {
                            Fields += PropertyModel.Name;
                            Fields += ",";
                            FieldsValue += String.Format("{0}={1}", PropertyModel.Name, IdUserSession);
                        }
                        if (PropertyModel.Name == "DateUpdate")
                        {
                            FieldsValue += ",";
                            Fields += PropertyModel.Name;
                            FieldsValue += String.Format("{0}='{1}'", PropertyModel.Name, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                        }
                    }
                    else if (TypeModel == "DELETE")
                    {
                        if (PropertyModel.Name == "_registry")
                        {
                            Fields += PropertyModel.Name;
                            FieldsValue += String.Format("{0}={1}", PropertyModel.Name, 2);
                        }
                        if (PropertyModel.Name == "IdUserDelete")
                        {
                            Fields += PropertyModel.Name;
                            FieldsValue += ",";
                            FieldsValue += String.Format("{0}={1} ", PropertyModel.Name, IdUserSession);
                            FieldsValue += ",";
                        }
                        if (PropertyModel.Name == "DateDelete")
                        {
                            Fields += PropertyModel.Name;
                            FieldsValue += String.Format("{0}='{1}'", PropertyModel.Name, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                        }
                    }
                }
                String[] Response = new String[] {Fields.ToString(), FieldsValue.ToString()};
                return Response;
            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("ControlField: {0}", ex.Message));
            }
        }

    }
}
