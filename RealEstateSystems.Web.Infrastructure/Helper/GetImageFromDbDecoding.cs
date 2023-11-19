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

        //public async Task<Image<Rgba32>> GetImageAsync(int imageId)
        //{
        //    var imageEntity = await dbContext.Images.FindAsync(imageId);

        //    if (imageEntity != null)
        //    {
        //        using (MemoryStream stream = new MemoryStream(imageEntity.Content))
        //        {
        //           
        //            var image = Image.Load<Rgba32>(stream);

        //            
        //            image.Mutate(x => x.Resize(new ResizeOptions
        //            {
        //                Size = new Size(200, 200),
        //                Mode = ResizeMode.Max
        //            }));

        //            return image;
        //        }
        //    }

        //    return null;
        //}
        public async Task<byte[]> GetImageAsync(int imageId)
        {
            var imageEntity = await dbContext.Images.FindAsync(imageId);

            if (imageEntity != null)
            {
                using (MemoryStream stream = new MemoryStream(imageEntity.Content))
                {
                   
                    var image = Image.Load<Rgba32>(stream);

                    
                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Size = new Size(200, 200),
                        Mode = ResizeMode.Max
                    }));

                   
                    using (MemoryStream encodedStream = new MemoryStream())
                    {
                        image.Save(encodedStream, new PngEncoder());
                        return encodedStream.ToArray();
                    }
                }
            }

            return null;
        }



    }
}
