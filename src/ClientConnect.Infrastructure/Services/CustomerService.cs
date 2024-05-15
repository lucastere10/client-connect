using AutoMapper;
using ClientConnect.Domain.Models;
using ClientConnect.Infrastructure.Data;
using ClientConnect.UseCases.Dto.Customer;

namespace ClientConnect.Infrastructure.Services;

public class CustomerService
{
    private IMapper _mapper;
    private ClientConnectContext _context;

    public CustomerService(IMapper mapper, ClientConnectContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Customer AddCustomer(CreateCustomerDto customerDto)
    {
        Customer customer = _mapper.Map<Customer>(customerDto);
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return customer;
    }

    public IEnumerable<ReadCustomerDto> GetCustomers(int pageNumber, int pageSize)
    {
        return _mapper.Map<List<ReadCustomerDto>>(_context.Customers
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList());
    }


    public ReadCustomerDto GetCustomerById(int id)
    {
        Customer customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        if (customer != null)
        {
            return _mapper.Map<ReadCustomerDto>(customer);
        }
        return null;
    }

    public Customer UpdateCustomer(int id, CreateCustomerDto customerDto)
    {
        Customer customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        if (customer != null)
        {
            _mapper.Map(customerDto, customer);
            _context.SaveChanges();
        }
        return customer;
    }

    public bool DeleteCustomer(int id)
    {
        Customer customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return true;
        }
        return false;
    }


}
