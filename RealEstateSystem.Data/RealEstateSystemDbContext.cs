using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data.Configurations;
using RealEstateSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static RealEstateSystem.Common.AdminRoleConstant;

namespace RealEstateSystem.Data
{
    public class RealEstateSystemDbContext :IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
    {
        
        private readonly bool seedData;

        public RealEstateSystemDbContext(DbContextOptions<RealEstateSystemDbContext> options,bool seedData=true)
            : base(options)
        {
            this.seedData = seedData;

        }


        // custum user is  not obligatory 
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public DbSet<House> Hauses { get; set; } = null!;

        public DbSet<Agent> Agents { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Image> Images { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {


            //Assembly assembly = Assembly.GetAssembly(typeof(RealEstateSystemDbContext)) ?? throw new InvalidOperationException("Assembly not found.");
            //    Assembly.GetExecutingAssembly();

            //builder.ApplyConfigurationsFromAssembly(assembly);
            //

            builder.ApplyConfiguration(new ApplicationUserEntityConfigurations());
            builder.ApplyConfiguration(new HouseEntityConfigurations());

            if (seedData)
            {
                //builder.ApplyConfiguration(new AdministratorAndAgentSeedConfigurations());
                builder.ApplyConfiguration<ApplicationUser>(new AdministratorAndAgentSeedConfigurations());
                builder.ApplyConfiguration<Agent>(new AdministratorAndAgentSeedConfigurations());

                builder.ApplyConfiguration(new CategoryEntityConfigurations());
                builder.ApplyConfiguration(new SeedHouseEntityConfigurations());

            }

            base.OnModelCreating(builder);           
           

        }


    }
}
