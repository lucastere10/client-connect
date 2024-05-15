using AutoMapper;
using ClientConnect.Domain.Models;
using ClientConnect.UseCases.Dto.Customer;

namespace ClientConnect.UseCases.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<Customer, ReadCustomerDto>()
            .ForMember(customerDto => customerDto.Interactions,
            opt => opt.MapFrom(customer => customer.Interactions));
    }
}
