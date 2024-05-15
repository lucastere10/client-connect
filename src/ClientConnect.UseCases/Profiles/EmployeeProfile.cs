using AutoMapper;
using ClientConnect.Domain.Models;
using ClientConnect.UseCases.Dto.Employee;

namespace ClientConnect.UseCases.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<CreateEmployeeDto, Employee>();
        CreateMap<Employee, ReadEmployeeDto>()
            .ForMember(employeeDto => employeeDto.Interactions,
            opt => opt.MapFrom(employee => employee.Interactions));
    }
}
