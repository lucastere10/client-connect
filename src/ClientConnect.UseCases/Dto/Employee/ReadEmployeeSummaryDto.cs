namespace ClientConnect.UseCases.Dto.Employee;

public class ReadEmployeeSummaryDto
{
    public int EmployeeId { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime Birthdate { get; set; }

    public DateTime CreationTimestamp { get; set; }

    public DateTime UpdateTimestamp { get; set; }
    public int InteractionCount { get; set; }
}
