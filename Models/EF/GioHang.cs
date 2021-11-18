namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [Key]
        [Column(Order = 0)]
        public int MaGH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaSP { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHD { get; set; }

        public int SoLuongMua { get; set; }

        [StringLength(100)]
        public string Tensanpham { get; set; }

        public int DonGia { get; set; }

        public int ThanhTien { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
