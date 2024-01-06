using RealEstateSystem.Data;
using RealEstateSystem.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Services.Data
{
    public class ApplicationUserService : IApplicationUserInterface
    {
        private readonly RealEstateSystemDbContext context;

        public ApplicationUserService(RealEstateSystemDbContext context)
        {
            this.context = context;
        }

        public async Task<string> GetFullUserNameAsync(Guid userId)
        {
            var user =await this.context.Users.FindAsync(userId);

            if (string.IsNullOrEmpty(user.FirstName)||string.IsNullOrEmpty(user.LastName))
            {
                return null;

            
            }

            
            return user.FirstName + " " + user.LastName;
        }
    }
}
