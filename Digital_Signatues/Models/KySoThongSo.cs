using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Signatues.Models
{
    public class KySoThongSo
    {
        [Key]
        public int Ma_KySoThongSo { get; set; }
        public int Ma_NguoiDung { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Hinh1 { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Hinh2 { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Hinh3 { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Hinh4 { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Hinh5 { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string LyDoMacDinh { get; set; }
        [Column(TypeName = "nvarchar(55)")]
        public string PassCode { get; set; }
        public int Ma_NguoiUpDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool TrangThai { get; set; }
        public int Type { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Signature { get; set; }
        [Column(TypeName = "nvarchar(55)")]
        public string Password { get; set; }
        public DateTime NgayChuKyHetHan { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Serial { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Subject { get; set; }
        public DateTime LastTrySign { get; set; }
        public int Ma_NguoiKyThu { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string TieuDe1 { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string TieuDe2 { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string TieuDe3 { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string TieuDe4 { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string TieuDe5 { get; set; }
        public ICollection<KySoFileDetail> KySoFileDetails { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public NguoiDung NguoiUpdate { get; set; }
        public NguoiDung NguoiKyThu { get; set; }
        public ICollection<KySoThongSoHinh> KySoThongSoHinhs { get; set; }
    }
}
