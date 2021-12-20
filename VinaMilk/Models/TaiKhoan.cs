namespace VinaMilk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(100)]
        [Required(ErrorMessage = "Tên TK không được để trống")]
        public string TenTK { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Mat_Khau { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Họ Tên không được để trống")]
        public string HoTen { get; set; }

        [StringLength(255)]
        public string Dia_Chi { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Quyền không được để trống")]
        public byte? Quyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}
