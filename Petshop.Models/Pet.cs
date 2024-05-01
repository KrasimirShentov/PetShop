using System.ComponentModel.DataAnnotations;
using PetShop.Petshop.Models.Enums;

namespace PetShop.Petshop.Models
{
    public class Pet
    {
        [Key]
        public int PetID { get; set; }

        [Display(Name = DataValidation.BreedDisplay)]
        [Required(ErrorMessage = DataValidation.BreedRequired)]
        public string Breed { get; set; }
        
        [Display(Name = DataValidation.PetnameDisplay)]
        [Required(ErrorMessage = DataValidation.PetnameRequired)]
        public string Name { get; set; }

        [Display(Name = DataValidation.PetAgeDisplay)]
        [Required(ErrorMessage = DataValidation.PetAgeRequired)]
        public int Age { get; set; }

        [Display(Name = DataValidation.PetTypeDisplay)]
        [Required(ErrorMessage = DataValidation.PetTypeRequired)]
        public PetType PetType { get; set; }

    }
}
