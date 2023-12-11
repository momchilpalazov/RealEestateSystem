using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;
using RealEstateSystem.Data.Models;
using RealEstateSystem.Models.ViewModels.Agents;
using RealEstateSystem.Models.ViewModels.Category;
using RealEstateSystem.Models.ViewModels.House;
using RealEstateSystem.Services.Data.Interfaces;
using RealEstateSystems.Web.Infrastructure.Helper;
using RealEstateSystems.Web.Infrastructure.HouseSorting;

namespace RealEstateSystem.Services.Data
{
    public class HouseService : IHouseInterface
    {

        private readonly RealEstateSystemDbContext db;       

        private readonly GetImageFromDbDecoding getImageFromDbDecoding;

        private readonly DataBaseSaveImageHelper dataBaseSaveImageHelper;

        private readonly IServiceProvider serviceProvider;

       



        public HouseService(RealEstateSystemDbContext db,GetImageFromDbDecoding fromDbDecoding,IServiceProvider serviceProvider,DataBaseSaveImageHelper dataBaseSaveImageHelper )
        {
            this.db = db;
            this.getImageFromDbDecoding = fromDbDecoding;
            this.serviceProvider = serviceProvider;  
            this.dataBaseSaveImageHelper = dataBaseSaveImageHelper;
           
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
                ImageId = house.ImagesId,
                AgentId = AgentId                

            };       

            await this.db.Hauses.AddAsync(houseEntity);
            await this.db.SaveChangesAsync();
            
        }

        public async Task DeleteHouse(Guid houseId)
        {
           
            var house= await this.db.Hauses.FindAsync(houseId);

            if (house == null) 
            {
                return;                   
            
            }

            this.db.Hauses.Remove( house);
            await this.db.SaveChangesAsync();


        }

        public Task<HouseFormModel?> EditGetHouseById(Guid houseId)
        {
            var house=this.db.Hauses.Where(h=>h.Id==houseId).Select(h=> new HouseFormModel 
            {
                Id = h.Id,
                Title = h.Title,
                Address = h.Address,
                PricePerMonth = h.PricePerMonth,
                ImageUrl = h.ImageUrl,
                Description = h.Description,
                CategoryId = h.CategoryId,
                ImagesId = h.ImageId ?? 0,     
               
                Categories = this.db.Categories.Select(c => new CategoryHouseServiceViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList()
            }).FirstOrDefaultAsync();

            return house;        
            
            
        }

        public async Task EditSaveHouse(Guid Id, HouseEditFormModel house )
        {
            var AgentId = Guid.Parse("723b08eb-551c-4f19-a202-8b83cd44568f");

            var houseEntity = await this.db.Hauses.FindAsync(house.Id);

            houseEntity.Id = house.Id;
            houseEntity.Title = house.Title;
            houseEntity.Address = house.Address;
            houseEntity.PricePerMonth = house.PricePerMonth;
            houseEntity.Description = house.Description;
            houseEntity.CategoryId = house.CategoryId;
            houseEntity.ImageUrl = house.ImageUrl;
            houseEntity.ImageId = house.ImagesId;
            houseEntity.AgentId = AgentId;
            houseEntity.RenterId = null;
            Category? categories = db.Categories.Where(c => c.Id == house.CategoryId).Select(c => new Category

            {
                Id = c.Id,
                Name = c.Name
            }).FirstOrDefault();

            houseEntity.Category = categories;

            await this.db.SaveChangesAsync();

                    
        }

        public Task<bool> Exist(Guid Id)
        {
            return this.db.Hauses.AnyAsync(h => h.Id == Id);
           
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
                    IsRented =h.RenterId != null,
                    ImageData = this.getImageFromDbDecoding.GetImageAsync(h.ImageId??0).Result
                   


                }).ToList();

            var totalHouse = housesQuery.Count();

            return new HouseQueryServiceModel()
            {
                TotalHousesCount = totalHouse,
                Houses = houses

            };

            
        }

        public async Task<IEnumerable<HouseServiceModel>> GetAllHouseByAgentId(Guid agentId)
        {      

           var houses = await  this.db.Hauses.Where(a => a.AgentId == agentId).ToListAsync();

           return ProjectToModel(Task.FromResult(houses));
           
        }
        public async Task<IEnumerable<HouseServiceModel>> GetAllHouseByUserId(Guid userId)
        {
            var houses = await this.db.Hauses.Where(u => u.RenterId == userId).ToListAsync();

            return ProjectToModel(Task.FromResult(houses));

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

        public async Task<HouseDetailsViewModel?> GetHouseDetailsById(Guid agentId)
        {
            var houseDetailsById=await this.db.Hauses.Where(h=>h.Id==agentId).Select(h=>new HouseDetailsViewModel
            {
                Id = h.Id,
                Title = h.Title,
                Address = h.Address,
                PricePerMonth = h.PricePerMonth,
                ImageUrl = h.ImageUrl,
                IsRented = h.RenterId != null,
                ImageData = this.getImageFromDbDecoding.GetImageAsync(h.ImageId ?? 0).Result,
                Description = h.Description,
                CategoryName = h.Category.Name,
                AgentName = new AgentServiceViewModel
                {
                    
                    PhoneNumber = h.Agent.PhoneNumber,
                    Email = h.Agent.User.Email
                }
            }).FirstOrDefaultAsync();

            return houseDetailsById;       

        }

        public async Task<bool> HasAgentWithId(Guid agentId, Guid currentUserId)
        {
            var house=await this.db.Hauses.FindAsync(agentId);
            var agent = await this.db.Agents.Where(a => a.Id == house.AgentId).FirstOrDefaultAsync();

            if (agent==null)
            {
                return false;
            }
            
            if (agent.UserId!=currentUserId)
            {
                return false;
            }

            return true;    

        }

        public async Task<bool> Isrented(Guid houseId)
        {          
            

                var house=await this.db.Hauses.FindAsync(houseId);
                var result= house.RenterId != null;
                return result;            
            
        }

        public async Task<bool> IsRentedByUserId(Guid houseId, Guid userId)
        {
            var house = await this.db.Hauses.FindAsync(houseId);

            if (house==null)
            
            {
                return false;
            
            }

            if (house.RenterId != userId)
            {
                return false;
            }

            return true;

            
        }

        public async  Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses()
        {
            var houses = await this.db.Hauses.OrderByDescending(x => x.Id).Take(3).Select(h => new HouseIndexServiceModel
            {

                Id = h.Id,
                Title = h.Title,
                ImageUrl = h.ImageUrl,
                ImageId = h.ImageId,


            }).ToListAsync();

            return houses;

        }

        public async Task  Rent(Guid houseId, Guid userId)
        {
           var house= await this.db.Hauses.FindAsync(houseId);

            if (house==null)
            {
                return;
            }

            house.RenterId = userId;

            this.db.SaveChangesAsync();
        }

        private IEnumerable<HouseServiceModel> ProjectToModel(Task<List<House>> houses)
        {

            var housesModel = houses.Result.Select(h => new HouseServiceModel
            {
                Id = h.Id,
                Title = h.Title,
                Address = h.Address,
                PricePerMonth = h.PricePerMonth,
                ImageUrl = h.ImageUrl,
                IsRented = h.RenterId != null,
                ImageData = this.getImageFromDbDecoding.GetImageAsync(h.ImageId ?? 0).Result
            });

            return housesModel;

        }
    }
}
