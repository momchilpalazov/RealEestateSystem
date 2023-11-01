using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;
using RealEstateSystem.Models.ViewModels.House;
using RealEstateSystem.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Services.Data
{
    public class HouseService : IHouseInterface
    {

        private readonly RealEstateSystemDbContext db;

        public HouseService(RealEstateSystemDbContext db)
        {
            this.db = db;
        }



        public async  Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses()
        {
            var houses= await this.db.Hauses.OrderByDescending(x=>x.Id).Take(3).Select(h=>new HouseIndexServiceModel

            {
                Id=h.Id,
                Title=h.Title,
                ImageUrl=h.ImageUrl
            
            }).ToListAsync();

            return houses;  
            
        }
    }
}
