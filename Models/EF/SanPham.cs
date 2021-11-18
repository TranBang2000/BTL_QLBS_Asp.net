namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;
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
        public string MaSP { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSP { get; set; }

        [Required]
        [StringLength(100)]
        public string Anh { get; set; }

        public int SoLuongCo { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,###}")]
        [Required(ErrorMessage = "Giá không được để trống")]
        public double? GiaHT { get; set; }

        public string MoTa { get; set; }

        [Required]
        [StringLength(20)]
        public string MaDM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHang { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
    }
}
