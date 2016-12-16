using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel
{
    class Furniture
    {
        public int TypeID { get; set; }
        public string NameType { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Depth { get; set; }
        public int quantity { get; set; } = 1;
    }
}
