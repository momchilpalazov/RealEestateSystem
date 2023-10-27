using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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

        public string FirstName { get; set; } = null!;


        public string LastName { get; set; } = null!;


        public ICollection<Hause> RentedHause { get; set; } 




    }
}
