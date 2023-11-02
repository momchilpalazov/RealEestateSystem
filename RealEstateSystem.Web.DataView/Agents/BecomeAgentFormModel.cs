using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Models.ViewModels.Agents
{
    public class BecomeAgentFormModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        [StringLength(10, MinimumLength = 15, ErrorMessage = "The phone number must be 10 digits long.")]
        public string PhoneNumber { get; set; }=null!;


    }
}
