namespace ClientConnect.UseCases.Dto.Employee;
using ClientConnect.Domain.Models;

public class ReadEmployeeDetailsDto
{
    public int EmployeeId { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime Birthdate { get; set; }

    public DateTime CreationTimestamp { get; set; }

    public DateTime UpdateTimestamp { get; set; }

    public virtual ICollection<Interaction> Interactions { get; set; }
}
