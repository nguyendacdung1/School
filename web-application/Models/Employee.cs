using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace web_application.Models
{
    public class Employee
    {
           
        [RegularExpression(@"EM[0-9]*")]
        [Display(Name = "EmployeeId")]
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Department { get; set; }
        
        public double Salary { get; set; }
    }
}
