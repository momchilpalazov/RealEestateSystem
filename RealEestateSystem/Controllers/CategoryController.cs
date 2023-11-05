﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Create()
        {
        
        }

       
    }
}
