using Microsoft.AspNetCore.Mvc;
using RealEstateSystem.Models.ViewModels.Category;
using RealEstateSystem.Services.Data.Interfaces;

namespace RealEstateSystem.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryInterface categoryService;

        public CategoryController(ICategoryInterface categoryService)
        {
            this.categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> AllCategory()
        {

              var allCategory = await this.categoryService.AllCategory();

            return this.View(allCategory);

            
            
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            return this.View();
        
        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryHouseServiceViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.categoryService.CreateNewCategory(model);

            return this.RedirectToAction("AllCategory", "Category");
        }


        [HttpGet]
        public async Task <IActionResult> Edit(CategoryHouseServiceViewModel model)
        {

            var categoryById = await this.categoryService.FindCategoryById(model);

            return this.View(categoryById);
            
                       
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(CategoryHouseServiceViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.categoryService.EditCategory(model);

            return this.RedirectToAction("AllCategory", "Category");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(CategoryHouseServiceViewModel model)
        {

            var categoryById = await this.categoryService.FindCategoryById(model);

            return this.View(categoryById);
        }


        [HttpPost]
        public async Task<IActionResult> DeletePost(CategoryHouseServiceViewModel model)
        {
            
            await this.categoryService.DeleteCategory(model);

            return this.RedirectToAction("AllCategory", "Category");
        }
       
    }
}
