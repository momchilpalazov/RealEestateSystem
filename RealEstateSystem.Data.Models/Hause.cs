using RealEstateSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Data.Models
{
    public class Hause
    {

        public Hause()
        {
            this.Id = Guid.NewGuid();
        }



        public Guid Id { get; set; } 

        public string Title { get; set; }=null!;

        public string Address { get; set; }=null!;

        public string Description { get; set; }=null!;

        public string ImageUrl { get; set; }=null!;

        public decimal PricePerMonth { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }=null!;

        public Guid AgentId { get; set; }

        public Agent Agent { get; set; }=null!;

        public Guid? RenterId { get; set; } 


        public virtual ApplicationUser? Renter { get; set; } = null!;



    }
}


