using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ControlField
    {
        public int _registry { get; set; }
        public int IdUserInsert { get; set; }
        public DateTime DateInsert { get; set; }
        public int IdUserUpdate { get; set; }
        public DateTime DateUpdate { get; set; }
        public int IdUserDelete { get; set; }
        public DateTime DateDelete { get; set; }
    }
}
