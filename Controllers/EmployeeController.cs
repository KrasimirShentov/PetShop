using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Petshop.Models;
using PetShop.Petshop.services.Interfaces;

namespace PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeRepository)
        {
            _logger = logger;
            _employeeService = employeeRepository;
        }

        [HttpGet("{employeeID}")]
        public async Task<IActionResult> GetEmployeeByIDAsync(int employeeID)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(employeeID);

            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("Get all")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok();
        }

        [HttpPost("Add employee")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            await _employeeService.AddEmployeeAsync(employee);
            return Ok();
        }

        [HttpDelete("Delete employee")]
        public async Task<IActionResult> DeleteEmployee(int employeeID)
        {
            await _employeeService.DeleteEmployeeAsync(employeeID);
            return Ok();
        }

        [HttpPut("Update employee")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            await _employeeService.UpdateEmployeeAsync(employee);
            return Ok();
        }
    }
}
