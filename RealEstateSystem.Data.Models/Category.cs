using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Data.Models
{
    public class Category
    {
        public int Id { get; init; }

        public string Name { get; set; }=null!;

        public IEnumerable<Hause> Hauses { get; set; } = new List<Hause>();



    }
}
