using ParsingExel.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParsingExel.Entities
{
    public class Closet
    {
        [Key]
        public int ClosetId { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public decimal? Depth { get; set; }
        public string Description { get; set; }
        public ClosetType Type { get; set; }   
        public int DoorsNumber { get; set; }
        public virtual IList<ClosetColor> Closetcolor { get; set; }
        public virtual IList<ClosetAmalgam> Closetamalgam { get; set; }
        public virtual IList<ClosetGlass> Closetglass { get; set; }
        public virtual IList<ClosetCorner> Closetcorner{ get; set; }
        public virtual IList<ClosetDepth> Closetdepth { get; set; }
        public virtual IList<ClosetTVDepth> ClosetTVdepth { get; set; }

        public Closet()
        {
            Closetdepth = new List<ClosetDepth>();
            Closetcolor = new List<ClosetColor>();
            Closetamalgam = new List<ClosetAmalgam>();
            Closetglass = new List<ClosetGlass>();
            Closetcorner = new List<ClosetCorner>();
            ClosetTVdepth = new List<ClosetTVDepth>();
        }
    }
}
