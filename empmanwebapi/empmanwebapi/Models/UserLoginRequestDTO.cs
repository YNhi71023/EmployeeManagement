using System.ComponentModel.DataAnnotations;

namespace empmanwebapi.Models
{
    public class UserLoginRequestDTO
    {
        [Required]
        public string username { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
    }
}
