using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Signatues.Models
{
    public class KySoDeXuat
    {
        [Key]
        public int Ma_KySoDeXuat { get; set; }
        [ForeignKey("KySo")]
        public int Ma_KySo { get; set; }
        [Column(TypeName ="nvarchar(255)")]
        public string Message { get; set; }
        [ForeignKey("NguoiDung")]
        public int Ma_NguoiDung { get; set; }
        public DateTime UpdateTime { get; set; }
        [ForeignKey("KySoFile")]
        public int Ma_KySoFile { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string TenFile { get; set; }
        public KySo KySo { get; set; }
        public NguoiDung NguoiDung { get; set;}
        public KySoFile KySoFile { get; set; }
    }
}
