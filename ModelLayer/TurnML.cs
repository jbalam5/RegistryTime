using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TurnML
    {
        public class DataBase
        {
            public const string Id = "id";
            public const string Name = "name";
            public const string Description = "description";
            public const string TimeEntry = "timeEntry";
            public const string StartEntry = "startEntry";
            public const string LimitEntry = "limitEntry";
            public const string Departuretime = "departuretime";
            public const string LimitDeparture = "limitDeparture";
            public const string HoursJornada = "hoursJornada";

        }

        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime TimeEntry { get; set; }
        public DateTime StartEntry { get; set; }
        public DateTime LimitEntry { get; set; }
        public DateTime Departuretime { get; set; }
        public DateTime LimitDeparture { get; set; }
        public DateTime HoursJornada { get; set; }
        
    }
}
