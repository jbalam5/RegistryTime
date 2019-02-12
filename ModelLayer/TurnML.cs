using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TurnML
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String StarTime { get; set; }
        public String Description { get; set; }
        public String TimeEntry { get; set; }
        public String StartEntry { get; set; }
        public String LimitEntry { get; set; }
        public String Departuretime { get; set; }
        public String LimitDeparture { get; set; }
        public int HoursJornada { get; set; }
        public int IdUserInsert { get; set; }
        public DateTime DateInsert { get; set; }
        public int IdUserUpdate { get; set; }
        public DateTime DateUpdate { get; set; }
        public int IdUserDelete { get; set; }
        public DateTime DateDelete { get; set; }
    }
}
