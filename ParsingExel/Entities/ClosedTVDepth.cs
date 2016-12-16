using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Entities
{
    public class ClosedTVDepth
    {
        public int ClosedTVDepthID { get; set; }
        public decimal ClosedTVdepth { get; set; }
        public decimal ClosedTVDepth1Price { get; set; }
        public decimal ClosedTVDepth2Price { get; set; }
        public decimal ClosedTVDepth3Price { get; set; }
        public decimal DoorsWidth { get; set; }
        public int ClosedID { get; set; } 
        public string Model { get; set; }
    }
}
