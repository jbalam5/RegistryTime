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
            public const string _registry = "_registry";
            public const string IdUserInsert = "idUserInsert";
            public const string DateInsert = "dateInsert";
            public const string IdUserUpdate = "idUserUpdate";
            public const string DateUpdate = "dateUpdate";
            public const string IdUserDelete = "idUserDelete";
            public const string DateDelete = "dateDelete";
        }

        public int Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public int Rol { get; set; }
        public String Image { get; set; }
        public int _regitry { get; set; }
        public int IdUserInsert { get; set; }
        public DateTime DateInsert { get; set; }
        public int IdUserUpdate { get; set; }
        public DateTime DateUpdate { get; set; }
        public int IdUserDelete { get; set; }
        public DateTime DateDelete { get; set; }
    }
}
