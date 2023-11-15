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
       

        public int Id { get; set; }

        public byte[]? Content { get; set; }

        public string? ContentType { get; set; }       




    }
}
