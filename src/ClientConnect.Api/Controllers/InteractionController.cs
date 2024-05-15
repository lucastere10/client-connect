using ClientConnect.Domain.Exceptions;
using ClientConnect.Domain.Models;
using ClientConnect.Infrastructure.Services;
using ClientConnect.UseCases.Dto.Interaction;
using Microsoft.AspNetCore.Mvc;

namespace ClientConnect.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class InteractionController : ControllerBase
{
    private InteractionService _interactionService;

    public InteractionController(InteractionService interactionService)
    {
        _interactionService = interactionService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CreateInteraction([FromBody] CreateInteractionDto interactionDto)
    {
        Interaction interaction = _interactionService.AddInteraction(interactionDto);
        return CreatedAtAction(nameof(GetInteractionsById), new { id = interaction.InteractionId }, interaction);
    }

    [HttpGet]
    public IEnumerable<ReadInteractionDto> GetInteractions(int pageNumber = 1, int pageSize = 10)
    {
        return _interactionService.GetInteractions(pageNumber, pageSize);
    }

    [HttpGet("{id}")]
    public IActionResult GetInteractionsById(int id)
    {
        ReadInteractionDto interactionDto = _interactionService.GetInteractionById(id);
        if (interactionDto != null)
        {
            return Ok(interactionDto);
        }
        throw new EntityNotFoundException($"Interaction with id {id} was not found.");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateInteraction(int id, [FromBody] CreateInteractionDto interactionDto)
    {
        Interaction interaction = _interactionService.UpdateInteraction(id, interactionDto);
        if (interaction != null)
        {
            return Ok(interaction);
        }
        return NotFound($"Interaction with id {id} was not found.");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteInteraction(int id)
    {
        bool deleted = _interactionService.DeleteInteraction(id);
        if (deleted)
        {
            return NoContent();
        }
        return NotFound($"Interaction with id {id} was not found.");
    }
}
