using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhuKienDienThoai.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Dữ liệu Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password, ErrorMessage = "Dữ liệu Mật khẩu không hợp lệ")]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ đăng nhập lần sau")]
        public bool RememberMe { get; set; }
    }
}
