using Microsoft.AspNetCore.Http;
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

        public async Task<int> SaveImageToDataAsync(IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                try
                {
                    using (var stream = new MemoryStream())
                    {
                        await image.CopyToAsync(stream);
                        var imageEntity = new Image
                        {
                            Content = stream.ToArray(),
                            ContentType = image.ContentType
                        };

                        dbContext.Images.Add(imageEntity);
                        await dbContext.SaveChangesAsync();

                        return imageEntity.Id;

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return 0;
        }






    }
}
