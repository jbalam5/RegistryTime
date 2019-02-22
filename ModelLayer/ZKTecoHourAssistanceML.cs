using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ZKTecoHourAssistanceML
    {

        public class DataBase
        {
            public const string id = "id";
            public const string machineNumber = "machineNumer";
            public const string idUser = "idUser";
            public const string verifyType = "verifyType";
            public const string verifyState = "verifyState";
            public const string workCode = "workCode";
            public const string dateTimeRecord = "dateTimeRecord";
            public const string dateOnlyRecord = "dateOnlyRecord";
            public const string timeOnlyRecord = "timeOnlyRecord";
        }

        public int Id { get; set; }
        public int MachineNumber { get; set; }
        public int IdUser { get; set; }
        public string DateTimeRecord { get; set; }
        public int VerifyType { get; set; }
        public int WorkCode { get; set; }
        public int VerifyState { get; set; }
        public DateTime DateOnlyRecord { get; set; }
        public DateTime TimeOnlyRecord { get; set; }
        public int _regitry { get; set; }
        public int IdUserInsert { get; set; }
        public DateTime DateInsert { get; set; }
        public int IdUserUpdate { get; set; }
        public DateTime DateUpdate { get; set; }
        public int IdUserDelete { get; set; }
        public DateTime DateDelete { get; set; }
    }
}
