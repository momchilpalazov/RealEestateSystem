using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;
using RealEstateSystem.Data.Models;
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

        public async Task<IEnumerable<CategoryHouseServiceViewModel>> CreateCategory(CategoryHouseServiceViewModel model)
        {
            var category = new Category
            {
                
                Name = model.Name
            };

            await this.db.Categories.AddAsync(category);
            await this.db.SaveChangesAsync();

            return await this.AllCategory();

            
        }
    }
}
