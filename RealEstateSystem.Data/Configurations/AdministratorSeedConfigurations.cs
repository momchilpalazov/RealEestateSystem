using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using RealEstateSystem.Data.Models;
using static RealEstateSystem.Common.AdminRoleConstant;

namespace RealEstateSystem.Data.Configurations
{


    //public class AdministratorSeedConfigurations : IEntityTypeConfiguration<ApplicationUser>, IEntityTypeConfiguration<Agent>
    //{
    //    private ApplicationUser AdminUser;

    //    private Agent AdminAgent;

    //    public void Configure(EntityTypeBuilder<ApplicationUser> builder)

    //    {

    //        SeedUsers();
    //        builder.HasData(AdminUser);
            
                        

            

    //    }

    //    private ApplicationUser SeedUsers()

    //    {

    //        ApplicationUser adminUser = new ApplicationUser
    //        {

    //            Id = Guid.NewGuid(),
    //            FirstName = "Great",
    //            LastName = "Admin",
    //            Email = AdminEmail,
    //            NormalizedEmail = AdminEmail.ToUpper(),
    //            UserName = AdminEmail,
    //            NormalizedUserName = AdminEmail.ToUpper(),
    //            EmailConfirmed = false,
    //            LockoutEnabled = true,
    //            LockoutEnd = null,
    //            PhoneNumber = "+49888888888",
    //            PhoneNumberConfirmed = false,
    //            AccessFailedCount = 0,
    //            TwoFactorEnabled = false,
    //            PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "123456"),
    //            SecurityStamp = Guid.NewGuid().ToString().ToUpper(),
    //            ConcurrencyStamp = Guid.NewGuid().ToString(),

    //        };

    //        //ICollection<Agent> adminAgents = new List<Agent>();




    //        //Agent agent = new Agent

    //        //{

    //        //    Id = Guid.NewGuid(),

    //        //    PhoneNumber = "+49888888888",

    //        //    UserId = adminUser.Id,

    //        //    User = adminUser,

    //        //};

    //        //adminAgents.Add(agent);



    //        return adminUser;

    //    }

    //    public void Configure(EntityTypeBuilder<Agent> builder)
    //    {
    //        SeedAgent();
    //        builder.HasData(AdminAgent);
    //    }
    //    private Agent SeedAgent()

    //    {

    //        Agent agent = new Agent

    //        {

    //            Id = Guid.NewGuid(),

    //            PhoneNumber = "+49888888888",

    //            UserId = AdminUser.Id,

                

    //        };

    //        return agent;

    //    }

       
    //}

}


