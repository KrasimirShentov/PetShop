using PetShop.Petshop.Models;

namespace PetShop.Petshop.Repositories.Interfaces
{
    public interface IEmployeeReposity
    {
        Task<Employee> GetEmployeeByIDAsync(int EmployeeID);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(Employee employeeToDelete);

    }
}
