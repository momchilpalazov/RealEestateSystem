using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static RealEstateSystem.Common.EntityValidationConsatnts.ApplicationUser;


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


        [Required]
        [MinLength(UserFirstNameMinLength)]
        [MaxLength(UserFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(UserLastNameMinLength)]
        [MaxLength(UserLastNameMaxLength)]
        public string LastName { get; set; }       

        public ICollection<House> RentedHause { get; set; }        

        
    }
}
