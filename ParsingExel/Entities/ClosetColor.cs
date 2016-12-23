using ParsingExel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Entities
{
    public class ClosetColor
    {
        public int ClosetColorId { get; set; }
        public ColorType color { get; set; }
        public decimal ColorPrice { get; set; }
        public int ClosetId { get; set; }
        public virtual Closet Closet { get; set; }
    }
}
