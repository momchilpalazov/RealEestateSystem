using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Models.ViewModels.House
{
    public  class HouseDeleteDetailsViewModel
    {

        public Guid Id { get; set; }

        public string Title { get; set; }=null!;

        public string Address { get; set; }=null!;  

        public string ImageUrl { get; set; }=null!;

        public int? ImagesId { get; set; }


        [DisplayName("Image Data")]
        public byte[]? ImageData { get; set; }



    }
}
