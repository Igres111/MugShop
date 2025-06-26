using System.ComponentModel.DataAnnotations;

namespace MugShop.DTOs.CustomerDTOs
{
    public class SignUpCustomerDto
    {
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
