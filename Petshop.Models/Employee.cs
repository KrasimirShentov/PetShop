﻿using System.ComponentModel.DataAnnotations;

namespace PetShop.Petshop.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]

        public string EmployeeSurname { get; set; }

        [Required]
        public string EmployeePhone { get; set; }

        [Required]
        public int EmployeeAge { get; set; }

        [Required]
        public string JobTitle { get; set; }
        
        [Required]
        public DateTime HireDate { get; set; }
        
        [Required]
        public int VacationHours { get; set; }
        
        [Required]
        public int SickLeaveHours { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}