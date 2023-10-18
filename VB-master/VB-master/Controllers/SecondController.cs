using Microsoft.AspNetCore.Mvc;

namespace VB.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult SecondView()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
