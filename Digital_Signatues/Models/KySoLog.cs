using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Signatues.Models
{
    public class KySoLog
    {
        [Key]
        public int Ma_KySoLog { get; set; }
        [ForeignKey("NguoiDung")]
        public int Ma_NguoiDung { get; set; }
        [ForeignKey("Role")]
        public int Ma_Role { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Message { get; set; }
        public int Type { get; set; }
        public DateTime UpdateTime { get; set; }
        public int Ma_ThongSo { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public Role Role { get; set; }
    }
}
