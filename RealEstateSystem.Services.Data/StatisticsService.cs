using RealEstateSystem.Data;
using RealEstateSystem.Models.ViewModels.Stastic;
using RealEstateSystem.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Services.Data
{
    public class StatisticsService : IStatisticsInterface
    {
        private readonly RealEstateSystemDbContext dbContext;

        public StatisticsService(RealEstateSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public StatisticServiceModelViewModel GetStatistics()
        {

            var totalHouses = this.dbContext.Hauses.Count();
            var totalRents = this.dbContext.Hauses.Where(t=>t.RenterId!=null).Count();

            return new StatisticServiceModelViewModel
            {
                TotalHouses= totalHouses,
                TotalRents = totalRents

            };

           
        }
    }
}
