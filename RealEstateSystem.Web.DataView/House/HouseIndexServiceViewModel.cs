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

        public string? ImageUrl { get; set; }

        public int? ImageId { get; set; }    

        public byte[]?ImageData { get; set; }    
        
        public string Address { get; set; }=null!;



    }
}
