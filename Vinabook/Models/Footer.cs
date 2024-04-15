using Microsoft.AspNetCore.Mvc;

namespace Vinabook.Models
{
    public class Footer : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}