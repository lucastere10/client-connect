using ClientConnect.Domain.Exceptions;
using ClientConnect.Domain.Models;
using ClientConnect.Infrastructure.Services;
using ClientConnect.UseCases.Dto.Customer;
using Microsoft.AspNetCore.Mvc;

namespace ClientConnect.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class CustomerController : ControllerBase
{
    private CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CreateCustomer([FromBody] CreateCustomerDto customerDto)
    {
        Customer customer = _customerService.AddCustomer(customerDto);
        return CreatedAtAction(nameof(GetCustomersById), new { id = customer.CustomerId }, customer);
    }

    [HttpGet]
    public IEnumerable<ReadCustomerDto> GetCustomers(int pageNumber = 1, int pageSize = 10)
    {
        return _customerService.GetCustomers(pageNumber, pageSize);
    }

    [HttpGet("{id}")]
    public IActionResult GetCustomersById(int id)
    {
        ReadCustomerDto customerDto = _customerService.GetCustomerById(id);
        if (customerDto != null)
        {
            return Ok(customerDto);
        }
        throw new EntityNotFoundException($"Customer with id {id} was not found.");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(int id, [FromBody] CreateCustomerDto customerDto)
    {
        Customer customer = _customerService.UpdateCustomer(id, customerDto);
        if (customer != null)
        {
            return Ok(customer);
        }
        return NotFound($"Customer with id {id} was not found.");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        bool deleted = _customerService.DeleteCustomer(id);
        if (deleted)
        {
            return NoContent();
        }
        return NotFound($"Customer with id {id} was not found.");
    }

}
