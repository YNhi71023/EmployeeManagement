using System.ComponentModel.DataAnnotations;

namespace empmanwebapi.Models
{
    public class RegisterModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string role { get; set; }
        
        

    }
    
    public class reponseRegister
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string token { get; set; }
    }
}
