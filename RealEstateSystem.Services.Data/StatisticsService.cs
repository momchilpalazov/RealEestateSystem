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


        public StatisticServiceViewModel GetStatistics()
        {

            var totalHouses = this.dbContext.Hauses.Count();
            var totalRents = this.dbContext.Hauses.Where(t=>t.RenterId!=null).Count();

            return new StatisticServiceViewModel
            {
                TotalHouses= totalHouses,
                TotalRents = totalRents

            };

           
        }
    }
}
