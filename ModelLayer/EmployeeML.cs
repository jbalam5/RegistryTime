using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class EmployeeML
    {
        public int Id { get; set; }
        public String RFC { get; set; }
        public String Curp { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Scholarship { get; set; }
        public String IdJob { get; set; }
        public String IdDepartament { get; set; }
        public String IdUser { get; set; }
        public int _regitry { get; set; }
        public int IdUserInsert { get; set; }
        public DateTime DateInsert { get; set; }
        public int IdUserUpdate { get; set; }
        public DateTime DateUpdate { get; set; }
        public int IdUserDelete { get; set; }
        public DateTime DateDelete { get; set; }
    }
}
