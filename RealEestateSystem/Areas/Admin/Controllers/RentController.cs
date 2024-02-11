using Microsoft.AspNetCore.Mvc;
using RealEstateSystem.Models.ViewModels.Rent;
using RealEstateSystem.Services.Data.Interfaces;
using RealEstateSystems.Web.Infrastructure.Helper;

namespace RealEstateSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RentController : BaseAdminController
    {

        private readonly IRentInterface _rentInterface;

        private readonly GetImageFromDbDecoding getImage;

        public RentController(IRentInterface rentInterface,GetImageFromDbDecoding getImage)
        {
            _rentInterface = rentInterface;
            this.getImage = getImage;
        }

        [HttpGet]
        [Route("Admin/Rent/All")]
        public async Task <IActionResult> All()
        {
            
            var allRents = await _rentInterface.All();

            foreach (var rent in allRents)
            {
                rent.ImageData = getImage.GetImageAsync(rent.ImageId).Result;
            }       

            return View(allRents);
            
        }
    }
}
