using PetShop.Petshop.Models;
using PetShop.Petshop.Models.Petshop.Requests;
using PetShop.Petshop.Models.Petshop.Responses;
using PetShop.Petshop.Repositories.Interfaces;
using PetShop.Petshop.services.Interfaces;
using System.Net;

namespace PetShop.Petshop.services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeReposity _employeeRepository;
        private readonly PetshopDB _dbContext;

        public EmployeeService(IEmployeeReposity employeeRepository, PetshopDB dbContext)
        {
            _employeeRepository = employeeRepository;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int emplyoeeID)
        {
            var result = await _employeeRepository.GetEmployeeByIDAsync(emplyoeeID);

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            return await _employeeRepository.GetEmployeeByIDAsync(emplyoeeID);
        }

        public async Task<EmployeeResponse> AddEmployeeAsync(EmployeeRequest employeeRequest)
        {
            var employee = await _employeeRepository.GetEmployeeByIDAsync(employeeRequest.EmployeeID);

            if (employee != null)
            {
                return new EmployeeResponse
                {
                    Employee = employee,
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    Message = "Employee already exists"
                };
            }

            if (employeeRequest.EmployeeID <= 0)
            {
                return new EmployeeResponse
                {
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    Message = "Employee ID must be greater than 0"
                };
            }

            var newEmployee = MapRequestToEmployee(employeeRequest);
            _dbContext.employees.Add(newEmployee);
            await _dbContext.SaveChangesAsync();

            return new EmployeeResponse
            {
                Employee = newEmployee,
                HttpStatusCode = HttpStatusCode.OK,
                Message = "Employee addded successfully"
            };
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var existingEmployee = await _employeeRepository.GetEmployeeByIDAsync(employee.EmployeeID);
            if (existingEmployee == null)
            {
                throw new ArgumentNullException($"Employee with ID {employee.EmployeeID} not found");
            }

            existingEmployee.EmployeeName = employee.EmployeeName;
            existingEmployee.EmployeeSurname = employee.EmployeeSurname;
            existingEmployee.JobTitle = employee.JobTitle;
            existingEmployee.VacationHours = employee.VacationHours;
            existingEmployee.SickLeaveHours = employee.SickLeaveHours;

            await _employeeRepository.UpdateEmployeeAsync(existingEmployee);
        }

        public async Task DeleteEmployeeAsync(int employeeID)
        {
            var employeeToDelete = await _employeeRepository.GetEmployeeByIDAsync(employeeID);
            if (employeeToDelete != null)
            {
                _dbContext.employees.Remove(employeeToDelete);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException($"Employee with this ID: {employeeID} does not exist");
            }
        }

        private Employee MapRequestToEmployee(EmployeeRequest employeeRequest)
        {
            return new Employee
            {
                EmployeeID = employeeRequest.EmployeeID,
                EmployeeName = employeeRequest.EmployeeName,
                EmployeeSurname = employeeRequest.EmployeeSurname,
                EmployeePhone = employeeRequest.EmployeePhone,
                EmployeeAge = employeeRequest.EmployeeAge,
                JobTitle = employeeRequest.JobTitle,
                HireDate = employeeRequest.HireDate,
                VacationHours = employeeRequest.VacationHours,
                SickLeaveHours = employeeRequest.SickLeaveHours,
                ModifiedDate = employeeRequest.ModifiedDate
            };
        }
    }
}
