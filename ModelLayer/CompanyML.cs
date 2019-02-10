using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class CompanyML
    {
        public class DataBase
        {
            public const string id = "id";
            public const string rfc = "rfc";
            public const string businessName = "businessName";
            public const string street = "street";
            public const string municipality = "municipality";
            public const string state = "state";
            public const string country = "country";
            public const string email = "email";
            public const string poltalCode = "postalCode";
            public const string telephone = "telephone";
            public const string image = "image";
            public const string _registry = "_registry";
            public const string idUserInsert = "idUserInsert";
            public const string dateInsert = "dateInsert";
            public const string idUserUpdate = "idUserUpdate";
            public const string dateUpdate = "dateUpdate";
            public const string idUserDelete = "idUserDelete";
            public const string dateDelete = "dateDelete";

        }

        public int Id { get; set; }
        public String Rfc { get; set; }
        public String BusinessName { get; set; }
        public String Street { get; set; }
        public String Municipality { get; set; }
        public String State { get; set; }
        public String Country { get; set; }
        public String Email { get; set; }
        public String PostalCode { get; set; }
        public String Telephone { get; set; }
        public String Image { get; set; }
        public int _regitry { get; set; }
        public int IdUserInsert { get; set; }
        public DateTime DateInsert { get; set; }
        public int IdUserUpdate { get; set; }
        public DateTime DateUpdate { get; set; }
        public int IdUserDelete { get; set; }
        public DateTime DateDelete { get; set; }
    }
}
