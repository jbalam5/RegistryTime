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
            public const string idEmployee = "idEmployee";
            public const string MachineNumber = "machineNumber";
            public const string DateTimeRecord = "dateTimeRecord";
            public const string DateOnlyRecord = "dateOnlyRecord";
            public const string TimeOnlyRecord = "timeOnlyRecord";
            public const string Turn = "turn";
            public const string TypeCheck = "typeCheck";

        }

        public int Id { get; set; }       
        public int IdEmployee { get; set; }
        public int MachineNumber { get; set; }
        public DateTime DateTimeRecord { get; set; }
        public DateTime DateOnlyRecord { get; set; }
        public TimeSpan TimeOnlyRecord { get; set; }
        public String Turn { get; set; }
        public String TypeCheck { get; set; }


    }
}
