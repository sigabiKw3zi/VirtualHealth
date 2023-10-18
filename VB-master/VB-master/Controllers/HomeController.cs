using CombinedWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CombinedWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            return View();
        }
        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult PatientInfo()
        {
            return View();
        }

        public IActionResult ChronicMed()
        {
            return View();
        }
        public IActionResult HealthInfo()
        {
            return View();
        }
        public IActionResult FamilyPlanning()
        {
            return View();
        }
        public IActionResult Chronic_Med1()
        {
            return View();
        }
        public IActionResult ChronicMed2()
        {
            return View();
        }
        public IActionResult ChronicMedPortal()
        {
            return View();
        }
        public IActionResult PharmacistManagerPortal()
        {
            return View();

        }
        public IActionResult PharmacistPortal()
        {
            return View();
        }
        public IActionResult PrenatalCare()
        {
            return View();
        }
        public IActionResult LearnMore_Broucher()
        {
            return View();
        }

        public IActionResult BirthControlPills()
        {
            return View();
        }
        public IActionResult Form()
        {
            return View();
        }
        public IActionResult Pregnancy()
        {
            return View();
        }
        public IActionResult Contraceptive()
        {
            return View();
        }
        public IActionResult Vasectomy()
        {
            return View();
        }
        public IActionResult TUBALLIGATION()
        {
            return View();
        }
        public IActionResult LAM()
        {
            return View();
        }
        public IActionResult NewOrOld()
        {
            return View();
        }
        public IActionResult EmApplication()
        {
            return View();
        }
        //public IActionResult PatientInfo()
        //{
        //    return View();
        //}
        //public IActionResult ThirdView()
        //{
        //    return View();
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}