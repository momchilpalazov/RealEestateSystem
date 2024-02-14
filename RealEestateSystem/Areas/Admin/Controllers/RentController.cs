using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RealEstateSystem.Models.ViewModels.Rent;
using RealEstateSystem.Services.Data.Interfaces;
using RealEstateSystems.Web.Infrastructure.Helper;
using static RealEstateSystem.Areas.Admin.AdminConstants;

namespace RealEstateSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RentController : BaseAdminController
    {

        private readonly IRentInterface _rentInterface;

        private readonly IMemoryCache _cache;

        private readonly GetImageFromDbDecoding getImage;

        public RentController(IRentInterface rentInterface,GetImageFromDbDecoding getImage,IMemoryCache cache)
        {
            _rentInterface = rentInterface;
            _cache = cache;
            this.getImage = getImage;
        }

        [HttpGet]
        [Route("Admin/Rent/All")]
        public async Task <IActionResult> All()
        {

            var rents = _cache.Get<IEnumerable<RentServiceViewModel>>(RentCacheKey);

            if (rents == null)
            {
                rents = await _rentInterface.All();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                _cache.Set(RentCacheKey, rents, cacheEntryOptions);
            }           
            

            foreach (var rent in rents)
            {
                rent.ImageData = getImage.GetImageAsync(rent.ImageId).Result;
            }       

            return View(rents);
            
        }
    }
}
