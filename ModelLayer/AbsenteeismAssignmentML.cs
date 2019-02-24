using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class AbsenteeismAssignmentML
    {
        public int Id { get; set; }
        public String controlNumber { get; set; }
        public String KeyAbsenteeism { get; set; }
        public String Description { get; set; }
        public String Status { get; set; }
        public DateTime DateStar { get; set; }
        public DateTime DateEnd { get; set; }
        public int _regitry { get; set; }
        public int IdUserInsert { get; set; }
        public DateTime DateInsert { get; set; }
        public int IdUserUpdate { get; set; }
        public DateTime DateUpdate { get; set; }
        public int IdUserDelete { get; set; }
        public DateTime DateDelete { get; set; }
    }
}
