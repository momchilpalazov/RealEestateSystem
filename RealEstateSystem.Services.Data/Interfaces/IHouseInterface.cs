using Microsoft.AspNetCore.Http;
using RealEstateSystem.Models.ViewModels.Category;
using RealEstateSystem.Models.ViewModels.House;
using RealEstateSystems.Web.Infrastructure.HouseSorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Services.Data.Interfaces
{
    public interface IHouseInterface
    {
        Task AddHouse(HouseFormModel house,Guid agentId);
        HouseQueryServiceModel GetAllHouse(int? categoryId=null,string? searchTerm=null,HouseSorting sorting= HouseSorting.Newest,int currentPage=1,int housesPerPage=1);
        ICollection<CategoryHouseServiceViewModel> GetCategories();
        Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses();

        Task<IEnumerable<HouseServiceModel>>GetAllHouseByAgentId(Guid agentId);

        Task<IEnumerable<HouseServiceModel>>GetAllHouseByUserId(Guid userId);

        Task<HouseDetailsViewModel?> GetHouseDetailsById(Guid agentId);

        Task<bool> Exist(Guid agentId);      

        Task<HouseFormModel?> EditGetHouseById(Guid houseId);

        Task EditSaveHouse(Guid Id,HouseEditFormModel house,Guid agentId);
       
        Task<bool> HasAgentWithId(Guid agentId,Guid currentUserId);

        Task DeleteHouse(Guid houseId);

        Task<bool>Isrented(Guid houseId);

        Task<bool> IsRentedByUserId (Guid houseId,Guid userId);

        Task Rent(Guid houseId,Guid userId);

        Task Leave(Guid houseId);
        

    }
}
