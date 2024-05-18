using AutoMapper;
using ClientConnect.Domain.Models;
using ClientConnect.UseCases.Dto.Employee;

namespace ClientConnect.UseCases.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<CreateEmployeeDto, Employee>();
        CreateMap<Employee, ReadEmployeeSimpleDto>();
        CreateMap<Employee, ReadEmployeeSummaryDto>()
            .ForMember(dto => dto.InteractionCount,
            opt => opt.MapFrom(c => c.Interactions.Count));
        CreateMap<Employee, ReadEmployeeDetailsDto>()
            .ForMember(employeeDto => employeeDto.Interactions,
            opt => opt.MapFrom(employee => employee.Interactions));
    }
}
