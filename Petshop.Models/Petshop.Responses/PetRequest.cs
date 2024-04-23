using PetShop.Petshop.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Petshop.Models.Petshop.Responses
{
    public class PetRequest
    {
        public int PetID { get; set; }

        public string Breed { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public PetType PetType { get; set; }
    }
}
