using Microsoft.AspNetCore.Mvc;
using Vinabook.Data;
using Vinabook.Infrastructure;
using Vinabook.Models;

namespace Vinabook.Controllers
{
    public class GioHangController : Controller
    {
        public GioHang? GioHang { get; set; }
        private readonly VinabookContext _context;

        public GioHangController(VinabookContext context)
        {
            _context = context;
        }
        public IActionResult ThemGioHang(int maSach)
        {
            Sach? sach = _context.Sach.FirstOrDefault(p => p.MaSach == maSach);
            if (sach != null)
            {
                GioHang = HttpContext.Session.GetJson<GioHang>("giohang") ?? new GioHang();
                GioHang.ThemMuc(sach, 1);
                HttpContext.Session.SetJson("giohang", GioHang);
            }
            return View("GioHang", GioHang);
        }
    }
}
