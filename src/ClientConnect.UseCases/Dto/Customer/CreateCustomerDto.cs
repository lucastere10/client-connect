using System.ComponentModel.DataAnnotations;

namespace ClientConnect.UseCases.Dto.Customer
{
    public class CreateCustomerDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }

}
