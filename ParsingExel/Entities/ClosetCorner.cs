using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Entities
{
    public class ClosetCorner
    {
        public int ClosetCornerHeightId { get; set; }
        public string Model { get; set; }
        public decimal? ClosetCornerheight { get; set; }
        public decimal? ClosetCornerdepth { get; set; }
        public decimal ClosetCornerPrice { get; set; }       
        public decimal ClosetId { get; set; }
        public virtual Closet Closet { get; set; }
    }
}
