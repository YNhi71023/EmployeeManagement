using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection;

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
        public int sex { get; set; }
        public string card_number { get; set; }
        public string image_before_card { get; set; }
        public string image_after_card { get; set; }
        public string address { get; set; }
        public string mail { get; set; }
        public string mobile { get; set; }
        public string image_profile { get; set; }
        public string position_name { get;set;}
        public string employee_type_name  { get;set;}
        public int position_id { get; set; }
        public int employee_type_id { get; set; }
        public string token { get; set; }
    }
}
