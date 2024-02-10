using Microsoft.AspNetCore.Mvc;
using RealEstateSystem.Services.Data.Interfaces;
using RealEstateSystems.Web.Infrastructure.Helper;
using static RealEstateSystem.Common.AdminRoleConstant;


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

            if (User.IsInRole(AdminRoleName))
            {
               return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

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
        public  IActionResult Error(int statusCode)
        {

            if ( statusCode == 400||statusCode==404)            
            {
                
                return  this.View("Error400");          
            
            
            }

            if (statusCode == 401)
            {
               
                return this.View("Error401");
            }
                

            return  View();
        }
    }
}