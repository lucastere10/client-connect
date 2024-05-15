using AutoMapper;
using ClientConnect.Domain.Models;
using ClientConnect.UseCases.Dto.Interaction;

namespace ClientConnect.UseCases.Profiles;

public class InteractionProfile : Profile
{
    public InteractionProfile()
    {
        CreateMap<CreateInteractionDto, Interaction>();
        CreateMap<Interaction, ReadInteractionDto>();
    }
}