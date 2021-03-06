﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhuKienDienThoai.Data;

namespace PhuKienDienThoai.ViewComponents
{
    public class PhuKienMoiViewComponent : ViewComponent
    {
        private ApplicationDbContext context;
        public PhuKienMoiViewComponent(ApplicationDbContext _context) => context = _context;
        public async Task<IViewComponentResult> InvokeAsync(int soluong)
        {
            var model = await context.SanPham.OrderByDescending(o => o.id).Take(soluong).ToListAsync();
            ViewData["Title"] = "Phụ kiện mới";

            return View("Components/ListSanPham.cshtml", model);
        }
    }
}