using ParsingExel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Entities
{
    public class ClosetAmalgam
    {
        public int AmalgamId { get; set; }
        public AmalgamType Amalgam { get; set; }
        public decimal AmalgamPrice { get; set; }
        public int ClosetId { get; set; }
        public virtual Closet Closet { get; set; }
    }
}
