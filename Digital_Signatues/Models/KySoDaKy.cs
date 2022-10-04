using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Signatues.Models
{
    public class KySoDaKy
    {
        [Key,ForeignKey("KySoDeXuat")]
        public int Ma_KySoDeXuat { get; set; }
        [Required,Column(TypeName ="nvarchar(255)")]
        public string TenFileDaKy { get; set; }
        public KySoDeXuat KySoDeXuat { get; set; }

    }
}
