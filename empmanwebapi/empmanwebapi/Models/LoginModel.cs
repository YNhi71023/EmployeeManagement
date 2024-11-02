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
        public int employee_id { get; set; }
        public string employee_name { get; set; }
        public int position_id { get; set; }
        public int employee_type_id { get; set; }
        public string token { get; set; }
    }
}
