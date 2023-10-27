using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static RealEstateSystem.Common.EntityValidationConsatnts.ApplicationUser;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Data.Models
{
    public  class ApplicationUser:IdentityUser<Guid>
    {
        // This is an example of a class that inherits from IdentityUser<Guid> and adds additional properties to the user.
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();

            RentedHause = new HashSet<Hause>();

        }

        [Required]
        [MinLength(FirstNameMinLength)]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(LastNameMinLength)]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;


        public ICollection<Hause> RentedHause { get; set; } 




    }
}
