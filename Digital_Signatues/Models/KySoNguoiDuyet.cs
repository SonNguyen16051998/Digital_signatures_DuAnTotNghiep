using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Signatues.Models
{
    public class KySoNguoiDuyet
    {
        [Key]
        public int Idex_NguoiDuyet { get; set; }
        [ForeignKey("KySo")]
        public int Ma_KySo { get; set; }
        public int Ma_NguoiDung { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        public bool Status { get; set; }
        public int SoThuTu { get; set; }
        public int ThaoTac { get; set; }
        public int Type { get; set; }
        public int Ma_NguoiTao { get; set; }
        public NguoiDung NguoiTao { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public KySo KySo { get; set; }
    }
}
