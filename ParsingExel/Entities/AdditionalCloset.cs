using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Entities
{
    public class AdditionalCloset
    {
        public int AdditionalClosetId { get; set; }
        public string Model { get; set; }
        public decimal Width { get; set; }
        public string Depth { get; set; }
        public string Height { get; set; }
        public decimal Price { get; set; }
    }
}
