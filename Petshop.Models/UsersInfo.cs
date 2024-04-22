using System.ComponentModel.DataAnnotations;

namespace PetShop.Petshop.Models
{
    public class UsersInfo
    {
        [Required]
        public int UserID { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

    }
}
