using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Entities
{
    public class StarkeColor
    {
        [Key]
        public int StarkeColorId { get; set; }
        public string Color { get; set; }        
    }
}
