using System.ComponentModel.DataAnnotations;

namespace PetShop.Petshop.Models
{
    public class UsersInfo
    {
        [Key]
        public int UserID { get; set; }

        [Display(Name = DataValidation.UsernameDisplay)]
        [Required(ErrorMessage = DataValidation.UsernameRequired)]
        [StringLength(DataValidation.UserNameMaxLength)]
        public string UserName { get; set; }

        [Display(Name = DataValidation.EmailDisplay)]
        [Required(ErrorMessage = DataValidation.EmailRequired)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = DataValidation.PasswordDisplay)]
        [Required(ErrorMessage = DataValidation.PasswordRequired)]
        [StringLength(DataValidation.PasswordMaxLength)]    
        public string Password { get; set; }
        public DateTime CreatedDate = DateTime.Now;

    }
}
