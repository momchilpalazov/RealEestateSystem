
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using House = RealEstateSystem.Data.Models.House;

namespace RealEstateSystem.Data.Configurations
{
    public class HouseEntityConfigurations : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.
                HasOne(h => h.Category)
                .WithMany(c => c.Hauses)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.
                HasOne(h => h.Agent)
                .WithMany(a => a.ManageHauses)
                .HasForeignKey(h => h.AgentId)
                .OnDelete(DeleteBehavior.Restrict);   

           


            
           
        }       


       

    }
}
