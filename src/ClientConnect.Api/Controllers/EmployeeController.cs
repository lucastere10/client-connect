using ClientConnect.Domain.Exceptions;
using ClientConnect.Domain.Models;
using ClientConnect.Infrastructure.Services;
using ClientConnect.UseCases.Dto.Employee;
using Microsoft.AspNetCore.Mvc;

namespace ClientConnect.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class EmployeeController : ControllerBase
{
    private EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CreateEmployee([FromBody] CreateEmployeeDto employeeDto)
    {
        Employee employee = _employeeService.AddEmployee(employeeDto);
        return CreatedAtAction(nameof(GetEmployeesById), new { id = employee.EmployeeId }, employee);
    }

    [HttpGet]
    public IEnumerable<ReadEmployeeSummaryDto> GetEmployees(int pageNumber = 1, int pageSize = 10)
    {
        return _employeeService.GetEmployees(pageNumber, pageSize);
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeesById(int id)
    {
        ReadEmployeeDetailsDto employeeDto = _employeeService.GetEmployeeById(id);
        if (employeeDto != null)
        {
            return Ok(employeeDto);
        }
        throw new EntityNotFoundException($"Employee with id {id} was not found.");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEmployee(int id, [FromBody] CreateEmployeeDto employeeDto)
    {
        Employee employee = _employeeService.UpdateEmployee(id, employeeDto);
        if (employee != null)
        {
            return Ok(employee);
        }
        return NotFound($"Employee with id {id} was not found.");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        bool deleted = _employeeService.DeleteEmployee(id);
        if (deleted)
        {
            return NoContent();
        }
        return NotFound($"Employee with id {id} was not found.");
    }
}
