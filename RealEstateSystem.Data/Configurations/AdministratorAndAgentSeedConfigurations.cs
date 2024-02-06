using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateSystem.Data.Models;
using static RealEstateSystem.Common.AdminRoleConstant;

namespace RealEstateSystem.Data.Configurations
{
    public class AdministratorAndAgentSeedConfigurations : IEntityTypeConfiguration<ApplicationUser>, IEntityTypeConfiguration<Agent>   
    {


        private ApplicationUser AdminUser;

        private Guid adminUserId = Guid.Parse("41142a71-27bb-410b-91f0-020b1c334de9");

        

        public AdministratorAndAgentSeedConfigurations()
        {
                AdminUser = new ApplicationUser();
        }

        

        
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(CreateUser());     

        }

        public void Configure(EntityTypeBuilder<Agent> builder)
        {
                        
           builder.HasData(CreateAgent());

        }
        
        private ApplicationUser CreateUser()
        {

            AdminUser = new ApplicationUser()
            {
                Id = adminUserId,
                FirstName = "Great",
                LastName = "Admin",
                Email = AdminEmail,
                NormalizedEmail = AdminEmail.ToUpper(),
                UserName = AdminEmail,
                AccessFailedCount = 0,               
                SecurityStamp = Guid.NewGuid().ToString().ToUpper(),
                NormalizedUserName = AdminEmail.ToUpper(),
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "123456")

            };

            return AdminUser;            
        
        }


        private Agent CreateAgent()
        {
            return new Agent
            {

                Id = Guid.NewGuid(),
                PhoneNumber = "+49888888888",
                UserId =adminUserId,
            };
        }


    }


}

