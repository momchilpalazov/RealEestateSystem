﻿
using System.ComponentModel.DataAnnotations;
using static RealEstateSystem.Common.EntityValidationConsatnts.Hause;


namespace RealEstateSystem.Data.Models
{
    public class House
    {

        public House()
        {
            this.Id = Guid.NewGuid();             
        }


        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }=null!;

        [Required]
        [MinLength(AddressMinLength)]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; }=null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }=null!;

       
        public string? ImageUrl { get; set; }

        
        
        public int? ImageId { get; set; }
        public virtual Image? Image { get; set; }


        [Required]
        [Range(typeof(decimal), PricePerMonthMinLength, PricePerMonthMaxLength)]       
        public decimal PricePerMonth { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }=null!;

        
        public Guid AgentId { get; set; }

        public virtual Agent Agent { get; set; }=null!;

        public Guid? RenterId { get; set; } 

        public virtual ApplicationUser? Renter { get; set; }       


    }
}


