using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetShop.Petshop.Models;
using PetShop.Petshop.services.Interfaces;

namespace PetShop.Petshop.services.Services
{
    public class EmployeeServices : IEmployeeService
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeServices(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            try
            {
                await _employeeService.AddEmployeeAsync(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding employee: {ex.Message}");
            }
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(employeeId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting employee: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            try
            {
                return await _employeeService.GetAllEmployeesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all employees: {ex.Message}");
                throw;
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            try
            {
                return await _employeeService.GetEmployeeByIdAsync(employeeId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting employee by ID: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                await _employeeService.UpdateEmployeeAsync(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating employee: {ex.Message}");
                throw;
            }
        }
    }
}
