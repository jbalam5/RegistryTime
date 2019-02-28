using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public static class GlobalBLL
    {
        public static ModelLayer.UsersML  userML = null;
        public static ModelLayer.CompanyML companyML = null;
        public static string  DirectoryFiles = "ImagenTMP";
    }
}
