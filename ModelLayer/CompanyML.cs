﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class CompanyML
    {
        public int Id { get; set; }
        public String Rfc { get; set; }
        public String BusinessName { get; set; }
        public String Street { get; set; }
        public String Musicipality { get; set; }
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