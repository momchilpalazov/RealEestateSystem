using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateSystem.Data.Models;

namespace RealEstateSystem.Models.ViewModels.House
{
    public class HouseServiceModel
    {

        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Address { get; set; }

        [DisplayName("Upload Image")]
        public int ImagesId { get; set; }

        public byte[]? DecodedImage { get; set; }
        //public Image<Rgba32>? DecodedImage { get; set; }        

        [DisplayName("Image Url")]
        public string? ImageUrl { get; set; }

        [DisplayName("Price Per Month")]
        public decimal PricePerMonth { get; set; }

        [DisplayName("Is Rented")]
        public bool IsRented { get; set; }

        


    }
}
