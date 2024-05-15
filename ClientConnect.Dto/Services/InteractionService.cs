using AutoMapper;
using ClientConnect.Domain.Models;
using ClientConnect.Infrastructure.Data;
using ClientConnect.UseCases.Dto.Interaction;

namespace ClientConnect.Infrastructure.Services;

public class InteractionService
{
    private IMapper _mapper;
    private ClientConnectContext _context;

    public InteractionService(IMapper mapper, ClientConnectContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Interaction AddInteraction(CreateInteractionDto interactionDto)
    {
        Interaction interaction = _mapper.Map<Interaction>(interactionDto);
        _context.Interactions.Add(interaction);
        _context.SaveChanges();
        return interaction;
    }

    public IEnumerable<ReadInteractionDto> GetInteractions(int pageNumber, int pageSize)
    {
        return _mapper.Map<List<ReadInteractionDto>>(_context.Interactions
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList());
    }


    public ReadInteractionDto GetInteractionById(int id)
    {
        Interaction interaction = _context.Interactions.FirstOrDefault(c => c.InteractionId == id);
        if (interaction != null)
        {
            return _mapper.Map<ReadInteractionDto>(interaction);
        }
        return null;
    }

    public Interaction UpdateInteraction(int id, CreateInteractionDto interactionDto)
    {
        Interaction interaction = _context.Interactions.FirstOrDefault(c => c.InteractionId == id);
        if (interaction != null)
        {
            _mapper.Map(interactionDto, interaction);
            _context.SaveChanges();
        }
        return interaction;
    }

    public bool DeleteInteraction(int id)
    {
        Interaction interaction = _context.Interactions.FirstOrDefault(c => c.InteractionId == id);
        if (interaction != null)
        {
            _context.Interactions.Remove(interaction);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}
