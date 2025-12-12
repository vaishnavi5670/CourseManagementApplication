using CourseManagementApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CourseManagementApp.Controllers
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
        public IActionResult Indexs()
        {
            return RedirectToAction("Indexs", "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }


    }
}
