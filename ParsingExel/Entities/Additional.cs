using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Entities
{
    public class Additional
    {
        [Key]
        public int AdditionalId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
