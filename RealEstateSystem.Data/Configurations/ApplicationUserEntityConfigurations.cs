using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateSystem.Data.Models;


namespace RealEstateSystem.Data.Configurations
{
    public class ApplicationUserEntityConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FirstName).
                HasDefaultValue("Admin");

            builder.Property(u => u.LastName).
                HasDefaultValue("Adminov");
        }

    }
}
