using HouseRealEstateSystem.Services.Mapping;


namespace RealEstateSystem.Models.ViewModels.Home
{
    public class IndexViewModel:IMapFrom<RealEstateSystem.Data.Models.House>
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public int? ImageId { get; set; }

        public byte[]? ImageData { get; set; }

        public string Address { get; set; } = null!;
    }
}
