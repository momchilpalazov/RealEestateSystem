using RealEstateSystem.Models.ViewModels.Category;
using static RealEstateSystem.Common.ViewModelValidationConstants.HouseFormModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using RealEstateSystem.Data.Models;
using System.ComponentModel;

namespace RealEstateSystem.Models.ViewModels.House
{
    public class HouseFormModel
    {

        public Guid Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        //[Required]
        [Display(Name = "Add Image Link")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Image Upload")]
        public int? ImagesId { get; set; }


        [DisplayName("Image Data")]
        public byte[]? ImageData { get; set; }


        [Required]
        [Display(Name = "Price Per Month")]
        [Range(typeof(decimal), PricePerMonthMinLength, PricePerMonthMaxLength,ErrorMessage ="Prise per Month must be positive number and less than {2} Euro")]
        public decimal PricePerMonth { get; set; }

        
        [Display(Name = "Agent")]
        public Guid AgentId { get; set; }

        [Display(Name = "Category")]    
        public int CategoryId { get; set; }


        public ICollection<CategoryHouseServiceViewModel> Categories { get; set; } = new HashSet<CategoryHouseServiceViewModel>();




    }
}
