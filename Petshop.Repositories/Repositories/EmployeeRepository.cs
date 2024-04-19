using PetShop.Petshop.Models;
using PetShop.Petshop.Repositories.Interfaces;

namespace PetShop.Petshop.Repositories.Repositories
{
    public class EmployeeRepository : IEmployeeReposity
    {
        private readonly List<Employee> _employees;
        private int _employeeId = 0;

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await Task.FromResult(_employees);
        }

        public async Task<Employee> GetEmployeeByIDAsync(int employeeID)
        {
            return await Task.FromResult(_employees.FirstOrDefault(x => x.EmployeeID == employeeID));
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            else
            {
                employee.EmployeeID = _employeeId++;
                _employees.Add(employee);
                await Task.CompletedTask;
            }

        }

        public async Task DeleteEmployeeAsync(int employeeID)
        {
            var employeeToDelete = await GetEmployeeByIDAsync(employeeID);
            if (employeeToDelete != null)
            {
                _employees.Remove(employeeToDelete);
                await Task.CompletedTask;
            }
            else
            {

                throw new ArgumentNullException("Employee with this ID does not exist");
            }
        }


        public async Task UpdateEmployeeAsync(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            else
            {
                var existingEmployee = await GetEmployeeByIDAsync(employee.EmployeeID);
                if (existingEmployee != null)
                {
                    existingEmployee.EmployeeName = employee.EmployeeName;
                    existingEmployee.EmployeeSurname = employee.EmployeeSurname;
                    existingEmployee.EmployeePhone = employee.EmployeePhone;
                    existingEmployee.EmployeeAge = employee.EmployeeAge;
                    existingEmployee.JobTitle = employee.JobTitle;
                    existingEmployee.HireDate = employee.HireDate;
                    existingEmployee.VacationHours = employee.VacationHours;
                    existingEmployee.SickLeaveHours = employee.SickLeaveHours;
                    existingEmployee.ModifiedDate = DateTime.Now;

                    await Task.CompletedTask;
                }
                else
                {
                    throw new ArgumentException($"Employee with ID {employee.EmployeeID} not found.");
                }
            }

        }
    }
}
