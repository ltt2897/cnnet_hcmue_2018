using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhuKienDienThoai.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Dữ liệu Email không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(100, ErrorMessage = "Mật khẩu {0} phải từ {2} kí tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Dữ liệu Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string  PhoneNumber { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Dữ liệu Mật khẩu không hợp lệ")]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu chưa trùng khớp với mật khẩu.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Dữ liệu Ngày sinh không hợp lệ")]
        [Required(ErrorMessage = "Ngày sinh là bắt buộc")]
        [Display(Name="Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Giới tính là bắt buộc")]
        [Display(Name = "Giới tính")]
        public bool GioiTinh { get; set; } = true;
        
        [Display(Name="Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string DiaChi { get; set; }

    }
}
