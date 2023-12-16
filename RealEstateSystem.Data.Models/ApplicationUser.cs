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

            RentedHause = new HashSet<House>();

        }

        public ICollection<House> RentedHause { get; set; } 

    }
}
