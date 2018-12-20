using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhuKienDienThoai.Data;
using X.PagedList;

namespace PhuKienDienThoai.Controllers
{
    public class DanhMucController : Controller
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                context.Dispose();
            base.Dispose(true);
        }
        ApplicationDbContext context;
        public DanhMucController(ApplicationDbContext _context) => context = _context;

        [HttpGet]
        [Route("mat-hang/{tendanhmuc}-{id:int}.html")]
        public async Task<IActionResult> Index(int id, int? page)
        {
            var data = await context.SanPham
                                    .Include(x => x.DanhMuc)
                                    .Where(x => x.DanhMuc.Id == id)
                                    .ToListAsync();
            var DanhMuc = await context.DanhMuc.FindAsync(id);
            var MatHang = await context.MatHang.FindAsync(DanhMuc.MatHangId);

            ViewData["ActiveMatHang"] = MatHang.TenMatHang;
            ViewData["ActiveDanhMuc"] = DanhMuc.TenDanhMuc;

            ViewData["HeadTitle"] = MatHang.TenMatHang + " cho sản phẩm " + DanhMuc.TenDanhMuc;
            ViewData["Title"] = ViewData["HeadTitle"];

            var model = data.ToPagedList(page ?? 1, 9);
            return View("Views/Home/Components/AllProducts.cshtml", model);
        }

        [Route("phu-kien-giam-gia.html")]
        public async Task<IActionResult> PhuKienGiamGia(int? page)
        {
            var data = await context.SanPham.Where(x => x.GiaCu > 0).OrderByDescending(o => o.PhanTramGiamGia).ToListAsync();

            ViewData["ActiveMatHang"] = "PhuKienGiamGia";

            ViewData["HeadTitle"] = "Phụ kiện đang giảm giá";
            ViewData["Title"] = "Phụ kiện đang giảm giá";

            var model = data.ToPagedList(page ?? 1, 9);
            return View("Views/Home/Components/AllProducts.cshtml", model);
        }

    }
}