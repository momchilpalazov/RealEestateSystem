using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateSystem.Data.Models;
using static RealEstateSystem.Common.AdminRoleConstant;

namespace RealEstateSystem.Data.Configurations
{
    public class AdministratorAndAgentSeedConfigurations :  IEntityTypeConfiguration<Agent>
    {
        private Agent? AdminAgent;

        private ApplicationUser? AdminUser;

        public void Configure(EntityTypeBuilder<Agent> builder)
        {

            //builder.HasData(AdminAgent);

            AdminAgent = new Agent
            {

                    Id = Guid.NewGuid(),
                    PhoneNumber = "+49888888888",
                    UserId = Guid.Parse("2ac68933-68b1-431e-8a11-09cf34d94a85"),               


                };
            }
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {

            //AdminUser = SeedUser();
            //builder.HasData(AdminUser);



            //builder.HasData(SeedUser());

            //builder.HasData(SeedAgents());

            //SeedUser();

            //builder.HasData(AdminAgent);

        }

        

        //public void Configure(EntityTypeBuilder<Agent> builder)
        //{
        //    builder.HasData(AdminAgent);

        //    AdminAgent = new Agent
        //    {

        //        Id = Guid.NewGuid(),
        //        PhoneNumber = "+49888888888",
        //        UserId = Guid.Parse("2ac68933-68b1-431e-8a11-09cf34d94a85"),               


        //    };

        //    //return AdminUser;
        //}

        //private ApplicationUser SeedUser()

        //{          



        //    //AdminUser =new ApplicationUser()

        //    //{
        //    //    Id = Guid.NewGuid(),
        //    //    FirstName = "Great",
        //    //    LastName = "Admin",
        //    //    Email = AdminEmail,
        //    //    NormalizedEmail = AdminEmail.ToUpper(),
        //    //    UserName = AdminEmail,
        //    //    NormalizedUserName = AdminEmail.ToUpper(),
        //    //    //EmailConfirmed = true,
        //    //    //LockoutEnabled = true,
        //    //    //LockoutEnd = null,
        //    //    //PhoneNumber = null,
        //    //    //PhoneNumberConfirmed = true,
        //    //    //AccessFailedCount = 0,
        //    //    //TwoFactorEnabled = true,
        //    //    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "123456"),
        //    //    //SecurityStamp = Guid.NewGuid().ToString().ToUpper(),
        //    //    //ConcurrencyStamp = Guid.NewGuid().ToString(),
        //    //};

        //    //return AdminUser;


        //    //AdminAgent = new Agent
        //    //{

        //    //    Id = Guid.NewGuid(),
        //    //    PhoneNumber = "+49888888888",
        //    //    UserId = AdminUser.Id,
        //    //    User = AdminUser,

        //    //};

        //    //return AdminUser;



        //}

        //private Agent SeedAgents()
        //{

        //    AdminAgent = new Agent
        //    {

        //        Id = Guid.NewGuid(),
        //        PhoneNumber = "+49888888888",
        //        UserId = AdminUser.Id,
        //        User = AdminUser,




        //    };

        //    return AdminAgent;

        //}



    }



}

