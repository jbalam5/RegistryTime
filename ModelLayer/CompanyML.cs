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
            public const string numberUserEmploye = "numberUserEmploye";

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
        public String NumberUserEmploye  { get; set; }

    }
}
