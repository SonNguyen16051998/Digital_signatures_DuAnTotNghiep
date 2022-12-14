using System.ComponentModel.DataAnnotations;

namespace Digital_Signatues.Models.ViewModel
{
    public class ViewChangePass
    {
        [Key]
        [Required(ErrorMessage = "Bạn cần nhập email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập mật khẩu")]
        [StringLength(12)]
        [MinLength(6, ErrorMessage = "Mật khẩu từ 6 - 12 kí tự")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập mật khẩu mới")]
        [StringLength(12)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Mật khẩu từ 6 - 12 kí tự")]
        public string NewPass { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bạn cần nhập lại mật khẩu mới")]
        [StringLength(12)]
        [MinLength(6, ErrorMessage = "Mật khẩu từ 6 - 12 kí tự")]
        [Compare("NewPass", ErrorMessage = "Mật khẩu không trùng khớp!!!")]
        public string RetypePass { get; set; }
    }
}
