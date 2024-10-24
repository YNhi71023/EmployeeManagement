using System.ComponentModel.DataAnnotations;

namespace empmanwebapi.Models
{
    public class LoginModel
    {
        public string username { get; set; }




        public string password { get; set; }
    }
    public class reponseLogin
    {
        public int account_id { get; set; }
        public string username { get; set; }
        public string token { get; set; }
    }
}
