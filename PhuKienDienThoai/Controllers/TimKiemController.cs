using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhuKienDienThoai.Data;
using X.PagedList;

namespace PhuKienDienThoai.Controllers
{
    public class TimKiemController : Controller
    {
        private ApplicationDbContext context;
        public TimKiemController(ApplicationDbContext _context) => context = _context;

        [HttpGet]
        [Route("tim-kiem/{*s}")]
        public async Task<IActionResult> Search(string keyword, int? page)
        {
            ViewData["HeadTitle"] = "Tìm kiếm: " + keyword + " - Phụ Kiện Điện Thoại Chính Hãng";
            ViewData["Title"] = "Kết quả tìm kiếm với từ khoá \"" + keyword + "\"";

            var KetQuaTimKiem = await context.SanPham
                                            .Where(sanpham => sanpham.TenSanPham.Contains(keyword) |
                                                            sanpham.DongDienThoai.TenDongDienThoai.Contains(keyword) |
                                                            sanpham.ThuongHieu.TenThuongHieu.Contains(keyword) |
                                                            sanpham.MatHang.TenMatHang.Contains(keyword) |
                                                            sanpham.DanhMuc.TenDanhMuc.Contains(keyword) |
                                                            sanpham.TomTat.Contains(keyword))
                                            .ToListAsync();

            var model = KetQuaTimKiem.ToPagedList(page ?? 1, 9);

            return View("Views/Home/Components/AllProducts.cshtml", model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                context.Dispose();
            base.Dispose(true);
        }
    }
}