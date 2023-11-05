using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;
using RealEstateSystem.Models.ViewModels.Category;
using RealEstateSystem.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Services.Data
{
    public class CategoryService : ICategoryInterface
    {

        private readonly RealEstateSystemDbContext db;

        public CategoryService(RealEstateSystemDbContext db)
        {
            this.db = db;
        }



        public async Task<IEnumerable<CategoryHouseServiceViewModel>> AllCategory()
        {
            var allCategory=this.db.Categories.Select(x=>new CategoryHouseServiceViewModel
            {
                Id=x.Id,
                Name=x.Name
            }).ToListAsync();

            return await allCategory;

            
        }
    }
}
