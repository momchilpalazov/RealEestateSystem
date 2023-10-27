using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static RealEstateSystem.Common.EntityValidationConsatnts.Category;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }=null!;

        public IEnumerable<Hause> Hauses { get; set; } = new List<Hause>();



    }
}
