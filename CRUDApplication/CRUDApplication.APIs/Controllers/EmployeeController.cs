using CRUDApplication.BL.DTOs;
using CRUDApplication.BL.Managers;
using Microsoft.AspNetCore.Mvc;

namespace CRUDApplication.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeManager.GetAllEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetEmployeeByName(string name)
        {
            try
            {
                var employee = await _employeeManager.GetEmployeeByNameAsync(name);
                if (employee == null)
                {
                    return NotFound($"Employee with name {name} not found.");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeManager.GetEmployeeByIdAsync(id);
                if (employee == null)
                {
                    return NotFound($"Employee with ID {id} not found.");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeWriteDTO employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest("Employee data is null.");
            }
            try
            {
                await _employeeManager.AddEmployeeAsync(employeeDto);
                return Ok(new { message = "Employee added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id,[FromBody] EmployeeWriteDTO employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest("Employee data is null.");
            }
            try
            {
                await _employeeManager.UpdateEmployeeAsync(id,employeeDto);
                return Ok(new { message = "Employee updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than zero.");
            }
            try
            {
                await _employeeManager.DeleteEmployeeAsync(id);
                return Ok(new { message = "Employee deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchEmployeeByName(string name)
        {
            try
            {
                var employees = await _employeeManager.SearchEmployeeAsync(name);
                if (employees == null)
                {
                    return NotFound($"Employee with name {name} not found.");
                }
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("pagination")]
        [HttpGet("pagination/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAllEmployees(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                if (pageNumber <= 0 || pageSize <= 0)
                    return BadRequest("Page number and size must be greater than 0.");

                var employees = await _employeeManager.GetEmployeesAsync(pageNumber, pageSize);
                if (employees == null)
                    return NotFound("No employees found.");
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }

}
