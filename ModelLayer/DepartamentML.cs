using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class DepartamentML
    {

        public class DataBase
        {
            public const string Id = "id";
            public const string Name = "name";
            public const string Manager = "manager";
            public const string Description = "description";
        }

        public int Id { get; set; }
        public String Name { get; set; }
        public String Manager { get; set; }
        public String Description { get; set; }
        
    }
}
