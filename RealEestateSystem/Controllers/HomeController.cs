using Microsoft.AspNetCore.Mvc;
using RealEstateSystem.Models;
using RealEstateSystem.Models.ViewModels.Home;
using RealEstateSystem.Services.Data;
using RealEstateSystem.Services.Data.Interfaces;
using System.Diagnostics;

namespace RealEstateSystem.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHouseInterface houseInteraface;

        public HomeController(IHouseInterface houseInterface)
        {
            this.houseInteraface = houseInterface;
            
        }
       

        public async Task<IActionResult> Index()
        {
            var houses = await this.houseInteraface.LastThreeHouses();

            return View(houses);
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