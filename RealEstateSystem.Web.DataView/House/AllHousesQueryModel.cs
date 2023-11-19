using RealEstateSystem.Models.ViewModels.Category;
using RealEstateSystems.Web.Infrastructure.HouseSorting;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Models.ViewModels.House
{
    public class AllHousesQueryModel
    {
        public const int HousesPerPage = 3;

        public int CategoryId { get; init; } 

        public string SearchTerm { get; init; } = null!;

        public HouseSorting Sorting { get; init; }

        public int CuurentPage { get; init; } = 1;

        public int TotalHouseCount { get; set; }

       

        public IEnumerable<HouseServiceModel> Houses { get; set; } = new List<HouseServiceModel>();

        public IEnumerable<CategoryHouseServiceViewModel> Categories { get; set; } = new List<CategoryHouseServiceViewModel>();
       


    }
}
