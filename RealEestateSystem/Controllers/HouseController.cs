﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstateSystem.Data;
using RealEstateSystem.Data.Models;
using RealEstateSystem.Models.ViewModels.Category;
using RealEstateSystem.Models.ViewModels.House;
using RealEstateSystem.Services.Data;
using RealEstateSystem.Services.Data.Interfaces;
using RealEstateSystems.Web.Infrastructure.Extensions;
using RealEstateSystems.Web.Infrastructure.Helper;

namespace RealEstateSystem.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {

        private readonly IHouseInterface houseService;

        private readonly DataBaseSaveImageHelper imageService;

        private readonly RealEstateSystemDbContext dbContext;

        private readonly GetImageFromDbDecoding getImageFromDbDecoding;

        private readonly IAgentInterface agent;


       

        public HouseController(IHouseInterface houseService, DataBaseSaveImageHelper imageService, RealEstateSystemDbContext dbContext, GetImageFromDbDecoding getImageFromDbDecoding,IAgentInterface agent)
        {
            this.houseService = houseService;
            this.imageService = imageService;
            this.dbContext = dbContext;
            this.getImageFromDbDecoding = getImageFromDbDecoding;
            this.agent = agent;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AllAsync([FromQuery] AllHousesQueryModel query,int imageId )
        {
            
            var housesQuery =  this.houseService.GetAllHouse(
                query.CategoryId,
                query.SearchTerm,
                query.Sorting,
                query.CuurentPage,                
                AllHousesQueryModel.HousesPerPage);

            query.TotalHouseCount = housesQuery.TotalHousesCount;
            query.Houses = housesQuery.Houses;

            var categoriesList = this.houseService.GetCategories();    
            query.Categories = categoriesList;   
            return View(query);
                        
        
        }        


        [AllowAnonymous]
        [HttpGet]
        public async Task <IActionResult> MineHouse()
        {
            IEnumerable<HouseServiceModel> myHouses = null;

            var userId = this.User.GetId(); 

            if (await agent.ExistById(Guid.Parse(userId)))
            {
                var currentAgent = await agent.GetAgentId(Guid.Parse(userId));

                myHouses=await this.houseService.GetAllHouseByAgentId(Guid.Parse(currentAgent));                

               
            }
            else
            {
                myHouses = await this.houseService.GetAllHouseByUserId(Guid.Parse(userId));
            }          


            return View(myHouses);
           
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(new HouseDetailsViewModel());
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Add(HouseFormModel model)
        {
            var categoriesList = this.houseService.GetCategories();
            model.Categories = categoriesList;

            //only agents are allowed to add houses


            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddPost(HouseFormModel house,IFormFile image)
        {
            //only agents are allowed to add houses

            if (ModelState.IsValid)
            {
                return View(house);
               
            }


           
            house.Categories= this.houseService.GetCategories();

            if (image!=null)
            {
                var Image = await this.imageService.SaveImageToDataAsync(image);

                if (Image.HasValue)
                {
                    house.ImagesId = Image.Value; 
                }

            }

           

            await this.houseService.AddHouse(house);
            return RedirectToAction("All");

           
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(new HouseFormModel());
        }

        
        [HttpPost]
        public IActionResult Edit(int id, HouseFormModel house)
        {
            return RedirectToAction(nameof(Details));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new HouseDetailsViewModel());
        }

       
        [HttpPost]
        public IActionResult Delete(HouseDetailsViewModel house)
        {
            return RedirectToAction(nameof(AllAsync));
        }


        [HttpPost]
        public IActionResult Rent(int id)
        {
            return RedirectToAction(nameof(MineHouse));
        }

        [HttpPost]
        public IActionResult Leave(int id)
        {
            return RedirectToAction(nameof(MineHouse));
        }

       
    }
}
