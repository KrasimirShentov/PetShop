using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Petshop.Models;
using PetShop.Petshop.Models.Petshop.Responses;
using PetShop.Petshop.services.Interfaces;
using System.Net;

namespace PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeRepository)
        {
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
            return Ok(employee);
        }

        [HttpGet("Get all")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpPost("Add employee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRequest employeeRequest)
        {
            await _employeeService.AddEmployeeAsync(employeeRequest);
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
