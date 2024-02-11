using AutoMapper;
using HouseRealEstateSystem.Services.Mapping;
using RealEstateSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Models.ViewModels.User
{
    public class UserServiceViewModel : IMapFrom<RealEstateSystem.Data.Models.Agent>, IMapFrom<RealEstateSystem.Data.Models.ApplicationUser>, IHaveCustomMappings
    {

        public string Email { get; set; } = null!;
        
        public string FullName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<RealEstateSystem.Data.Models.Agent, UserServiceViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.User.FirstName + " " + x.User.LastName))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.User.Email));

            configuration.CreateMap<RealEstateSystem.Data.Models.ApplicationUser, UserServiceViewModel>()
               .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName))
               .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => string.Empty));

        }

       
    }
}
