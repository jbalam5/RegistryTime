﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    class UsersEmployeeML
    {
        public class DataBase
        {
            public const string id = "id";
            public const string idEmployee = "idEmploye";
            public const string idUser = "idUser";
        }

        public int id { get; set; }
        public int idEmployee { get; set; }
        public int idUser { get; set; }
    }
}
