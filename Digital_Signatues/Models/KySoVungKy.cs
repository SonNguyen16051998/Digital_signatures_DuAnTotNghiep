using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Signatues.Models
{
    public class KySoVungKy
    {
        [Key]
        public int Ma_KySoVungKy { get; set; }
        [ForeignKey("NguoiDung")]
        public int Ma_NguoiDung { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(4000)")]
        public string NoiDung { get; set; }
        [Column(TypeName = "nvarchar(4000)")]
        public string Json { get; set; }
        public NguoiDung NguoiDung { get; set; }
    }
}
