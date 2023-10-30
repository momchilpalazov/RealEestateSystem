using Microsoft.AspNetCore.Mvc;

namespace RealEstateSystem.Controllers
{
    public class AgentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
