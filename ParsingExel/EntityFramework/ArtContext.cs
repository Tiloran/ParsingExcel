using ParsingExel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingExel.EntityFramework
{
    public class ArtContext : DbContext
    {
        public ArtContext() : base("Furniture") { }

        public DbSet<Additional> Additionals { get; set; }
        public DbSet<AdditionalCloset> AdditionalClosets { get; set; }
        public DbSet<Closet> Closets { get; set; }
        public DbSet<ClosetAmalgam> ClosetAmalgams { get; set; }
        public DbSet<ClosetColor> ClosetColors { get; set; }
        public DbSet<ClosetCorner> ClosetCorners { get; set; }
        public DbSet<ClosetDepth> ClosetDepths { get; set; }
        public DbSet<ClosetGlass> ClosetGlases { get; set; }
        public DbSet<ClosetTVDepth> ClosetTVDepths { get; set; }
        public DbSet<ColorPrice> ColorPrices { get; set; }
        public DbSet<Curvilinear> Curvilinears { get; set; }
        public DbSet<PaintPrice> PaintPrices { get; set; }
        public DbSet<Rectilinear> Rectilinears { get; set; }
        public DbSet<StarkeColor> StarkeColors { get; set; }
        public DbSet<StarkePaint> StarkePaints { get; set; }       
    }
}
