using ParsingExel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.Abstraction
{
    public class ListOfClosetOptions
    {
        private List<ClosetDepth> depth = new List<ClosetDepth>();
        public List<ClosetDepth> Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        private List<ClosetTVDepth> depthTV = new List<ClosetTVDepth>();
        public List<ClosetTVDepth> DepthTV
        {
            get { return depthTV; }
            set { depthTV = value; }
        }

        private List<ClosetCorner> cornerHeight = new List<ClosetCorner>();
        public List<ClosetCorner> CornerHeight
        {
            get { return cornerHeight; }
            set { cornerHeight = value; }
        }
    }
}
