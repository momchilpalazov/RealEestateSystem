
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RealEstateSystem.Common.EntityValidationConsatnts.Agent;


namespace RealEstateSystem.Data.Models
{
    public class Agent
    {

        public Agent()
        {
            this.Id = Guid.NewGuid();

            ManageHauses = new HashSet<House>();

        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(PhoneNumberMinLength)]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; }=null!;


        public virtual ICollection<House>? ManageHauses { get; set; }


    }
}
