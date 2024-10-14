using Microsoft.AspNetCore.Mvc;
using storeworkingapi.Models;

namespace storeworkingapi.Models
{
    public class Employees
    {

        public string employee_name { get; set; }
        public int sex { get; set; }
        public string card_number { get; set; }
        public string address { get; set; }
    }
    
}
