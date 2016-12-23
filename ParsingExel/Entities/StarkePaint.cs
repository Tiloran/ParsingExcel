using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Entities
{
    public class StarkePaint
    {
        [Key]
        public int StarkePaintId { get; set; }
        public string Paint { get; set; }        
    }
}
