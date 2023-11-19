using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateSystem.Models.ViewModels.Agents;
using RealEstateSystem.Services.Data.Interfaces;
using RealEstateSystems.Web.Infrastructure.Extensions;



namespace RealEstateSystem.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {

        private readonly IAgentInterface agentInterface;

        public AgentController(IAgentInterface agentInterface)
        {
            this.agentInterface = agentInterface;
        }
       
        public async Task <IActionResult> Become()
        {

            var userId = this.User.GetId();

            if (userId != null)
            {
                var isAgent = await this.agentInterface.ExistById(Guid.Parse(userId));

                if (!isAgent)
                {
                    return View("Agent Error", "There was an error processing your request as a dealer.");
                }


            }

            return View();
        }

        [HttpPost]        
        public async Task <IActionResult> BecomeAgent(BecomeAgentFormModel becomeAgent)
        {


            var userId = this.User.GetId();

            if (userId != null)
            {
                var isAgent = await this.agentInterface.ExistById(Guid.Parse(userId));

                if (!isAgent)
                {
                    return View("Agent Error", "There was an error processing your request as a dealer.");
                }


            }
            
            if (await agentInterface.ExistUserByPhoneNumber(becomeAgent.PhoneNumber))
            {
                ModelState.AddModelError(nameof(becomeAgent.PhoneNumber), "This phone number is already in use. Enter another one. ");
            }

            if (await agentInterface.UserHasRent(Guid.Parse(userId)))
            {
                ModelState.AddModelError("Error","You can't be a dealer because you have a rent.");
            }
            

            if (!ModelState.IsValid)
            {
                return View(nameof(Become));
            }

            await agentInterface.Create(Guid.Parse(userId), becomeAgent.PhoneNumber);
            
            return RedirectToAction(nameof(HouseController.AllAsync), "House");


        }


    }
}
