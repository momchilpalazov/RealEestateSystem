using AutoMapper;
using HouseRealEstateSystem.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;
using RealEstateSystem.Data.Models;
using RealEstateSystem.Models.ViewModels.Agents;
using RealEstateSystem.Models.ViewModels.Category;
using RealEstateSystem.Models.ViewModels.Home;
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

        private readonly IApplicationUserInterface applicationUser;

       



        public HouseService(RealEstateSystemDbContext db,GetImageFromDbDecoding fromDbDecoding,
            IServiceProvider serviceProvider,DataBaseSaveImageHelper dataBaseSaveImageHelper,
         IApplicationUserInterface applicationUser )
        {
            this.db = db;
            this.getImageFromDbDecoding = fromDbDecoding;
            this.serviceProvider = serviceProvider;  
            this.dataBaseSaveImageHelper = dataBaseSaveImageHelper;
            this.applicationUser = applicationUser;
            
           
        }

        public async Task AddHouse(HouseFormModel house,Guid agentId )
        {
             
            House newHouse= AutoMapperConfig.MapperInstance.Map<House>(house);
            newHouse.ImageId = house.ImagesId;
            newHouse.AgentId = agentId;
             

            await this.db.Hauses.AddAsync(newHouse);
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

        public async Task EditSaveHouse(Guid Id, HouseEditFormModel house,Guid agentId )
        {
            

            var houseEntity = await this.db.Hauses.FindAsync(house.Id);

            houseEntity.Id = house.Id;
            houseEntity.Title = house.Title;
            houseEntity.Address = house.Address;
            houseEntity.PricePerMonth = house.PricePerMonth;
            houseEntity.Description = house.Description;
            houseEntity.CategoryId = house.CategoryId;
            houseEntity.ImageUrl = house.ImageUrl;
            houseEntity.ImageId = house.ImagesId;
            houseEntity.AgentId = agentId;
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

           var houses = await  this.db.Hauses.Where(a => a.Agent.Id == agentId).ToListAsync();

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
                    
                    FullName = this.applicationUser.GetFullUserNameAsync(h.Agent.UserId).Result,
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

        public async  Task<IEnumerable<IndexViewModel>> LastThreeHouses()
        {
            var houses = await this.db.Hauses.OrderByDescending(x => x.Id).
                Take(3).
                To<IndexViewModel>().ToListAsync();

            return houses;

        }

        public async Task Leave(Guid houseId)
        {
            var house = await this.db.Hauses.FindAsync(houseId);

            if (house==null)
            {
                return;
            }

            house.RenterId = null;
            await db.SaveChangesAsync();
            
        }

        public async Task  Rent(Guid houseId, Guid userId)
        {
           var house= await this.db.Hauses.FindAsync(houseId);

            if (house==null)
            {
                return;
            }

            house.RenterId = userId;

            await this.db.SaveChangesAsync();
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
