﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;
using RealEstateSystem.Data.Models;
using RealEstateSystem.Models.ViewModels.Category;
using RealEstateSystem.Models.ViewModels.House;
using RealEstateSystem.Services.Data.Interfaces;
using RealEstateSystems.Web.Infrastructure.Helper;
using RealEstateSystems.Web.Infrastructure.HouseSorting;
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

        private readonly GetImageFromDbDecoding getImageFromDbDecoding;

        

        public HouseService(RealEstateSystemDbContext db,GetImageFromDbDecoding fromDbDecoding)
        {
            this.db = db;
            this.getImageFromDbDecoding = fromDbDecoding;
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
                Image = new Image
                {
                    Content = Encoding.ASCII.GetBytes(house.Images.ToString()),
                    ContentType = "image/jpeg"
                },
                AgentId = AgentId                

            };           

            
            
            
            await this.db.Hauses.AddAsync(houseEntity);
            await this.db.SaveChangesAsync();
            
        }

        

        public HouseQueryServiceModel GetAllHouse(int? categoryId=null  , string? searchTerm = null, HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1)
        {

            var housesQuery = this.db.Hauses.AsQueryable();

            if (categoryId!=0)
            {

                housesQuery = housesQuery.Where(n => n.CategoryId == categoryId.Value);


            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {

                housesQuery = housesQuery.Where(
                    s => s.Address.ToLower().Contains(searchTerm.ToLower()) ||
                    s.Title.ToLower().Contains(searchTerm.ToLower()) ||
                    s.Description.ToLower().Contains(searchTerm.ToLower())
                    );


            }


            housesQuery = sorting switch
            {
                HouseSorting.Price => housesQuery.OrderBy(h => h.PricePerMonth),
                HouseSorting.NotRentedFirst => housesQuery.OrderBy(r => r.RenterId != null).ThenByDescending(h => h.Id),
                _ => housesQuery.OrderByDescending(h => h.Id)


            };

            var houses = housesQuery
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .Select(h => new HouseServiceModel

                {
                    Id = h.Id,
                    Title = h.Title,
                    Address= h.Address,
                    PricePerMonth = h.PricePerMonth,                   
                    ImageUrl=h.ImageUrl,
                    ImagesId = h.Image.Id,
                    DecodedImage = getImageFromDbDecoding.GetImageAsync(h.Image.Id).Result,
                    IsRented =h.RenterId != null,


                }).ToList();

            var totalHouse = housesQuery.Count();

            return new HouseQueryServiceModel()
            {
                TotalHousesCount = totalHouse,
                Houses = houses


            };

            
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
