using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Entities
{
    public class ColorPrice
    {
        [Key]
        public int ColorPriceId { get; set; }
        public decimal Price { get; set; }
        public string Model { get; set; }
    }
}
