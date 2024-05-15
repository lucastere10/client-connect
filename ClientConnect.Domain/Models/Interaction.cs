using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientConnect.Domain.Models;

public class Interaction
{
    [Key]
    [Required]
    public int InteractionId { get; set; }

    [Required]
    public string InteractionType { get; set; }

    public string Comment { get; set; }

    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime InteractionDate { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }
}
