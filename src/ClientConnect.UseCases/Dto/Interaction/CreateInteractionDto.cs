using System.ComponentModel.DataAnnotations;

namespace ClientConnect.UseCases.Dto.Interaction;

public class CreateInteractionDto
{

    [Required]
    public string InteractionType { get; set; }

    public string Comment { get; set; }

    public int CustomerId { get; set; }

    public int EmployeeId { get; set; }

}
