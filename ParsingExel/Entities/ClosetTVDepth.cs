using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Entities
{
    public class ClosetTVDepth
    {
        [Key]
        public int ClosetTVDepthId { get; set; }
        public decimal ClosetTVdepth { get; set; }
        public decimal ClosetTVDepthPrice { get; set; }       
        public decimal DoorsWidth { get; set; }
        public int ClosetId { get; set; }
        public virtual Closet Closet { get; set; }
        public string Model { get; set; }
    }
}
