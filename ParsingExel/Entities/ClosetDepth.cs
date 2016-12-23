using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Entities
{
    public class ClosetDepth
    {
        public int ClosetDepthId { get; set; }
        public decimal Closetdepth { get; set; }
        public decimal ClosetDepthPrice { get; set; }
        public string Model { get; set; }
        public int ClosetId { get; set; }
        public virtual Closet Closet { get; set; }
    }
}
