namespace DatGheXemPhim.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GheNgoi")]
    public partial class GheNgoi
    {
        [Key]
        [StringLength(6)]
        public string MaGhe { get; set; }

        [Required]
        [StringLength(50)]
        public string LoaiGhe { get; set; }

        public int TrangThai { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
