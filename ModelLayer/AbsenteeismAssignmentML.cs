using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class AbsenteeismAssignmentML
    {
        public class DataBase
        {
            public const string Id = "id";
            public const string controlNumber = "controlNumber";
            public const string KeyAbsenteeism = "keyAbsenteeism";
            public const string Description = "description";
            public const string Status = "status";
            public const string DateStar = "dateStar";
            public const string DateEnd = "dateEnd";

        }

        public int Id { get; set; }
        public String ControlNumber { get; set; }
        public String KeyAbsenteeism { get; set; }
        public String Description { get; set; }
        public String Status { get; set; }
        public DateTime DateStar { get; set; }
        public DateTime DateEnd { get; set; }

    }
}
