using Microsoft.AspNetCore.Mvc;
using Vinabook.Data;

namespace Vinabook.Models
{
    public class Navbar: ViewComponent
    {
        private readonly VinabookContext _context;

        public Navbar(VinabookContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.DanhMuc.ToList());
        }
    }
}
