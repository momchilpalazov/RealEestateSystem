using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;
using RealEstateSystem.Models.ViewModels.Stastic;
using RealEstateSystem.Services.Data.Interfaces;


namespace RealEstateSystem.Services.Data
{
    public class StatisticsService : IStatisticsInterface
    {
        private readonly RealEstateSystemDbContext dbContext;

        public StatisticsService(RealEstateSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task <StatisticServiceViewModel> GetStatisticsAsync()
        {

            var totalHouses = await this.dbContext.Hauses.CountAsync();
            var totalRents = await this.dbContext.Hauses.Where(t=>t.RenterId!=null).CountAsync();

            return new StatisticServiceViewModel
            {
                TotalHouses= totalHouses,
                TotalRents = totalRents
            };
           
        }
    }
}
