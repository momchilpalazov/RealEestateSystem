using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateSystem.Models.ViewModels.Agents;

namespace RealEstateSystem.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
       
        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Become(BecomeAgentFormModel becomeAgent)
        {
            return RedirectToAction(nameof(HouseController.All),"Houses");
        }


    }
}
