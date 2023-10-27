using System;
using System.Collections.Generic;
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

            OwnedHauses = new HashSet<Hause>();
        }

        public Guid Id { get; set; }
       

        public string PhoneNumber { get; set; } = null!;

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        public virtual ICollection<Hause> OwnedHauses { get; set; }        

        



    }
}
