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

namespace RealEstateSystem.Data
{
    public class RealEstateSystemDbContext :IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
    {

        public RealEstateSystemDbContext(DbContextOptions<RealEstateSystemDbContext> options)
            : base(options)
        {

        }


        // custum user is not not obligatory 
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public DbSet<Hause> Hauses { get; set; } = null!;

        public DbSet<Agent> Agents { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly assembly = Assembly.GetAssembly(typeof(RealEstateSystemDbContext)) ?? throw new InvalidOperationException("Assembly not found.");
                Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(builder);
        }


    }
}
