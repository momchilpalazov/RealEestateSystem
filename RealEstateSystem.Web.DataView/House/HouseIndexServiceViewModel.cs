using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Models.ViewModels.House
{
    public class HouseIndexServiceModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }=null!;

        public string ImageUrl { get; set; }=null!;
        


    }
}
