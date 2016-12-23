using ParsingExel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Entities
{
    public class ClosetGlass
    {
        public int ClosetGlassId { get; set; }
        public GlassType Glass { get; set; }
        public decimal GlassPrice { get; set; }
        public int ClosetId { get; set; }
        public virtual Closet Closet { get; set; }
    }
}
