using System.ComponentModel.DataAnnotations;

namespace ClientConnect.Domain.Models;

public class Customer
{
    [Key]
    [Required]
    public int CustomerId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    public virtual ICollection<Interaction> Interactions { get; set; }
}
