using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Data.Models
{
    public class Image
    {
       

        public Guid Id { get; set; }

        public byte[]? Content { get; set; }

        public string? ContentType { get; set; } 
        
        public Guid HouseId { get; set; }

        public House? House { get; set; } 

        public Guid AgentId { get; set; }

        public Agent? Agent { get; set; } 



    }
}
