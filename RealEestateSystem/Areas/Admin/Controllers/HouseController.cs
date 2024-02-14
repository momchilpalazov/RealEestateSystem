using Microsoft.AspNetCore.Mvc;
using RealEstateSystem.Areas.Admin.Models.House;
using RealEstateSystem.Services.Data.Interfaces;
using RealEstateSystems.Web.Infrastructure.Extensions;


namespace RealEstateSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HouseController:BaseAdminController
    {
        private readonly IHouseInterface _houseInterface;

        private readonly IAgentInterface _agentInterface;

        public HouseController(IHouseInterface houseInterface, IAgentInterface agentInterface)
        {
            _houseInterface = houseInterface;
            _agentInterface = agentInterface;
        }        


        public async Task<IActionResult> MineHouse()
        {
            var myHouses = new MyHousesViewModel();
            
            var userIdString =  User.GetId();
            var adminUserId = Guid.Parse(userIdString);
            myHouses.RentedHouses = await _houseInterface.GetAllHouseByUserId(adminUserId);

            string adminAgentId = await _agentInterface.GetAgentId(adminUserId);
            var adminAgent= Guid.Parse(adminAgentId);
            myHouses.AddedHouses = await _houseInterface.GetAllHouseByAgentId(adminAgent);

            return View(myHouses);
        }


    }
}
