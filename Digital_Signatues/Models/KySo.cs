using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Signatues.Models
{
    public class KySo
    {
        [Key]
        public int Ma_KySo { get; set; }
        [ForeignKey("NguoiDung")]
        public int Ma_NguoiTao { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string ThuMuc { get; set; }
        public DateTime ThoiDiem { get; set; }
        [Column(TypeName ="nvarchar(255)")]
        public string Ten_KySo { get; set; }
        public bool TrangThai { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName ="nvarchar(255)")]
        public string GhiChu { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public ICollection<KySoDeXuat> KySoDeXuats { get; set; }
        public ICollection<KySoFile> KySoFiles { get; set;}
        public ICollection<KySoFileDetail> KySoFileDetails { get; set; }
        public ICollection<KySoNguoiDuyet> KySoNguoiDuyets { get; set; }
    }
}
