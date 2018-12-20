using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhuKienDienThoai.Data;
using X.PagedList;

namespace PhuKienDienThoai.Controllers
{
    public class ThuongHieuController : Controller
    {
        ApplicationDbContext context;
        public ThuongHieuController(ApplicationDbContext _context) => context = _context;

        [HttpGet]
        [Route("thuong-hieu/{tenthuonghieu}-{id:int}.html")]
        public async Task<IActionResult> Index(int id, int? page)
        {
            var data = await context.SanPham
                                    .Include(x => x.ThuongHieu)
                                    .Where(x => x.ThuongHieu.Id == id)
                                    .ToListAsync();

            var ThuongHieu = await context.ThuongHieu.FindAsync(id);

            ViewData["HeadTitle"] = ThuongHieu.TenThuongHieu;
            ViewData["Title"] = "Sản phẩm theo thương hiệu " + ViewData["HeadTitle"];
            var model = data.ToPagedList(page ?? 1, 9);
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