using AutoMapper;
using ClientConnect.Domain.Models;
using ClientConnect.Infrastructure.Data;
using ClientConnect.UseCases.Dto.Employee;

namespace ClientConnect.Infrastructure.Services;

public class EmployeeService
{
    private IMapper _mapper;
    private ClientConnectContext _context;

    public EmployeeService(IMapper mapper, ClientConnectContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Employee AddEmployee(CreateEmployeeDto employeeDto)
    {
        Employee employee = _mapper.Map<Employee>(employeeDto);
        _context.Employees.Add(employee);
        _context.SaveChanges();
        return employee;
    }

    public IEnumerable<ReadEmployeeSummaryDto> GetEmployees(int pageNumber, int pageSize)
    {
        return _mapper.Map<List<ReadEmployeeSummaryDto>>(_context.Employees
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList());
    }


    public ReadEmployeeDetailsDto GetEmployeeById(int id)
    {
        Employee employee = _context.Employees.FirstOrDefault(c => c.EmployeeId == id);
        if (employee != null)
        {
            return _mapper.Map<ReadEmployeeDetailsDto>(employee);
        }
        return null;
    }

    public Employee UpdateEmployee(int id, CreateEmployeeDto employeeDto)
    {
        Employee employee = _context.Employees.FirstOrDefault(c => c.EmployeeId == id);
        if (employee != null)
        {
            _mapper.Map(employeeDto, employee);
            _context.SaveChanges();
        }
        return employee;
    }

    public bool DeleteEmployee(int id)
    {
        Employee employee = _context.Employees.FirstOrDefault(c => c.EmployeeId == id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}
