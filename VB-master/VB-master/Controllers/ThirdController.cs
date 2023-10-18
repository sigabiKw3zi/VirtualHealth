using Microsoft.AspNetCore.Mvc;

namespace VB.Controllers
{
    public class ThirdController : Controller
    {
        public IActionResult ThirdView()
        {
            return View();
        }
    }
}
