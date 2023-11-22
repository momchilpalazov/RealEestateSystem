using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;
using RealEstateSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Image = RealEstateSystem.Data.Models.Image;

namespace RealEstateSystems.Web.Infrastructure.Helper
{
    public class DataBaseSaveImageHelper
    {

        private readonly RealEstateSystemDbContext dbContext;

        public DataBaseSaveImageHelper(RealEstateSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int?> SaveImageToDataAsync(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (MemoryStream memoryStream =  new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);

                    var image = new Image
                    {
                        Content = memoryStream.ToArray(),
                        ContentType = imageFile.ContentType
                        
                    };

                    dbContext.Images.Add(image);
                    await dbContext.SaveChangesAsync();

                    return image.Id;
                }
            }

            return null; 
        }


    }
}
