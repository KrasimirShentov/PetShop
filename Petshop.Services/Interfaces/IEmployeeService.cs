using PetShop.Petshop.Models;
using PetShop.Petshop.Models.Petshop.Requests;
using PetShop.Petshop.Models.Petshop.Responses;

namespace PetShop.Petshop.services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task<Employee> AddEmployeeAsync(EmployeeRequest employeeRequest);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int employeeId);
    }
}
