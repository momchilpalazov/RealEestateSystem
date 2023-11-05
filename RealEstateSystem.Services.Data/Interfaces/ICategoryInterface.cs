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
    }
}
