using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class EmployeeML
    {
        public class DataBase
        {
            public const string Id = "id";
            public const string Rfc = "rfc";
            public const string Curp = "curp";
            public const string Name = "name";
            public const string Lastname = "lastname";
            public const string Scholarship = "scholarship";
            public const string Birthdate = "birthdate";
            public const string Gender = "gender";
            public const string Nationality = "nationality";
            public const string Address = "address";
            public const string Municipality = "municipality";
            public const string Country = "country";
            public const string AdmissionDate = "admissionDate";
            public const string Email = "email";
            public const string Telephone = "telephone";
            public const string CivilStatus = "civilStatus";
            public const string Colony = "colony";
            public const string StateCountry = "stateCountry";
            public const string PostalCode = "postalCode";
            public const string IdDepartament = "idDepartament";
            public const string SureType = "sureType";
            public const string NumberSure = "numberSure";
            public const string Salary = "salary";
            public const string IdJob = "idJob";
            public const string IdUser = "idUser";
        }

        public int Id { get; set; }
        public String RFC { get; set; } 
        public String Curp { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Scholarship { get; set; }
        public DateTime Birthdate { get; set; }
        public String Gender { get; set; }
        public String Nationality { get; set; }
        public String Address { get; set; }
        public String Municipality { get; set; }
        public String Country { get; set; }
        public String Email { get; set; }
        public String Telephone { get; set; }
        public String CivilStatus { get; set; }
        public int PostalCode { get; set; }
        public String Colony { get; set; }
        public String StateCountry { get; set; }
        public int IdDepartament { get; set; }
        public String SureType { get; set; }
        public String NumberSure { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int IdJob { get; set; }
        public decimal Salary { get; set; }
        public int IdUser { get; set; }
        
    }
}
