using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RealEstateSystem.Data.Models;
using static RealEstateSystem.Common.AdminRoleConstant;

namespace RealEstateSystems.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        //This method is used to seed the admin user in the database if it is not already seeded
        //Passed email schoould be a valid email of the existing admin user  
        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email)
        {


            using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = serviceScope.ServiceProvider;

            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }

                IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);

                await roleManager.CreateAsync(role);

                ApplicationUser adminUser = await userManager.FindByEmailAsync(email);

                await userManager.AddToRoleAsync(adminUser, AdminRoleName);

            }).GetAwaiter().GetResult();

            return app;



        }
    }
}
