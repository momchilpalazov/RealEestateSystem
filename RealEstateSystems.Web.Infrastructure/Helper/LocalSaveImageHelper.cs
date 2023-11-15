using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystems.Web.Infrastructure.Helper
{
    public class LocalSaveImageHelper
    {
        private readonly IWebHostEnvironment hostingEnvironment;

        public LocalSaveImageHelper(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }


        public async Task<string> SaveImageAsync(IFormFile image)
        {
            string uploadsFolder =  Path.Combine(hostingEnvironment.WebRootPath, "images");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            if (image != null && image.Length > 0)
            {

                try
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                       await image.CopyToAsync(fileStream);
                    }

                    return await Task.FromResult(uniqueFileName);
                }
                catch (Exception)
                {

                    throw;
                }


            }

            return await Task.FromResult(string.Empty);


        }


    }
}
