using RealEstateSystem.Data;
using SixLabors.ImageSharp;

using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Png;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystems.Web.Infrastructure.Helper
{
    public class GetImageFromDbDecoding
    {

        private readonly RealEstateSystemDbContext dbContext;

        public GetImageFromDbDecoding(RealEstateSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        
        public async Task<byte[]> GetImageAsync(int imageId)
        {
            var imageEntity = await dbContext.Images.FindAsync(imageId);

            if (imageEntity != null)
            {
               return imageEntity?.Content;
            }

            return null;
        }



    }
}
