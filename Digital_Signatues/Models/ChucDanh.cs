using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Signatues.Models
{
    public class ChucDanh
    {
        [Key]
        public int Ma_ChucDanh { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập tên chức vụ!!!")]
        [Column(TypeName = "nvarchar(100)"), Display(Name = "Chức vụ")]
        public string Ten_ChucDanh { get; set; }
        public int Oder { get; set; }
        public bool IsDeleted { get; set; }
        public NguoiDung NguoiDung { get; set; }
    }
}
