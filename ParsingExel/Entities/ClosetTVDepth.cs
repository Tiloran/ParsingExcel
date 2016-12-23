using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Entities
{
    public class ClosetTVDepth
    {
        public int ClosetTVDepthId { get; set; }
        public decimal ClosetTVdepth { get; set; }
        public decimal ClosetTVDepthPrice { get; set; }       
        public decimal DoorsWidth { get; set; }
        public int ClosetId { get; set; }
        public virtual Closet Closet { get; set; }
        public string Model { get; set; }
    }
}
