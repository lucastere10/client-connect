using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientConnect.Domain.Models;

public class Employee
{
    [Key]
    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public DateTime Birthdate { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreationTimestamp { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdateTimestamp { get; set; }

    public virtual ICollection<Interaction> Interactions { get; set; }
}
