using ParsingExel.Enum;
using System.Collections.Generic;

namespace ParsingExel.Entities
{
    public class Closet
    {
        public int ClosetId { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public decimal? Depth { get; set; }
        public string Description { get; set; }
        public ClosetType Type { get; set; }   
        public int DoorsNumber { get; set; }
        public virtual List<ClosetColor> Closetcolor { get; set; }
        public virtual List<ClosetAmalgam> Closetamalgam { get; set; }
        public virtual List<ClosetGlass> Closetglass { get; set; }
        public virtual List<ClosetCorner> Closetcorner{ get; set; }
        public virtual List<ClosetDepth> Closetdepth { get; set; }
        public virtual List<ClosetTVDepth> ClosetTVdepth { get; set; }        
    }
}
