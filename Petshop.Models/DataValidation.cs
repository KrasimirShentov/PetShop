using PetShop.Petshop.Models.Enums;

namespace PetShop.Petshop.Models
{
    public class DataValidation
    {
        //Employees + Users

        //First/surname and pet name lenght
        public int MaxLenght = 20;

        //Username lenght
        public const int UserNameMaxLength = 16;

        //Password lenght
        public const int PasswordMaxLength = 24;

        //First name required/display/invalidInput
        public const string FirstnameRequired = "Firstname is requied";
        public const string FirstnameDisplay = "First name";
        public const string InvalidFirstname = "First name is invalid, it must be between 4-20 characters";

        //Surname required/display/invalidInput
        public const string SurnameRequired = "Surname is requied";
        public const string SurnameDisplay = "Surname";
        public const string InvalidSurname = "Surname is invalid, it must be between 4-20 characters";

        //Email required/display/invalidInput
        public const string EmailRequired = "Email is requied";
        public const string EmailDisplay = "Email";
        public const string InvalidEmail = "Email is invalid";

        //Phone required/display/invalidInput
        public const string PhoneRequired = "Phone is requied";
        public const string PhoneDisplay = "Phone";

        //Password required/display/invalidInput
        public const string PasswordRequired = "Password is requied";
        public const string PasswordDisplay = "Password";
        public const string InvalidPassword = "Password is invalid, it must be between 8-24 characters";

        //Username required/display/invalidInput
        public const string UsernameRequired = "Username is requied";
        public const string UsernameDisplay = "Username";
        public const string InvalidUsername = "Username is invalid, it must be between 4-20 characters";

         //Age required/display/invalidInput
        public const string AgeRequired = "Age is requied";
        public const string AgeDisplay = "Age";
        public const string InvalidAge = "Age is invalid, it must be between 4-16 characters";

        //Jobtitle required/display/invalidInput
        public const string JobtitleRequired = "Jobtitle is requied";
        public const string JobtitleDisplay = "Jobtitle";

        //Pets

        //Breed required/display/invalidInput
        public const string BreedRequired = "Breed is requied";
        public const string BreedDisplay = "Breed";

        //Pet name required/display/invalidInput
        public const string PetnameRequired = "Pet name is requied";
        public const string PetnameDisplay = "Pet name";
        public const string InvalidPetname = "Pet name is invalid, it must be between 4-20 characters";

        //Pet age name required/display/invalidInput
        public const string PetAgeRequired = "Pet age is requied";
        public const string PetAgeDisplay = "Pet age";

        //Pet type name required/display/invalidInput
        public const string PetTypeRequired = "Pet type is requied";
        public const string PetTypeDisplay = "Pet type";
    }
}
