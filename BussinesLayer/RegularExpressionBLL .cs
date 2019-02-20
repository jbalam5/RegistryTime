using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BussinesLayer
{
    public class RegularExpressionBLL
    {
        private String core = "DataLayer.UsersDAL";
        public Boolean SingleNumber(String TextName)
        {
            try
            {
                Regex Regex = new Regex("^[0-9]*$");
                if (Regex.IsMatch(TextName))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.SingleNumber: {1}", core, ex));
            }
        }

        public Boolean ValidEmal(String TextName)
        {
            try
            {
                Regex Regex = new Regex("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$");
                if (Regex.IsMatch(TextName))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.SingleNumber: {1}", core, ex));
            }
        }

        public Boolean ValidDecimal(String TextName)
        {
            try
            {
                Regex Regex = new Regex("^[0-9]+([.][0-9]+)?$");
                if (Regex.IsMatch(TextName))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("{0}.SingleNumber: {1}", core, ex));
            }
        }
    }
}
