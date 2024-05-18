namespace ClientConnect.UseCases.Dto.Customer;
using ClientConnect.Domain.Models;

public class ReadCustomerDetailsDto
{
    public int CustomerId { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public virtual ICollection<Interaction> Interactions { get; set; }
}
