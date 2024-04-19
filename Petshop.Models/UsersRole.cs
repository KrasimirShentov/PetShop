using Microsoft.AspNetCore.Identity;

namespace PetShop.Petshop.Models
{
    public class UsersRole : IdentityRole
    {
        public int UserId { get; set; }
    }
}
