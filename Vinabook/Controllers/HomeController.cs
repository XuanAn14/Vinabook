using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vinabook.Data;
using Vinabook.Models;

namespace Vinabook.Controllers
{
    public class HomeController : Controller
    {
        private readonly VinabookContext _context;

        public HomeController(VinabookContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Sach.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
