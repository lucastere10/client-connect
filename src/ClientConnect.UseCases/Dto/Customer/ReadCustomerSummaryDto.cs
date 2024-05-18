namespace ClientConnect.UseCases.Dto.Customer;

public class ReadCustomerSummaryDto
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int InteractionCount { get; set; }
}
