using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Entities
{
    public class Rectilinear
    {
        [Key]
        public int RectilinearId { get; set; }
        public int Parts { get; set; }
        public decimal Price { get; set; }
    }
}
