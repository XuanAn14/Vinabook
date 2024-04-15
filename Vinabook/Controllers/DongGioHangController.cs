using Microsoft.AspNetCore.Mvc;
using Vinabook.Data;
using Vinabook.Models;
using Vinabook.Infrastructure;

namespace Vinabook.Controllers
{
    public class DongGioHangController : Controller
    {
        private readonly VinabookContext _context;

        public DongGioHangController(VinabookContext context)
        {
            _context = context;
        }

        public List<DongGioHang> dongGioHang
        {
            get
            {
                var data = HttpContext.Session.Get<List<DongGioHang>>("GioHang");
                if (data == null)
                {
                    data = new List<DongGioHang>();
                }
                return data;
            }
        }

        public IActionResult Index()
        {
            return View(dongGioHang);
        }

        public IActionResult ThemVaoGio(int id)
        {
            var gioHang = dongGioHang;
            var item = gioHang.SingleOrDefault(p => p.MaSach == id);
            var sach = _context.Sach.SingleOrDefault(p => p.MaSach == id);
            if (item == null)
            {
                item = new DongGioHang
                {
                    MaSach = id,
                    Ten = sach.Ten,
                    Gia = sach.Gia,
                    SoLuong = 1,
                    URLAnh = sach.URLAnh,
                };
                gioHang.Add(item);
            }
            else
            {
                item.SoLuong++;
            }
            HttpContext.Session.Set("GioHang", gioHang);
           
            return RedirectToAction("Index");
        }

        public IActionResult GiamSoLuong(int id)
        {
            var gioHang = dongGioHang;
            var item = gioHang.SingleOrDefault(p => p.MaSach == id);
            if (item != null)
            {
                item.SoLuong--;
            }
            HttpContext.Session.Set("GioHang", gioHang);
            return RedirectToAction("Index");
        }

        public IActionResult XoaKhoiGio(int id)
        {
            var gioHang = dongGioHang;
            var item = gioHang.SingleOrDefault(p => p.MaSach == id);

            if (item != null)
            {
                gioHang.Remove(item);
            }
            HttpContext.Session.Set("GioHang", gioHang);
            return RedirectToAction("Index");
        }
    }
}
