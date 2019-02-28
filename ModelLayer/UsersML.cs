using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class UsersML
    {

        public class DataBase
        {
            public const string Id = "id";
            public const string UserName = "userName";
            public const string Password = "password";
            public const string Rol = "rol";
            public const string Image = "image";
        }

        public int Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public int Rol { get; set; }
        public String Image { get; set; }
    }
}
