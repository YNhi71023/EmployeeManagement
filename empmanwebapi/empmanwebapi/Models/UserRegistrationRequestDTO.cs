using System.ComponentModel.DataAnnotations;

namespace empmanwebapi.Models
{
    public class UserRegistrationRequestDTO
    {
        [Required]
        public string employee_name { get; set; } = string.Empty;
        [Required]
        public string username { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
    }
}
