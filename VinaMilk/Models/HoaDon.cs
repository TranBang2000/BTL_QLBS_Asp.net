namespace VinaMilk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            GioHang = new HashSet<GioHang>();
        }

        [Key]
        public int MaHD { get; set; }

        [StringLength(100)]
        public string TenTK { get; set; }

        [Required]
        [StringLength(255)]
        public string DiaChiNhan { get; set; }

        public int SoLuongMua { get; set; }

        public int DonGia { get; set; }

        [Required]
        [StringLength(100)]
        public string Sodienthoai { get; set; }

        [Required]
        [StringLength(100)]
        public string ThanhTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHang { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
