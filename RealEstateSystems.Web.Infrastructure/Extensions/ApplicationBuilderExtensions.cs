using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RealEstateSystem.Data.Models;
using static RealEstateSystem.Common.AdminRoleConstant;

namespace RealEstateSystems.Web.Infrastructure.Extensions
{
    public  class ApplicationBuilderExtensions
    {

        public static IApplicationBuilder SeedAdmin(IApplicationBuilder application,string email)
        {


            using var serviceScope = application.ApplicationServices.CreateScope();

            var serviceProvider = serviceScope.ServiceProvider;

            var userManager=serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var roleManger=serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManger.RoleExistsAsync(AdminRoleName)) 
                { 
                    return;                
                
                }

                IdentityRole<Guid> role= new IdentityRole<Guid>(AdminRoleName);

                await roleManger.CreateAsync(role);

                ApplicationUser adminUser = await userManager.FindByEmailAsync(email);

                await userManager.AddToRoleAsync(adminUser, AdminRoleName);

            }).GetAwaiter().GetResult();

            return application;         


            
        }




    }
}
