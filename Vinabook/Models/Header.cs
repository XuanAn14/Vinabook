using Microsoft.AspNetCore.Mvc;

namespace Vinabook.Models
{
    public class Header : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}