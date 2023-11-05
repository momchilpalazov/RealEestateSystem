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

        public async Task<IEnumerable<CategoryHouseServiceViewModel>> CreateNewCategory(CategoryHouseServiceViewModel model)
        {
            var category = new Category
            {
                
                Name = model.Name
            };

            await this.db.Categories.AddAsync(category);
            await this.db.SaveChangesAsync();

            return await this.AllCategory();

            
        }

        public async Task<CategoryHouseServiceViewModel> DeleteCategory(CategoryHouseServiceViewModel model)
        {

            var deleteCategory = await this.db.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (deleteCategory != null)
            {
                this.db.Categories.Remove(deleteCategory);
                await this.db.SaveChangesAsync();
            }

            return model;
            


            
        }

        public async Task EditCategory(CategoryHouseServiceViewModel model)
        {

            var editCategory = await this.db.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (editCategory != null)
            {
              
                editCategory.Name = model.Name;
                await this.db.SaveChangesAsync();
            }



           
        }

        public async Task<CategoryHouseServiceViewModel?>FindCategoryById(CategoryHouseServiceViewModel model)
        {

            
            var categoryById = await this.db.Categories.Where(x => x.Id == model.Id).Select(x => new CategoryHouseServiceViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            return categoryById.FirstOrDefault();

            
            
        }
    }
}
