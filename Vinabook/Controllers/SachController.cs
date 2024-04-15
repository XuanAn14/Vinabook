using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vinabook.Data;
using Vinabook.Models;

namespace Vinabook.Controllers
{
    public class SachController : Controller
    {
        private readonly VinabookContext _context;

        public SachController(VinabookContext context)
        {
            _context = context;
        }


        // GET: Sach
        public async Task<IActionResult> Index()
        {
            var vinabookContext = _context.Sach.Include(s => s.DanhMuc);
            return View(await vinabookContext.ToListAsync());
        }

        //Tim Kiem
        [HttpPost]
        public async Task<IActionResult> Index(int batma, string tukhoa)
        {
            var vinabookContext = _context.Sach.Include(s => s.DanhMuc).Where(s => s.Ten.Contains(tukhoa) || s.MaDanhMuc == batma || s.TacGia.Contains(tukhoa));
            return View(await vinabookContext.ToListAsync());
        }
        // GET: Sach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach
                .Include(s => s.DanhMuc)
                .FirstOrDefaultAsync(m => m.MaSach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        [Authorize(Roles = "Quản lý")]
        // GET: Sach/Create
        public IActionResult Create()
        {
            ViewData["MaDanhMuc"] = new SelectList(_context.DanhMuc, "MaDanhMuc", "Ten");
            return View();
        }

        // POST: Sach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Quản lý")]
        public async Task<IActionResult> Create([Bind("MaSach,Ten,TacGia,MoTa,URLAnh,Gia,SoLuong,MaDanhMuc")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDanhMuc"] = new SelectList(_context.DanhMuc, "MaDanhMuc", "Ten", sach.MaDanhMuc);
            return View(sach);
        }

        // GET: Sach/Edit/5
        [Authorize(Roles = "Quản lý")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach.FindAsync(id);
            if (sach == null)
            {
                return NotFound();
            }
            ViewData["MaDanhMuc"] = new SelectList(_context.DanhMuc, "MaDanhMuc", "Ten", sach.MaDanhMuc);
            return View(sach);
        }

        // POST: Sach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Quản lý")]
        public async Task<IActionResult> Edit(int id, [Bind("MaSach,Ten,TacGia,MoTa,URLAnh,Gia,SoLuong,MaDanhMuc")] Sach sach)
        {
            if (id != sach.MaSach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SachExists(sach.MaSach))
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
            ViewData["MaDanhMuc"] = new SelectList(_context.DanhMuc, "MaDanhMuc", "Ten", sach.MaDanhMuc);
            return View(sach);
        }

        [Authorize(Roles = "Quản lý")]
        // GET: Sach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach
                .Include(s => s.DanhMuc)
                .FirstOrDefaultAsync(m => m.MaSach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // POST: Sach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Quản lý")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sach = await _context.Sach.FindAsync(id);
            if (sach != null)
            {
                _context.Sach.Remove(sach);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SachExists(int id)
        {
            return _context.Sach.Any(e => e.MaSach == id);
        }
    }
}
