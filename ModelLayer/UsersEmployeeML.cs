using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class UsersEmployeeML
    {
        public class DataBase
        {
            public const string Id = "id";
            public const string IdEmployee = "idEmployee";
            public const string IdUser = "idUser";
            public const string NumControl = "numControl";
            
        }

        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public int IdUser { get; set; }
        public int NumControl { get; set; }
        
    }
}
