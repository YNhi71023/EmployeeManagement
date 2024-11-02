using System.ComponentModel.DataAnnotations;

namespace empmanwebapi.Models
{
    public class Users
    {
        [Required]
        public string user_name { get; set; }
        [Required]
        public string password { get; set; }
    }
    public class CreateUserModel
    {
        public int employee_id { get; set; }
        [Required]
        public string user_name { get; set; }
        [Required]
        public string password { get; set; }

    }
}
