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
            public const string _registry = "_registry";
            public const string IdUserInsert = "idUserInsert";
            public const string DateInsert = "dateInsert";
            public const string IdUserUpdate = "idUserUpdate";
            public const string DateUpdate = "dateUpdate";
            public const string IdUserDelete = "idUserDelete";
            public const string DateDelete = "dateDelete";
            public const string Id = "id";
            public const string Name = "name";
            public const string Description = "description";
            public const string TimeEntry = "timeEntry";
            public const string StartEntry = "startEntry";
            public const string Departuretime = "departuretime";
            public const string LimitDeparture = "limitDeparture";

        }

        public int _registry { get; set; }
        public int IdUserInsert { get; set; }
        public DateTime DateInsert { get; set; }
        public int IdUserUpdate { get; set; }
        public DateTime DateUpdate { get; set; }
        public int IdUserDelete { get; set; }
        public DateTime DateDelete { get; set; }
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
