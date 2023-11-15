using Microsoft.AspNetCore.Http;
using RealEstateSystem.Models.ViewModels.Category;
using RealEstateSystem.Models.ViewModels.House;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Services.Data.Interfaces
{
    public interface IHouseInterface
    {
        Task AddHouse(HouseFormModel house);
        ICollection<CategoryHouseServiceViewModel> GetCategories();
        Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses();
    }
}
