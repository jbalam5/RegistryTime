using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class CheckInHoursML
    {
        public class Database {
            public const string id = "id";
            public const string date = "date";
            public const string type = "type";
            public const string idEmployee = "idEmployee";
            public const string MachineNumber = "machineNumber";
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int IdEmployee { get; set; }
        public String Type { get; set; }
        public int MachineNumber { get; set; }
    }
}
