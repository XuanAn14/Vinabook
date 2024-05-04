using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Vinabook.Data;
using Vinabook.Models;

namespace Vinabook.Controllers
{
    public class NguoiDungController : Controller
    {
        private readonly VinabookContext _context;

        public NguoiDungController(VinabookContext context)
        {
            _context = context;
        }

        // GET: NguoiDung
        public async Task<IActionResult> Index()
        {
            return View(await _context.NguoiDung.ToListAsync());
        }

        // GET: NguoiDung/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDung
                .FirstOrDefaultAsync(m => m.MaNguoiDung == id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return View(nguoiDung);
        }


        public IActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        // Dang Nhap
        public IActionResult DangNhap(string ten, string matkhau)
        {
            var NguoiDung = _context.NguoiDung.Where(m => m.Email == ten && m.MatKhau == matkhau).FirstOrDefault<NguoiDung>();
            if (NguoiDung == null || _context.NguoiDung == null)
            {
                TempData["ThongBao"] = "Sai thông tin tài khoản hoặc mật khẩu";
                return RedirectToAction("Index", "Home");
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, NguoiDung.TenNguoiDung),
                new Claim(ClaimTypes.Role, NguoiDung.VaiTro),
            };
            var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));
            return RedirectToAction("Index","Home");
        }

        //Dang Xuat
        public IActionResult DangXuat()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //Dang Ky
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(NguoiDung _nguoidung)
        {
            var check = _context.NguoiDung.FirstOrDefault(m => (m.Email == _nguoidung.Email));
            if (check == null)
            {
                _context.NguoiDung.Add(_nguoidung);
                _nguoidung.VaiTro = "Khách hàng";
                _context.SaveChanges();
                TempData["ThongBaoTC"] = "Đăng ký thành công";
                return View();
            }
            else
            {
                TempData["ThongBao"] = "Đăng ký không thành công, email đã tồn tại";
                return View();
            }
        }

        //Doi mat khau
        public IActionResult DoiMatKhau()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoiMatKhau(string matkhaucu, string matkhaumoi)
        {
            var nguoidung = _context.NguoiDung.FirstOrDefault(u => u.MatKhau == matkhaucu);
            if (nguoidung != null)
            {
                nguoidung.MatKhau = matkhaumoi;
                _context.SaveChanges();
                TempData["ThongBaoTC"] = "Đổi mật khẩu thành công";
                return View();
            }
            else
            {
                TempData["ThongBao"] = "Đổi mật khẩu thất bại, mật khẩu cũ không khớp!";
                return View();
            }
        }
        // GET: NguoiDung/Create
        [Authorize(Roles = "Quản lý")]
        public IActionResult Create()
        {
            return View();
        }


        // POST: NguoiDung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Quản lý")]
        public async Task<IActionResult> Create([Bind("MaNguoiDung,TenNguoiDung,Email,NgaySinh,MatKhau,VaiTro")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoiDung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nguoiDung);
        }

        // GET: NguoiDung/Edit/5
        [Authorize(Roles = "Quản lý")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDung.FindAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }
            return View(nguoiDung);
        }

        // POST: NguoiDung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Quản lý")]
        public async Task<IActionResult> Edit(int id, [Bind("MaNguoiDung,TenNguoiDung,Email,NgaySinh,MatKhau,VaiTro")] NguoiDung nguoiDung)
        {
            if (id != nguoiDung.MaNguoiDung)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoiDung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoiDungExists(nguoiDung.MaNguoiDung))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nguoiDung);
        }

        // GET: NguoiDung/Delete/5
        [Authorize(Roles = "Quản lý")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDung
                .FirstOrDefaultAsync(m => m.MaNguoiDung == id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return View(nguoiDung);
        }

        // POST: NguoiDung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Quản lý")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nguoiDung = await _context.NguoiDung.FindAsync(id);
            if (nguoiDung != null)
            {
                _context.NguoiDung.Remove(nguoiDung);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguoiDungExists(int id)
        {
            return _context.NguoiDung.Any(e => e.MaNguoiDung == id);
        }
    }
}
