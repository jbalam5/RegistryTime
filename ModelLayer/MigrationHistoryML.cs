using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class MigrationHistoryML
    {
        public class Database
        {
            public const string Id = "id";
            public const string DateStart = "dateStart";
            public const string DateEnd = "dateEnd";
        }

        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

    }
}

