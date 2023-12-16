using Microsoft.AspNetCore.Mvc;
using RealEstateSystem.Models.ViewModels.Stastic;
using RealEstateSystem.Services.Data.Interfaces;

namespace RealEstateSystem.Controllers.Api
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticApiController:ControllerBase
    {

        private readonly IStatisticsInterface statisticsInterface;

        public StatisticApiController(IStatisticsInterface statisticsInterface)
        {
            this.statisticsInterface = statisticsInterface;
        }

        [HttpGet]
        public StatisticServiceViewModel GetStaticResult()
        {
            
            return statisticsInterface.GetStatistics();        
        
        }



    }
}
