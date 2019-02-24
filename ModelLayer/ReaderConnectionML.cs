using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ReaderConnectionML
    {
        public class DataBase
        {
            public const string id = "id";
            public const string name = "name";
            public const string ip = "ip";
            public const string port = "port";
            public const string isDefault = "isDefault";
            public const string idReader = "idReader";
        }

        public int id { get; set; }
        public string name { get; set; }
        public string ip { get; set; }
        public string port { get; set; }
        public bool isDefault { get; set; }
        public int idReader { get; set; }
        public int idUserInsert { get; set; }
        public DateTime dateInsert { get; set; }
        public int idUserUpdate { get; set; }
        public DateTime dateUpdate { get; set; }
        public int idUserDelete { get; set; }
        public DateTime dateDelete { get; set; }
    }
}
