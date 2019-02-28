using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class DaysOfTurnML
    {
        public class DataBase
        {
            public const string Id = "id";
            public const string IdDays = "idDays";
            public const string IdTurn = "idTurn";
        }

        public int Id { get; set; }
        public String IdDays { get; set; }
        public String IdTurn { get; set; }
    }
}
