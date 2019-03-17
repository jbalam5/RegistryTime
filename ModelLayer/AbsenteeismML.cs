using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class AbsenteeismML
    {
        public class DataBase
        {
            public const string Id = "id";
            public const string IsKey = "isKey";
            public const string Concept = "concept";
            public const string description = "description";
       
        }

        public int Id { get; set; }
        public String IsKey { get; set; }
        public String Concept { get; set; }
        public String description { get; set; }  
    }
}
