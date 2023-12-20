using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateSystem.Models.ViewModels.Stastic;
using RealEstateSystem.Services.Data.Interfaces;

namespace RealEstateSystem.WebApi.Controllers
{
    [Route("api/statistics")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticsInterface statisticsInterface;

        public StatisticsApiController(IStatisticsInterface statisticsInterface)
        {
            this.statisticsInterface = statisticsInterface;
        }
        

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type=typeof(StatisticServiceViewModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStaticResult()
        {

            try
            {
               StatisticServiceViewModel result = await this.statisticsInterface.GetStatisticsAsync();
                return Ok(result);
            }
            catch (Exception )
            {
                return BadRequest();
            }


            

        }

    }
}
