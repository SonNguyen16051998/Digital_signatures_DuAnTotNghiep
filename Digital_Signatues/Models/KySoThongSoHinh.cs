using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Signatues.Models
{
    public class KySoThongSoHinh
    {
        [Key]
        public int Ma_ThongSoHinh { get; set; }
        [ForeignKey("KySoThongSo")]
        public int Ma_ThongSo { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string TenHinh { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public KySoThongSo KySoThongSo { get; set; }
    }
}
