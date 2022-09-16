using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Signatues.Models
{
    public class KySoQuyTrinh
    {
        [Key]
        public int Ma_kySoQuyTrinh { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string TenQuyTrinh { get; set; }
        [ForeignKey("PhongBan")]
        public int Ma_PhongBan { get; set; }
        [ForeignKey("NguoiDung")]
        public int Ma_NguoiDung { get; set; }
        public bool TrangThai { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string GhiChu { get; set; }
        public bool IsDeleted { get; set; }
        public int STT { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public PhongBan PhongBan { get; set; }
    }
}
