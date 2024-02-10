using RealEstateSystem.Models.ViewModels.House;

namespace RealEstateSystem.Areas.Admin.Models.House
{
    public class MyHousesViewModel
    {

        public IEnumerable<HouseServiceModel> AddedHouses { get; set; }=new List<HouseServiceModel>();

        public IEnumerable<HouseServiceModel> RentedHouses { get; set; }=new List<HouseServiceModel>();


    }
}
