namespace PetShop.Petshop.Models.Petshop.Responses
{
    public class EmployeeRequest
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeePhone { get; set; }
        public int EmployeeAge { get; set; }
        public string JobTitle { get; set; }
        public DateTime HireDate { get; set; }
        public int VacationHours { get; set; }
        public int SickLeaveHours { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
