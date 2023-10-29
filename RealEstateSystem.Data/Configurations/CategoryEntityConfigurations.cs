using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Data.Configurations
{
    public class CategoryEntityConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(GetCategories());   
        }


        private Category[] GetCategories()
        {

            ICollection<Category> categories = new List<Category>();

            Category category;


            category = new Category
            {
                Id = 1,
                Name = "Cottage"

            };
            categories.Add(category);

            category=new Category
            {
                Id = 2,
                Name = "Single-Family"

            };
            categories.Add(category);

            category = new Category
            {
                Id = 3,
                Name = "Duplex"

            };
            categories.Add(category);

           return categories.ToArray();
        }

    }
}
