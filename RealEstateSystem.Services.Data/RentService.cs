using AutoMapper;
using HouseRealEstateSystem.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;
using RealEstateSystem.Models.ViewModels.Rent;
using RealEstateSystem.Services.Data.Interfaces;
using RealEstateSystems.Web.Infrastructure.Helper;

namespace RealEstateSystem.Services.Data
{
    public class RentService : IRentInterface
    {

        private readonly RealEstateSystemDbContext db;

        private readonly GetImageFromDbDecoding getImageFromDbDecoding;

        private readonly IMapper mapper;

        public RentService(RealEstateSystemDbContext db,GetImageFromDbDecoding getImage)
        {
            this.db = db;
            this.getImageFromDbDecoding = getImage;
        }


        public async Task<IEnumerable<RentServiceViewModel>> All()
        {
            
            var allRents=new List<RentServiceViewModel>();

            var rents= await this.db.Hauses
                .Include(h=>h.Agent.User)
                .Include(h=>h.Renter)
                .Where(h=>h.RenterId!=null)
                .To<RentServiceViewModel>()
                .ToListAsync();

            allRents.AddRange(rents);    
                       
            return allRents;
            
        }
    }
}
