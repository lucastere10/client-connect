using System.ComponentModel.DataAnnotations;

namespace ClientConnect.UseCases.Dto.Employee;

public class CreateEmployeeDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public DateTime Birthdate { get; set; }
}
