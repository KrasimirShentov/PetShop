using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Petshop.Models;
using PetShop.Petshop.Repositories.Repositories;

namespace PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController(ILogger<EmployeeController> logger, EmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        [HttpGet("{employeeID}")]
        public async Task<IActionResult> GetEmployeeByIDAsync(int employeeID)
        {
            var employee = await _employeeRepository.GetEmployeeByIDAsync(employeeID);
            
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok();
        }

        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);
            return Ok();
        }

        public async Task<IActionResult> DeleteEmployee(int employeeID)
        {
            await _employeeRepository.DeleteEmployeeAsync(employeeID);
            return Ok();
        }

        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            await _employeeRepository.UpdateEmployeeAsync(employee);
            return Ok();
        }
    }
}
