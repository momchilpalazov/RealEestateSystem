using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Data.Configurations
{
    public class HauseEntityConfigurations : IEntityTypeConfiguration<Hause>
    {
        public void Configure(EntityTypeBuilder<Hause> builder)
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
