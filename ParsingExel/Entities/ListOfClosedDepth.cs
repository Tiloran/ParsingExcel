using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Entities
{
    public class ListOfClosedDepth
    {
        private List<ClosedDepth> Depth = new List<ClosedDepth> ();

        public List<ClosedDepth> depth
        {
            get { return Depth; }
            set { Depth = value; }
        }
        private List<ClosedTVDepth> DepthTV = new List<ClosedTVDepth>();
        
        public List<ClosedTVDepth> depthTV
        {
            get { return DepthTV; }
            set { DepthTV = value; }
        }        
    }
}
