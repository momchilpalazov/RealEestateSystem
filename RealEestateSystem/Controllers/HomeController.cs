using Microsoft.AspNetCore.Mvc;
using RealEstateSystem.Models;
using RealEstateSystem.Models.ViewModels.Home;
using System.Diagnostics;

namespace RealEstateSystem.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View(new IndexViewModel());
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