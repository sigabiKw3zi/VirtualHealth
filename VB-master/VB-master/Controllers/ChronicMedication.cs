using Microsoft.AspNetCore.Mvc;

namespace VB.Controllers
{
    public class ChronicMedication : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult ChronicMedPortal()
        //{
        //    return View();
        //}
        //public IActionResult ActivePrescriptions()
        //{
        //    // Get active prescriptions for the currently logged-in patient
        //    var patientId = GetCurrentUserId(); // Replace with actual method to get patient ID
        //    var activePrescriptions = GetActivePrescriptions(patientId);

        //    return View(activePrescriptions);
        //}

        
    }
}
