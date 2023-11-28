using Microsoft.AspNetCore.Mvc;
using RealEstateSystem.Models;
using RealEstateSystem.Services.Data.Interfaces;
using RealEstateSystems.Web.Infrastructure.Helper;
using System.Diagnostics;

namespace RealEstateSystem.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHouseInterface houseInteraface;

        private readonly GetImageFromDbDecoding getImageFromDbDecoding;

        public HomeController(IHouseInterface houseInterface,GetImageFromDbDecoding getImageFromDbDecoding)
        {
            this.houseInteraface = houseInterface;
            this.getImageFromDbDecoding = getImageFromDbDecoding;
            
        }
       

        public async Task<IActionResult> Index()
        {
            var houses = await this.houseInteraface.LastThreeHouses();


            foreach (var house in houses)
            {
                house.ImageData = await this.getImageFromDbDecoding.GetImageAsync(house.ImageId??0);
            }           

           

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