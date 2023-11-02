using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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




       
        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]        
        public async Task <IActionResult> BecomeAgent()
        {


            var userId = this.User.GetId();

            if (userId != null)
            {
                var isDealer = await this.agentInterface.ExistById(Guid.Parse(userId));

                if (!isDealer)
                {
                    return View("Agent Error", "There was an error processing your request as a dealer.");
                }


            }         
            
            
            return RedirectToAction("Index", "Home");


        }


    }
}
