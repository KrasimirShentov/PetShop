using System.ComponentModel.DataAnnotations;
using PetShop.Petshop.Models.Enums;

namespace PetShop.Petshop.Models
{
    public class Pet
    {
        [Required]
        public int PetID { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public PetType PetType { get; set; }

    }
}
