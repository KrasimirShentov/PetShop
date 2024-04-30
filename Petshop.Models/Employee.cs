using System.ComponentModel.DataAnnotations;

namespace PetShop.Petshop.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeID { get; set; }

        [Display(Name = DataValidation.FirstnameDisplay)]
        [Required(ErrorMessage = DataValidation.FirstnameRequired)]
        public string EmployeeName { get; set; }

        [Display(Name = DataValidation.SurnameDisplay)]
        [Required(ErrorMessage = DataValidation.SurnameRequired)]

        public string EmployeeSurname { get; set; }

        [Display(Name = DataValidation.PhoneDisplay)]
        [Required(ErrorMessage = DataValidation.PhoneRequired)]
        public string EmployeePhone { get; set; }

        [Display(Name = DataValidation.AgeDisplay)]
        [Required(ErrorMessage = DataValidation.AgeRequired)]
        public int EmployeeAge { get; set; }

        [Display(Name = DataValidation.JobtitleDisplay)]
        [Required(ErrorMessage = DataValidation.JobtitleRequired)]
        public string JobTitle { get; set; }
        public DateTime HireDate { get; set; }
        public int VacationHours { get; set; }
        public int SickLeaveHours { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
