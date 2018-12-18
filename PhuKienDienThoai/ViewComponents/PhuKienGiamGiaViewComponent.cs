using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhuKienDienThoai.Data;

namespace PhuKienDienThoai.ViewComponents
{
    public class PhuKienGiamGiaViewComponent : ViewComponent
    {
        private ApplicationDbContext context;
        public PhuKienGiamGiaViewComponent(ApplicationDbContext _context) => context = _context;
        public async Task<IViewComponentResult> InvokeAsync(int soluong)
        {
            var model = await context.SanPham.Where(x => x.PhanTramGiamGia > 0).OrderByDescending(o => o.PhanTramGiamGia).Take(soluong).ToListAsync();
            ViewData["Title"] = "Phụ kiện giảm giá sốc";

            return View("Components/ListSanPham.cshtml", model);
        }
    }
}