using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatGheXemPhim.RapPhimModel
{
    public partial class contextDB : DbContext
    {
        public contextDB()
            : base("name=contextDB1")
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
