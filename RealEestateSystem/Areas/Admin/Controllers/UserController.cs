using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RealEstateSystem.Models.ViewModels.User;
using RealEstateSystem.Services.Data.Interfaces;
using static RealEstateSystem.Areas.Admin.AdminConstants;

namespace RealEstateSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : BaseAdminController
    {

        private readonly IUserInterface _userInterface;
        private readonly IMemoryCache _cache;

        public UserController(IUserInterface userInterface,IMemoryCache cache)
        {
            _userInterface = userInterface;
            _cache = cache;
        }

        [HttpGet]
        [Route("Admin/User/All")]
        public async Task<IActionResult> All()
        {
            var users= _cache.Get<IEnumerable<UserServiceViewModel>>(UserCacheKey); 

            if (users == null)
            {
                users = await _userInterface.All();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                _cache.Set(UserCacheKey, users, cacheEntryOptions);
            }            

            return View(users);
        }
    }
}
