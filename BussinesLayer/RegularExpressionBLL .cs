using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BussinesLayer
{
    class RegularExpressionBLL
    {
        private String core = "DataLayer.UsersDAL";
        public Boolean SingleNumber(String TextName)
        {
            try
            {
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.SingleNumber: {1}", core, ex));
            }
        }
    }
}
