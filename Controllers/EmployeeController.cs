using Microsoft.AspNetCore.Mvc;
using PetShop.Petshop.Models;
using PetShop.Petshop.Models.Petshop.Responses;
using PetShop.Petshop.services.Interfaces;

namespace PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
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

        [HttpGet]
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

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRequest employeeRequest)
        {
            try
            {
                await _employeeService.AddEmployeeAsync(employeeRequest);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return Forbid(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int employeeID)
        {
            try
            {

                await _employeeService.DeleteEmployeeAsync(employeeID);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return Forbid(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            try
            {
                await _employeeService.UpdateEmployeeAsync(employee);
                return Ok(employee);
            }
            catch (InvalidOperationException ex)
            {
                return Forbid(ex.Message);
            }
        }
    }
}
