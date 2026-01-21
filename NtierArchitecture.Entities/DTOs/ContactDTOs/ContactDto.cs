using System.ComponentModel.DataAnnotations;

namespace NtierArchitecture.Entities.DTOs.ContactDtos
{
    public class ContactDto
    {
        [Required]
        public string? Name { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Message { get; set; }
    }
}
