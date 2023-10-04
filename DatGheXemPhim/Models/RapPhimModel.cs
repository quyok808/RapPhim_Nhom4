using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatGheXemPhim.Models
{
    public partial class RapPhimModel : DbContext
    {
        public RapPhimModel()
            : base("name=RapPhimModel3")
        {
        }

        public virtual DbSet<GheNgoi> GheNgois { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GheNgoi>()
                .Property(e => e.MaGhe)
                .IsFixedLength();

            modelBuilder.Entity<GheNgoi>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsFixedLength();
        }
    }
}
