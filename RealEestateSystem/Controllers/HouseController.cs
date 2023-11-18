﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstateSystem.Models.ViewModels.Category;
using RealEstateSystem.Models.ViewModels.House;
using RealEstateSystem.Services.Data.Interfaces;
using RealEstateSystems.Web.Infrastructure.Helper;

namespace RealEstateSystem.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {

        private readonly IHouseInterface houseService;

       private readonly DataBaseSaveImageHelper imageService;
       

        public HouseController(IHouseInterface houseService, DataBaseSaveImageHelper imageService)
        {
            this.houseService = houseService;
            this.imageService = imageService;
        }





        [AllowAnonymous]
        [HttpGet]
        public  IActionResult All([FromQuery] AllHousesQueryModel query )
        {
            
            var housesQuery =  this.houseService.GetAllHouse(
                query.Category,
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
        public IActionResult MineHouse()
        {
            return View(new AllHousesQueryModel());
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
             var Image = await this.imageService.SaveImageToDataAsync(image);

            await this.houseService.AddHouse(house);
            return RedirectToAction(nameof(All));

           
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
            return RedirectToAction(nameof(All));
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
