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

            Query.AppendFormat("INSERT INTO {0} VALUES(", TableName);
            
            int contProperty = 0;

            foreach (PropertyInfo PropertyModel in ObjectModel.GetType().GetProperties())
            {
                if (PropertyModel.Name != "Id")
                {
                    if (contProperty > 0)
                        Query.AppendLine(",");

                    if (PropertyModel.PropertyType == typeof(int))
                    {
                        if (PropertyModel.Name == "IdUserInsert")
                        {
                            Query.AppendFormat(" {0}", IdUserSession);
                            
                        }else if(PropertyModel.Name == "IdUserUpdate")
                        {
                            Query.AppendLine(" NULL");
                        }
                        else if (PropertyModel.Name == "IdUserDelete")
                        {
                            Query.AppendLine(" NULL");
                        }
                        else if (PropertyModel.Name == "_registry")
                        {
                            Query.AppendLine(" 1");
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(PropertyModel.GetValue(ObjectModel).ToString())){
                                Query.AppendFormat(" {0}", PropertyModel.GetValue(ObjectModel).ToString());
                            }
                            else{
                                Query.AppendLine(" NULL");
                            }

                        }
                    }else if (PropertyModel.PropertyType == typeof(DateTime))
                    {
                        if (PropertyModel.Name == "DateInsert")
                        {
                            Query.AppendFormat(" '{0}'", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                        }
                        else if (PropertyModel.Name == "DateUpdate") 
                        {
                            Query.AppendLine(" NULL");
                        }
                        else if (PropertyModel.Name == "DateDelete")
                        {
                            Query.AppendLine(" NULL");
                        }
                        else if (!String.IsNullOrEmpty(PropertyModel.GetValue(ObjectModel).ToString()))
                        {
                            DateTime date = Convert.ToDateTime(PropertyModel.GetValue(ObjectModel).ToString());
                            Query.AppendFormat(" '{0}'", date.ToString("yyyy-MM-dd hh:mm:ss"));
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(PropertyModel.GetValue(ObjectModel).ToString()))
                        {
                            Query.AppendFormat(" '{0}'", PropertyModel.GetValue(ObjectModel).ToString());
                        }
                        else
                        {
                            Query.AppendLine(" NULL");
                        }
                    }
                    contProperty++;
                }
            }
            Query.AppendLine(" )");
            Query.AppendLine(" SELECT CAST(scope_identity() AS int)");
            return Query.ToString();
        }

        public String UpdateModel(Object ObjectModel, String TableName, int IdUserSession)
        {
            StringBuilder Query = new StringBuilder();

            Query.AppendFormat("UPDATE {0} SET", TableName);

            int contProperty = 0;
            String IdEdit = String.Empty;
            
            foreach (PropertyInfo PropertyModel in ObjectModel.GetType().GetProperties())
            {
                if (PropertyModel.Name == "Id")
                {
                    IdEdit = PropertyModel.GetValue(ObjectModel).ToString();
                }


                
                if (PropertyModel.PropertyType == typeof(int))
                {
                    if (PropertyModel.Name != "Id" && PropertyModel.Name != "IdUserInsert" && PropertyModel.Name != "_registry" && PropertyModel.Name != "IdUserDelete")
                    {
                        if (PropertyModel.Name == "IdUserUpdate")
                        {
                            Query.AppendFormat(" {0}={1}, ",PropertyModel.Name.ToString(), IdUserSession);
                        }
                        else
                        {
                            Query.AppendFormat(" {0} = {1}, ", PropertyModel.Name.ToString(), PropertyModel.GetValue(ObjectModel).ToString());
                        }
                    }
                }
                else if (PropertyModel.PropertyType == typeof(DateTime))
                {
                    if (PropertyModel.Name != "DateInsert" && PropertyModel.Name != "DateDelete")
                    {
                        if (PropertyModel.Name == "DateUpdate")
                        {
                            Query.AppendFormat(" {0}='{1}', ", PropertyModel.Name.ToString(), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss "));
                        }
                        else
                        {
                            DateTime date = Convert.ToDateTime(PropertyModel.GetValue(ObjectModel).ToString());
                            Query.AppendFormat(" {0}='{1}',", PropertyModel.Name.ToString(), date.ToString("yyyy-MM-dd hh:mm:ss"));
                        }
                    }
                }
                else
                {
                    Query.AppendFormat(" {0}='{1}' ,", PropertyModel.Name.ToString(), PropertyModel.GetValue(ObjectModel).ToString());
                }
            }
            Query.AppendLine(" _registry=1 ");
            Query.AppendFormat(" WHERE id = {0} ", IdEdit);
            
            
            return Query.ToString();
        }


    }
}
