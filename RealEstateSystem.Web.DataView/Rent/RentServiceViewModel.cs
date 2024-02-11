

using AutoMapper;
using HouseRealEstateSystem.Services.Mapping;

namespace RealEstateSystem.Models.ViewModels.Rent
{
    public class RentServiceViewModel : IMapFrom<RealEstateSystem.Data.Models.House>, IHaveCustomMappings
    {


       
        public string HouseTite { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int ImageId { get; set; }
        public byte[]? ImageData { get; set; }

        public string AgentFullName { get; set; } = null!;  

        public string AgentEmail { get; set; } = null!; 

        public string RenterFullName { get; set; } = null!;

        public string RenterEmail { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {

            configuration.CreateMap<RealEstateSystem.Data.Models.House, RentServiceViewModel>()
                .ForMember(x => x.HouseTite, opt =>
                                   opt.MapFrom(x => x.Title))
                .ForMember(x => x.ImageUrl, opt =>
                                   opt.MapFrom(x => x.ImageUrl))               
                .ForMember(x => x.AgentFullName, opt =>
                                   opt.MapFrom(x => x.Agent.User.FirstName + " " + x.Agent.User.LastName))
                .ForMember(x => x.AgentEmail, opt =>
                                   opt.MapFrom(x => x.Agent.User.Email))
                .ForMember(x => x.RenterFullName, opt =>
                                   opt.MapFrom(x => x.Renter.FirstName + " " + x.Renter.LastName))
                .ForMember(x => x.RenterEmail, opt =>
                                   opt.MapFrom(x => x.Renter.Email));

           
        }
    }
}
