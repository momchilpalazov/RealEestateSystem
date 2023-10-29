using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static RealEstateSystem.Common.EntityValidationConsatnts.Agent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Data.Models
{
    public class Agent
    {

        public Agent()
        {
            this.Id = Guid.NewGuid();

            ManageHauses = new HashSet<Hause>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(PhoneNumberMinLength)]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        public virtual ICollection<Hause> ManageHauses { get; set; }        

        



    }
}
