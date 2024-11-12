using Microsoft.AspNetCore.Mvc;
using storeworkingapi.Models;

namespace storeworkingapi.Models
{

    public class Employees
    {
        public int employee_id { get; set; }
        public string? employee_name { get; set; }
        public int sex { get; set; }
        public string? card_number { get; set; }
        public string? image_before_card { get; set; }
        public string? image_after_card { get; set; }  
        public DateOnly? birthday { get; set; }
        public string address { get; set; }
        public string? mail {  get; set; }
        public string? mobile { get; set; }
        public string? image_profile { get; set; }
        public int employee_type_id { get; set; }
        public int position_id { get; set; }
        //public int status { get; set; }
        //public int created_by { get; set; }
    }
    public class EmployeeCreateModel
    {
        public string? employee_name { get; set; }
        public int sex { get; set; }
        public string? card_number { get; set; }
        public string? image_before_card { get; set; }
        public string? image_after_card { get; set; }
        public DateOnly? birthday { get; set; }
        public string address { get; set; }
        public string? mail { get; set; }
        public string? mobile { get; set; }
        public string? image_profile { get; set; }
        public int employee_type_id { get; set; }
        public int position_id { get; set; }
    }
    public class EmployeeFilterModel
    {
        public int employee_id { get; set; }
        public string employee_name { get; set; } 
        public int sex { get; set; }
        public string card_number { get; set; }
        public int employee_type_id { get; set; }
        public string mail { get; set; }
        public string mobile { get; set; }
        public int position_id { get; set; }
    }
    public class EmpTypes: EmpTypeModel
    {
        public int type_id { get; set; }
    }
    public class EmpTypeDelete
    {
        public int type_id { get; set; }
    }
    public class EmpTypeModel
    {
        public string type_code { get; set; }
        public string type_name { get; set; }
        public int level { get; set; }
    }
    public class TypeFilterModel
    {
        public int type_id { get; set; }
        public string type_code { get; set; }
        public string type_name { get; set; }
        public int level { get; set; }
    }
    public class EmpPosition : EmpPositionModel
    {
        public int position_id { get; set; }
    }
    public class EmpPositionDelete
    {
        public int position_id { get; set; }
    }
    public class EmpPositionModel
    {      
        public string position_code { get; set; }
        public string position_name { get; set; } 
        //public int status { get; set; }
    }

    public class PositionFilterModel
    {
        public int position_id { get; set; }
        public string position_code { get; set; }
        public string position_name { get; set; }
    }
}
