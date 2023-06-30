using System.ComponentModel.DataAnnotations;

namespace _4.CusView.ModelRequest
{
    public class LoginRequest : ValidationAttribute
    {
        [Required(ErrorMessage = "Vui lòng không để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Mật khẩu ít nhất 6 ký tự")]
        public string? MatKhau { get; set; }
        public bool Remember { get; set; }
    }
}
