using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;
using RealEstateSystem.Data.Models;
using RealEstateSystem.Models.ViewModels.Category;
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

        public async Task AddHouse(HouseFormModel house )
        {
            var AgentId = Guid.Parse("723b08eb-551c-4f19-a202-8b83cd44568f");

            var houseEntity = new House
            {
                Title =  house.Title,
                Description = house.Description,
                PricePerMonth = house.PricePerMonth,               
                Address = house.Address,                              
                CategoryId = house.CategoryId,
                ImageUrl = house.ImageUrl,
                Images = new Image
                {
                    Content = Encoding.ASCII.GetBytes(house.Images.ToString()),
                    ContentType = "image/jpeg"
                },
                AgentId = AgentId                

            };           

            
            
            
            await this.db.Hauses.AddAsync(houseEntity);
            await this.db.SaveChangesAsync();
            
        }

        public ICollection<CategoryHouseServiceViewModel> GetCategories()
        {

            var categories = this.db.Categories.Select(x => new CategoryHouseServiceViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return categories;
            
        }

        public async  Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses()
        {
            var houses= await this.db.Hauses.OrderByDescending(x=>x.Id).Take(7).Select(h=>new HouseIndexServiceModel

            {
                Id=h.Id,
                Title=h.Title,
                ImageUrl=h.ImageUrl
            
            }).ToListAsync();

            return houses;  
            
        }
    }
}
