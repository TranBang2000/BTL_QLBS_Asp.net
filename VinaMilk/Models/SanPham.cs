namespace VinaMilk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            GioHang = new HashSet<GioHang>();
        }

        [Key]
        [StringLength(20)]
        [Required(ErrorMessage = "Mã SP không được để trống")]
        public string MaSP { get; set; }

        [Required(ErrorMessage = "Tên SP không được để trống")]
        [StringLength(100)]
        public string TenSP { get; set; }

        [Required(ErrorMessage = "Ảnh không được để trống")]
        [StringLength(100)]
        public string Anh { get; set; }

        public int SoLuongCo { get; set; }

        public double? GiaHT { get; set; }

        public string MoTa { get; set; }

        [Required(ErrorMessage = "Mã DM không được để trống")]
        [StringLength(25)]
        public string MaDM { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHang { get; set; }
    }
}
