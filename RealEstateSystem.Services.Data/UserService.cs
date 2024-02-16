using AutoMapper;
using HouseRealEstateSystem.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;
using RealEstateSystem.Models.ViewModels.User;
using RealEstateSystem.Services.Data.Interfaces;


namespace RealEstateSystem.Services.Data
{
    public class UserService : IUserInterface
    {

        private readonly RealEstateSystemDbContext db;

        private readonly IMapper mapper;

        public UserService(RealEstateSystemDbContext db)
        {
            this.db = db;
            
        }


        public async Task<IEnumerable<UserServiceViewModel>> All()
        {

            var allUsers= new List<UserServiceViewModel>();

            var agent= await this.db.Agents.Include(x => x.User).To<UserServiceViewModel>().ToListAsync();

            allUsers.AddRange(agent);

            var usresClient = await this.db.Users.Where(u => !db.Agents.Any(a => a.UserId == u.Id)).To<UserServiceViewModel>().ToListAsync();

            allUsers.AddRange(usresClient);

            return allUsers;
            
        }

        public async Task<string> UserFullName(Guid userId)
        {

            var user = await this.db.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user==null)
            {
                throw new ArgumentNullException("User not found");
            }

            return $"{user.FirstName} {user.LastName}";       

            
        }

        public async Task<bool> UserHasRent(Guid userId)
        {
            var hasRent = await this.db.Hauses.AnyAsync(x => x.RenterId == userId);

            return hasRent;
        }
    }
}
