using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Signatues.Models
{
    public class KySoFileDetail
    {
        [Key]
        public int Ma_KySoDetail { get; set; }
        [ForeignKey("KySo")]
        public int Ma_KySo { get; set; }
        [ForeignKey("KySoFile")]
        public int Ma_KySoFile { get; set; }
        [ForeignKey("NguoiDung")]
        public int Ma_NguoiDung { get; set; }
        [ForeignKey("KySoThongSo")]
        public int Ma_ThongSo { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string NoiDung { get; set; }
        public bool TrangThai { get; set; }
        public KySo KySo { get; set; }
        public KySoFile KySoFile { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public KySoThongSo KySoThongSo { get;set; }
    }
}
