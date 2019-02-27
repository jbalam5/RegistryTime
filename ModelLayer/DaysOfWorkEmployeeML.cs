using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class DaysOfWorkEmployeeML
    {

        public class DataBase
        {
            public const string Id = "id";
            public const string IdEmployee = "idEmployee";
            public const string IdDays = "idDays";
        }

        public int Id { get; set; }
        public int IdDays { get; set; }
        public int IdEmployee { get; set; }

    }
}
