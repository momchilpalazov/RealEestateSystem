using RealEstateSystem.Models.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Services.Data.Interfaces
{
    public interface ICategoryInterface
    {
        Task<IEnumerable<CategoryHouseServiceViewModel>> AllCategory();
        Task<IEnumerable<CategoryHouseServiceViewModel>> CreateNewCategory(CategoryHouseServiceViewModel model);
        Task <CategoryHouseServiceViewModel>DeleteCategory(CategoryHouseServiceViewModel model);
        Task EditCategory(CategoryHouseServiceViewModel model);
        Task<CategoryHouseServiceViewModel?>FindCategoryById(CategoryHouseServiceViewModel model);
    }
}
