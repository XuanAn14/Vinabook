using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vinabook.Data;
using Vinabook.Infrastructure;
using Vinabook.Models;


namespace Vinabook.Controllers
{
    public class GioHangController : Controller
    {
        private readonly VinabookContext _context;

        public GioHangController(VinabookContext context)
        {
            _context = context;
        }

        

    }
}
