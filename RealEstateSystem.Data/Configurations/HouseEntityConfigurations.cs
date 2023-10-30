using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static RealEstateSystem.Common.EntityValidationConsatnts;
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

            builder.HasData(GetHauses());
           
        }

        private House[] GetHauses()
        {
            ICollection<House> hause=new List<House>();

            House haus;

            haus = new House
            {

                Title = "Big House Marina",
                Address = "North London, UK (near the border)",
                Description = "A big house for your whole family. Don't miss to buy a house with three bedrooms.",
                ImageUrl = "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg",
                PricePerMonth = 2100.00M,
                CategoryId = 3,
                AgentId = Guid.Parse("723b08eb-551c-4f19-a202-8b83cd44568f"),//Agent.Id is admin first manuel created in the database
                RenterId = Guid.Parse("842c3156-8794-4456-aaa6-e67f1821eafe") //Renter.Id is userId first manuel created in the database

            };

            hause.Add(haus);

            haus = new House
            {
                
                Title = "Family House Comfort",
                Address = "Near the Sea Garden in Burgas, Bulgaria",
                Description = "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.",
                 ImageUrl ="https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a & o = &hp = 1",
                 PricePerMonth = 1200.00M,
                 CategoryId = 2,
                AgentId = Guid.Parse("723b08eb-551c-4f19-a202-8b83cd44568f"),//Agent.Id is admin first manuel created in the database

            };
            hause.Add(haus);

            haus = new House
            {
               
                Title = "Grand House",
                Address = "Boyana Neighbourhood, Sofia, Bulgaria",
                Description = "This luxurious house is everything you will need. It is just excellent.",
                ImageUrl = "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg",
                PricePerMonth = 2000.00M,
                CategoryId = 1,
                AgentId = Guid.Parse("723b08eb-551c-4f19-a202-8b83cd44568f"),//Agent.Id is admin first manuel created in the database

            };

            hause.Add(haus);

            return hause.ToArray();       
        
        
        }

    }
}
