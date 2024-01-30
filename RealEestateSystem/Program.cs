using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;
using RealEstateSystem.Data.Models;
using RealEstateSystem.Services.Data;
using RealEstateSystem.Services.Data.Interfaces;
using RealEstateSystems.Web.Infrastructure.Helper;
using RealEstateSystems.Web.Infrastructure.Extensions;
using static RealEstateSystem.Common.AdminRoleConstant;





namespace RealEestateSystem
{


    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<RealEstateSystemDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");                
                options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");

            }).AddRoles<IdentityRole<Guid>>().AddEntityFrameworkStores<RealEstateSystemDbContext>().AddDefaultUI().AddDefaultTokenProviders();

           

            builder.Services.AddScoped<IHouseInterface, HouseService>();
            builder.Services.AddScoped<IAgentInterface, AgentServiceIndex>();
            builder.Services.AddScoped<ICategoryInterface, CategoryService>();
            builder.Services.AddScoped<IStatisticsInterface,StatisticsService>();
            builder.Services.AddScoped<IApplicationUserInterface,ApplicationUserService>();
            builder.Services.AddScoped<LocalSaveImageHelper>();
            builder.Services.AddScoped<DataBaseSaveImageHelper>();
            builder.Services.AddScoped<GetImageFromDbDecoding>();
           

            //Add AntiforgeryToken filter against CSRF attacks
            builder.Services.AddControllersWithViews( options=>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });  
            
            
            builder.Services.AddRazorPages();

            var app = builder.Build();


            //app.SeedAdministrator("администраторският имейл");

            
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                               
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");    
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles(
                
                new StaticFileOptions
                {
                    OnPrepareResponse = ctx =>
                    {
                        ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=3600");
                    }
                });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            if (app.Environment.IsDevelopment())
            {
                app.SeedAdministrator(AdminEmail);
            }    



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "areaRoute",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");                
            });

            app.MapDefaultControllerRoute();

            app.MapRazorPages();                    

            app.Run();
        }
    }
}