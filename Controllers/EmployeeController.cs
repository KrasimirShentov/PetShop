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
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(employeeID);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("/employee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRequest employeeRequest)
        {
            try
            {
                await _employeeService.AddEmployeeAsync(employeeRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("/employee")]
        public async Task<IActionResult> DeleteEmployee(int employeeID)
        {
            try
            {

                await _employeeService.DeleteEmployeeAsync(employeeID);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("/employee")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            try
            {
                await _employeeService.UpdateEmployeeAsync(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
