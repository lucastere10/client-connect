using AutoMapper;
using ClientConnect.Domain.Models;
using ClientConnect.UseCases.Dto.Customer;

namespace ClientConnect.UseCases.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<Customer, ReadCustomerSimpleDto>();
        CreateMap<Customer, ReadCustomerSummaryDto>()
            .ForMember(dto => dto.InteractionCount, opt => opt.MapFrom(c => c.Interactions.Count));
        CreateMap<Customer, ReadCustomerDetailsDto>()
            .ForMember(dto => dto.Interactions, opt => opt.MapFrom(c => c.Interactions));
    }
}