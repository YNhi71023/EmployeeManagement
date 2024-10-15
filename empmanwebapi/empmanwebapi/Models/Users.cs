using System.ComponentModel.DataAnnotations;

namespace empmanwebapi.Models
{
    public class Users
    {
        [Required]
        public string user_name { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string role { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
