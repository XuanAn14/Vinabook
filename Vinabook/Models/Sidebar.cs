using Microsoft.AspNetCore.Mvc;
using Vinabook.Data;

namespace Vinabook.Models
{
    public class Sidebar: ViewComponent
    {
        private readonly VinabookContext _context;

        public Sidebar(VinabookContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.DanhMuc.ToList());
        }
    }
}
