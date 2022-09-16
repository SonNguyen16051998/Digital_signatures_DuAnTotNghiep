using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Signatues.Models
{
    public class KySoFile
    {
        [Key]
        public int Ma_KySoFile { get; set; }
        [ForeignKey("KySo")]
        public int Ma_KySo { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string TenFile { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string TenFileMoi { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ThuMuc { get; set; }
        [Column(TypeName = "nvarchar(55)")]
        public string Gui { get; set; }
        [Column(TypeName = "nvarchar(55)")]
        public string NewGui { get; set; }
        public bool TrangThai { get; set; }
        public bool FlagKySo { get; set; }
        [ForeignKey("NguoiDung")]
        public int Ma_NguoiKyCuoi { get; set; }
        public DateTime SignDate { get; set; }
        [Column(TypeName = "ntext")]
        public string Json { get; set; }
        public int Ma_QRCode { get; set; }
        public ICollection<KySoDeXuat> KySoDeXuats { get; set; }
        public KySo KySo { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public ICollection<KySoFileDetail> KySoFileDetails { get; set; }    
    }
}
