using Microsoft.AspNetCore.Authorization;
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
        public  IActionResult AllAsync([FromQuery] AllHousesQueryModel query,int imageId )
        {
            
            var housesQuery =   this.houseService.GetAllHouse(
                query.CategoryId,
                query.SearchTerm,
                query.Sorting,
                query.CuurentPage,                
                AllHousesQueryModel.HousesPerPage);

            query.TotalHouseCount = housesQuery.TotalHousesCount;
            query.Houses = housesQuery.Houses;

            var categoriesList =  this.houseService.GetCategories();    
            query.Categories = categoriesList;   
            return  View(query);
                        
        
        }        


        [AllowAnonymous]
        [HttpGet]
        public async Task <IActionResult> MineHouse()
        {
            IEnumerable<HouseServiceModel>? myHouses = null;

            var userId = this.User.GetId(); 


            if (userId == null)

            {
                return RedirectToAction("Login", "Account");
            }

            

            if (userId != null)
            {
                if (await agent.ExistById(Guid.Parse(userId)))
                {
                    var currentAgent = await agent.GetAgentId(Guid.Parse(userId));

                    myHouses = await this.houseService.GetAllHouseByAgentId(Guid.Parse(currentAgent));


                }
                else
                {
                    myHouses = await this.houseService.GetAllHouseByUserId(Guid.Parse(userId));
                }


            }               


            return View(myHouses);
           
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            if (await houseService.Exist(id)==false)
            {
                return BadRequest();

            }

            var house= await this.houseService.GetHouseDetailsById(id);

            return View(house);            
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
        [ActionName("AddPost")]
        public async Task<IActionResult> AddPost(HouseFormModel house,IFormFile image)
        {
            //only agents are allowed to add houses

            if (!ModelState.IsValid)
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
        public async Task<IActionResult> Edit(Guid id)
        {

            if (await houseService.Exist(id) == false)
            {
                return Unauthorized();

            }

            if (await houseService.HasAgentWithId(id, new Guid(this.User.GetId())) == false)
            {
                return BadRequest();    

            }
            


            var house = await this.houseService.EditGetHouseById(id);

            if(house.ImagesId!=null)
            {

                house.ImageData = this.getImageFromDbDecoding.GetImageAsync(house.ImagesId ?? 0).Result;            
            
            }

            return View(house);
           
        }

        
        [HttpPost]
        public async Task <IActionResult> EditPost(Guid Id, HouseEditFormModel house,IFormFile image)
        {

            if (await houseService.Exist(Id) == false)
            {
                return View();

            }

            if (await houseService.HasAgentWithId(Id, new Guid(this.User.GetId())) == false)
            {
                return Unauthorized();

            }

            if (!ModelState.IsValid)
            {
                return View(house);

            }

            if (image != null)
            {
                var imageEdit = await this.imageService.SaveImageToDataAsync(image);

                if (imageEdit.HasValue)
                {
                    house.ImagesId = imageEdit.Value;
                }

            }  

            await this.houseService.EditSaveHouse(Id,house);
            return RedirectToAction("All");
            
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task <IActionResult> Delete(Guid id)
        {
            if (await houseService.Exist(id) == false)
            {
                return BadRequest();

            }

            if (await houseService.HasAgentWithId(id, new Guid(this.User.GetId())) == false)
            {
                return Unauthorized();

            }

            var house = await this.houseService.EditGetHouseById(id);
           

            var modelHouse = new HouseDeleteDetailsViewModel
            {
                Id = house.Id,
                Title = house.Title,
                Address = house.Address,
                ImageUrl = house.ImageUrl,
                ImagesId = house.ImagesId,
                ImageData=this.getImageFromDbDecoding.GetImageAsync(house.ImagesId ?? 0).Result                
                
            };         

             return View(modelHouse);              
        }

       
        [HttpPost]
        public async Task <IActionResult> Delete(HouseDeleteDetailsViewModel house)
        {

            if (await houseService.Exist(house.Id) == false)
            {
                return BadRequest();

            }

            if (await houseService.HasAgentWithId(house.Id, new Guid(this.User.GetId())) == false)
            {
                return Unauthorized();

            }

            await this.houseService.DeleteHouse(house.Id);

            return RedirectToAction("All");
        }


        [HttpPost]
        public async Task <IActionResult> Rent(Guid id)
        {

            if (await houseService.Exist(id) == false)
            {
                return BadRequest();

            }

            if (await agent.ExistById(new Guid(User.GetId())))
            {
                return Unauthorized();

            }



            if (await houseService.Isrented(id))
            {
                return BadRequest();

            }

            houseService.Rent(id, new Guid(this.User.GetId()));

            return RedirectToAction(nameof(MineHouse));
            
        }

        [HttpPost]
        public IActionResult Leave(int id)
        {
            return RedirectToAction(nameof(MineHouse));
        }

       
    }
}
