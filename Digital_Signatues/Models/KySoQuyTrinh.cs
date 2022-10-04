using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Signatues.Models
{
    public class KySoQuyTrinh
    {
        [Key]
        public int Ma_KySoQuyTrinh { get; set; }
        [Required,Column(TypeName ="nvarchar(255)")]
        public string TenQuyTrinh { set; get; }
        [Column(TypeName = "nvarchar(500)")]
        public string GhiChu { set; get; }
        [ForeignKey("KySoDeXuat")]
        public int Ma_KySoDeXuat { set; get; }
        public KySoDeXuat KySoDeXuat { get; set; }
    }
}
