using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Signatues.Models
{
    public class KySoDeXuat
    {
        [Key]
        public int Ma_KySoDeXuat { get; set; }
        [ForeignKey("NguoiDungDeXuat")]
        public int Ma_NguoiDeXuat { get; set; }
        [ForeignKey("NguoiDungKy")]
        public string inputFile { get; set; }
        public DateTime NgayDeXuat { get; set; }
        [Column(TypeName = "nvarchar(1000)")]
        public NguoiDung NguoiDungDeXuat { get; set;}
        public KySoDaKy KySoDaKy { get; set; }  
        public ICollection<KySoQuyTrinh> KySoQuyTrinhs { get; set; }
    }
}
