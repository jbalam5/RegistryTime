using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ModelReaderML
    {
        public class DataBase
        {
            public const string id = "id";
            public const string brand = "brand";
            public const string model = "model";
        }

        public int id { get; set; }
        public string brand {get; set; }
        public string model { get; set; }
    }
}
