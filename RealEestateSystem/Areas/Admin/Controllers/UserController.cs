using Microsoft.AspNetCore.Mvc;
using RealEstateSystem.Services.Data.Interfaces;

namespace RealEstateSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : BaseAdminController
    {

        private readonly IUserInterface _userInterface;

        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet]
        [Route("Admin/User/All")]
        public async Task<IActionResult> All()
        {
            var allUsers = await _userInterface.All();

            return View(allUsers);
        }
    }
}
