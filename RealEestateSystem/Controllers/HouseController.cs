using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstateSystem.Models.ViewModels.House;
using RealEstateSystem.Services.Data.Interfaces;

namespace RealEstateSystem.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {

        private readonly IHouseInterface houseService;

        public HouseController(IHouseInterface houseService)
        {
            this.houseService = houseService;
        }





        [AllowAnonymous]
        [HttpGet]
        public IActionResult All()
        {
            
            return View(new AllHousesQueryModel());             
        
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
        public IActionResult AddPost(HouseFormModel house)
        {
            //only agents are allowed to add houses
            return RedirectToAction(nameof(Details));
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
