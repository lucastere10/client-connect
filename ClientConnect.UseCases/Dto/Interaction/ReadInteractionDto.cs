using ClientConnect.UseCases.Dto.Customer;
using ClientConnect.UseCases.Dto.Employee;

namespace ClientConnect.UseCases.Dto.Interaction;

public class ReadInteractionDto
{

    public int InteractionId { get; set; }

    public string InteractionType { get; set; }

    public string Comment { get; set; }

    public DateTime InteractionDate { get; set; }

    public virtual ReadCustomerDto Customer { get; set; }

    public virtual ReadEmployeeDto Employee { get; set; }
}
