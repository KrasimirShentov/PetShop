using System.ComponentModel.DataAnnotations;

namespace PetShop.Petshop.Models
{
    public class UserInfo
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
